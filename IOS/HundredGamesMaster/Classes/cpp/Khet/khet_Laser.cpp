#include "khet_Laser.hpp"
#include <cstring>
#include <cstdlib>

namespace Khet
{
    bool Laser::Fire(const Player& player, const ILaserable& board)
    {
        // Find the starting location and direction for the laserbeam.
        _targetIndex = Sphinx[(int32_t)player];
        _targetSquare = Empty;
        int32_t dirIndex = GetOrientation(board.Get(_targetIndex));
        while (_targetSquare != OffBoard && dirIndex >= 0)
        {
            // Take a step with the laserbeam.
            _targetIndex += Directions[dirIndex];
            
            // Is this location occupied?
            _targetSquare = board.Get(_targetIndex);
            if (IsPiece(_targetSquare))
            {
                _targetPiece = (int32_t)GetPiece(_targetSquare);
                dirIndex = Reflections[dirIndex][_targetPiece - 2][GetOrientation(_targetSquare)];
            }
            
            OnStep(_targetIndex, dirIndex);
        }
        
        return dirIndex == Dead;
    }
    
    void Laser::OnStep(int32_t targetIndex, int32_t postDir)
    {
        // This is overriden in extended lasers.
    }
    
    /////////////////////////////////////////////////////////////////////////////////////
    //////////////////// Convert ///////////////////
    /////////////////////////////////////////////////////////////////////////////////////
    
    int32_t Laser::getByteSize()
    {
        int32_t ret = 0;
        {
            // int32_t _targetIndex
            ret+=sizeof(int32_t);
            // Square _targetSquare
            ret+=sizeof(Square);
            // int32_t _targetPiece
            ret+=sizeof(int32_t);
        }
        return ret;
    }
    
    int32_t Laser::convertToByteArray(Laser* laser, uint8_t* &byteArray)
    {
        int32_t length = Laser::getByteSize();
        uint8_t* ret = (uint8_t*)calloc(length, sizeof(uint8_t));
        {
            int32_t pointerIndex = 0;
            // int32_t _targetIndex
            {
                int32_t size = sizeof(int32_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, &laser->_targetIndex, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: _targetIndex: %d, %d\n", pointerIndex, length);
                }
            }
            // Square _targetSquare
            {
                int32_t size = sizeof(Square);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, &laser->_targetSquare, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: _targetSquare: %d, %d\n", pointerIndex, length);
                }
            }
            // int32_t _targetPiece
            {
                int32_t size = sizeof(int32_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, &laser->_targetPiece, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: _targetPiece: %d, %d\n", pointerIndex, length);
                }
            }
            // printf("convert position to array: return value: %d; %d\n", pointerIndex, length);
        }
        byteArray = ret;
        return length;
    }
    
    int32_t Laser::parseByteArray(Laser* laser, uint8_t* bytes, int32_t length, int32_t start, bool canCorrect)
    {
        int32_t pointerIndex = start;
        int32_t index = 0;
        bool isParseCorrect = true;
        while (pointerIndex < length) {
            bool alreadyPassAll = false;
            switch (index) {
                case 0:
                {
                    // int32_t _targetIndex
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&laser->_targetIndex, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: _targetIndex: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 1:
                {
                    // Square _targetSquare
                    int32_t size = sizeof(Square);
                    if(pointerIndex+size<=length){
                        memcpy(&laser->_targetSquare, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: _targetSquare: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 2:
                {
                    // int32_t _targetPiece
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&laser->_targetPiece, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: _targetPiece: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
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
