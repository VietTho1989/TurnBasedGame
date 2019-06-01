using UnityEngine;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace Rubiks
{
    public class Cube
    {
        /*
         * Author: theolincke.com
         *
         * Date: 2018-12-14
         *
         * Description
         *
         * This is a rubiks cube class a cube is a 1D array, so all opperations are done
         * to the cube by switching array elements This class does not solve the cube,
         * it only turns faces and fixes the 1D array to coorespond with a certain move
         * This is essentially a "tools" class
         */

        // Cube specific Vars
        // For debugging, printCube() prints cube in color format shown below, I've
        // commented out the color, but you can use either
        // private final char[] COLORFACES = { 'b', 'o', 'w', 'r', 'y', 'g' };
        private static readonly char[] COLORFACES = { '0', '1', '2', '3', '4', '5' };

        // list of edge cubies and indexes and corner cubies
        private List<EdgeCubie> edgeCubies;
        private List<CornerCubie> cornerCubies;

        // Faces is a one dimentional array (Woah! a 3D cube is represented in 1D?)
        public List<int> faces;

        // a 3x3 cube has dimension 3
        public int dimension;
        // every cube state has a unique scramble algorithm
        public List<Move> scrambleAlgorithm = new List<Move>();
        // every move that has been done on the cube. used in solver.java
        public List<Move> algorithm = new List<Move>();

        // creates a new cube of _dimension
        public Cube(int _dimension)
        {
            dimension = _dimension;
            int myBase = dimension * dimension;
            faces = new List<int>();
            for (int i = 0; i < 6 * myBase; i++)
            {
                faces.Add(i);
            }
            fillCornerCubies();
            fillEdgeCubies();
        }

        // takes in a Cubenxn and creates a cube, used in transitioning from n x n to 3
        // x 3
        public Cube(Cubenxn cube)
        {
            dimension = cube.dimension;
            faces = cube.faces;
            edgeCubies = cube.getEdgeCubies();
            cornerCubies = cube.getCornerCubies();
            algorithm = cube.algorithm;
            scrambleAlgorithm = cube.scrambleAlgorithm;
        }

        public Cube(Cube3x3 cube)
        {
            dimension = cube.dimension;
            faces = cube.faces;
            edgeCubies = cube.getEdgeCubies();
            cornerCubies = cube.getCornerCubies();
            algorithm = cube.algorithm;
            scrambleAlgorithm = cube.scrambleAlgorithm;
        }

        // fills all the edge indices
        private void fillEdgeCubies()
        {
            edgeCubies = new List<EdgeCubie>();
            for (int i = 1; i < dimension - 1; i++)
            {
                edgeCubies.Add(new EdgeCubie(getPosition(0, i, 0), getPosition(1, 0, i)));
                edgeCubies.Add(new EdgeCubie(getPosition(0, 0, i), getPosition(4, 0, dimension - 1 - i)));
                edgeCubies.Add(new EdgeCubie(getPosition(0, i, dimension - 1), getPosition(3, 0, dimension - 1 - i)));
                edgeCubies.Add(new EdgeCubie(getPosition(1, i, 0), getPosition(4, i, dimension - 1)));
                edgeCubies.Add(new EdgeCubie(getPosition(1, dimension - 1, i), getPosition(5, dimension - 1 - i, 0)));
                edgeCubies.Add(new EdgeCubie(getPosition(5, i, dimension - 1), getPosition(3, dimension - 1, i)));
                edgeCubies.Add(new EdgeCubie(getPosition(5, dimension - 1, i), getPosition(4, dimension - 1, dimension - 1 - i)));
                edgeCubies.Add(new EdgeCubie(getPosition(3, i, dimension - 1), getPosition(4, i, 0)));
                edgeCubies.Add(new EdgeCubie(getPosition(1, i, dimension - 1), getPosition(2, i, 0)));
                edgeCubies.Add(new EdgeCubie(getPosition(0, dimension - 1, i), getPosition(2, 0, i)));
                edgeCubies.Add(new EdgeCubie(getPosition(2, dimension - 1, i), getPosition(5, 0, i)));
                edgeCubies.Add(new EdgeCubie(getPosition(2, i, dimension - 1), getPosition(3, i, 0)));
            }
        }

        // fills corner indicies
        private void fillCornerCubies()
        {
            cornerCubies = new List<CornerCubie>();
            cornerCubies.Add(new CornerCubie(getPosition(0, 0, 0), getPosition(1, 0, 0), getPosition(4, 0, dimension - 1)));
            cornerCubies
                .Add(new CornerCubie(getPosition(0, 0, dimension - 1), getPosition(3, 0, dimension - 1), getPosition(4, 0, 0)));
            cornerCubies
                .Add(new CornerCubie(getPosition(0, dimension - 1, 0), getPosition(1, 0, dimension - 1), getPosition(2, 0, 0)));
            cornerCubies.Add(new CornerCubie(getPosition(0, dimension - 1, dimension - 1), getPosition(2, 0, dimension - 1),
                getPosition(3, 0, 0)));
            cornerCubies.Add(new CornerCubie(getPosition(2, dimension - 1, 0), getPosition(1, dimension - 1, dimension - 1),
                getPosition(5, 0, 0)));
            cornerCubies.Add(new CornerCubie(getPosition(2, dimension - 1, dimension - 1), getPosition(3, dimension - 1, 0),
                getPosition(5, 0, dimension - 1)));
            cornerCubies.Add(new CornerCubie(getPosition(5, dimension - 1, 0), getPosition(1, dimension - 1, 0),
                getPosition(4, dimension - 1, dimension - 1)));
            cornerCubies.Add(new CornerCubie(getPosition(5, dimension - 1, dimension - 1),
                getPosition(3, dimension - 1, dimension - 1), getPosition(4, dimension - 1, 0)));
        }

        // returns faces (an array list)
        public List<int> getFaces()
        {
            return faces;
        }

        // returns corner cubies, rarely used so I made it private
        public List<CornerCubie> getCornerCubies()
        {
            return cornerCubies;
        }

        // returns edge cubies
        public List<EdgeCubie> getEdgeCubies()
        {
            return edgeCubies;
        }

        // returns an array list of edgecubies that match color1 and color2
        public List<EdgeCubie> getEdgeCubie(int color1, int color2)
        {
            int myBase = dimension * dimension;
            List<EdgeCubie> cubies = new List<EdgeCubie>();
            foreach (EdgeCubie cubie in edgeCubies)
            {
                if ((cubie.index1 / myBase == color1 && cubie.index2 / myBase == color2)
                    || (cubie.index1 / myBase == color2 && cubie.index2 / myBase == color1))
                {
                    cubies.Add(cubie);
                }
            }
            return cubies;
        }

        // returns the corner cubie associated with color 1 2 and 3
        public CornerCubie getCornerCubie(int color1, int color2, int color3)
        {
            int myBase = dimension * dimension;
            List<int> colors;
            List<int> testingColors = new List<int>();
            testingColors.Add(color1);
            testingColors.Add(color2);
            testingColors.Add(color3);
            testingColors.Sort(); // Collections.sort(testingColors);

            foreach (CornerCubie cubie in cornerCubies)
            {
                colors = new List<int>();
                colors.Add(cubie.index1 / myBase);
                colors.Add(cubie.index2 / myBase);
                colors.Add(cubie.index3 / myBase);
                colors.Sort();// Collections.sort(colors);
                bool match = true;
                for (int i = 0; i < 3; i++)
                {
                    if (colors[i] != testingColors[i])
                    {
                        match = false;
                        break;
                    }
                }
                if (match)
                {
                    return cubie;
                }
            }
            return null;

        }

        // Returns dimension
        public int getDimension()
        {
            return dimension;
        }

        /**
         * positioning methods in the cube printout (printCube()), face is the square
         * the cubie is on and row is the row and col col note that on face 4, col is
         * mirrored
         */

        // The general formula that returns the index in the 1d array that cooresponds
        // to
        // the coordinate triplet (face, row, col)
        public int getPosition(int face, int row, int index)
        {
            return dimension * dimension * face + dimension * row + index;
        }

        // returns what row a cubie is on
        public int getRow(int cubie)
        {
            int myBase = dimension * dimension;
            return (getFaces().IndexOf(cubie) % myBase) / dimension;
        }

        // returns what col a cubie is on
        public int getCol(int cubie)
        {
            return getFaces().IndexOf(cubie) % getDimension();
        }

        /******************************************************************************
         * BASIC TOOLS - ROTATE FACES
         ********************************************************************/
        // rotates a given face (does not change the cubies around so this is not a
        // valid move, it helps the other algorithms)

        // transposes and flips horizontally an n x n matrix being represented by a 1 x
        // n^2 vector
        public void rotateFullFace(int direction, int face)
        {
            int[] temp1 = new int[dimension * dimension];
            int[] temp2 = new int[dimension * dimension];
            int starter = getPosition(face, 0, 0);

            for (int i = 0; i < dimension * dimension; i++)
            {
                temp1[i] = faces[starter + i];
            }

            for (int i = 0; i < temp1.Length; i++)
            {
                // transposes and flips horizontally an n x n matrix being represented by a 1 x n^2 vector
                // sexy sexy piece of code right here
                temp2[(i % dimension) * dimension + (dimension - 1 - (i / (dimension)))] = temp1[i];
            }

            if (direction == 1)
            {
                for (int i = 0; i < temp1.Length; i++)
                {
                    // faces.set(starter + i, temp2[i]);
                    faces[starter + i] = temp2[i];
                }
            }
            else
            {
                int counter = 0;
                for (int i = temp2.Length - 1; i >= 0; i--)
                {
                    // faces.set(starter + counter, temp2[i]);
                    faces[starter + counter] = temp2[i];
                    counter++;
                }
            }
        }

        // colNum 0 is left face colNum dimension - 1 is right face
        // always rotates clockwise where right face is in front (unlike the standard R
        // vs L notation in rubiks cube algorithms)
        public void rotateSide(int direction, int colNum, bool isAlgorithAdd)
        {
            if (colNum == 0)
            {
                rotateFullFace(-direction, 1);
            }
            else if (colNum == dimension - 1)
            {
                rotateFullFace(direction, 3);
            }
            if (direction == 1)
            {
                for (int i = 0; i < dimension; i++)
                {
                    int temp0 = faces[getPosition(0, i, colNum)];
                    int temp2 = faces[getPosition(2, i, colNum)];
                    int temp4 = faces[getPosition(4, dimension - i - 1, dimension - colNum - 1)];
                    int temp5 = faces[getPosition(5, i, colNum)];
                    faces[getPosition(2, i, colNum)] = temp5;
                    faces[getPosition(0, i, colNum)] = temp2;
                    faces[getPosition(4, dimension - i - 1, dimension - colNum - 1)] = temp0;
                    faces[getPosition(5, i, colNum)] = temp4;
                }
                if (isAlgorithAdd)
                    algorithm.Add(new Move("Y+", colNum));
                Debug.Log(this.printCube());
            }
            else
            {
                for (int i = 0; i < dimension; i++)
                {
                    int temp0 = faces[getPosition(0, i, colNum)];
                    int temp2 = faces[getPosition(2, i, colNum)];
                    int temp4 = faces[getPosition(4, dimension - i - 1, dimension - colNum - 1)];
                    int temp5 = faces[getPosition(5, i, colNum)];
                    faces[getPosition(5, i, colNum)] = temp2;
                    faces[getPosition(2, i, colNum)] = temp0;
                    faces[getPosition(0, i, colNum)] = temp4;
                    faces[getPosition(4, dimension - i - 1, dimension - colNum - 1)] = temp5;
                }
                if (isAlgorithAdd)
                    algorithm.Add(new Move("Y-", colNum));
                Debug.Log(this.printCube());
            }
        }

        // Layer 0 is top layer layer dimension - 1 is bottom
        // Always rotates clockwise where top is facing you
        public void rotateLayer(int direction, int layerNum, bool isAlgorithAdd)
        {
            if (layerNum == 0)
            {
                rotateFullFace(direction, 2);
            }
            else if (layerNum == dimension - 1)
            {
                rotateFullFace(-direction, 4);
            }

            if (direction == 1)
            {
                for (int i = 0; i < dimension; i++)
                {
                    int temp0 = faces[getPosition(0, dimension - layerNum - 1, i)];
                    int temp3 = faces[getPosition(3, i, layerNum)];
                    int temp5 = faces[getPosition(5, layerNum, dimension - i - 1)];
                    int temp1 = faces[getPosition(1, dimension - i - 1, dimension - layerNum - 1)];

                    faces[getPosition(3, i, layerNum)] = temp0;
                    faces[getPosition(5, layerNum, dimension - i - 1)] = temp3;
                    faces[getPosition(1, dimension - i - 1, dimension - layerNum - 1)] = temp5;
                    faces[getPosition(0, dimension - layerNum - 1, i)] = temp1;
                }
                if (isAlgorithAdd)
                    algorithm.Add(new Move("X+", layerNum));
                Debug.Log(this.printCube());
            }
            else
            {
                for (int i = 0; i < dimension; i++)
                {
                    int temp0 = faces[getPosition(0, dimension - layerNum - 1, i)];
                    int temp3 = faces[getPosition(3, i, layerNum)];
                    int temp5 = faces[getPosition(5, layerNum, dimension - i - 1)];
                    int temp1 = faces[getPosition(1, dimension - i - 1, dimension - layerNum - 1)];

                    faces[getPosition(3, i, layerNum)] = temp5;
                    faces[getPosition(5, layerNum, dimension - i - 1)] = temp1;
                    faces[getPosition(1, dimension - i - 1, dimension - layerNum - 1)] = temp0;
                    faces[getPosition(0, dimension - layerNum - 1, i)] = temp3;
                }
                if (isAlgorithAdd)
                    algorithm.Add(new Move("X-", layerNum));
                Debug.Log(this.printCube());
            }
        }

        // faceNum 0 is the back faceNym dimension - 1 is front
        // always rotates face where front is facing you
        public void rotateFrontFace(int direction, int faceNum, bool isAlgorithAdd)
        {
            if (faceNum == 0)
            {
                rotateFullFace(-direction, 0);
            }
            else if (faceNum == dimension - 1)
            {
                rotateFullFace(direction, 5);
            }
            int temp1;
            int temp2;
            int temp3;
            int temp4;
            if (direction == 1)
            {
                temp1 = faces[getPosition(1, faceNum, 0)];
                for (int x = 0; x < dimension; x++)
                {
                    temp1 = faces[getPosition(1, faceNum, x)];
                    temp2 = faces[getPosition(2, faceNum, x)];
                    temp3 = faces[getPosition(3, faceNum, x)];
                    temp4 = faces[getPosition(4, faceNum, x)];

                    faces[getPosition(1, faceNum, x)] = temp4;
                    faces[getPosition(2, faceNum, x)] = temp1;
                    faces[getPosition(3, faceNum, x)] = temp2;
                    faces[getPosition(4, faceNum, x)] = temp3;
                }
                if (isAlgorithAdd)
                    algorithm.Add(new Move("Z+", faceNum));
                Debug.Log(this.printCube());
            }
            else
            {
                for (int x = 0; x < dimension; x++)
                {
                    temp1 = faces[getPosition(1, faceNum, x)];
                    temp2 = faces[getPosition(2, faceNum, x)];
                    temp3 = faces[getPosition(3, faceNum, x)];
                    temp4 = faces[getPosition(4, faceNum, x)];

                    faces[getPosition(4, faceNum, x)] = temp1;
                    faces[getPosition(1, faceNum, x)] = temp2;
                    faces[getPosition(2, faceNum, x)] = temp3;
                    faces[getPosition(3, faceNum, x)] = temp4;
                }
                if (isAlgorithAdd)
                    algorithm.Add(new Move("Z-", faceNum));
                Debug.Log(this.printCube());
            }
        }

        /****************************************************************************
         * COMPLEX TOOLS - ORIENTS THE CUBE
         ****************************************************************/

        // The following rotate the entire cube (so that the cube orientation changes)
        public void rotateCubeClockwise(bool isAlgorithAdd)
        {
            for (int i = 0; i < dimension; i++)
            {
                rotateLayer(1, i, false);
                // I don't want translations represented as moves, so I'm creating my own
                // translation move
                // algorithm.remove(algorithm.size() - 1);
                // algorithm.RemoveAt(algorithm.Count - 1);
            }
            if (isAlgorithAdd)
                algorithm.Add(new Move("XX", 1, true));
            Debug.Log(this.printCube());
        }

        public void rotateCubeCounterClockwise(bool isAlgorithAdd)
        {
            for (int i = 0; i < dimension; i++)
            {
                rotateLayer(-1, i, false);
                // algorithm.remove(algorithm.size() - 1);
                // algorithm.RemoveAt(algorithm.Count - 1);
            }
            if (isAlgorithAdd)
                algorithm.Add(new Move("XX", -1, true));
            Debug.Log(this.printCube());
        }

        public void rotateCubeDown(bool isAlgorithAdd)
        {
            for (int i = 0; i < dimension; i++)
            {
                rotateSide(-1, i, false);
                // algorithm.remove(algorithm.size() - 1);
                // algorithm.RemoveAt(algorithm.Count - 1);
            }
            if (isAlgorithAdd)
                algorithm.Add(new Move("YY", -1, true));
            Debug.Log(this.printCube());
        }

        public void rotateCubeUp(bool isAlgorithmAdd)
        {
            for (int i = 0; i < dimension; i++)
            {
                rotateSide(1, i, false);
                // algorithm.remove(algorithm.size() - 1);
                // algorithm.RemoveAt(algorithm.Count - 1);
            }
            if (isAlgorithmAdd)
                algorithm.Add(new Move("YY", 1, true));
            Debug.Log(this.printCube());
        }

        /**
         * 
         * Puts the above together tangibly orients the cube just so that the
         * colorfacefront is in front
         */

        // orients the cube so that the current position of the desired faceleft / face
        // front (they can be anywhere on the cube) become left and front
        public void orientCubeFrontLeft(int faceLeft, int faceFront)
        {
            // store a cubie so that we can find what face this cubie lands on after we
            // execute the first translation (all translations will change the orientation
            // of the second face)
            int tempCubie = getFaces()[getPosition(faceFront, 1, 1)];
            switch (faceLeft)
            {
                case 0:
                    rotateCubeCounterClockwise(true);
                    break;
                case 2:
                    rotateCubeDown(true);
                    rotateCubeClockwise(true);
                    break;
                case 3:
                    rotateCubeClockwise(true);
                    rotateCubeClockwise(true);
                    break;
                case 4:
                    rotateCubeUp(true);
                    rotateCubeClockwise(true);
                    break;
                case 5:
                    rotateCubeClockwise(true);
                    break;
            }

            faceFront = getFaceOrientation(tempCubie);

            switch (faceFront)
            {
                case 0:
                    rotateCubeUp(true);
                    rotateCubeUp(true);
                    break;
                case 2:
                    rotateCubeDown(true);
                    break;
                case 4:
                    rotateCubeUp(true);
                    break;
            }
        }

        // Orients the cube so that facefront is the front face, face top is the top
        // face and facebottom is the bottom face color

        public void orientCube(int colorFaceFront, int colorFaceTop)
        {
            // If impossible orientation, only puts color face top on top
            if (dimension % 2 == 0)
            {
                return;
            }
            int cubieFaceTop = getCenterCubie(colorFaceTop);
            switch (getFaceOrientation(cubieFaceTop))
            {
                case 0:
                    rotateCubeDown(true);
                    break;
                case 1:
                    rotateCubeCounterClockwise(true);
                    rotateCubeUp(true);
                    break;
                case 3:
                    rotateCubeClockwise(true);
                    rotateCubeUp(true);
                    break;
                case 4:
                    rotateCubeUp(true);
                    rotateCubeUp(true);
                    break;
                case 5:
                    rotateCubeUp(true);
                    break;
            }

            int cubieFaceFront = getCenterCubie(colorFaceFront);

            switch (getFaceOrientation(cubieFaceFront))
            {
                case 0:
                    rotateCubeClockwise(true);
                    rotateCubeClockwise(true);
                    break;
                case 1:
                    rotateCubeCounterClockwise(true);
                    break;
                case 3:
                    rotateCubeClockwise(true);
                    break;
            }
        }

        /****************************************************************************
         * FINDER TOOLS - LOCATE PIECES
         ****************************************************************/

        // takes in a specific value somewhere in the array and returns which face that
        // piece is on (0 - 5)
        public int getFaceOrientation(int color)
        {
            int myBase = dimension * dimension;
            return faces.IndexOf(color) / myBase;
        }

        // Takes in a number as an edgepiece (a specific number in the array) returns
        // the cooresponding edge piece (all edge cubies are two edgepieces) returns -1
        // if corner or invalid
        public int getCoorespondingEdgePiece(int color)
        {
            foreach (EdgeCubie cubie in edgeCubies)
            {
                if (cubie.index1 == color)
                    return cubie.index2;
                if (cubie.index2 == color)
                    return cubie.index1;
            }
            return -1;
        }

        // Same as above, but returns and int array of the cooresponding corner pieces
        public int[] getCoorespondingCorners(int color)
        {
            foreach (CornerCubie cubie in cornerCubies)
            {
                if (cubie.index1 == color)
                {
                    int[] result = { cubie.index2, cubie.index3 };
                    return result;
                }
                else if (cubie.index2 == color)
                {
                    int[] result = { cubie.index1, cubie.index3 };
                    return result;
                }
                else if (cubie.index3 == color)
                {
                    int[] result = { cubie.index1, cubie.index2 };
                    return result;
                }

            }
            int[] falseArray = { -1, -1 };
            return falseArray;
        }

        public int getCenterCubie(int color)
        {
            if (color > 5 || color < 0 || getDimension() % 2 == 0)
            {
                return -1;
            }
            int myBase = dimension * dimension;
            for (int i = 0; i < 6; i++)
            {
                if (faces[getPosition(i, getDimension() / 2, getDimension() / 2)] / myBase == color)
                    return faces[getPosition(i, getDimension() / 2, getDimension() / 2)];
            }
            return -1;
        }

        // Only works on odd dimensions

        public int getColor(int face)
        {
            if (dimension % 2 == 0)
            {
                return -1;
            }
            return faces[getPosition(face, dimension / 2, dimension / 2)] / (dimension * dimension);
        }

        /****************************************************************************
         * PUTTING EVERYTHING TOGETHER - PRACTICAL
         ****************************************************************/
        // Takes in a readable list of moves (classic rubik's cube notation U R T T' U'
        // etc.) executes those moves
        public void moveSequenceNxN(List<Move> moves)
        {
            foreach (Move move in moves)
            {
                if (move.main.Equals("X+"))
                {
                    rotateLayer(1, move.layerNo, true);
                }
                else if (move.main.Equals("X-"))
                {
                    rotateLayer(-1, move.layerNo, true);
                }
                else if (move.main.Equals("Y+"))
                {
                    rotateSide(1, move.layerNo, true);
                }
                else if (move.main.Equals("Y-"))
                {
                    rotateSide(-1, move.layerNo, true);
                }
                else if (move.main.Equals("Z+"))
                {
                    rotateFrontFace(1, move.layerNo, true);
                }
                else if (move.main.Equals("Z-"))
                {
                    rotateFrontFace(-1, move.layerNo, true);
                }
                else if (move.main.Equals("XX") && move.layerNo == 1)
                {
                    rotateCubeClockwise(true);
                }
                else if (move.main.Equals("YY") && move.layerNo == 1)
                {
                    rotateCubeUp(true);
                }
                else if (move.main.Equals("XX") && move.layerNo == -1)
                {
                    rotateCubeCounterClockwise(true);
                }
                else if (move.main.Equals("YY") && move.layerNo == -1)
                {
                    rotateCubeDown(true);
                }
                Debug.Log(this.printCube());
            }
        }

        public void moveSequenceNxN(Move move, bool isAlgorithmAdd)
        {
            if (move.main.Equals("X+"))
            {
                rotateLayer(1, move.layerNo, isAlgorithmAdd);
            }
            else if (move.main.Equals("X-"))
            {
                rotateLayer(1, move.layerNo, isAlgorithmAdd);
            }
            else if (move.main.Equals("Y+"))
            {
                rotateSide(1, move.layerNo, isAlgorithmAdd);
            }
            else if (move.main.Equals("Y-"))
            {
                rotateSide(-1, move.layerNo, isAlgorithmAdd);
            }
            else if (move.main.Equals("Z+"))
            {
                rotateFrontFace(1, move.layerNo, isAlgorithmAdd);
            }
            else if (move.main.Equals("Z-"))
            {
                rotateFrontFace(-1, move.layerNo, isAlgorithmAdd);
            }
            else if (move.main.Equals("XX") && move.layerNo == 1)
            {
                rotateCubeClockwise(isAlgorithmAdd);
            }
            else if (move.main.Equals("YY") && move.layerNo == 1)
            {
                rotateCubeUp(isAlgorithmAdd);
            }
            else if (move.main.Equals("XX") && move.layerNo == -1)
            {
                rotateCubeCounterClockwise(isAlgorithmAdd);
            }
            else if (move.main.Equals("YY") && move.layerNo == -1)
            {
                rotateCubeDown(isAlgorithmAdd);
            }
            Debug.Log(this.printCube());
        }

        private void generateScramble(int moves)
        {
            int slice;
            int major;
            int direction;
            String majorStr = "";
            for (int i = 0; i < moves; i++)
            {
                slice = Common.random.Next(dimension);// (int) (Math.random() * dimension);
                major = Common.random.Next(3); //(int) (Math.random() * 3);
                direction = Common.random.Next(2);// (int) (Math.random() * 2);
                switch (major)
                {
                    case 0:
                        majorStr = "X";
                        break;
                    case 1:
                        majorStr = "Y";
                        break;
                    case 2:
                        majorStr = "Z";
                        break;
                }
                if (direction == 1)
                {
                    majorStr += "+";
                }
                else
                {
                    majorStr += "-";
                }
                scrambleAlgorithm.Add(new Move(majorStr, slice));
            }
        }

        /****************************************************************************
         * DEBUGGING
         ****************************************************************/

        /**
         * ------BACK
         * 
         * LEFT TOP RIGHT BOTTOM
         * 
         * ------FRONT
         */

        // Prints the cube with colors as letters (r g w y b o)
        public string printCube()
        {
            StringBuilder builder = new StringBuilder();
            {
                builder.AppendLine("moves: " + this.algorithm.Count + ", " + this.scrambleAlgorithm.Count);
                builder.AppendLine("___________________________________________________________________");
                builder.AppendLine();
                int myBase = dimension * dimension;
                List<string> colors = new List<string>();
                for (int i = 0; i < faces.Count; i++)
                {
                    colors.Add(COLORFACES[faces[i] / myBase].ToString());
                }

                int count = 0;
                for (int i = 0; i < dimension; i++)
                {
                    for (int x = 0; x < dimension + 3; x++)
                    {
                        builder.Append("  ");
                    }

                    builder.Append("| ");
                    for (int j = 0; j < dimension; j++)
                    {
                        builder.Append(colors[count] + " ");
                        count++;
                    }
                    builder.Append("| ");
                    builder.AppendLine();
                }

                builder.AppendLine();

                for (int i = 0; i < dimension; i++)
                {
                    count = myBase + dimension * i;

                    for (int j = 0; j < 4; j++)
                    {
                        builder.Append(" | ");
                        for (int x = 0; x < dimension; x++)
                        {
                            builder.Append(colors[count + x] + " ");
                        }
                        builder.Append("| ");
                        count = count + myBase;
                    }
                    builder.AppendLine();
                }
                builder.AppendLine();

                count = myBase * 5;
                for (int i = 0; i < dimension; i++)
                {
                    for (int x = 0; x < dimension + 3; x++)
                    {
                        builder.Append("  ");
                    }

                    builder.Append("| ");
                    for (int j = 0; j < dimension; j++)
                    {
                        builder.Append(colors[count] + " ");
                        count++;
                    }
                    builder.Append("| ");
                    builder.AppendLine();
                }
                builder.AppendLine("___________________________________________________________________");
            }
            return builder.ToString();
        }

        // prints cube in square format (the numbers) cross format
        public string printCubeNums()
        {
            StringBuilder builder = new StringBuilder();
            {
                builder.AppendLine("___________________________________________________________________");
                builder.AppendLine();
                int myBase = dimension * dimension;

                int count = 0;
                for (int i = 0; i < dimension; i++)
                {
                    for (int x = 0; x < dimension + 2; x++)
                    {
                        builder.Append("   ");
                    }

                    builder.Append("| ");
                    for (int j = 0; j < dimension; j++)
                    {
                        int a = faces[count];
                        if (a < 10)
                        {
                            builder.Append("0" + a + " ");
                        }
                        else
                        {
                            builder.Append(a + " ");
                        }
                        count++;
                    }
                    builder.Append("| ");
                    builder.AppendLine();
                }

                builder.AppendLine();

                for (int i = 0; i < dimension; i++)
                {
                    count = myBase + dimension * i;

                    for (int j = 0; j < 4; j++)
                    {

                        builder.Append(" | ");
                        for (int x = 0; x < dimension; x++)
                        {
                            int a = faces[count + x];
                            if (a < 10)
                            {
                                builder.Append("0" + a + " ");
                            }
                            else
                            {
                                builder.Append(a + " ");
                            }
                        }
                        builder.Append("| ");
                        count = count + myBase;
                    }
                    builder.AppendLine();
                }
                builder.AppendLine();

                count = myBase * 5;
                for (int i = 0; i < dimension; i++)
                {
                    for (int x = 0; x < dimension + 2; x++)
                    {
                        builder.Append("   ");
                    }

                    builder.Append("| ");
                    for (int j = 0; j < dimension; j++)
                    {
                        int a = faces[count];
                        if (a < 10)
                        {
                            builder.Append("0" + a + " ");
                        }
                        else
                        {
                            builder.Append(a + " ");
                        }
                        count++;
                    }
                    builder.Append("| ");
                    builder.AppendLine();
                }
                builder.AppendLine("___________________________________________________________________");
            }
            return builder.ToString();
        }

        // A few testing methods - use these to showcase what every move does
        public static void testRotations()
        {

            // Change dimension to try different size cubes
            Cube testCube3 = new Cube(3);
            Debug.Log("Origional Cube shown as array");
            Debug.Log(testCube3.faces);

            Debug.Log("Origional Cube");
            testCube3.printCube();
            testCube3.printCubeNums();
            // Change 1 to -1 to rotate counter clockwise

            Debug.Log("Back Face Clockwise");
            // rotates back layer clockwise (when front is in front)
            testCube3.rotateFrontFace(1, 0, true);
            testCube3.printCubeNums();
            testCube3.rotateFrontFace(-1, 0, true);

            Debug.Log("Front Face Clockwise");
            // rotates front face clockwise (when front is in front)
            testCube3.rotateFrontFace(1, testCube3.getDimension() - 1, true);
            testCube3.printCubeNums();
            testCube3.rotateFrontFace(-1, testCube3.getDimension() - 1, true);

            Debug.Log("Left Face Clockwise");
            // rotates left side clockwise (when right is in front)
            testCube3.rotateSide(1, 0, true);
            testCube3.printCubeNums();
            testCube3.rotateSide(-1, 0, true);

            Debug.Log("Right Face Clockwise");
            // rotates right side clockwise (when right is in front)
            testCube3.rotateSide(1, testCube3.getDimension() - 1, true);
            testCube3.printCubeNums();
            testCube3.rotateSide(-1, testCube3.getDimension() - 1, true);

            Debug.Log("Top Layer Clockwise");
            // rotates top layer clockwise (when looking down on the cube)
            testCube3.rotateLayer(1, 0, true);
            testCube3.printCubeNums();
            testCube3.rotateLayer(-1, 0, true);

            Debug.Log("Bottom Layer Clockwise");
            // rotates bottom layer clockwise (when looking down on the cube)
            testCube3.rotateLayer(1, testCube3.getDimension() - 1, true);
            testCube3.printCubeNums();
            testCube3.rotateLayer(1, testCube3.getDimension() - 1, true);

        }

        public Cube solveCube(Cubenxn cube)
        {
            // TODO, SPECIAL CASES 2X2 1X1
            if (cube.dimension != 3)
            {
                cube.reduceCubeto3x3();
            }
            Cube3x3 cube3x3 = new Cube3x3(cube);
            cube3x3.solve();
            Cube solvedCube = new Cube(cube3x3);
            return solvedCube;
        }

        // Run this to see everything work
        public static void testSolve(int dimension)
        {
            // shows the cube being sovled while timing scramble and solve
            Cubenxn myCube = new Cubenxn(dimension);
            // print the origional cube
            Debug.Log("Cube OG at dimension: " + dimension);
            myCube.printCube();

            // Timing the scramble
            long startTime = Common.nanoTime();

            // scramble the cube 1000000 times (for large nxn cubes, you could remove Y and
            // X from scrambleCube)
            myCube.scrambleNxN(1000);

            long endTime = Common.nanoTime();

            // get difference of two nanoTime values
            long timeElapsed = endTime - startTime;

            Debug.Log("Scrambled cube at 1000 moves");
            // print the scrambled cube
            myCube.printCube();

            Debug.Log("Execution time of scramble in nanoseconds  : " + timeElapsed);

            Debug.Log("Execution time of scramble in milliseconds : " + timeElapsed / 1000000);

            // Timing the scramble
            startTime = Common.nanoTime();

            // solve the scrambled cube
            // Check the sequence of steps in the method solve
            Cube solvedCube = myCube.solveCube(myCube);

            endTime = Common.nanoTime();

            // get difference of two nanoTime values
            timeElapsed = endTime - startTime;
            Debug.Log("Solved cube");
            solvedCube.printCube();

            Debug.Log("Execution time of reduction in nanoseconds  : " + timeElapsed);

            Debug.Log("Execution time of reduction in milliseconds : " + timeElapsed / 1000000);

        }


        //creates an arraylist of moves to scramble the cube
        public static List<Move> generateScrambleAlgorithm(int moves, int _dimension)
        {
            List<Move> scramble = new List<Move>();
            string[] possibleMoves = { "X+", "Y+", "Z+", "X-", "Y-", "Z-" };
            int randomLayer;
            int randomChooser;
            for (int i = 0; i < moves; i++)
            {
                randomLayer = Common.random.Next(_dimension);// (int) (Math.random() * _dimension);
                randomChooser = Common.random.Next(6);// (int) (Math.random() * 6);
                Move move = new Move(possibleMoves[randomChooser], randomLayer);
                scramble.Add(move);
            }
            return scramble;
        }

    }
}