#include "khet_Board.hpp"
#include "khet_MoveHelpers.hpp"
#include "khet_SquareHelpers.hpp"
#include "khet_Utils.hpp"
#include "khet_Zobrist.hpp"
#include <cassert>
#include <cctype>
#include <cstring>
#include <iostream>

namespace Khet
{
    
    Board::Board()
    {
        Init();
    }
    
    Board::Board(const Board& other)
    {
        Init();
        _playerToMove = other._playerToMove;
        memcpy(_hashes, other._hashes, MaxGameLength*sizeof(uint64_t));
        memcpy(_board, other._board, BoardArea*sizeof(Square));
        memcpy(_pharaohPositions, other._pharaohPositions, 2*sizeof(int));
    }
    
    Board::Board(const std::string& ks)
    {
        Init();
        FromString(ks);
    }
    
    // If there is no difference then return zero.
    // The comparison takes into account the squares, the player to move and the hash.
    int32_t Board::Compare(const Board& other)
    {
        int32_t ret = 0;
        
        // Compare the board squares.
        for (ret = 1; ret <= BoardArea; ret++)
        {
            if (_board[ret - 1] != other._board[ret - 1]) break;
        }
        
        if (ret > BoardArea)
        {
            ret = _playerToMove == other._playerToMove &&
            _hashes[_moveNumber] != other._hashes[_moveNumber] ?  -1 : 0;
        }
        
        return ret;
    }
    
    void Board::Init()
    {
        memset(_hashes, 0, MaxGameLength*sizeof(uint64_t));
        memset(_captureSquare, Empty, MaxGameLength*sizeof(Square));
        memset(_captureLocation, -1, MaxGameLength*sizeof(int32_t));
        memset(_movesWithoutCapture, 0, MaxGameLength*sizeof(int32_t));
    }
    
    bool Board::IsLegal(Move move) const
    {
        // assert(move != NoMove);
        {
            if(move==NoMove){
                printf("error, assert(move != NoMove)\n");
                return false;
            }
        }
        Square start = _board[GetStart(move)];
        Square end = _board[GetEnd(move)];
        bool endOccupancy;
        bool startOccupancy = IsPiece(start) && GetOwner(start) == _playerToMove;
        if (startOccupancy)
            endOccupancy = end == Empty ||
            GetRotation(move) != 0 ||
            (GetPiece(start) == Piece::Scarab && (int32_t)GetPiece(end) < 4);
        
        return startOccupancy && endOccupancy;
    }
    
    void Board::MakeMove(Move move)
    {
        // assert(move != NoMove);
        if(move == NoMove){
            printf("error, assert(move != NoMove)\n");
            return;
        }
        // assert(!_drawn && !_checkmate);
        if(_drawn || _checkmate){
            printf("error, assert(!_drawn && !_checkmate)\n");
            return;
        }
        // assert(IsLegal(move));
        if(!IsLegal(move)){
            printf("error, assert(IsLegal(move))\n");
            return;
        }
        
        auto z = Zobrist::Instance();
        uint64_t hash = _hashes[_moveNumber++];
        
        int32_t start = GetStart(move);
        int32_t end = GetEnd(move);
        int32_t rotation = GetRotation(move);
        
        Square movingPiece = _board[start];
        hash ^= z->Key(movingPiece, start);
        
        if (rotation != 0)
        {
            movingPiece = Rotate(movingPiece, rotation);
        }
        
        _board[start] = _board[end];
        _board[end] = movingPiece;
        hash ^= z->Key(movingPiece, end);
        
        // Update pharaoh positions.
        if (GetPiece(movingPiece) == Piece::Pharaoh)
        {
            _pharaohPositions[(int32_t)_playerToMove] = end;
        }
        
        // Check whether pieces are captured.
        if (_laser.Fire(_playerToMove, *this))
        {
            _movesWithoutCapture[_moveNumber] = 0;
            _captureSquare[_moveNumber] = _laser.TargetSquare();
            _captureLocation[_moveNumber] = _laser.TargetIndex();
            _board[_laser.TargetIndex()] = Empty;
            _checkmate |= _laser.TargetPiece() == (int32_t)Piece::Pharaoh;
            hash ^= Zobrist::Instance()->Key(_laser.TargetSquare(), _laser.TargetIndex());
        }
        else
        {
            _movesWithoutCapture[_moveNumber] = _movesWithoutCapture[_moveNumber - 1] + 1;
            _captureSquare[_moveNumber] = Empty;
        }
        
        _playerToMove = _playerToMove == Player::Silver ? Player::Red : Player::Silver;
        hash ^= z->Silver();
        
        _moves[_moveNumber] = move;
        _hashes[_moveNumber] = hash;
        
        CheckForDraw();
    }
    
    // Note: The move that needs to be undone should already be cached.
    void Board::UndoMove()
    {
        Move move = _moves[_moveNumber];
        
        // Restore any captured pieces.
        Square cap = _captureSquare[_moveNumber];
        int32_t capLoc = _captureLocation[_moveNumber];
        
        --_moveNumber;
        if (cap != Empty)
        {
            _board[capLoc] = cap;
        }
        
        int32_t start = GetStart(move);
        int32_t end = GetEnd(move);
        int32_t rotation = GetRotation(move);
        
        Square movedPiece = _board[end];
        
        if (rotation != 0)
        {
            // Reverse the rotation.
            movedPiece = Rotate(movedPiece, -1*rotation);
        }
        
        _board[end] = _board[start];
        _board[start] = movedPiece;
        
        _checkmate = false;
        _drawn = false;
        _playerToMove = _playerToMove == Player::Silver ? Player::Red : Player::Silver;
        
        // Update pharaoh positions.
        if (GetPiece(movedPiece) == Piece::Pharaoh)
        {
            _pharaohPositions[(int32_t)_playerToMove] = start;
        }
    }
    
    // Check whether the game is now drawn.
    void Board::CheckForDraw()
    {
        // Check for draw by inactivity.
        int32_t movesWithoutCapture = _movesWithoutCapture[_moveNumber];
        _drawn = movesWithoutCapture >= TimeSinceCaptureLimit;
        if (!_drawn)
        {
            // Check for draw by repetition.
            uint64_t repeatHash = _hashes[_moveNumber];
            int32_t numRepeats = 1;
            for (int32_t m = 1; m < movesWithoutCapture && numRepeats < RepetitionLimit; m++)
            {
                numRepeats += _hashes[_moveNumber-m] == repeatHash ? 1 : 0;
            }
            
            _drawn = numRepeats >= RepetitionLimit;
        }
    }
    
    // Serialise the board to a human-readable string.
    std::string Board::ToString() const
    {
        std::string pieces;
        std::string orientations;
        
        for (int32_t r = BoardHeight - 1; r > -1; r--) {
            for (int32_t c = 0; c < BoardWidth; c++) {
                int32_t i = r*BoardWidth + c;
                if (i % BoardWidth == 0) {
                    pieces += "\n";
                    orientations += "\n";
                }
                
                if (_board[i] == OffBoard)
                {
                    pieces += "*";
                    orientations += "*";
                }
                else if (_board[i] == Empty)
                {
                    pieces += ".";
                    orientations += ".";
                }
                else
                {
                    Player player = GetOwner(_board[i]);
                    Piece piece = GetPiece(_board[i]);
                    Orientation orientation = GetOrientation(_board[i]);
                    
                    pieces += CharFromPiece(player, piece);
                    orientations += std::to_string((int32_t)orientation);
                }
            }
        }
        
        return pieces + "\n" + orientations;
    }
    
    // Initialise the board from the specified Khet string.
    void Board::FromString(const std::string& ks)
    {
        memset(_board, OffBoard, BoardArea*sizeof(Square));
        
        auto utils = Utils::GetInstance();
        auto tokens = utils->Split(ks, ' ');
        _playerToMove = tokens[1] == "0" ? Player::Silver : Player::Red;
        _hashes[0] ^= _playerToMove == Player::Silver ? Zobrist::Instance()->Silver() : 0;
        
        tokens = utils->Split(tokens[0], '/');
        for (size_t i = 0; i < tokens.size(); i++)
        {
            ParseLine(i, tokens[i]);
        }
    }
    
    void Board::ParseLine(int32_t index, const std::string& line)
    {
        // The zero-th index is the back rank.
        // Also need to take into account padding.
        int32_t boardIndex = BoardWidth * (BoardHeight - index - 2) + 1;
        
        // Fill the line with empty initially.
        memset(&_board[boardIndex], Empty, (BoardWidth - 2)*sizeof(Square));
        
        auto z = Zobrist::Instance();
        uint64_t hash = 0;
        for (size_t i = 0; i < line.size(); i++)
        {
            if (isalpha(line[i]))
            {
                // Specifying a piece.
                Player player = isupper(line[i]) ? Player::Silver : Player::Red;
                Piece piece = PieceFromChar(line[i]);
                
                Orientation orientation;
                if (piece == Piece::Pharaoh)
                {
                    orientation = Orientation::Up;
                    _pharaohPositions[(int32_t)player] = boardIndex;
                }
                else
                {
                    orientation = (Orientation)(line[++i] - 1 - '0');
                }
                
                Square sq = MakeSquare(player, piece, orientation);
                hash ^= z->Key(sq, boardIndex);
                _board[boardIndex++] = sq;
            }
            else
            {
                // A gap between pieces.
                boardIndex += (line[i] - '0');
            }
        }
        
        _hashes[0] = hash;
    }
    
    void Board::makeFen(char* strFen)
    {
        strFen[0] = 0;
        // make board and orientation
        char board[80];
        int32_t orientations[80];
        {
            for (int32_t r = BoardHeight - 1; r > -1; r--) {// tu 9 den 0: 10 so
                for (int32_t c = 0; c < BoardWidth; c++) {// tu 0 den 11: 12 so
                    int32_t i = r*BoardWidth + c;
                    int32_t loc = (r-1)*10+(c-1);
                    if(loc>=0 && loc<80){
                        if (_board[i] == OffBoard) {
                            
                        } else if (_board[i] == Empty)
                        {
                            board[loc] = 0;
                            orientations[loc] = 0;
                        } else {
                            Player player = GetOwner(_board[i]);
                            Piece piece = GetPiece(_board[i]);
                            Orientation orientation = GetOrientation(_board[i]);
                            
                            board[loc] = CharFromPiece(player, piece);
                            orientations[loc] = (int32_t)orientation;
                        }
                    }else{
                        // printf("error, loc error: %d, %d, %d\n", loc, r, c);
                    }
                }
            }
            
        }
        // make strFen
        {
            for(int32_t r=7; r>-1; r--){
                int32_t space = 0;
                for(int32_t c=0; c<10; c++){
                    int32_t i = 10*r + c;
                    if(board[i]){
                        if(space > 0){
                            sprintf(strFen, "%s%d", strFen, space);
                            space = 0;
                        }
                        
                        char p = board[i];
                        sprintf(strFen, "%s%c", strFen, p);
                        if(toupper(p) != 'K'){
                            sprintf(strFen, "%s%d", strFen, orientations[i]+1);
                        }
                    }else{
                        space += 1;
                    }
                }
                
                if (space > 0 && space < 10){
                    sprintf(strFen, "%s%d", strFen, space);
                    space = 0;
                }
                
                if(r > 0){
                    sprintf(strFen, "%s/", strFen);
                }
            }
            sprintf(strFen, "%s%s", strFen, _playerToMove==Player::Silver ? " 0" : " 1");
        }
    }
    
    Piece Board::PieceFromChar(char c) const
    {
        auto p = Piece::Sphinx;
        
        c = tolower(c);
        if (c == 'a')
            p = Piece::Anubis;
        else if (c == 'p')
            p = Piece::Pyramid;
        else if (c == 's')
            p = Piece::Scarab;
        else if (c == 'k')
            p = Piece::Pharaoh;
        
        return p;
    }
    
    char Board::CharFromPiece(Player player, Piece piece) const
    {
        char c = 'x';
        
        if (piece == Piece::Anubis)
            c = 'a';
        else if (piece == Piece::Pyramid)
            c = 'p';
        else if (piece == Piece::Scarab)
            c = 's';
        else if (piece == Piece::Pharaoh)
            c = 'k';
        
        return player == Player::Silver ? toupper(c) : c;
    }
    
    void Board::Board_Init()
    {
        Zobrist::Instance();
        Utils::GetInstance();
    }
  
    /////////////////////////////////////////////////////////////////////////////////////
    //////////////////// Convert ///////////////////
    /////////////////////////////////////////////////////////////////////////////////////
    
    const uint64_t DefaultHash = 0;
    const Square DefaultCaptureSquare = Empty;
    const int32_t DefaultCaptureLocation = -1;
    const int32_t DefaultMovesWithoutCapture = 0;
    
    int32_t Board::getByteSize()
    {
        int32_t ret = 0;
        {
            // Player _playerToMove
            ret+=sizeof(Player);
            // bool _checkmate = false
            ret+=sizeof(bool);
            // bool _drawn = false
            ret+=sizeof(bool);
            // int32_t _moveNumber = 0
            ret+=sizeof(int32_t);
            // uint64_t _hashes[MaxGameLength]
            {
                // find hashCount
                int32_t hashCount = 0;
                {
                    for(int32_t i=MaxGameLength; i>=1; i--){
                        if(_hashes[i-1]!=DefaultHash){
                            hashCount = i;
                            break;
                        }
                    }
                }
                // add
                ret+=sizeof(int32_t);
                ret+=hashCount*sizeof(uint64_t);
            }
            // Laser _laser
            ret+=Laser::getByteSize();
            
            // Square _board[BoardArea]
            ret+=sizeof(Square)*BoardArea;
            
            // Move _moves[MaxGameLength] = { NoMove }
            {
                // find move count
                int32_t moveCount = 0;
                {
                    for(int32_t i=MaxGameLength; i>=1; i--){
                        if(_moves[i-1]!=NoMove){
                            moveCount=i;
                            break;
                        }
                    }
                }
                // add
                ret+=sizeof(int32_t);
                ret+=moveCount*sizeof(Move);
            }
            
            // int32_t _pharaohPositions[2]
            ret+=2*sizeof(int32_t);
            
            // Square _captureSquare[MaxGameLength]
            {
                // find captureSquareCount
                int32_t captureSquareCount = 0;
                {
                    for(int32_t i=MaxGameLength; i>=1; i--){
                        if(_captureSquare[i-1]!=DefaultCaptureSquare){
                            captureSquareCount = i;
                            break;
                        }
                    }
                }
                // add
                ret+=sizeof(int32_t);
                ret+=captureSquareCount*sizeof(Square);
            }
            // int32_t _captureLocation[MaxGameLength];
            {
                // find captureLocationCount
                int32_t captureLocationCount = 0;
                {
                    for(int32_t i=MaxGameLength; i>=1; i--){
                        if(_captureLocation[i-1]!=DefaultCaptureLocation){
                            captureLocationCount = i;
                            break;
                        }
                    }
                }
                // add
                ret+=sizeof(int32_t);
                ret+=captureLocationCount*sizeof(int32_t);
            }
            
            // int32_t _movesWithoutCapture[MaxGameLength]
            {
                // find movesWithoutCaptureCount
                int32_t moveWithoutCaptureCount = 0;
                {
                    for(int32_t i=MaxGameLength; i>=1; i--){
                        if(_movesWithoutCapture[i-1]!=DefaultMovesWithoutCapture){
                            moveWithoutCaptureCount=i;
                            break;
                        }
                    }
                }
                // add
                ret+=sizeof(int32_t);
                ret+=moveWithoutCaptureCount*sizeof(int32_t);
            }
        }
        return ret;
    }
    
    int32_t Board::convertToByteArray(Board* board, uint8_t* &byteArray)
    {
        int32_t length = board->getByteSize();
        uint8_t* ret = (uint8_t*)calloc(length, sizeof(uint8_t));
        {
            int32_t pointerIndex = 0;
            // Player _playerToMove
            {
                int32_t size = sizeof(Player);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, &board->_playerToMove, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: _playerToMove: %d, %d\n", pointerIndex, length);
                }
            }
            // bool _checkmate = false
            {
                int32_t size = sizeof(bool);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, &board->_checkmate, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: _checkmate: %d, %d\n", pointerIndex, length);
                }
            }
            // bool _drawn = false
            {
                int32_t size = sizeof(bool);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, &board->_drawn, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: _draw: %d, %d\n", pointerIndex, length);
                }
            }
            // int32_t _moveNumber = 0
            {
                int32_t size = sizeof(int32_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, &board->_moveNumber, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: _moveNumber: %d, %d\n", pointerIndex, length);
                }
            }
            // uint64_t _hashes[MaxGameLength]
            {
                // find hashCount
                int32_t hashCount = 0;
                {
                    for(int32_t i=MaxGameLength; i>=1; i--){
                        if(board->_hashes[i-1]!=DefaultHash){
                            hashCount = i;
                            break;
                        }
                    }
                }
                // add count
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(ret + pointerIndex, &hashCount, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: _hashCount: %d, %d\n", pointerIndex, length);
                    }
                }
                // add content
                {
                    int32_t size = hashCount*sizeof(uint64_t);
                    if(pointerIndex+size<=length){
                        memcpy(ret + pointerIndex, board->_hashes, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: hash: %d, %d\n", pointerIndex, length);
                    }
                }
            }
            // Laser _laser
            {
                uint8_t* _laserByteArray;
                int32_t size = Laser::convertToByteArray (&board->_laser, _laserByteArray);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, _laserByteArray, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: _laser: %d, %d\n", pointerIndex, length);
                }
                free(_laserByteArray);
            }
            
            // Square _board[BoardArea]
            {
                int32_t size = BoardArea*sizeof(Square);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, board->_board, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: _board: %d, %d\n", pointerIndex, length);
                }
            }
            
            // Move _moves[MaxGameLength] = { NoMove }
            {
                // find move count
                int32_t moveCount = 0;
                {
                    for(int32_t i=MaxGameLength; i>=1; i--){
                        if(board->_moves[i-1]!=NoMove){
                            moveCount=i;
                            break;
                        }
                    }
                }
                // add count
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(ret + pointerIndex, &moveCount, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: moveCount: %d, %d\n", pointerIndex, length);
                    }
                }
                // add content
                {
                    int32_t size = moveCount*sizeof(Move);
                    if(pointerIndex+size<=length){
                        memcpy(ret + pointerIndex, board->_moves, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: moves: %d, %d\n", pointerIndex, length);
                    }
                }
            }
            
            // int32_t _pharaohPositions[2]
            {
                int32_t size = 2*sizeof(int32_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, board->_pharaohPositions, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: _pharaohPositions: %d, %d\n", pointerIndex, length);
                }
            }
            
            // Square _captureSquare[MaxGameLength]
            {
                // find captureSquareCount
                int32_t captureSquareCount = 0;
                {
                    for(int32_t i=MaxGameLength; i>=1; i--){
                        if(board->_captureSquare[i-1]!=DefaultCaptureSquare){
                            captureSquareCount = i;
                            break;
                        }
                    }
                }
                // add count
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(ret + pointerIndex, &captureSquareCount, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: captureSquareCount: %d, %d\n", pointerIndex, length);
                    }
                }
                // add content
                {
                    int32_t size = captureSquareCount*sizeof(Square);
                    if(pointerIndex+size<=length){
                        memcpy(ret + pointerIndex, board->_captureSquare, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: _captureSquare: %d, %d\n", pointerIndex, length);
                    }
                }
            }
            // int32_t _captureLocation[MaxGameLength];
            {
                // find captureLocationCount
                int32_t captureLocationCount = 0;
                {
                    for(int32_t i=MaxGameLength; i>=1; i--){
                        if(board->_captureLocation[i-1]!=DefaultCaptureLocation){
                            captureLocationCount = i;
                            break;
                        }
                    }
                }
                // add count
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(ret + pointerIndex, &captureLocationCount, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: captureLocationCount: %d, %d\n", pointerIndex, length);
                    }
                }
                // add content
                {
                    int32_t size = captureLocationCount*sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(ret + pointerIndex, board->_captureLocation, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: _captureLocation: %d, %d\n", pointerIndex, length);
                    }
                }
            }
            
            // int32_t _movesWithoutCapture[MaxGameLength]
            {
                // find movesWithoutCaptureCount
                int32_t moveWithoutCaptureCount = 0;
                {
                    for(int32_t i=MaxGameLength; i>=1; i--){
                        if(board->_movesWithoutCapture[i-1]!=DefaultMovesWithoutCapture){
                            moveWithoutCaptureCount=i;
                            break;
                        }
                    }
                }
                // add count
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(ret + pointerIndex, &moveWithoutCaptureCount, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: moveWithoutCaptureCount: %d, %d\n", pointerIndex, length);
                    }
                }
                // add content
                {
                    int32_t size = moveWithoutCaptureCount*sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(ret + pointerIndex, board->_movesWithoutCapture, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: _captureLocation: %d, %d\n", pointerIndex, length);
                    }
                }
            }
            // printf("convert position to array: return value: %d; %d\n", pointerIndex, length);
        }
        byteArray = ret;
        return length;
    }
    
    int32_t Board::parseByteArray(Board* board, uint8_t* bytes, int32_t length, int32_t start, bool canCorrect)
    {
        int32_t pointerIndex = start;
        int32_t index = 0;
        bool isParseCorrect = true;
        while (pointerIndex < length) {
            bool alreadyPassAll = false;
            switch (index) {
                case 0:
                // Player _playerToMove
                {
                    int32_t size = sizeof(Player);
                    if(pointerIndex+size<=length){
                        memcpy(&board->_playerToMove, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: _playerToMove: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 1:
                // bool _checkmate = false
                {
                    int32_t size = sizeof(bool);
                    if(pointerIndex+size<=length){
                        memcpy(&board->_checkmate, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: _checkmate: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 2:
                    // bool _drawn = false
                {
                    int32_t size = sizeof(bool);
                    if(pointerIndex+size<=length){
                        memcpy(&board->_drawn, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: _draw: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 3:
                    // int32_t _moveNumber = 0
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&board->_moveNumber, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: _moveNumber: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 4:
                    // uint64_t _hashes[MaxGameLength]
                {
                    // find hashCount
                    int32_t hashCount = 0;
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&hashCount, bytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: hashCount: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                        // correct
                        if(hashCount<0 || hashCount>MaxGameLength){
                            printf("hashCount error: %d\n", hashCount);
                            hashCount = 0;
                        }
                    }
                    // content
                    {
                        int32_t size = hashCount*sizeof(uint64_t);
                        if(pointerIndex+size<=length){
                            memcpy(&board->_hashes, bytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: _hashes: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                        // other
                        for(int32_t i=hashCount; i<MaxGameLength; i++){
                            board->_hashes[i] = DefaultHash;
                        }
                    }
                }
                    break;
                case 5:
                    // Laser _laser
                {
                    int32_t _laserByteLength = Laser::parseByteArray (&board->_laser, bytes, length, pointerIndex, canCorrect);
                    if (_laserByteLength > 0) {
                        pointerIndex+= _laserByteLength;
                    } else {
                        printf("cannot parse _laser\n");
                        isParseCorrect = false;
                    }
                }
                    break;
                case 6:
                    // Square _board[BoardArea]
                {
                    int32_t size = BoardArea*sizeof(Square);
                    if(pointerIndex+size<=length){
                        memcpy(&board->_board, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: _board: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 7:
                    // Move _moves[MaxGameLength] = { NoMove }
                {
                    // find moveCount
                    int32_t moveCount = 0;
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&moveCount, bytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: moveCount: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                        // correct
                        if(moveCount<0 || moveCount>MaxGameLength){
                            printf("moveCount error: %d\n", moveCount);
                            moveCount = 0;
                        }
                    }
                    // content
                    {
                        int32_t size = moveCount*sizeof(Move);
                        if(pointerIndex+size<=length){
                            memcpy(&board->_moves, bytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: _moves: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                        // other
                        for(int32_t i=moveCount; i<MaxGameLength; i++){
                            board->_moves[i] = NoMove;
                        }
                    }
                }
                    break;
                case 8:
                    // int32_t _pharaohPositions[2]
                {
                    int32_t size = 2*sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&board->_pharaohPositions, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: _pharaohPositions: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 9:
                    // Square _captureSquare[MaxGameLength]
                {
                    // find captureSquareCount
                    int32_t captureSquareCount = 0;
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&captureSquareCount, bytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: captureSquareCount: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                        // correct
                        if(captureSquareCount<0 || captureSquareCount>MaxGameLength){
                            printf("captureSquareCount error: %d\n", captureSquareCount);
                            captureSquareCount = 0;
                        }
                    }
                    // content
                    {
                        int32_t size = captureSquareCount*sizeof(Square);
                        if(pointerIndex+size<=length){
                            memcpy(&board->_captureSquare, bytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: _captureSquare: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                        // other
                        for(int32_t i=captureSquareCount; i<MaxGameLength; i++){
                            board->_captureSquare[i] = DefaultCaptureSquare;
                        }
                    }
                }
                    break;
                case 10:
                    // int32_t _captureLocation[MaxGameLength];
                {
                    // find captureLocationCount
                    int32_t captureLocationCount = 0;
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&captureLocationCount, bytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: captureLocationCount: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                        // correct
                        if(captureLocationCount<0 || captureLocationCount>MaxGameLength){
                            printf("captureLocationCount error: %d\n", captureLocationCount);
                            captureLocationCount = 0;
                        }
                    }
                    // content
                    {
                        int32_t size = captureLocationCount*sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&board->_captureLocation, bytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: _captureLocation: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                        // other
                        for(int32_t i=captureLocationCount; i<MaxGameLength; i++){
                            board->_captureLocation[i] = DefaultCaptureLocation;
                        }
                    }
                }
                    break;
                case 11:
                    // int32_t _movesWithoutCapture[MaxGameLength]
                {
                    // find movesWithoutCaptureCount
                    int32_t movesWithoutCaptureCount = 0;
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&movesWithoutCaptureCount, bytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: movesWithoutCaptureCount: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                        // correct
                        if(movesWithoutCaptureCount<0 || movesWithoutCaptureCount>MaxGameLength){
                            printf("captureLocationCount error: %d\n", movesWithoutCaptureCount);
                            movesWithoutCaptureCount = 0;
                        }
                    }
                    // content
                    {
                        int32_t size = movesWithoutCaptureCount*sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&board->_movesWithoutCapture, bytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: _movesWithoutCapture: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                        // other
                        for(int32_t i=movesWithoutCaptureCount; i<MaxGameLength; i++){
                            board->_movesWithoutCapture[i] = DefaultMovesWithoutCapture;
                        }
                    }
                }
                    break;
                default:
                {
                    // printf("unknown index: %d\n", index);
                    alreadyPassAll = true;
                }
                    break;
            }
            // printf("convert byte array to position: count: %d; %d; %d\n", pointerIndex, index, length);
            index++;
            if (!isParseCorrect) {
                printf("not parse correct\n");
                break;
            }
            if (alreadyPassAll) {
                break;
            }
        }
        // check position ok: if not, correct it
        if(canCorrect){
            // offBoard
            {
                for (int32_t r = BoardHeight - 1; r > -1; r--) {
                    for (int32_t c = 0; c < BoardWidth; c++) {
                        int32_t i = r*BoardWidth + c;
                        if(r==BoardHeight - 1 || r==0 || c==0 || c==BoardWidth-1){
                            board->_board[i] = OffBoard;
                        }
                    }
                }
            }
        }
        // return
        if (!isParseCorrect) {
            printf("error parse fail: %d; %d; %d\n", pointerIndex, length, start);
            return -1;
        } else {
            // printf("parse success: %d; %d; %d %d\n", pointerIndex, length, start, (pointerIndex - start));
            return (pointerIndex - start);
        }
    }
    
}
