using UnityEngine;
using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;

namespace Rubiks
{
    public class Cubenxn : Cube
    {

        /**
         * A Cube nxn is a cube that is more than 3 dimensions. This is a step of moves
         * that solves only the center and the edge pieces of the rubiks cube When a 3x3
         * cube is input, it goes to Cube3x3. All cubes are interacted with in the main
         * Cube class However, they change class, starting from a cube nxnn to a cube
         * 3x3 then to acube while being sovled. These methods will never be used on a
         * 3x3 cube.
         * 
         */

        // local variable cubePieces used to identify when all pieces are in place to
        // move on to a 3x3 cube
        private List<CubePiece> cubePieces = new List<CubePiece>();

        // used for testing reduction of cube
        public bool reduced;

        public Cubenxn(int dimension) : base(dimension)
        {
            for (int i = 0; i < dimension * dimension * 6; i++)
            {
                cubePieces.Add(new CubePiece(i, false));
            }
            reduced = false;
        }

        // Solving methods
        /**
         * ***********************************************************************************
         * SOLVING THE CENTERS
         * ***********************************************************************************
         */

        // Cube is facing you, find a piece that matechs the coordinate pair (row, col)

        // finds all pieces on the cube that can fit in a given center spot (returns an
        // array of all the absolute indexes of the positions)
        private List<int> findAvaliableCenterPieces(int row, int col, int color)
        {
            // either 1, 2 or 4, the rest will be zero
            List<int> indexes = new List<int>();
            if (col <= 0 || col >= dimension - 1)
            {
                return indexes;
            }

            // for each, check whether cubie can fit into the slot row col and that it is
            // not already in place (if in place, we don't really want to move it)
            int myBase = dimension * dimension;
            for (int i = 0; i < 6; i++)
            {
                if (!cubePieces[faces[getPosition(i, row, col)]].inPlace
                        && color == faces[getPosition(i, row, col)] / myBase)
                {
                    indexes.Add(getPosition(i, row, col));
                }
                if (!cubePieces[faces[getPosition(i, col, dimension - 1 - row)]].inPlace
                        && color == faces[getPosition(i, col, dimension - 1 - row)] / myBase)
                {
                    indexes.Add(getPosition(i, col, dimension - 1 - row));
                }
                if (!cubePieces[faces[getPosition(i, dimension - 1 - col, row)]].inPlace
                        && color == faces[getPosition(i, dimension - 1 - col, row)] / myBase)
                {
                    indexes.Add(getPosition(i, dimension - 1 - col, row));
                }
                if (!cubePieces[faces[getPosition(i, dimension - 1 - row, dimension - 1 - col)]].inPlace
                        && color == faces[getPosition(i, dimension - 1 - row, dimension - 1 - col)] / myBase)
                {
                    indexes.Add(getPosition(i, dimension - 1 - row, dimension - 1 - col));
                }

            }
            return indexes;

            // remove dubplicates

        }

        // moves a piece on the right face row2 col2 to position row col on the top face
        // without disturbing anyfaces except right and top
        // A COMMON PLACE FOR PROBLEMS - Going in infinite loops
        public void rightFaceCenterPieceToFront(int row, int col, int row2, int col2)
        {

            // both rows and cols match
            bool inPlace = (row == row2) && (col == col2);
            int cubieNum = faces[getPosition(3, row2, col2)];
            int failsafe = 0;
            while (failsafe < 4 && !inPlace)
            {
                rotateSide(1, dimension - 1, true);
                row2 = getRow(cubieNum);
                // col of desired piece (now on the right face)
                col2 = getCol(cubieNum);
                inPlace = (row == row2) && (col == col2);
                failsafe++;

            }

            if (failsafe == 4)
            {
                Debug.LogError("ERROR, row and col doesn't match up - row = " + row + " col = " + col + " row2 = "
                        + row2 + " col2 = " + col2);
            }
            rotateFrontFace(-1, row, true);
            // printCubeNums();

            bool rotateDirection = (row < (dimension / 2) && col < (dimension / 2))
                    || (row >= (dimension / 2) && col >= (dimension / 2));

            // if cubie is on top left or bottom right, rotate right face clockwise
            if (rotateDirection)
            {
                rotateLayer(-1, 0, true);
                // printCubeNums();
                rotateFrontFace(1, row, true);
                // printCubeNums();
                rotateLayer(1, 0, true);
                // printCubeNums();
            }

            // If cubie is on top right or bottom left, rotate right face counter clockwise
            else
            {
                rotateLayer(1, 0, true);
                // printCubeNums();
                rotateFrontFace(1, row, true);
                // printCubeNums();
                rotateLayer(-1, 0, true);
                // printCubeNums();
            }

        }

        // Solve top middle col only used for odd dimensional cubes
        public void solveTopMiddleColPos(int row)
        {
            if (row == dimension / 2 || dimension % 2 == 0)
            {
                cubePieces[faces[getPosition(2, dimension / 2, dimension / 2)]].inPlace = true;
                return;
            }

            int color = getColor(2);

            // These are the locations of all the possible cubes we could use (locations!
            // not actual cubes!)
            List<int> possibleIndexes = findAvaliableCenterPieces(row, dimension / 2, color);

            // All of them are in place, then just return, we don't need to do anything
            if (possibleIndexes.Count == 0)
            {
                return;
            }

            int desiredCubie = faces[possibleIndexes[0]];

            // origionally I just picked the first, but on rare cases, everytime you
            // transfer a cube from face 2 to face 5,
            // a new cube is transfered to face 2, so it would cause infinite recursive
            // loops (pretty rare, but it happens)
            // so now, just pick the first one that isn't on face 2
            if (getFaceOrientation(desiredCubie) == 2)
            {
                for (int i = 0; i < possibleIndexes.Count; i++)
                {
                    if (getFaceOrientation(faces[possibleIndexes[i]]) != 2)
                    {
                        desiredCubie = faces[possibleIndexes[i]];
                        break;
                    }
                }
            }

            // which face is the cubie on
            int faceDesiredCubie = getFaceOrientation(desiredCubie);

            // used in the if statements
            int rowDesiredCubie = getRow(desiredCubie);
            int colDesiredCubie = getCol(desiredCubie);

            // desired cubie is on the back face
            if (faceDesiredCubie == 0)
            {
                rotateLayer(-1, 0, true);

                // we will be rotating the back face until the desired cubie and the cubie slot
                // match
                bool backInPlace = rowDesiredCubie == dimension / 2 && colDesiredCubie == row;
                while (!backInPlace)
                {
                    // rotate the back face clockwise
                    rotateFrontFace(1, 0, true);

                    // Is the cubie in the correct spot to move on?
                    rowDesiredCubie = getRow(desiredCubie);
                    colDesiredCubie = getCol(desiredCubie);
                    backInPlace = rowDesiredCubie == dimension / 2 && colDesiredCubie == row;
                }

                // cubie's col now equals row, so rotate row index of side
                rotateSide(-1, row, true);

                // put things back to where they started
                rotateLayer(1, 0, true);
                rotateSide(1, row, true);
                return;

            }

            // desired cubie is on the left face
            else if (faceDesiredCubie == 1)
            {
                // Ask if the cubie is in the right spot to move on (row == row col == col)
                bool backInPlace = rowDesiredCubie == row && colDesiredCubie == dimension / 2;
                while (!backInPlace)
                {
                    rotateSide(1, 0, true);

                    // Is the cubie in the correct spot to move on?
                    rowDesiredCubie = getRow(desiredCubie);
                    colDesiredCubie = getCol(desiredCubie);
                    backInPlace = rowDesiredCubie == row && colDesiredCubie == dimension / 2;

                }
                rotateFrontFace(1, row, true);

                // return everything back to normal
                rotateLayer(1, 0, true);
                rotateFrontFace(-1, row, true);
                rotateLayer(-1, 0, true);
                return;
            }

            // desiredCubie is on top face, will move to front face because front face is
            // always temporary storage
            else if (faceDesiredCubie == 2)
            {

                // if cubie is on the col that can be solved (too complicated to just keep it
                // there, so we will move it to the front face)
                if (colDesiredCubie == dimension / 2)
                {

                    colDesiredCubie = getCol(desiredCubie);
                    rotateLayer(-1, 0, true);

                    rotateSide(-1, colDesiredCubie, true);

                    rowDesiredCubie = getRow(desiredCubie);
                    colDesiredCubie = getCol(desiredCubie);

                    rotateFrontFace(1, dimension - 1, true);

                    rotateSide(1, colDesiredCubie, true);
                    rotateLayer(1, 0, true);

                    solveTopMiddleColPos(row);

                    return;

                }
                else
                {
                    rotateSide(-1, colDesiredCubie, true);
                    rowDesiredCubie = getRow(desiredCubie);
                    colDesiredCubie = getCol(desiredCubie);
                    bool quadrant = (rowDesiredCubie < dimension / 2 && colDesiredCubie < dimension / 2)
                            || (rowDesiredCubie >= dimension / 2 && colDesiredCubie >= dimension / 2);
                    if (quadrant)
                    {
                        rotateFrontFace(1, dimension - 1, true);
                    }
                    else
                    {
                        rotateFrontFace(-1, dimension - 1, true);
                    }
                    rotateSide(1, colDesiredCubie, true);

                    solveTopMiddleColPos(row);
                    return;

                    // Problem before: entire row moved to right face and we rotated the right face
                    // and messed shit up
                }
            }

            // desired cubie is on the right face (same as part two of front face (*above))
            else if (faceDesiredCubie == 3)
            {
                bool backInPlace = rowDesiredCubie == row && colDesiredCubie == dimension / 2;
                while (!backInPlace)
                {
                    rotateSide(1, dimension - 1, true);

                    // Is the cubie in the correct spot to move on?
                    rowDesiredCubie = getRow(desiredCubie);
                    colDesiredCubie = getCol(desiredCubie);
                    backInPlace = rowDesiredCubie == row && colDesiredCubie == dimension / 2;

                }

                rotateFrontFace(-1, row, true);

                // return everything back to normal
                rotateLayer(1, 0, true);
                rotateFrontFace(1, row, true);
                rotateLayer(-1, 0, true);
                return;

            }

            // desired cubie is on the bottom face (OH NO) do the same thing as back, but
            // rotate two times
            else if (faceDesiredCubie == 4)
            {
                rotateLayer(-1, 0, true);

                // we will be rotating the back face until the desired cubie and the cubie slot
                // match
                bool backInPlace = rowDesiredCubie == dimension / 2 && colDesiredCubie == dimension - 1 - row;
                while (!backInPlace)
                {
                    // rotate the bottom face clockwise
                    rotateLayer(1, dimension - 1, true);

                    // Is the cubie in the correct spot to move on?
                    rowDesiredCubie = getRow(desiredCubie);
                    colDesiredCubie = getCol(desiredCubie);
                    backInPlace = rowDesiredCubie == dimension / 2 && colDesiredCubie == dimension - 1 - row;
                }

                // cubie's col now equals row, so rotate row index of side
                rotateSide(-1, row, true);
                rotateSide(-1, row, true);

                // put things back to where they started
                rotateLayer(1, 0, true);
                rotateSide(1, row, true);
                rotateSide(1, row, true);
                return;

            }

            // cube is on front face
            else if (faceDesiredCubie == 5)
            {
                rotateLayer(-1, 0, true);

                // we will be rotating the back face until the desired cubie and the cubie slot
                // match
                bool backInPlace = rowDesiredCubie == dimension / 2 && colDesiredCubie == row;
                while (!backInPlace)
                {
                    // rotate the front face clockwise
                    rotateFrontFace(1, dimension - 1, true);

                    // Is the cubie in the correct spot to move on?
                    rowDesiredCubie = getRow(desiredCubie);
                    colDesiredCubie = getCol(desiredCubie);
                    backInPlace = rowDesiredCubie == dimension / 2 && colDesiredCubie == row;
                }

                // cubie's col now equals row, so rotate row index of side
                rotateSide(1, row, true);

                // put things back to where they started
                rotateLayer(1, 0, true);
                rotateSide(-1, row, true);
                return;

            }

        }

        public void solveTopMiddleCol()
        {
            if (dimension % 2 == 0)
                return;
            for (int i = 1; i < dimension - 1; i++)
            {
                solveTopMiddleColPos(i);
                cubePieces[faces[getPosition(2, i, dimension / 2)]].inPlace = true;

            }
        }

        // desiredCubie is the value of the cubie we want in position desiredRow,
        // desiredCol on the front face (face 2)
        // wherever cubie is, moves it to a spot so that all we need to do is rotate
        // desired face and then insert the cubie in the right place.
        public void alignCubies(int desiredCubie, int desiredRow, int desiredCol)
        {
            int face = getFaceOrientation(desiredCubie);

            int row = getRow(desiredCubie);
            int col = getCol(desiredCubie);
            bool inPlace;

            int cubieTemp = faces[getPosition(5, desiredRow, desiredCol)];

            // cubie is on the "middle layer"
            if (face == 0)
            {

                inPlace = dimension - 1 - row == desiredRow && dimension - 1 - col == desiredCol;

                // cubie will be slidden in horizontally so no need to change orientation of
                // frontface
                while (!inPlace)
                {
                    rotateFrontFace(1, 0, true);

                    row = getRow(desiredCubie);
                    col = getCol(desiredCubie);
                    inPlace = dimension - 1 - row == desiredRow && dimension - 1 - col == desiredCol;
                }
            }
            else if (face == 3)
            {
                inPlace = dimension - 1 - row == desiredCol && col == desiredRow;

                // cubie will be slidden in horizontally so no need to change orientation of
                // frontface
                while (!inPlace)
                {

                    rotateSide(1, dimension - 1, true);

                    row = getRow(desiredCubie);
                    col = getCol(desiredCubie);
                    inPlace = ((dimension - 1 - row) == desiredCol) && (col == desiredRow);
                }

            }

            else if (face == 1)
            {
                // move piece to the right face, then do this again and return
                rotateLayer(-1, dimension - 1 - col, true);
                rotateLayer(-1, dimension - 1 - col, true);

                row = getRow(desiredCubie);
                col = getCol(desiredCubie);

                bool quadrant = (row < dimension / 2 && col < dimension / 2)
                        || (row >= dimension / 2 && col >= dimension / 2);

                if (quadrant)
                {
                    rotateSide(1, dimension - 1, true);
                }
                else
                {
                    rotateSide(-1, dimension - 1, true);

                }

                // IMPORTANT col changed so now col equals the laayer we want to turn back to
                // place
                rotateLayer(-1, col, true);
                rotateLayer(-1, col, true);
                // now cubie is on the right face so do this again
                alignCubies(desiredCubie, desiredRow, desiredCol);
                return;
            }
            else if (face == 2)
            {
                // all edges are free because we haven't solved the top and bottom face yet and
                // we solve sides after top and bottom
                // but assume the bottom is solved
                // so move the piece to the right face then do this again

                // do a quick check to see which side is solved, bottom or right
                // if back is bottom is solved, we can move cubie to the right face
                // if bottom is not slolved we can move cubie to the bottom face

                // so if the bottom is solved, every front and center piece has an inplace value
                // of true

                // if bottom is solved then we can sotore the cubie on the right face

                rotateLayer(1, 0, true);

                // col becomes row so rotate col
                rotateFrontFace(1, col, true);

                row = getRow(desiredCubie);
                col = getCol(desiredCubie);

                bool quadrant = (row < dimension / 2 && col < dimension / 2)
                        || (row >= dimension / 2 && col >= dimension / 2);

                if (quadrant)
                {
                    rotateSide(-1, dimension - 1, true);
                }
                else
                {
                    rotateSide(1, dimension - 1, true);
                }

                rotateFrontFace(-1, row, true);
                rotateLayer(-1, 0, true);

                alignCubies(desiredCubie, desiredRow, desiredCol);

                return;

            }
            else if (face == 4)
            {

                // to insert cubie into face, col we're solving for on front face must be
                // horizontal
                rotateFrontFace(1, dimension - 1, true);
                // THIS IS REVERED IN insertcubie

                desiredCol = getCol(cubieTemp);
                desiredRow = getRow(cubieTemp);
                // if we're find it at the bottom, then we are on the first step so just align
                // the row to equal row, only difference is bottom is mirror image
                inPlace = dimension - 1 - row == desiredRow && dimension - 1 - col == desiredCol;

                // cubie will be slidden in horizontally so no need to change orientation of
                // frontface
                while (!inPlace)
                {
                    rotateLayer(1, dimension - 1, true);

                    row = getRow(desiredCubie);
                    col = getCol(desiredCubie);
                    inPlace = dimension - 1 - row == desiredRow && dimension - 1 - col == desiredCol;
                }

            }
            else if (face == 5)
            {
                // f its on the front, its on our col face, so move it to the right face an then
                // do this again.
                // move piece to the right face, then do this again and return

                // FIX THIS, CAUSES SOME BUGS

                if (col == desiredCol)
                {
                    rotateLayer(-1, row, true);

                    row = getRow(desiredCubie);
                    col = getCol(desiredCubie);

                    bool quadrant = (row < dimension / 2 && col < dimension / 2)
                            || (row >= dimension / 2 && col >= dimension / 2);

                    if (quadrant)
                    {
                        rotateSide(1, dimension - 1, true);
                    }
                    else
                    {
                        rotateSide(-1, dimension - 1, true);

                    }

                    // IMPORTANT col changed so now col equals the laayer we want to turn back to
                    // place
                    rotateLayer(1, col, true);
                    // now cubie is on the right face so do this again
                    alignCubies(desiredCubie, desiredRow, desiredCol);
                    return;
                }
                else
                {
                    rotateFrontFace(1, dimension - 1, true);
                    rotateLayer(-1, col, true);

                    row = getRow(desiredCubie);
                    col = getCol(desiredCubie);

                    bool quadrant = (row < dimension / 2 && col < dimension / 2)
                            || (row >= dimension / 2 && col >= dimension / 2);

                    if (quadrant)
                    {
                        rotateSide(1, dimension - 1, true);
                    }
                    else
                    {
                        rotateSide(-1, dimension - 1, true);
                    }

                    // IMPORTANT col changed so now col equals the laayer we want to turn back to
                    // place
                    rotateLayer(1, col, true);
                    // now cubie is on the right face so do this again
                    rotateFrontFace(-1, dimension - 1, true);
                    alignCubies(desiredCubie, desiredRow, desiredCol);
                    return;
                }
            }

        }

        // align cubie has already been done, so desiredCubie row just needs to be
        // turned
        // also cubie is on face 0 3 or 4
        public void insertCubie(int desiredCubie)
        {
            int face = getFaceOrientation(desiredCubie);
            int row = getRow(desiredCubie);
            int col = getCol(desiredCubie);
            if (face == 0)
            {
                rotateLayer(1, dimension - 1 - row, true);
                rotateLayer(1, dimension - 1 - row, true);

                row = getRow(desiredCubie);
                col = getCol(desiredCubie);

                bool quadrant = (row < dimension / 2 && col < dimension / 2)
                        || (row >= dimension / 2 && col >= dimension / 2);

                int direction;

                if (quadrant)
                {
                    direction = -1;
                }
                else
                {
                    direction = 1;
                }

                rotateFrontFace(direction, dimension - 1, true);
                rotateLayer(1, row, true);
                rotateLayer(1, row, true);
                rotateFrontFace(-direction, dimension - 1, true);

            }
            else if (face == 3)
            {
                rotateLayer(1, col, true);
                row = getRow(desiredCubie);
                col = getCol(desiredCubie);

                bool quadrant = (row < dimension / 2 && col < dimension / 2)
                        || (row >= dimension / 2 && col >= dimension / 2);

                int direction;

                if (quadrant)
                {
                    direction = -1;
                }
                else
                {
                    direction = 1;
                }

                rotateFrontFace(direction, dimension - 1, true);
                rotateLayer(-1, row, true);
                rotateFrontFace(-direction, dimension - 1, true);
            }
            else if (face == 4)
            {

                rotateSide(1, dimension - 1 - col, true);

                row = getRow(desiredCubie);
                col = getCol(desiredCubie);

                bool quadrant = (row < dimension / 2 && col < dimension / 2)
                        || (row >= dimension / 2 && col >= dimension / 2);

                if (quadrant)
                {
                    rotateFrontFace(1, dimension - 1, true);
                    rotateSide(-1, col, true);
                    rotateFrontFace(-1, dimension - 1, true);
                    rotateFrontFace(-1, dimension - 1, true);
                }
                else
                {
                    rotateFrontFace(-1, dimension - 1, true);
                    rotateSide(-1, col, true);
                }
                // remember front face is in the wrong orientation so MAKE IT RIGHT

            }

        }

        // moves the correct colored cubie to the position row col on the front face
        // assuming we are making a col of cubies
        public void solveCubieFrontFaceRowCol(int row, int col, int color)
        {
            if (row < 1 || row > dimension - 2 || col < 1 || col > dimension - 2)
            {
                // Debug.LogError("Error: tried to move an edge piece to the center. Line no "
                //        + Thread.currentThread().getStackTrace()[1].getLineNumber());
                return;
            }
            else if ((faces[getPosition(5, row, col)] / (dimension * dimension)) == color)
            {
                cubePieces[faces[getPosition(5, row, col)]].inPlace = true;
                return;
            }
            else if (dimension % 2 == 1 && col == dimension / 2)
            {
                // System.out.println("Error: you can't execute alignCubie on a center col piece line no "
                //        + Thread.currentThread().getStackTrace()[1].getLineNumber());
                return;
            }

            // find desired cubie
            List<int> possibleIndexes = findAvaliableCenterPieces(row, col, color);

            // findabaliablecenters only returns indexes when the cubies are not solved
            if (possibleIndexes.Count == 0)
            {
                return;
            }
            int desiredCubie = faces[possibleIndexes[0]];
            alignCubies(desiredCubie, row, col);
            insertCubie(desiredCubie);

            // Don't want to mess up what we've alreay done so mark this as true
            cubePieces[desiredCubie].inPlace = true;

        }

        public void solveColFrontFace(int col, int color)
        {
            for (int i = 1; i < dimension - 1; i++)
            {
                solveCubieFrontFaceRowCol(i, col, color);
            }
        }

        // inserts vertical col into place (correctly on the desiredFace, (orientation
        // of col depends on the face))
        // will only be inserting cols into the top face and the left face
        // col is always stored on the front face

        public void insertColFrontFace(int col, int desiredFace)
        {
            if (desiredFace == 2)
            {
                rotateLayer(1, 0, true);
                rotateLayer(1, 0, true);
                rotateSide(1, col, true);
                rotateLayer(1, 0, true);
                rotateLayer(1, 0, true);
                rotateSide(-1, col, true);
            }
            else if (desiredFace == 1)
            {
                rotateFrontFace(-1, dimension - 1, true);
                rotateSide(1, 0, true);
                rotateSide(1, 0, true);
                rotateLayer(1, dimension - 1 - col, true);
                rotateSide(1, 0, true);
                rotateSide(1, 0, true);
                rotateLayer(-1, dimension - 1 - col, true);
            }

        }

        public void solveFirstFourFronts()
        {
            orientCube(5, 2);
            int[] topOrder = { 2, 4, 2, 2 };
            int[] frontOrder = { 5, 5, 5, 3 };
            int[] colorSolveOrder = { 2, 4, 1, 5 };
            for (int i = 0; i < 4; i++)
            {
                orientCube(frontOrder[i], colorSolveOrder[i]);
                solveTopMiddleCol();
                orientCube(frontOrder[i], topOrder[i]);
                for (int j = 1; j < dimension - 1; j++)
                {
                    solveColFrontFace(j, colorSolveOrder[i]);
                    insertColFrontFace(i, getFaceOrientation(getCenterCubie(colorSolveOrder[i])));
                }
            }
        }


        // DEBUGGING
        /*
         * private ArrayList<Integer> printAllIndecesInPlace() {
         * 
         * ArrayList<Integer> cubepieces = new ArrayList<>();
         * 
         * for (CubePiece cube : cubePieces) { if (cube.inPlace) {
         * cubepieces.add(cube.cubeVal); } } return cubepieces; }
         */



        public void solveLeftFaceCenter(int color)
        {

            // solve the top front center
            rotateCubeCounterClockwise(true);
            rotateCubeUp(true);
            rotateCubeClockwise(true);

            solveTopMiddleCol();

            rotateCubeCounterClockwise(true);
            rotateCubeDown(true);
            rotateCubeClockwise(true);

            for (int i = 1; i < dimension / 2; i++)
            {

                solveColFrontFace(i, color);
                insertColFrontFace(i, 1);
            }

            for (int i = (dimension / 2) - 1; i > 0; i--)
            {

                solveColFrontFace(i, color);
                insertColFrontFace(i, 1);

            }
        }

        public void solveTopFaceCenter(int color)
        {

            solveTopMiddleCol();

            for (int i = 1; i < dimension / 2; i++)
            {

                solveColFrontFace(i, color);
                insertColFrontFace(i, 2);
            }

            for (int i = (dimension / 2) - 1; i > 0; i--)
            {

                solveColFrontFace(i, color);
                insertColFrontFace(i, 2);

            }

        }


        //uses a special algorithm to move center piece to desired face without disrupting any other faces
        //its a long algorithm so thats why I didn't use this for all faces (I could)
        public void solveLastCenterColPos(int row)
        {
            int color = getColor(2);
            int myBase = dimension * dimension;

            if (faces[getPosition(2, row, dimension / 2)] / myBase == color)
            {

                // maybe call cubiePlaces true, its not necessary but it would be consistant
                return;
            }
            else if (row >= dimension - 1 || row <= 0 || row == dimension / 2)
            {
                return;
            }

            int desiredCubie;

            if (faces[getPosition(5, row, dimension / 2)] / myBase == color)
            {
                desiredCubie = faces[getPosition(5, row, dimension / 2)];
            }
            else if (faces[getPosition(5, dimension / 2, row)] / myBase == color)
            {
                desiredCubie = faces[getPosition(5, dimension / 2, row)];
            }
            else if (faces[getPosition(5, dimension - 1 - row, dimension / 2)] / myBase == color)
            {
                desiredCubie = faces[getPosition(5, dimension - 1 - row, dimension / 2)];
            }
            else if (faces[getPosition(5, dimension / 2, dimension - 1 - row)] / myBase == color)
            {
                desiredCubie = faces[getPosition(5, dimension / 2, dimension - 1 - row)];
            }
            else
            {
                // not neccessary, will help debugging
                return;
            }

            int desiredCubieRow = getRow(desiredCubie);

            int desiredCubieCol = getCol(desiredCubie);

            rotateLayer(-1, 0, true);

            int col = row;
            row = dimension / 2;

            bool inPlace = desiredCubieCol == col && desiredCubieRow == row;
            int failsafe = 0;

            while (failsafe < 4 && !inPlace)
            {
                rotateFrontFace(1, dimension - 1, true);
                desiredCubieRow = getRow(desiredCubie);
                desiredCubieCol = getCol(desiredCubie);
                inPlace = desiredCubieCol == col && desiredCubieRow == row;
                failsafe++;
            }
            if (failsafe == 4)
            {
                Debug.LogError("Got stuck in loop line 816");
                return;
            }
            // cubies are now lined up so insert cubie
            rotateSide(1, desiredCubieCol, true);
            rotateLayer(1, 0, true);
            rotateSide(-1, desiredCubieCol, true);
        }

        public void solveLastCenterCol()
        {
            for (int i = 1; i < dimension - 1; i++)
            {
                solveLastCenterColPos(i);
                cubePieces[faces[getPosition(2, i, dimension / 2)]].inPlace = true;
            }
        }

        public void alignTopCubieWithFrontCubie(int desiredRow, int desiredCol)
        {

            int myBase = dimension * dimension;

            int desiredCubiePos = faces[getPosition(5, desiredRow, desiredCol)];
            // place we want to insert the cubie
            // last two colors will be 1 and 3

            int colorTop = desiredCubiePos / myBase;

            int colorFront;
            if (colorTop == 0)
            {
                colorFront = 3;
            }
            else
            {
                colorFront = 0;
            }

            List<int> possibleIndexes = new List<int>();

            possibleIndexes = findAvaliableCenterPieces(desiredRow, desiredCol, colorFront);

            int desiredCubie = -1;

            foreach (int n in possibleIndexes)
            {
                if (getFaceOrientation(faces[n]) == 2)
                {
                    desiredCubie = faces[n];
                    break;
                }

            }

            bool inPlace = getRow(desiredCubie) == desiredRow && getCol(desiredCubie) == desiredCol;

            int failsafe = 0;

            while (failsafe < 4 && !inPlace)
            {
                rotateLayer(1, 0, true);
                inPlace = getRow(desiredCubie) == desiredRow && getCol(desiredCubie) == desiredCol;
                failsafe++;
            }

            if (failsafe == 5)
            {
                Debug.LogError("Stuck in loop 884");
            }

        }

        public void switchTopCubieWithFrontCubie(int row, int col)
        {
            // assuming cubies are already aligned
            // if edge cubies, assuming they are on the sides and not on top or bottom

            // this is the cubie that wants to be on the front face but is not
            int desiredCubie = faces[getPosition(2, row, col)];

            rotateSide(-1, col, true);

            int rowDesiredCubie = getRow(desiredCubie);
            int colDesiredCubie = getCol(desiredCubie);

            bool quadrant = (rowDesiredCubie < dimension / 2 && colDesiredCubie < dimension / 2)
                    || (rowDesiredCubie >= dimension / 2 && colDesiredCubie >= dimension / 2);

            int direction;

            if (quadrant)
            {
                direction = 1;
            }
            else
            {
                direction = -1;
            }

            rotateFrontFace(direction, dimension - 1, true);

            colDesiredCubie = getCol(desiredCubie);

            rotateSide(-1, colDesiredCubie, true);

            rotateFrontFace(-direction, dimension - 1, true);

            rotateSide(1, col, true);

            rotateFrontFace(direction, dimension - 1, true);

            rotateSide(1, colDesiredCubie, true);

            rotateFrontFace(-direction, dimension - 1, true);

        }

        public void solveLastTwoFaces(int colorFront, int colorTop)
        {

            int myBase = dimension * dimension;
            int tempCubie;

            for (int i = 1; i < dimension - 1; i++)
            {
                for (int x = 1; x < dimension - 1; x++)
                {
                    tempCubie = faces[getPosition(5, i, x)];
                    if (tempCubie / myBase != colorFront)
                    {
                        alignTopCubieWithFrontCubie(i, x);
                        switchTopCubieWithFrontCubie(i, x);
                    }
                    cubePieces[tempCubie].inPlace = true;
                }
            }
        }

        //puts everything together from above
        public void solveCenters()
        {
            orientCube(5, 2);
            // System.out.println("oriented 5 front 2 top");
            // printCube();
            solveTopFaceCenter(2);
            // System.out.println("2 center col solved");
            // printCube();
            rotateCubeUp(true);
            rotateCubeUp(true);
            // System.out.println("oriented for bottom face");
            // printCube();
            solveTopFaceCenter(4);
            // System.out.println("first two faces are solved");
            // printCube();
            rotateCubeUp(true);
            rotateCubeUp(true);
            solveLeftFaceCenter(1);
            // System.out.println("left face is solved");
            // printCube();
            rotateCubeClockwise(true);
            solveLeftFaceCenter(5);
            // System.out.println("first 4 faces solved");
            // printCube();
            rotateCubeUp(true);
            rotateCubeClockwise(true);
            // System.out.println("oriented for last step");
            // solveLastCenterCol();
            // printCube();
            solveLastTwoFaces(0, 3);
            // System.out.println("all faces solved");
            // printCube();
            bool solved = checkCenters();
            if (!solved)
            {
                // really lazy coding but I want this project fucking done
                // so the deal is, about 1 in 100 center solves just dont work so I'm just
                // starting over and solving again
                // really really lazy I know but I cant find why this is so I'm just giving up
                // and redoing it
                scrambleNxN(10);
                solveCenters();
                return;
            }
        }



        /**
         * Edge solver methods
         * solves all 10 edges then does parity and swapping algorithms to solve last two edges
         * 
         * general method moves an unsolved piece to the left front edge (this is the piece we're solving for)
         * it solves for whatever color is on top
         * It then moves an unsolved piece to the top left edge, which is used once we insert a cubie into place, we replace
         * front left with top left temporarily so that the only edge we break is an unsolved one
         * moves desired insertion piece to front right edge
         */

        //only moves an unsolved edge piece (no inserting or anything)
        // we don't have to worry about dirupting any edge pieces on this step
        public void moveUnsolvedEdgePieceToLeftFrontEdge()
        {

            // we are solving the left edge from top to bottom, so if any of them are
            // unsolved at this step, we can just keep the left edge where it is if it is
            // unsolved already

            if (!cubePieces[faces[getPosition(5, 1, 0)]].inPlace)
            {
                return;
            }

            List<EdgeCubie> cubies = findUnsolvedEdgePieces();

            // at this point, we aren't halfway solving an edge, so any unsolved edge pieces
            // means the entire edge is unsolved

            if (cubies.Count == 0)
            {
                // don't know why this would happen, but it means that all the edges are solved,
                // pretty nice
                return;
            }

            // we already checked if edge front / left is unsolved, if it is solved, then
            // there are no cubies in cubies that are contained on face front / left. if it
            // is not, we already returned
            EdgeCubie desiredCubie = cubies[0];

            orientCubeFrontLeft(getFaceOrientation(desiredCubie.index1), getFaceOrientation(desiredCubie.index2));

        }

        // moves an unsolved piece without disrupting the front left or right edges to top left edge (for replacing desired solved edge)
        public void moveUnsolvedEdgePiecetoTopLeftEdge()
        {

            if (!cubePieces[faces[getPosition(2, 1, 0)]].inPlace)
            {
                return;
            }

            List<EdgeCubie> cubies = findUnsolvedEdgePieces();

            // at this point, we aren't halfway solving an edge, so any unsolved edge pieces
            // means the entire edge is unsolved

            if (cubies.Count == 0)
            {
                // don't know why this would happen, but it means that all the edges are solved,
                // pretty nice
                return;
            }

            int failsafe = 0;
            EdgeCubie desiredCubie = null;

            while (failsafe < cubies.Count)
            {
                int cubie1Face = getFaceOrientation(cubies[failsafe].index1);
                int cubie2Face = getFaceOrientation(cubies[failsafe].index2);
                if ((cubie1Face == 5 && (cubie2Face == 1 || cubie2Face == 3))
                        || (cubie2Face == 5 && (cubie1Face == 1 || cubie1Face == 3)))
                {
                    failsafe++;
                }
                else
                {
                    desiredCubie = cubies[failsafe];
                    break;
                }

            }

            failsafe = 0;

            // we already checked if edge front / left is unsolved, if it is solved, then
            // there are no cubies in cubies that are contained on face front / left. if it
            // is not, we already returned

            int face1 = getFaceOrientation(desiredCubie.index1);
            int face2 = getFaceOrientation(desiredCubie.index2);
            bool top;

            if (face1 == 2 || face2 == 2)
            {
                top = (face1 == 2 && face2 == 1) || (face1 == 1 && face2 == 2);
                while (failsafe < 4 && !top)
                {
                    rotateLayer(1, 0, true);
                    face1 = getFaceOrientation(desiredCubie.index1);
                    face2 = getFaceOrientation(desiredCubie.index2);

                    top = (face1 == 2 && face2 == 1) || (face1 == 1 && face2 == 2);
                    failsafe++;
                }
                if (failsafe >= 4)
                {
                    Debug.LogError("Error in while loop in move unsolved edge piece to top left edge part one");
                }
                return;
            }
            else if (face1 == 4 || face2 == 4)
            {
                top = (face1 == 4 && face2 == 0) || (face1 == 0 && face2 == 4);
                while (failsafe < 4 && !top)
                {
                    rotateLayer(1, dimension - 1, true);
                    face1 = getFaceOrientation(desiredCubie.index1);
                    face2 = getFaceOrientation(desiredCubie.index2);
                    top = (face1 == 4 && face2 == 0) || (face1 == 0 && face2 == 4);
                    failsafe++;
                }
                rotateFrontFace(1, 0, true);
                rotateFrontFace(1, 0, true);
                rotateLayer(-1, 0, true);
                if (failsafe >= 4)
                {
                    Debug.LogError("Error in while loop in move unsolved edge piece to top left edge part two");
                }
                return;
            }
            else if (face1 == 1 || face2 == 1)
            {
                rotateFrontFace(1, 0, true);
                rotateLayer(-1, 0, true);
                return;
            }
            else if (face1 == 3 || face2 == 3)
            {
                rotateFrontFace(-1, 0, true);
                rotateLayer(-1, 0, true);
                return;
            }

        }

        // aligns an edge cubie to fit on the right edge so that the top is not
        // disturbed
        // we will be solving the edge piece based on which edge piece is on top
        // in this method, we only need to worry about dirupting the left edgepiece
        public void alignEdgeCubie(int row)
        {

            int myBase = dimension * dimension;

            // always judging color off of top left edge piece
            int colorFront = faces[getPosition(5, 1, 0)] / myBase;
            int colorLeft = faces[getPosition(1, dimension - 1, dimension - 2)] / myBase;

            if (row <= 0 || row >= dimension - 1)
            {
                return;
            }

            if (faces[getPosition(5, 1, 0)] / myBase == faces[getPosition(5, row, 0)] / myBase
                    && faces[getPosition(1, dimension - 1, dimension - 2)]
                            / myBase == faces[getPosition(1, dimension - 1, dimension - 1 - row)] / myBase)
            {
                return;
            }

            EdgeCubie desiredCubie = findAvailableEdgeCubiePositions(colorFront, colorLeft, row);

            int frontFaceCubie;
            int leftFaceCubie;

            // get the singular cubie face that should be in front
            if (desiredCubie.index1 / myBase == colorFront)
            {
                frontFaceCubie = desiredCubie.index1;
                leftFaceCubie = desiredCubie.index2;
            }
            else
            {
                frontFaceCubie = desiredCubie.index2;
                leftFaceCubie = desiredCubie.index1;
            }

            int faceFrontCubie = getFaceOrientation(frontFaceCubie);
            int faceLeftCubie = getFaceOrientation(leftFaceCubie);

            // if either one of the cubies are on the bottom face
            if (faceFrontCubie == 4 || faceLeftCubie == 4)
            {
                bool inPlace;
                if (faceFrontCubie == 4)
                {
                    inPlace = faceLeftCubie == 0;

                    while (!inPlace)
                    {
                        rotateLayer(1, dimension - 1, true);
                        faceLeftCubie = getFaceOrientation(leftFaceCubie);
                        inPlace = faceLeftCubie == 0;
                    }

                    rotateFrontFace(-1, 0, true);
                    rotateSide(1, dimension - 1, true);
                    rotateSide(1, dimension - 1, true);

                }
                else
                {
                    inPlace = faceFrontCubie == 3;
                    while (!inPlace)
                    {
                        rotateLayer(1, dimension - 1, true);
                        faceFrontCubie = getFaceOrientation(frontFaceCubie);
                        inPlace = faceFrontCubie == 3;
                    }

                    rotateSide(1, dimension - 1, true);
                }

            }
            // edge piece is located on the top layer
            else if (faceFrontCubie == 2 || faceLeftCubie == 2)
            {
                bool inPlace;
                if (faceFrontCubie == 2)
                {
                    inPlace = faceLeftCubie == 0;
                    while (!inPlace)
                    {
                        rotateLayer(1, 0, true);
                        faceLeftCubie = getFaceOrientation(leftFaceCubie);
                        inPlace = faceLeftCubie == 0;
                    }

                    rotateFrontFace(1, 0, true);
                    rotateSide(1, dimension - 1, true);
                    rotateSide(1, dimension - 1, true);

                }
                else
                {
                    inPlace = faceFrontCubie == 3;

                    while (!inPlace)
                    {
                        rotateLayer(1, 0, true);
                        faceFrontCubie = getFaceOrientation(frontFaceCubie);
                        inPlace = faceFrontCubie == 3;
                    }

                    rotateSide(-1, dimension - 1, true);
                }

            }
            // edge piece is located in the equator
            else
            {
                if (faceFrontCubie == 0 || faceLeftCubie == 0)
                {
                    rotateFrontFace(1, 0, true);
                    alignEdgeCubie(row);
                    return;
                }
                else
                {
                    if (faceFrontCubie == 1 || faceLeftCubie == 1)
                    {
                        // make sure there is an unsolved piece at the top left edge piece
                        int tempRow = getRow(leftFaceCubie);
                        moveUnsolvedEdgePiecetoTopLeftEdge();
                        rotateLayer(1, 0, true);
                        rotateLayer(1, 0, true);
                        rotateSide(-1, dimension - 1, true);
                        moveUnsolvedEdgePiecetoTopLeftEdge();
                        rotateLayer(-1, tempRow, true);
                        rotateSide(1, dimension - 1, true);
                        rotateLayer(1, 0, true);
                        rotateLayer(1, 0, true);
                        rotateSide(-1, dimension - 1, true);
                        rotateLayer(1, tempRow, true);
                        alignEdgeCubie(row);

                        return;
                    }
                    else if (faceFrontCubie == 3)
                    {
                        return;
                    }
                    else
                    {
                        rotateSide(1, dimension - 1, true);
                        rotateLayer(-1, 0, true);
                        rotateFrontFace(1, 0, true);
                        rotateSide(1, dimension - 1, true);
                        rotateSide(1, dimension - 1, true);
                    }
                }
            }

        }


        //inserts the edge cubie that is on the right front edge to the left front while only disturbing unsolved edges
        public void insertEdgeCubie(int row)
        {
            int myBase = dimension * dimension;

            if (faces[getPosition(5, 1, 0)] / myBase == faces[getPosition(5, row, 0)] / myBase
                    && faces[getPosition(1, dimension - 1, dimension - 2)]
                            / myBase == faces[getPosition(1, dimension - 1, dimension - 1 - row)] / myBase)
            {
                return;
            }

            rotateLayer(1, row, true);
            rotateFrontFace(1, dimension - 1, true);
            rotateLayer(-1, 0, true);
            rotateFrontFace(-1, dimension - 1, true);
            rotateLayer(-1, row, true);
            rotateLayer(1, 0, true);
            rotateFrontFace(-1, dimension - 1, true);
        }

        //solves entire left edge for the color on top
        public void solveLeftEdge()
        {
            moveUnsolvedEdgePieceToLeftFrontEdge();
            cubePieces[faces[getPosition(5, 1, 0)]].inPlace = true;
            cubePieces[faces[getPosition(1, dimension - 1, dimension - 2)]].inPlace = true;

            for (int i = 2; i < dimension - 1; i++)
            {
                alignEdgeCubie(i);
                moveUnsolvedEdgePiecetoTopLeftEdge();
                insertEdgeCubie(i);
                cubePieces[faces[getPosition(5, i, 0)]].inPlace = true;
                cubePieces[faces[getPosition(1, dimension - 1, dimension - 1 - i)]].inPlace = true;
            }
        }

        //solves first ten edges (no shit sherlock)
        public void solveFirstTenEdges()
        {
            for (int i = 0; i < 10; i++)
            {
                solveLeftEdge();
            }
            moveUnsolvedEdgePieceToLeftFrontEdge();
            orientCubeForLastStep();
            rotateCubeUp(true);
            rotateCubeClockwise(true);

        }

        //orients so that last two unsolved edge pieces are on top/front and top/back
        public void orientCubeForLastStep()
        {
            List<EdgeCubie> cubies = findUnsolvedEdgePieces();

            // unsolved should be found on the left front edge rn, so ignore that part
            int desiredCubie1 = 0;
            int desiredCubie2 = 0;

            for (int i = 0; i < cubies.Count; i++)
            {
                desiredCubie1 = cubies[i].index1;
                desiredCubie2 = cubies[i].index2;
                if (!((getFaceOrientation(desiredCubie1) == 5 && getFaceOrientation(desiredCubie2) == 1)
                        || (getFaceOrientation(desiredCubie1) == 1 && getFaceOrientation(desiredCubie2) == 5)))
                {
                    break;
                }
            }

            int face1 = getFaceOrientation(desiredCubie1);
            int face2 = getFaceOrientation(desiredCubie2);

            bool inPlace;
            if (face1 == 2 || face2 == 2)
            {
                inPlace = face1 == 3 || face2 == 3;
                while (!inPlace)
                {
                    rotateLayer(1, 0, true);
                    face1 = getFaceOrientation(desiredCubie1);
                    face2 = getFaceOrientation(desiredCubie2);
                    inPlace = face1 == 3 || face2 == 3;

                }
                rotateSide(-1, dimension - 1, true);
            }
            else if (face1 == 4 || face2 == 4)
            {
                inPlace = face1 == 3 || face2 == 3;
                while (!inPlace)
                {
                    rotateLayer(1, dimension - 1, true);
                    face1 = getFaceOrientation(desiredCubie1);
                    face2 = getFaceOrientation(desiredCubie2);
                    inPlace = face1 == 3 || face2 == 3;

                }
                rotateSide(1, dimension - 1, true);

            }
            else if (face1 == 3 || face2 == 3)
            {
                inPlace = face1 == 5 || face2 == 5;
                while (!inPlace)
                {
                    rotateSide(1, dimension - 1, true);
                    face1 = getFaceOrientation(desiredCubie1);
                    face2 = getFaceOrientation(desiredCubie2);
                    inPlace = face1 == 5 || face2 == 5;

                }
            }
            else
            {
                rotateFrontFace(1, 0, true);
                orientCubeForLastStep();
                return;
            }

        }

        // algorithm to swap cubies on top face
        public void swapCubiesTopFace(int i)
        {
            int index = dimension - 1 - i;
            rotateSide(1, index, true);
            rotateLayer(1, 0, true);
            rotateLayer(1, 0, true);
            rotateSide(1, index, true);
            rotateLayer(1, 0, true);
            rotateLayer(1, 0, true);
            rotateFrontFace(1, dimension - 1, true);
            rotateFrontFace(1, dimension - 1, true);
            rotateSide(1, index, true);
            rotateFrontFace(1, dimension - 1, true);
            rotateFrontFace(1, dimension - 1, true);
            rotateSide(1, dimension - 1 - index, true);
            rotateLayer(1, 0, true);
            rotateLayer(1, 0, true);
            rotateSide(-1, dimension - 1 - index, true);
            rotateLayer(1, 0, true);
            rotateLayer(1, 0, true);
            rotateSide(1, index, true);
            rotateSide(1, index, true);
        }

        // algorithm to flip parity edges (if edge is in wrong orientation compared to center / desired color)
        //note that parity can only affect mirror cubies, so this is done to only half the cube, when I flip col index,
        //col dimension - 1 - index is also changed
        public void flipEdges(int index)
        {
            rotateSide(1, dimension - 1 - index, true);
            rotateSide(1, dimension - 1 - index, true);
            rotateLayer(1, 0, true);
            rotateLayer(1, 0, true);
            rotateSide(1, dimension - 1 - index, true);
            rotateSide(1, dimension - 1 - index, true);
            rotateLayer(1, 0, true);
            rotateLayer(1, 0, true);
            rotateSide(1, dimension - 1 - index, true);
            rotateLayer(1, 0, true);
            rotateLayer(1, 0, true);
            rotateSide(1, dimension - 1 - index, true);
            rotateLayer(1, 0, true);
            rotateLayer(1, 0, true);
            rotateSide(-1, dimension - 1 - index, true);
            rotateLayer(1, 0, true);
            rotateLayer(1, 0, true);
            rotateFrontFace(1, 0, true);
            rotateFrontFace(1, 0, true);
            rotateLayer(-1, 0, true);
            rotateSide(-1, dimension - 1 - index, true);
            rotateLayer(1, 0, true);
            rotateFrontFace(1, 0, true);
            rotateFrontFace(1, 0, true);
            rotateLayer(-1, 0, true);
            rotateSide(1, dimension - 1 - index, true);
            rotateLayer(-1, 0, true);

        }

        // flips edge (only one edge) on the front / top face
        public void flipFrontTopEdge()
        {
            rotateLayer(1, 0, true);
            rotateSide(-1, 0, true);
            rotateLayer(-1, 0, true);
            rotateFrontFace(1, dimension - 1, true);
            rotateLayer(-1, 0, true);
            rotateFrontFace(-1, dimension - 1, true);
            rotateLayer(1, 0, true);
        }

        //puts above algorithms together to solve parity (for now)
        //even cubes have OLL and PLL parity that is solved in cube 3x3, but rn, we can't 
        //tell if OLL or PLL parity exists or not
        public void solveLastTwoEdges()
        {

            int myBase = dimension * dimension;
            int colorFront = 0;
            int colorFront_top = 0;
            int colorBack = 0;
            int colorBack_top = 0;
            int colorFrontTemp;
            int colorFront_topTemp;
            int colorBackTemp;
            int colorBack_topTemp;
            // assign colors, these are permanent and will be the desired orientation of the
            // cube in the end
            bool match;
            if (dimension % 2 == 1)
            {
                colorFront = faces[getPosition(5, 0, dimension / 2)] / myBase;
                colorFront_top = faces[getPosition(2, dimension - 1, dimension / 2)] / myBase;
                colorBack = faces[getPosition(0, dimension - 1, dimension / 2)] / myBase;
                colorBack_top = faces[getPosition(2, 0, dimension / 2)] / myBase;
            }
            else
            {
                colorFront = faces[getPosition(5, 0, 1)] / myBase;
                colorFront_top = faces[getPosition(2, dimension - 1, 1)] / myBase;
                for (int i = 1; i < dimension - 1; i++)
                {
                    colorBack = faces[getPosition(0, dimension - 1, i)] / myBase;
                    colorBack_top = faces[getPosition(2, 0, i)] / myBase;
                    // do they match?
                    match = (colorFront == colorBack && colorFront_top == colorBack_top)
                            || (colorFront == colorBack_top && colorFront_top == colorBack);
                    if (!match)
                    {
                        break;
                    }
                }
            }
            // firstly, we need to get all the edge cubies on the right side, then we'll
            // deal with parity
            for (int i = 1; i < dimension - 1; i++)
            {
                // check if the color is in the right spot
                colorFrontTemp = faces[getPosition(5, 0, i)] / myBase;
                colorFront_topTemp = faces[getPosition(2, dimension - 1, i)] / myBase;
                colorBackTemp = faces[getPosition(0, dimension - 1, i)] / myBase;
                colorBack_topTemp = faces[getPosition(2, 0, i)] / myBase;
                match = (colorFrontTemp == colorFront && colorFront_topTemp == colorFront_top)
                        || (colorFrontTemp == colorFront_top && colorFront_topTemp == colorFront);
                // if piece doesn't belong there, we need to swap it for a piece on the other
                // side
                if (!match)
                {
                    match = (colorBackTemp == colorBack && colorBack_topTemp == colorBack_top)
                            || (colorBackTemp == colorBack_top && colorBack_topTemp == colorBack);
                    if (match)
                    {
                        rotateCubeDown(true);
                        flipFrontTopEdge();
                        rotateCubeUp(true);
                    }
                    swapCubiesTopFace(i);

                }
            }

            colorFront = faces[getPosition(5, 0, dimension / 2)] / myBase;
            colorBack_top = faces[getPosition(2, 0, dimension / 2)] / myBase;

            for (int i = 1; i < dimension / 2; i++)
            {
                colorFrontTemp = faces[getPosition(5, 0, i)] / myBase;
                if (colorFrontTemp != colorFront)
                {
                    flipEdges(i);
                }
            }
            rotateCubeDown(true);
            for (int i = 1; i < dimension / 2; i++)
            {
                colorBack_topTemp = faces[getPosition(5, 0, i)] / myBase;
                if (colorBack_topTemp != colorBack_top)
                {
                    flipEdges(i);
                }
            }

        }


        // due to parity rules, there is only one edge cubie that will fit in a desired
        // row
        public bool edgeCubieChecker(EdgeCubie cubie, int row, int colorBack, int colorFront)
        {
            // colors match
            int myBase = dimension * dimension;
            bool colorsMatch = (colorBack == cubie.index1 / myBase && colorFront == cubie.index2 / myBase)
                    || (colorBack == cubie.index2 / myBase && colorFront == cubie.index1 / myBase);
            if (!colorsMatch)
            {
                return false;
            }

            int colorFrontFace;

            if (colorFront == cubie.index1 / myBase)
            {
                colorFrontFace = cubie.index1;
            }
            else
            {
                colorFrontFace = cubie.index2;
            }

            int desiredCubieRow = getRow(colorFrontFace);
            int desiredCubieCol = getCol(colorFrontFace);

            bool quad1 = desiredCubieCol == 0 && desiredCubieRow == row;
            bool quad2 = desiredCubieCol == dimension - 1 - row && desiredCubieRow == 0;

            bool quad3 = desiredCubieCol == row && dimension - 1 == desiredCubieRow;

            bool quad4 = desiredCubieCol == dimension - 1 && desiredCubieRow == dimension - 1 - row;
            return quad1 || quad2 || quad3 || quad4;

        }

        public EdgeCubie findAvailableEdgeCubiePositions(int colorFront, int colorBack, int row)
        {

            List<EdgeCubie> edgeCubies = getEdgeCubies();

            foreach (EdgeCubie cubie in edgeCubies)
            {
                if (edgeCubieChecker(cubie, row, colorBack, colorFront))
                {
                    return cubie;
                }
            }

            return null;
        }

        //HELPER METHODS FOR ABOVE

        // there always needs to be two open edges, one that we can use to replace and
        // one that we can use as the solving edge piece
        // takes the color on the top of the left edge as the left edge cubie



        /**
         * Final methods, solving the cube and overal checkers
         */

        public void reduceCubeto3x3()
        {
            if (reduced)
            {
                return;
            }
            algorithm.Clear();
            solveCenters();
            solveFirstTenEdges();
            solveLastTwoEdges();

            // will take this out
            bool cubeGood = edgeMatches();
            // has never happened yet, where edges don't solve, but there are a fuckload of
            // combos for a cube
            // I might have missed something (I've tested it 1000 times on repeat in debug
            // and it hasn't not solved, so if this is called, it is rediculously rare)
            if (!cubeGood)
            {
                scrambleNxN(10);
                //also clears the algorithm
                reduceCubeto3x3();
                return;
            }
            reduced = true;
        }

        //checks if centers are solved
        public bool checkCenters()
        {
            int myBase = dimension * dimension;
            for (int x = 0; x < 6; x++)
            {
                int color = faces[getPosition(x, 1, 1)] / myBase;
                for (int i = 1; i < dimension - 1; i++)
                {
                    for (int j = 1; j < dimension - 2; j++)
                    {
                        if (faces[getPosition(x, i, j)] / myBase != color)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        //checks if edges are solved
        public bool edgeMatches()
        {
            bool value = true;
            int myBase = dimension * dimension;
            for (int j = 0; j < 6; j++)
            {
                for (int i = 1; i < dimension - 2; i++)
                {
                    value = faces[getPosition(j, 0, i)] / myBase == faces[getPosition(j, 0, i + 1)] / myBase
                            && faces[getPosition(j, dimension - 1, i)]
                                    / myBase == faces[getPosition(j, dimension - 1, i + 1)] / myBase
                            && faces[getPosition(j, i, dimension - 1)]
                                    / myBase == faces[getPosition(j, i + 1, dimension - 1)] / myBase
                            && faces[getPosition(j, i, 0)] / myBase == faces[getPosition(j, i + 1, 0)] / myBase;
                    if (!value)
                    {
                        return value;
                    }
                }
            }

            return value;
        }

        public void scrambleNxN(int moves)
        {
            reduced = false;
            String[] possibleMoves = { "X+", "Y+", "Z+", "X-", "Y-", "Z-" };
            int randomLayer;
            int randomChooser;
            for (int i = 0; i < moves; i++)
            {
                randomLayer = Common.random.Next(dimension);// (int) (Math.random() * dimension);
                randomChooser = Common.random.Next(6);// (int) (Math.random() * 6);
                Move move = new Move(possibleMoves[randomChooser], randomLayer);
                moveSequenceNxN(move, false);
                scrambleAlgorithm.Add(move);
            }
            cubePieces = new List<CubePiece>();
            for (int i = 0; i < dimension * dimension * 6; i++)
            {
                cubePieces.Add(new CubePiece(i, false));
            }
        }



        //finds unsolved edge pieces (duh)
        public List<EdgeCubie> findUnsolvedEdgePieces()
        {
            List<EdgeCubie> result = new List<EdgeCubie>();
            foreach (EdgeCubie cubie in getEdgeCubies())
            {
                if (!cubePieces[cubie.index1].inPlace)
                {
                    result.Add(new EdgeCubie(cubie.index1, cubie.index2));
                }
            }
            return result;
        }

        private static void testnxn(int dimension)
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
            myCube.reduceCubeto3x3();

            endTime = Common.nanoTime();

            // get difference of two nanoTime values
            timeElapsed = endTime - startTime;
            Debug.Log("reduced cube");
            myCube.printCube();

            Debug.Log("Execution time of reduction in nanoseconds  : " + timeElapsed);

            Debug.Log("Execution time of reduction in milliseconds : " + timeElapsed / 1000000);

        }

    }
}