#include "Laser.h"
#include <cstring>

bool Laser::Fire(const Player& player, const ILaserable& board)
{
    // Find the starting location and direction for the laserbeam.
    _targetIndex = Sphinx[(int)player];
    _targetSquare = Empty;
    int dirIndex = GetOrientation(board.Get(_targetIndex));
    while (_targetSquare != OffBoard && dirIndex >= 0)
    {
        // Take a step with the laserbeam.
        _targetIndex += Directions[dirIndex];

        // Is this location occupied?
        _targetSquare = board.Get(_targetIndex);
        if (IsPiece(_targetSquare))
        {
            _targetPiece = (int)GetPiece(_targetSquare);
            dirIndex = Reflections[dirIndex][_targetPiece - 2][GetOrientation(_targetSquare)];
        }

        OnStep(_targetIndex, dirIndex);
    }

	return dirIndex == Dead;
}

void Laser::OnStep(int targetIndex, int postDir)
{
    // This is overriden in extended lasers.
}
