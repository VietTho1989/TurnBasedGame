using UnityEngine;
using System;

namespace Rubiks
{
    public class Move
    {

        //A move can be X+ Y+ Z+ or X- Y- or Z-
        //X rotates a layer (rotateLayer)
        //Y rotates a side (rotateSide)
        //Z rotates a frontFace (rotateFrontFace)
        public string main;
        public int layerNo;
        public bool translation;

        //top layer = 0
        //left side = 0
        //back face = 0
        public Move(string _main, int _layerNo)
        {
            layerNo = _layerNo;
            main = _main;
            translation = false;
        }

        public Move(String _main, int _layerNo, bool _translation)
        {
            layerNo = _layerNo;
            main = _main;
            translation = _translation;
        }

        public bool equals(Move move)
        {
            return main.Equals(move.main) && layerNo == move.layerNo;
        }

        public static void testMain(String[] args)
        {
            Move move1 = new Move("XX", 1);
            Move move2 = new Move("YY", 1);
            Debug.Log(move1.equals(move2));
        }

    }
}