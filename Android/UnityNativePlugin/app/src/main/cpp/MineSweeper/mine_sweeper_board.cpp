#include "mine_sweeper_Board.hpp"
#include "../Platform.h"

namespace MineSweeper
{
    Board::Board() {
        N = 30;// 9;//30;
        M = 30;//9;//30;
        K = 150;//200;
        init = 0;
        booom = 0;
        minesFound=0;
        board = ByteMatrix(N, vector<int8_t>(M));
        bombs = ByteMatrix(N, vector<int8_t>(M));
        //flags = DoubleMatrix(N, vector<double>(M));
        flags = ByteMatrix(N, vector<int8_t>(M));
        for (int32_t i = 0; i < N; i++) {
            for (int32_t j = 0; j < M; j++) {
                board[i][j] = -1;
                bombs[i][j] = 0;
                flags[i][j] = 0;
            }
        }
    }
    
    Board::Board(int32_t a, int32_t b, int32_t c) {
        N = a;
        M = b;
        K = c;
        init = 0;
        booom = 0;
        minesFound = 0;
        board = ByteMatrix(N, vector<int8_t>(M));
        bombs = ByteMatrix(N, vector<int8_t>(M));
        //flags = DoubleMatrix(N, vector<double>(M));
        flags = ByteMatrix(N, vector<int8_t>(M));
        for (int32_t i = 0; i < N; i++) {
            for (int32_t j = 0; j < M; j++) {
                board[i][j] = -1;
                bombs[i][j] = 0;
                flags[i][j] = 0;
            }
        }
    }
    
    void Board::print() {
        string edge(2*N + 3, '=');
        cout << " |";
        for (int32_t j = 0; j < M; j++) cout << j<<" ";
        cout << endl;
        cout << edge << endl;
        for (int32_t i = 0; i<N; i++) {
            cout << i;
            cout << "|";
            for (int32_t j = 0; j<M; j++) {
                if (board[i][j] == -1) {
                    cout << "* ";
                }//where is unknown
                else {
                    if (board[i][j] == 0)
                        cout << "  ";//where is the interior
                    else if (board[i][j] == -2)
                        cout << "x ";//where you lose
                    else
                        cout << board[i][j]<<" ";//where is the boudary
                }
            }
            cout << "|" << endl;
        }
        cout << edge << edge << endl;
    }
    
    void Board::print(char* ret)
    {
        ret[0] = 0;
        sprintf(ret, "%sPosition: %d, %d, %d, neb: %lu\n", ret, N, M, K, neb.size());
        // edge
        /*{
            string edge(2*N + 3, '=');
            cout << " |";
            for (int32_t j = 0; j < M; j++)
                cout << j<<" ";
            cout << endl;
            cout << edge << endl;
        }*/
        // board
        {
            sprintf(ret, "%sBoard: \n", ret);
            for (int32_t i = 0; i<N; i++) {
                sprintf(ret, "%s%03d", ret, i);
                sprintf(ret, "%s|", ret);
                for (int32_t j = 0; j<M; j++) {
                    if (board[i][j] == -1) {
                        sprintf(ret, "%s* ", ret);
                    }//where is unknown
                    else {
                        if (board[i][j] == 0) {
                            //where is the interior
                            sprintf(ret, "%s  ", ret);
                        }
                        else if (board[i][j] == -2) {
                            //where you lose
                            sprintf(ret, "%sx ", ret);
                        }
                        else {
                            //where is the boudary
                            sprintf(ret, "%s%d ", ret, board[i][j]);
                        }
                    }
                }
                sprintf(ret, "%s|\n", ret);
            }
        }
        // bombs
        {
            sprintf(ret, "%sBombs: \n", ret);
            for (int32_t i = 0; i<N; i++) {
                sprintf(ret, "%s%03d", ret, i);
                sprintf(ret, "%s|", ret);
                for (int32_t j = 0; j<M; j++) {
                    sprintf(ret, "%s%d ", ret, bombs[i][j]);
                }
                sprintf(ret, "%s|\n", ret);
            }
        }
        // flags
        {
            sprintf(ret, "%sFlags: \n", ret);
            for (int32_t i = 0; i<N; i++) {
                sprintf(ret, "%s%03d", ret, i);
                sprintf(ret, "%s|", ret);
                for (int32_t j = 0; j<M; j++) {
                    sprintf(ret, "%s%d ", ret, flags[i][j]);
                }
                sprintf(ret, "%s|\n", ret);
            }
        }
        if(this->isEOG()){
            sprintf(ret, "%sGameEnd: %d\n", ret, this->winOrLoss());
        }
        // cout << edge << edge << endl;
    }
    
    void Board::printFlags() {
        string edge(2*N + 3, '=');
        cout << " |";
        for (int32_t j = 0; j < M; j++) cout << j << " ";
        cout << endl;
        cout << edge << endl;
        for (int32_t i = 0; i<N; i++) {
            cout << i;
            cout << "|";
            for (int32_t j = 0; j<M; j++) {
                cout<<flags[i][j]<<" ";
            }
            cout << "|" << endl;
        }
        cout << edge << endl;
    }
    
    void Board::printBomb() {
        string edge(2*N + 3, '=');
        cout << " |";
        for (int32_t j = 0; j < M; j++) cout << j << " ";
        cout << endl;
        cout << edge << endl;
        for (int32_t i = 0; i<N; i++) {
            cout << i;
            cout << "|";
            for (int32_t j = 0; j<M; j++) {
                cout<<bombs[i][j]<<" ";
            }
            cout << "|" << endl;
        }
        cout << edge << endl;
    }
    
    bool Board::isEOG() {
        if (booom == 1)
            return 1;
        int32_t count =0;
        for(int32_t i=0; i<N; i++){
            for(int32_t j=0; j<M; j++){
                if(board[i][j]==-1)
                    count++;
            }
        }
        if (K == count)
            return 1;
        return 0;
    }
    
    void Board::pick(int8_t x, int8_t y) {
        if (!init) {
            initialBombs(x,y);//initialize after first pick
        }
        
        if (board[x][y] != -1)
            return;//this place has already been checked
        
        if (bombs[x][y] == 1) {
            booom = 1;
            board[x][y] = -2;
            return;
        }
        
        Point p{x, y};
        //if in one fringe ang it has no mines near it then update that neb
        for(int32_t i=0; i<neb.size(); i++){
            Neb nebnow = neb[i];
            for(int32_t j=0; j<nebnow.fringe.size(); j++){
                if(i<nebnow.fringe.size()){
                    if(x==nebnow.fringe[j].x && y==nebnow.fringe[j].y && bombsNearby(nebnow.fringe[i])==0){
                        //update boundary and fringe:never erase boundary(boundary is always boundary)
                        //cout<<"updating to "<<i+1<<" neb"<<endl;
                        // neb[i].fringe.erase(neb[i].fringe.begin()+j);
                        nebOf(p, neb[i]);
                        //erase interior part and boundary part of fringe
                        for(int32_t k=0; k<neb[i].fringe.size(); k++){
                            for(int32_t y=0; y<neb[i].boundary.size(); y++){
                                if(k<neb[i].fringe.size()){
                                    if(neb[i].fringe[k].x==neb[i].boundary[y].x && neb[i].fringe[k].y==neb[i].boundary[y].y){
                                        neb[i].fringe.erase(neb[i].fringe.begin()+k);
                                    }
                                }else{
                                    // printf("error, k too large: %d, %lu\n", k, neb[i].fringe.size());
                                }
                            }
                            for(int32_t y=0; y<neb[i].interior.size(); y++){
                                if(k<neb[i].fringe.size()){
                                    if(neb[i].fringe[k].x==neb[i].interior[y].x && neb[i].fringe[k].y==neb[i].interior[y].y){
                                        neb[i].fringe.erase(neb[i].fringe.begin()+k);
                                    }
                                }else{
                                    // printf("error, k too large: %d, %lu\n", k, neb[i].fringe.size());
                                }
                            }
                        }
                        return;
                    }
                }else{
                    // printf("error, i<nebnow size: %d, %lu\n", i, nebnow.fringe.size());
                }
            }
        }
        
        //if not in any fringe; then add a new neb
        //cout<<"adding a new neb! num: "<<neb.size()+1<<endl;
        Neb newNeb;
        nebOf(p, newNeb);
        //erase interior part and boundary part of fringe
        for(int32_t i=0; i<newNeb.fringe.size(); i++){
            for(int32_t j=0; j<newNeb.boundary.size(); j++){
                if(i<newNeb.fringe.size()){
                    if(newNeb.fringe[i].x==newNeb.boundary[j].x && newNeb.fringe[i].y==newNeb.boundary[j].y){
                        newNeb.fringe.erase(newNeb.fringe.begin()+i);
                    }
                }else{
                    // printf("error, i<newNebsize: %d, %lu\n", i, newNeb.fringe.size());
                }
            }
            for(int32_t j=0; j<newNeb.interior.size(); j++){
                if(i<newNeb.fringe.size()){
                    if(newNeb.fringe[i].x==newNeb.interior[j].x && newNeb.fringe[i].y==newNeb.interior[j].y){
                        newNeb.fringe.erase(newNeb.fringe.begin()+i);
                    }
                }else{
                     // printf("error, i<newNebsize1: %d, %lu\n", i, newNeb.fringe.size());
                }
            }
        }
        neb.push_back(newNeb);
        return;
    }
    
    void Board::nebOf(Point p, Neb &f) {
        if (bombs[p.x][p.y] != 0)
            return;//is boom
        
        //if this is a interior cell
        if (bombsNearby(p) == 0) {
            f.interior.push_back(p);
            flags[p.x][p.y] = 2;//interior cells have been checked
            board[p.x][p.y] = 0;
            for (int8_t i = -1; i < 2; i++) {
                for (int8_t j = -1; j < 2; j++) {
                    if (i == 0 && j == 0)
                        continue;
                    Point np{static_cast<int8_t>(p.x+i), static_cast<int8_t>(p.y+j)};
                    if (np.x < 0 || np.x >= N || np.y < 0 || np.y >= M)
                        continue;
                    if (board[np.x][np.y] != -1)
                        continue;
                    nebOf(np, f);//recursively search its neighborhood
                }
            }
        }// if is a boundary cell
        else {
            flags[p.x][p.y] = 2;//boundary cells have been checked
            f.boundary.push_back(p);
            board[p.x][p.y] = bombsNearby(p);
            //add adjacent unknown cells to fringe
            for (int8_t i = -1; i < 2; i++) {
                for (int8_t j = -1; j < 2; j++) {
                    if (i == 0 && j == 0)
                        continue;
                    Point np{static_cast<int8_t>(p.x+i), static_cast<int8_t>(p.y+j)};
                    if (np.x < 0 || np.x >= N || np.y < 0 || np.y >= M)
                        continue;
                    if (board[np.x][np.y] != -1)
                        continue;
                    
                    //unknown cells near this boundary cell, see if it is already in fringe of this neb
                    bool isAlreadyFringe = false;
                    for(int32_t k=0; k<f.fringe.size(); k++){
                        if(np.x==f.fringe[k].x && np.y==f.fringe[k].y){
                            isAlreadyFringe = true;
                            break;
                        }
                    }
                    if(!isAlreadyFringe &&  board[np.x][np.y]==-1){
                        //not already in fringe and in unknown
                        // printf("fringe add point: %d, %d\n", np.x, np.y);
                        f.fringe.push_back(np);
                    }
                }
            }
        }
    }
    
    int32_t Board::bombsNearby(Point &p) {
        int32_t sum= 0;
        for (int8_t i = -1; i < 2; i++) {
            for (int8_t j = -1; j < 2; j++) {
                if (i == 0 && j == 0)
                    continue;
                Point np{ static_cast<int8_t>(p.x + i), static_cast<int8_t>(p.y + j) };
                if (np.x < 0 || np.x >= N || np.y < 0 || np.y >= M)
                    continue;
                if (bombs[np.x][np.y] == 1)
                    sum++;
            }
        }
        return sum;
    }
    
    //called only once, make sure the first pick is not a mine
    void Board::initialBombs(int32_t x, int32_t y) {
        printf("initialBombs: %d, %d\n", x, y);
        init = 1;
        srand((int32_t)now());
        int32_t T = N*M;
        int32_t count = 0;
        while(count<K){
            int32_t t = rand() % T;
            int32_t row = t/M;
            int32_t col = t-row*M;
            if (x == row && y == col)
                continue;//if it is what's picked, skip
            if (bombs[row][col] == 1)
                continue;//if it is already a mine, skip
            bombs[row][col] = 1;
            count++;
        }
    }
    
    int32_t Board::winOrLoss() {
        if (isEOG()==1 && booom == 1)
            return -1;
        if (isEOG()==1 && booom != 1)
            return 1;
        else
            return 0;
    }
    
    NebSet Board::getNeb() {
        return neb;
    }
    
    ByteMatrix Board::getBoard() {
        return board;
    }
    
    /////////////////////////////////////////////////////////////////////////////////////
    //////////////////// Convert Neb ///////////////////
    /////////////////////////////////////////////////////////////////////////////////////
    
    int32_t Neb::getByteSize()
    {
        int32_t ret = 0;
        {
            // vector<Point> interior
            ret+= sizeof(int32_t) + 2*sizeof(int8_t)*interior.size();
            // vector<Point> fringe
            ret+= sizeof(int32_t) + 2*sizeof(int8_t)*fringe.size();
            // vector<Point> boundary
            ret+= sizeof(int32_t) + 2*sizeof(int8_t)*boundary.size();
        }
        // printf("neb getByteSize: %d\n", ret);
        return ret;
    }
    
    int32_t Neb::convertToByteArray(Neb* neb, uint8_t* &byteArray)
    {
        int32_t length = neb->getByteSize();
        uint8_t* ret = (uint8_t*)calloc(length, sizeof(uint8_t));
        {
            int32_t pointerIndex = 0;
            // vector<Point> interior
            {
                // interior size
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        int32_t interiorSize = (int32_t)neb->interior.size();
                        memcpy(ret + pointerIndex, &interiorSize, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: interiorSize: %d, %d\n", pointerIndex, length);
                    }
                }
                // content
                // printf("interior size: %lu\n", neb->interior.size());
                for(int32_t i=0; i<neb->interior.size(); i++){
                    // x
                    {
                        int32_t size = sizeof(int8_t);
                        if(pointerIndex+size<=length){
                            int8_t x = neb->interior[i].x;
                            memcpy(ret + pointerIndex, &x, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: x: %d, %d\n", pointerIndex, length);
                        }
                    }
                    // y
                    {
                        int32_t size = sizeof(int8_t);
                        if(pointerIndex+size<=length){
                            int8_t y = neb->interior[i].y;
                            memcpy(ret + pointerIndex, &y, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: y: %d, %d\n", pointerIndex, length);
                        }
                    }
                }
            }
            // vector<Point> fringe
            {
                // fringe size
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        int32_t fringeSize = (int32_t)neb->fringe.size();
                        // printf("fringe size: %lu\n", neb->fringe.size());
                        memcpy(ret + pointerIndex, &fringeSize, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: fringeSize: %d, %d\n", pointerIndex, length);
                    }
                }
                // content
                for(int32_t i=0; i<neb->fringe.size(); i++){
                    // x
                    {
                        int32_t size = sizeof(int8_t);
                        if(pointerIndex+size<=length){
                            int8_t x = neb->fringe[i].x;
                            memcpy(ret + pointerIndex, &x, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: x: %d, %d\n", pointerIndex, length);
                        }
                    }
                    // y
                    {
                        int32_t size = sizeof(int8_t);
                        if(pointerIndex+size<=length){
                            int8_t y = neb->fringe[i].y;
                            memcpy(ret + pointerIndex, &y, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: y: %d, %d\n", pointerIndex, length);
                        }
                    }
                }
            }
            // vector<Point> boundary
            {
                // boundary size
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        int32_t boundarySize = (int32_t)neb->boundary.size();
                        memcpy(ret + pointerIndex, &boundarySize, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: boundarySize: %d, %d\n", pointerIndex, length);
                    }
                }
                // content
                // printf("boundary size: %lu\n", neb->boundary.size());
                for(int32_t i=0; i<neb->boundary.size(); i++){
                    // x
                    {
                        int32_t size = sizeof(int8_t);
                        if(pointerIndex+size<=length){
                            int8_t x = neb->boundary[i].x;
                            memcpy(ret + pointerIndex, &x, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: x: %d, %d\n", pointerIndex, length);
                        }
                    }
                    // y
                    {
                        int32_t size = sizeof(int8_t);
                        if(pointerIndex+size<=length){
                            int8_t y = neb->boundary[i].y;
                            memcpy(ret + pointerIndex, &y, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: y: %d, %d\n", pointerIndex, length);
                        }
                    }
                }
            }
            // printf("convert position to array: return value: %d; %d\n", pointerIndex, length);
        }
        byteArray = ret;
        return length;
    }
    
    int32_t Neb::parseByteArray(Neb* neb, uint8_t* bytes, int32_t length, int32_t start, bool canCorrect) {
        int32_t pointerIndex = start;
        int32_t index = 0;
        bool isParseCorrect = true;
        while (pointerIndex < length) {
            bool alreadyPassAll = false;
            switch (index) {
                case 0:
                {
                    // vector<Point> interior
                    // interior size
                    int32_t interioriSize = 0;
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&interioriSize, bytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: interioriSize: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                    // content
                    // printf("parse interioriSize: %d\n", interioriSize);
                    neb->interior.clear();
                    for(int32_t i=0; i<interioriSize; i++){
                        Point point{0, 0};
                        // x
                        {
                            int32_t size = sizeof(int8_t);
                            if(pointerIndex+size<=length){
                                memcpy(&point.x, bytes + pointerIndex, size);
                                pointerIndex+=size;
                            }else{
                                printf("length error: x: %d, %d\n", pointerIndex, length);
                                isParseCorrect = false;
                            }
                        }
                        // y
                        {
                            int32_t size = sizeof(int8_t);
                            if(pointerIndex+size<=length){
                                memcpy(&point.y, bytes + pointerIndex, size);
                                pointerIndex+=size;
                            }else{
                                printf("length error: y: %d, %d\n", pointerIndex, length);
                                isParseCorrect = false;
                            }
                        }
                        neb->interior.push_back(point);
                    }
                }
                    break;
                case 1:
                {
                    // vector<Point> fringe
                    // fringe size
                    int32_t fringeSize = 0;
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&fringeSize, bytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: fringeSize: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                    // content
                    // printf("parse fringeSize: %d\n", fringeSize);
                    neb->fringe.clear();
                    for(int32_t i=0; i<fringeSize; i++){
                        Point point{0, 0};
                        // x
                        {
                            int32_t size = sizeof(int8_t);
                            if(pointerIndex+size<=length){
                                memcpy(&point.x, bytes + pointerIndex, size);
                                pointerIndex+=size;
                            }else{
                                printf("length error: x: %d, %d\n", pointerIndex, length);
                                isParseCorrect = false;
                            }
                        }
                        // y
                        {
                            int32_t size = sizeof(int8_t);
                            if(pointerIndex+size<=length){
                                memcpy(&point.y, bytes + pointerIndex, size);
                                pointerIndex+=size;
                            }else{
                                printf("length error: y: %d, %d\n", pointerIndex, length);
                                isParseCorrect = false;
                            }
                        }
                        // printf("parse fringe point: %d, %d\n", point.x, point.y);
                        neb->fringe.push_back(point);
                    }
                }
                    break;
                case 2:
                {
                    // vector<Point> boundary
                    // boundary size
                    int32_t boundarySize = 0;
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&boundarySize, bytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: boundarySize: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                    // content
                    // printf("parse boundarySize: %d\n", boundarySize);
                    neb->boundary.clear();
                    for(int32_t i=0; i<boundarySize; i++){
                        Point point{0,0};
                        // x
                        {
                            int32_t size = sizeof(int8_t);
                            if(pointerIndex+size<=length){
                                memcpy(&point.x, bytes + pointerIndex, size);
                                pointerIndex+=size;
                            }else{
                                printf("length error: x: %d, %d\n", pointerIndex, length);
                                isParseCorrect = false;
                            }
                        }
                        // y
                        {
                            int32_t size = sizeof(int8_t);
                            if(pointerIndex+size<=length){
                                memcpy(&point.y, bytes + pointerIndex, size);
                                pointerIndex+=size;
                            }else{
                                printf("length error: y: %d, %d\n", pointerIndex, length);
                                isParseCorrect = false;
                            }
                        }
                        neb->boundary.push_back(point);
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
        // return
        if (!isParseCorrect) {
            printf("parse fail\n");
        } else {
            // printf("parse success");
        }
        // check position ok: if not, correct it
        if(canCorrect){
            
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
    
    /////////////////////////////////////////////////////////////////////////////////////
    //////////////////// Convert Board ///////////////////
    /////////////////////////////////////////////////////////////////////////////////////
    
    int32_t Board::getByteSize()
    {
        int32_t ret = 0;
        {
            // int32_t N
            ret+= sizeof(int32_t);
            // int32_t M
            ret+= sizeof(int32_t);
            // int32_t K
            ret+= sizeof(int32_t);
            // Matrix bombs
            ret+= N*M*sizeof(int8_t);
            // bool booom
            ret+= sizeof(bool);
            // Matrix flags
            ret+= N*M*sizeof(int8_t);
            // Matrix board
            ret+= N*M*sizeof(int8_t);
            // int32_t minesFound
            ret+= sizeof(int32_t);
            // bool init
            ret+= sizeof(bool);
            // NebSet neb;
            {
                ret+= sizeof(int32_t);
                for(int32_t i=0; i<neb.size(); i++){
                    ret+= neb[i].getByteSize();
                }
            }
        }
        return ret;
    }
    
    int32_t Board::convertToByteArray(Board* position, uint8_t* &byteArray)
    {
        int32_t length = position->getByteSize();
        uint8_t* ret = (uint8_t*)calloc(length, sizeof(uint8_t));
        {
            int32_t pointerIndex = 0;
            // int32_t N
            {
                int32_t size = sizeof(int32_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, &position->N, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: N: %d, %d\n", pointerIndex, length);
                }
                // printf("convertToByteArray: N: %d\n", pointerIndex);
            }
            // int32_t M
            {
                int32_t size = sizeof(int32_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, &position->M, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: M: %d, %d\n", pointerIndex, length);
                }
                // printf("convertToByteArray: M: %d\n", pointerIndex);
            }
            // int32_t K
            {
                int32_t size = sizeof(int32_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, &position->K, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: K: %d, %d\n", pointerIndex, length);
                }
                // printf("convertToByteArray: K: %d\n", pointerIndex);
            }
            // Matrix bombs
            {
                int32_t size = sizeof(int8_t);
                for(int32_t n=0; n<position->N; n++)
                    for (int32_t m=0; m<position->M; m++) {
                        if(pointerIndex+size<=length){
                            memcpy(ret + pointerIndex, &position->bombs[n][m], size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: bombs: %d, %d\n", pointerIndex, length);
                        }
                    }
                // printf("convertToByteArray: bombs: %d\n", pointerIndex);
            }
            // bool booom
            {
                int32_t size = sizeof(bool);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, &position->booom, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: booom: %d, %d\n", pointerIndex, length);
                }
                // printf("convertToByteArray: booom: %d\n", pointerIndex);
            }
            // Matrix flags
            {
                int32_t size = sizeof(int8_t);
                for(int32_t n=0; n<position->N; n++)
                    for (int32_t m=0; m<position->M; m++) {
                        if(pointerIndex+size<=length){
                            memcpy(ret + pointerIndex, &position->flags[n][m], size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: flags: %d, %d\n", pointerIndex, length);
                        }
                    }
                // printf("convertToByteArray: flags: %d\n", pointerIndex);
            }
            // Matrix board
            {
                int32_t size = sizeof(int8_t);
                for(int32_t n=0; n<position->N; n++)
                    for (int32_t m=0; m<position->M; m++) {
                        if(pointerIndex+size<=length){
                            memcpy(ret + pointerIndex, &position->board[n][m], size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: board: %d, %d\n", pointerIndex, length);
                        }
                    }
                // printf("convertToByteArray: board: %d\n", pointerIndex);
            }
            // int32_t minesFound
            {
                int32_t size = sizeof(int32_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, &position->minesFound, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: minesFound: %d, %d\n", pointerIndex, length);
                }
            }
            // bool init
            {
                int32_t size = sizeof(bool);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, &position->init, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: init: %d, %d\n", pointerIndex, length);
                }
                // printf("convertToByteArray: init: %d\n", pointerIndex);
            }
            // NebSet neb;
            {
                // neb count
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        int32_t nebCount = (int32_t)position->neb.size();
                        memcpy(ret + pointerIndex, &nebCount, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: nebCount: %d, %d\n", pointerIndex, length);
                    }
                }
                // content
                for(int32_t i=0; i<position->neb.size(); i++){
                    uint8_t* nebByteArray;
                    int32_t size = Neb::convertToByteArray(&position->neb[i], nebByteArray);
                    // write
                    if(pointerIndex+size<=length){
                        memcpy(ret + pointerIndex, nebByteArray, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: neb: %d, %d\n", pointerIndex, length);
                    }
                    free(nebByteArray);
                }
                // printf("convertToByteArray: neb: %d\n", pointerIndex);
            }
            // printf("convert position to array: return value: %d; %d\n", pointerIndex, length);
        }
        byteArray = ret;
        return length;
    }
    
    int32_t Board::parseByteArray(Board* position, uint8_t* bytes, int32_t length, int32_t start, bool canCorrect)
    {
        int32_t pointerIndex = start;
        int32_t index = 0;
        bool isParseCorrect = true;
        while (pointerIndex < length) {
            bool alreadyPassAll = false;
            switch (index) {
                case 0:
                    // int32_t N
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->N, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: N: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                    // printf("parseByteArray: N: %d\n", pointerIndex);
                }
                    break;
                case 1:
                {
                    // int32_t M
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->M, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: M: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                    // printf("parseByteArray: M: %d\n", pointerIndex);
                }
                    break;
                case 2:
                    // int32_t K
                {
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->K, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: K: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                    // printf("parseByteArray: K: %d\n", pointerIndex);
                }
                    break;
                case 3:
                {
                    // correct input
                    if(canCorrect){
                        if(position->N<5){
                            position->N = 5;
                        }
                        if(position->N>MAX_DIMENSION){
                            position->N = MAX_DIMENSION;
                        }
                        if(position->M<5){
                            position->M = 5;
                        }
                        if(position->M>MAX_DIMENSION){
                            position->M = MAX_DIMENSION;
                        }
                        if(position->K<0){
                            position->K = 1;
                        }
                        if(position->K>=position->N*position->M){
                            position->K = position->N*position->M-1;
                        }
                    }
                    // Matrix bombs
                    position->bombs = ByteMatrix(position->N, vector<int8_t>(position->M));
                    // set
                    int32_t size = sizeof(int8_t);
                    for(int32_t n=0; n<position->N; n++)
                        for (int32_t m=0; m<position->M; m++) {
                            if(pointerIndex+size<=length){
                                memcpy(&position->bombs[n][m], bytes + pointerIndex, size);
                                pointerIndex+=size;
                            }else{
                                printf("length error: bombs: %d, %d\n", pointerIndex, length);
                                isParseCorrect = false;
                            }
                        }
                    // printf("parseByteArray: bombs: %d\n", pointerIndex);
                }
                    break;
                case 4:
                {
                    // bool booom
                    int32_t size = sizeof(bool);
                    if(pointerIndex+size<=length){
                        memcpy(&position->booom, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: booom: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                    // printf("parseByteArray: boomb: %d\n", pointerIndex);
                }
                    break;
                case 5:
                {
                    // Matrix flags
                    position->flags = ByteMatrix(position->N, vector<int8_t>(position->M));
                    // set
                    int32_t size = sizeof(int8_t);
                    for(int32_t n=0; n<position->N; n++)
                        for (int32_t m=0; m<position->M; m++) {
                            if(pointerIndex+size<=length){
                                memcpy(&position->flags[n][m], bytes + pointerIndex, size);
                                pointerIndex+=size;
                                // printf("parse flags: %d, %d, %d\n", n, m, position->board[n][m]);
                            }else{
                                printf("length error: flags: %d, %d\n", pointerIndex, length);
                                isParseCorrect = false;
                            }
                        }
                }
                    break;
                case 6:
                {
                    // Matrix board
                    position->board = ByteMatrix(position->N, vector<int8_t>(position->M));
                    // set
                    int32_t size = sizeof(int8_t);
                    for(int32_t n=0; n<position->N; n++)
                        for (int32_t m=0; m<position->M; m++) {
                            if(pointerIndex+size<=length){
                                memcpy(&position->board[n][m], bytes + pointerIndex, size);
                                pointerIndex+=size;
                                // printf("parse board: %d, %d, %d\n", n, m, position->board[n][m]);
                            }else{
                                printf("length error: board: %d, %d\n", pointerIndex, length);
                                isParseCorrect = false;
                            }
                        }
                    // printf("parseByteArray: board: %d\n", pointerIndex);
                }
                    break;
                case 7:
                {
                    // int32_t minesFound
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->minesFound, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: minesFound: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 8:
                {
                    // bool init
                    int32_t size = sizeof(bool);
                    if(pointerIndex+size<=length){
                        memcpy(&position->init, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: init: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                    // printf("parseByteArray: init: %d\n", pointerIndex);
                }
                    break;
                case 9:
                {
                    // NebSet neb
                    // neb count
                    int32_t needCount = 0;
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&needCount, bytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: needCount: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                    // content
                    for(int32_t i=0; i<needCount; i++){
                        Neb neb;
                        {
                            int32_t nebByteLength = Neb::parseByteArray(&neb, bytes, length, pointerIndex, canCorrect);
                            if (nebByteLength > 0) {
                                pointerIndex+= nebByteLength;
                            } else {
                                printf("error, cannot parse: pos\n");
                                isParseCorrect = false;
                            }
                        }
                        position->neb.push_back(neb);
                    }
                    // printf("parseByteArray: neb: %d\n", pointerIndex);
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
        // return
        if (!isParseCorrect) {
            printf("parse fail\n");
        } else {
            // printf("parse success");
        }
        // check position ok: if not, correct it
        if(canCorrect){
            
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
