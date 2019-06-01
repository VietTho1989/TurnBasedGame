using System;

namespace Rubiks
{
    public class CubePiece
    {

        public int cubeVal;
        public bool inPlace;

        public CubePiece(int _index, bool _inPlace)
        {
            cubeVal = _index;
            inPlace = _inPlace;
        }

    }
}