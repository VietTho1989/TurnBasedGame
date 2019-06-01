using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Rubiks
{
    public class Cube3x3 : Cube
    {
        // Does not solve 2x2

        public Cube3x3(int dimension) : base(dimension)
        {

        }

        public Cube3x3(Cubenxn cube) : base(cube)
        {

        }

        //scrambles cube like a 3x3 (only moves outside edges)
        private void scrambleCube3x3(int moves)
        {
            List<string> validMoves = new List<string>();
            {
                validMoves.Add("R");
                validMoves.Add("R'");
                validMoves.Add("L");
                validMoves.Add("L'");
                validMoves.Add("U");
                validMoves.Add("U'");
                validMoves.Add("D");
                validMoves.Add("D'");
                validMoves.Add("F");
                validMoves.Add("F'");
                validMoves.Add("B");
                validMoves.Add("B'");
                validMoves.Add("X");
                validMoves.Add("X'");
                validMoves.Add("Y");
                validMoves.Add("Y'");
            }
            List<string> scrambleAlgorithm = new List<string>();
            int randomInt;

            for (int i = 0; i < moves; i++)
            {
                randomInt = Common.random.Next(12);// (int) (Math.random() * 12);
                scrambleAlgorithm.Add(validMoves[randomInt]);
                moveSequence3x3(scrambleAlgorithm[scrambleAlgorithm.Count - 1]);
            }
        }

        /************************************************************************************
         * SOLVING METHODS
         * **********************************************************************************
         */

        /************************************************************************************
         * FIRST LAYER METHODS
         * **********************************************************************************
         */



        // Moves desired the edge piece that cooresponds to whatever color is on back
        // and top to right place without disrupting anything important
        private void solveTopBackEdgePiece()
        {
            int myBase = dimension * dimension;
            int topFaceColor = faces[getPosition(2, 1, 1)] / myBase;
            // Find what colors are surrounding
            // Assuming center is already solved
            int backFaceColor = faces[getPosition(0, 1, 1)] / myBase;

            List<EdgeCubie> edgeCubie = getEdgeCubie(topFaceColor, backFaceColor);

            // The magnitude of the certain edge cubie we are looking for
            int colorTopEdgeCubie;

            // a cubie has two indexes, test which one cooresponds to the color on the top
            // of the cube
            if (edgeCubie[0].index1 / myBase == topFaceColor)
            {
                colorTopEdgeCubie = edgeCubie[0].index1;
            }
            else
            {
                colorTopEdgeCubie = edgeCubie[0].index2;
            }
            int cubieBackTopFace = getFaceOrientation(colorTopEdgeCubie);
            // cubie is located on the back face
            // -------------------------------------------------------------
            if (cubieBackTopFace == 0)
            {
                // cubie is on bottom
                if (faces.IndexOf(colorTopEdgeCubie) < dimension)
                {
                    rotateFrontFace(1, 0, true);
                    rotateLayer(-1, 0, true);
                    rotateSide(-1, 0, true);
                    rotateLayer(1, 0, true);
                }
                // if cubie is on the "left" edge
                else if (faces.IndexOf(colorTopEdgeCubie) % dimension == 0)
                {
                    rotateLayer(-1, 0, true);
                    rotateSide(-1, 0, true);
                    rotateLayer(1, 0, true);
                }
                // if cubie is on the "right edge"
                else if ((faces.IndexOf(colorTopEdgeCubie) + 1) % dimension == 0)
                {
                    rotateFrontFace(1, 0, true);
                    rotateFrontFace(1, 0, true);
                    rotateLayer(-1, 0, true);
                    rotateSide(-1, 0, true);
                    rotateLayer(1, 0, true);
                }
                else
                {
                    rotateFrontFace(-1, 0, true);
                    rotateLayer(-1, 0, true);
                    rotateSide(-1, 0, true);
                    rotateLayer(1, 0, true);

                }
                // else, cubie is bordering top and middle
                // printCubeNums();

            }
            // Cubie is on left face
            // -------------------------------------------------------------------------
            else if (cubieBackTopFace == 1)
            {
                if (faces.IndexOf(colorTopEdgeCubie) < myBase + dimension)
                {
                    rotateFrontFace(1, 0, true);
                }
                // if cubie is on the "left" edge
                else if (faces.IndexOf(colorTopEdgeCubie) % dimension == 0)
                {
                    rotateSide(-1, 0, true);
                    rotateFrontFace(1, 0, true);
                    rotateSide(1, 0, true);
                }
                // if cubie is on the "right edge"
                else if ((faces.IndexOf(colorTopEdgeCubie) + 1) % dimension == 0)
                {
                    rotateSide(1, 0, true);
                    rotateFrontFace(1, 0, true);
                }
                else
                {
                    rotateSide(1, 0, true);
                    rotateSide(1, 0, true);
                    rotateFrontFace(1, 0, true);
                    rotateSide(1, 0, true);
                    rotateSide(1, 0, true);

                }
                // else, cubie is bordering top and middle
                // printCubeNums();
            }
            // Cubie is on front face
            // --------------------------------------------------------------------------
            else if (cubieBackTopFace == 5)
            {
                if (faces.IndexOf(colorTopEdgeCubie) < 5 * myBase + dimension)
                {
                    rotateLayer(1, 0, true);
                    rotateLayer(1, 0, true);
                    rotateFrontFace(1, 0, true);
                    rotateLayer(-1, 0, true);
                    rotateSide(-1, dimension - 1, true);
                    rotateLayer(-1, 0, true);

                }
                // if cubie is on the "left" edge
                else if (faces.IndexOf(colorTopEdgeCubie) % dimension == 0)
                {
                    rotateLayer(-1, 0, true);
                    rotateSide(1, 0, true);
                    rotateLayer(1, 0, true);
                }
                // if cubie is on the "right edge"
                else if ((faces.IndexOf(colorTopEdgeCubie) + 1) % dimension == 0)
                {
                    rotateLayer(1, 0, true);
                    rotateSide(1, dimension - 1, true);
                    rotateLayer(-1, 0, true);
                }
                else
                {
                    rotateFrontFace(-1, dimension - 1, true);
                    rotateLayer(1, 0, true);
                    rotateSide(1, dimension - 1, true);
                    rotateLayer(-1, 0, true);
                    rotateFrontFace(1, dimension - 1, true);

                }
                // printCubeNums();
            }
            // Cubie is on right face
            // --------------------------------------------------------------------------
            else if (cubieBackTopFace == 3)
            {
                if (faces.IndexOf(colorTopEdgeCubie) < 3 * myBase + dimension)
                {
                    rotateFrontFace(-1, 0, true);
                }
                // if cubie is on the "right" edge
                else if ((faces.IndexOf(colorTopEdgeCubie) + 1) % dimension == 0)
                {
                    rotateSide(-1, dimension - 1, true);
                    rotateFrontFace(-1, 0, true);
                    rotateSide(1, dimension - 1, true);
                }
                // if cubie is on the "left edge"
                else if (faces.IndexOf(colorTopEdgeCubie) % dimension == 0)
                {
                    rotateSide(1, dimension - 1, true);
                    rotateFrontFace(-1, 0, true);
                }
                else
                {
                    rotateLayer(-1, 0, true);
                    rotateLayer(-1, 0, true);
                    rotateFrontFace(-1, dimension - 1, true);
                    rotateLayer(-1, 0, true);
                    rotateLayer(-1, 0, true);
                }

                // printCubeNums();
            }
            // Cubie is on the desired face (top face)
            // ---------------------------------------------------------
            else if (cubieBackTopFace == 2)
            {
                // if cubie is on the "left" edge
                if (faces.IndexOf(colorTopEdgeCubie) % dimension == 0)
                {
                    rotateSide(1, 0, true);
                    rotateLayer(-1, 0, true);
                    rotateSide(-1, 0, true);
                    rotateLayer(1, 0, true);
                }
                // if cubie is on the "right edge"
                else if ((faces.IndexOf(colorTopEdgeCubie) + 1) % dimension == 0)
                {
                    rotateSide(1, dimension - 1, true);
                    rotateLayer(1, 0, true);
                    rotateSide(-1, dimension - 1, true);
                    rotateLayer(-1, 0, true);
                }
                else if (faces.IndexOf(colorTopEdgeCubie) < 3 * myBase
                      && faces.IndexOf(colorTopEdgeCubie) > myBase * 2 + dimension * (dimension - 1))
                {
                    rotateLayer(-1, 0, true);
                    rotateLayer(-1, 0, true);
                    rotateFrontFace(1, 0, true);
                    rotateLayer(1, 0, true);
                    rotateLayer(1, 0, true);
                    rotateFrontFace(-1, 0, true);
                }
                // printCubeNums();
            }
            // cubie is on bottom
            // ------------------------------------------------------------------------------
            else if (cubieBackTopFace == 4)
            {
                if (faces.IndexOf(colorTopEdgeCubie) < 4 * myBase + dimension)
                {
                    rotateFrontFace(1, 0, true);
                    rotateFrontFace(1, 0, true);
                }
                // if cubie is on the "left" edge
                else if ((faces.IndexOf(colorTopEdgeCubie) + 1) % dimension == 0)
                {
                    rotateLayer(1, dimension - 1, true);
                    rotateFrontFace(1, 0, true);
                    rotateFrontFace(1, 0, true);
                }
                // if cubie is on the "right edge"
                else if (faces.IndexOf(colorTopEdgeCubie) % dimension == 0)
                {
                    rotateLayer(-1, dimension - 1, true);
                    rotateFrontFace(1, 0, true);
                    rotateFrontFace(1, 0, true);
                }
                else
                {
                    rotateLayer(-1, dimension - 1, true);
                    rotateLayer(-1, dimension - 1, true);
                    rotateFrontFace(1, 0, true);
                    rotateFrontFace(1, 0, true);
                }
                // printCubeNums();
            }
        }

        // does solvetopbackedgepiece four times all while rotating cube everytime
        private void solveCross()
        {
            for (int i = 0; i < 4; i++)
            {
                solveTopBackEdgePiece();
                rotateCubeClockwise(true);
            }
        }

        // CORNERS

        // moves any corner piece to index 0,0,0 or 0,dim-1,0 then does the following
        // two methods to put it in place
        private void solveTopBackRightCornerPiece()
        {
            int myBase = dimension * dimension;
            int topFaceColor = faces[getPosition(2, 1, 1)] / myBase;
            // Find what colors are surrounding
            // Assuming center is already solved
            int backFaceColor = faces[getPosition(0, 1, 1)] / myBase;
            int rightFaceColor = faces[getPosition(3, 1, 1)] / myBase;

            CornerCubie cornerCubie = getCornerCubie(topFaceColor, backFaceColor, rightFaceColor);

            // The magnitude of the certain edge cubie we are looking for
            int colorTopCornerCubie;

            // a cubie has two indexes, test which one cooresponds to the color on the top
            // of the cube
            if (cornerCubie.index1 / myBase == topFaceColor)
            {
                colorTopCornerCubie = cornerCubie.index1;
            }
            else if (cornerCubie.index2 / myBase == topFaceColor)
            {
                colorTopCornerCubie = cornerCubie.index2;
            }
            else
            {
                colorTopCornerCubie = cornerCubie.index3;
            }

            int cubieBackTopFace = getFaceOrientation(colorTopCornerCubie);
            // cubie is located on the back face
            // -------------------------------------------------------------
            if (cubieBackTopFace == 0)
            {
                // Top left corner
                if (faces.IndexOf(colorTopCornerCubie) == cubieBackTopFace * myBase)
                {
                    backBottomLeftCornertoTopBackRightCorner();
                }
                // Top right corner
                else if (faces.IndexOf(colorTopCornerCubie) == cubieBackTopFace * myBase + (dimension - 1))
                {
                    backBottomRightCornertoTopBackRightCorner();
                }
                // bottom right corner
                else if (faces.IndexOf(colorTopCornerCubie) == cubieBackTopFace * myBase + (myBase - 1))
                {
                    // get piece to bottom left corner of back
                    rotateFrontFace(1, 0, true);
                    rotateLayer(1, dimension - 1, true);
                    rotateFrontFace(-1, 0, true);
                    rotateLayer(-1, dimension - 1, true);

                    // Now it is on the bottom right corner, but it is backwards, move it to left
                    // corner

                    // move piece to place
                    backBottomRightCornertoTopBackRightCorner();
                }

                // bottom left corner
                else
                {

                    // get piece to bottom right corner
                    rotateFrontFace(-1, 0, true);
                    rotateLayer(-1, dimension - 1, true);
                    rotateFrontFace(1, 0, true);
                    rotateLayer(1, dimension - 1, true);

                    // get piece to place
                    backBottomLeftCornertoTopBackRightCorner();
                }
                // else, cubie is bordering top and middle
                // printCubeNums();

            }
            // Cubie is on left face
            // -------------------------------------------------------------------------
            else if (cubieBackTopFace == 1)
            {
                // Top left corner
                if (faces.IndexOf(colorTopCornerCubie) == cubieBackTopFace * myBase)
                {
                    rotateLayer(1, dimension - 1, true);
                    backBottomRightCornertoTopBackRightCorner();
                }
                // Top right corner
                else if (faces.IndexOf(colorTopCornerCubie) == cubieBackTopFace * myBase + (dimension - 1))
                {
                    rotateSide(1, 0, true);
                    rotateLayer(1, dimension - 1, true);
                    rotateSide(-1, 0, true);
                    backBottomRightCornertoTopBackRightCorner();
                }
                // bottom right corner
                else if (faces.IndexOf(colorTopCornerCubie) == cubieBackTopFace * myBase + (myBase - 1))
                {
                    rotateSide(-1, 0, true);
                    rotateLayer(-1, dimension - 1, true);
                    rotateSide(1, 0, true);
                    rotateLayer(-1, dimension - 1, true);
                    rotateLayer(-1, dimension - 1, true);
                    backBottomLeftCornertoTopBackRightCorner();

                }

                // bottom left corner
                else
                {
                    rotateLayer(1, dimension - 1, true);
                    backBottomLeftCornertoTopBackRightCorner();

                }
                // else, cubie is bordering top and middle
                // printCubeNums();

            }
            // Cubie is on right face
            // --------------------------------------------------------------------------
            else if (cubieBackTopFace == 3)
            {
                if (faces.IndexOf(colorTopCornerCubie) == cubieBackTopFace * myBase)
                {
                    rotateSide(1, dimension - 1, true);
                    rotateLayer(-1, dimension - 1, true);
                    rotateSide(-1, dimension - 1, true);
                    backBottomLeftCornertoTopBackRightCorner();
                }
                // if cubie is on the "right" edge
                else if (faces.IndexOf(colorTopCornerCubie) == cubieBackTopFace * myBase + (dimension - 1))
                {
                    rotateLayer(-1, dimension - 1, true);
                    backBottomLeftCornertoTopBackRightCorner();
                }
                // if cubie is on the "left edge"
                else if (faces.IndexOf(colorTopCornerCubie) == cubieBackTopFace * myBase + (myBase - 1))
                {
                    rotateLayer(-1, dimension - 1, true);
                    backBottomRightCornertoTopBackRightCorner();
                }
                else
                {
                    rotateSide(-1, dimension - 1, true);
                    rotateLayer(1, dimension - 1, true);
                    rotateSide(1, dimension - 1, true);
                    rotateLayer(-1, dimension - 1, true);
                    rotateLayer(-1, dimension - 1, true);
                    backBottomRightCornertoTopBackRightCorner();

                }

                // printCubeNums();
            }
            // Cubie is on the desired face (top face)
            // ---------------------------------------------------------
            else if (cubieBackTopFace == 2)
            {
                if (faces.IndexOf(colorTopCornerCubie) == cubieBackTopFace * myBase)
                {
                    rotateSide(1, 0, true);
                    rotateLayer(1, dimension - 1, true);
                    rotateSide(-1, 0, true);
                    rotateLayer(-1, dimension - 1, true);
                    backBottomLeftCornertoTopBackRightCorner();
                }

                else if (faces.IndexOf(colorTopCornerCubie) == cubieBackTopFace * myBase + (myBase - 1))
                {
                    rotateSide(-1, dimension - 1, true);
                    rotateLayer(1, dimension - 1, true);
                    rotateSide(1, dimension - 1, true);
                    rotateLayer(1, dimension - 1, true);
                    backBottomLeftCornertoTopBackRightCorner();
                }

                else if (faces.IndexOf(colorTopCornerCubie) == cubieBackTopFace * (myBase)
                        + ((dimension) * (dimension - 1)))
                {
                    rotateSide(-1, 0, true);
                    rotateLayer(-1, dimension - 1, true);
                    rotateSide(1, 0, true);
                    rotateLayer(-1, dimension - 1, true);
                    backBottomRightCornertoTopBackRightCorner();

                }

                // printCubeNums();
            }
            else if (cubieBackTopFace == 5)
            {
                // Top left corner
                if (faces.IndexOf(colorTopCornerCubie) == cubieBackTopFace * myBase)
                {

                    rotateFrontFace(-1, dimension - 1, true);
                    rotateLayer(1, dimension - 1, true);
                    rotateFrontFace(1, dimension - 1, true);
                    rotateLayer(1, dimension - 1, true);
                    backBottomRightCornertoTopBackRightCorner();
                }
                // Top right corner
                else if (faces.IndexOf(colorTopCornerCubie) == cubieBackTopFace * myBase + (dimension - 1))
                {
                    rotateFrontFace(1, dimension - 1, true);
                    rotateLayer(-1, dimension - 1, true);
                    rotateFrontFace(-1, dimension - 1, true);
                    rotateLayer(-1, dimension - 1, true);
                    backBottomLeftCornertoTopBackRightCorner();

                }
                // bottom right corner
                else if (faces.IndexOf(colorTopCornerCubie) == cubieBackTopFace * myBase + (myBase - 1))
                {
                    rotateLayer(-1, dimension - 1, true);
                    rotateLayer(-1, dimension - 1, true);
                    backBottomLeftCornertoTopBackRightCorner();
                }

                // bottom left corner
                else
                {
                    rotateLayer(-1, dimension - 1, true);
                    rotateLayer(-1, dimension - 1, true);
                    backBottomRightCornertoTopBackRightCorner();
                }
                // else, cubie is bordering top and middle
                // printCubeNums();

            }
            else if (cubieBackTopFace == 4)
            {
                // Top left corner
                if (faces.IndexOf(colorTopCornerCubie) == cubieBackTopFace * myBase)
                {
                    rotateFrontFace(1, 0, true);
                    rotateLayer(1, dimension - 1, true);
                    rotateLayer(1, dimension - 1, true);
                    rotateFrontFace(-1, 0, true);
                    rotateLayer(-1, dimension - 1, true);
                    backBottomRightCornertoTopBackRightCorner();
                }
                // Top right corner
                else if (faces.IndexOf(colorTopCornerCubie) == cubieBackTopFace * myBase + (dimension - 1))
                {
                    rotateLayer(1, dimension - 1, true);
                    rotateFrontFace(1, 0, true);
                    rotateLayer(1, dimension - 1, true);
                    rotateLayer(1, dimension - 1, true);
                    rotateFrontFace(-1, 0, true);
                    rotateLayer(-1, dimension - 1, true);
                    backBottomRightCornertoTopBackRightCorner();

                }
                // bottom right corner
                else if (faces.IndexOf(colorTopCornerCubie) == cubieBackTopFace * myBase + (myBase - 1))
                {
                    rotateLayer(-1, dimension - 1, true);
                    rotateLayer(-1, dimension - 1, true);
                    rotateFrontFace(1, 0, true);
                    rotateLayer(1, dimension - 1, true);
                    rotateLayer(1, dimension - 1, true);
                    rotateFrontFace(-1, 0, true);
                    rotateLayer(-1, dimension - 1, true);
                    backBottomRightCornertoTopBackRightCorner();
                }

                // bottom left corner
                else
                {

                    rotateLayer(-1, dimension - 1, true);
                    rotateFrontFace(1, 0, true);
                    rotateLayer(1, dimension - 1, true);
                    rotateLayer(1, dimension - 1, true);
                    rotateFrontFace(-1, 0, true);
                    rotateLayer(-1, dimension - 1, true);
                    backBottomRightCornertoTopBackRightCorner();

                }
                // else, cubie is bordering top and middle
                // printCubeNums();

            }
        }

        // FOLLOWING TWO ARE USED A LOT IN THE SOLVE CORNER METHOD
        // if you're looking at the cube foldout, moves
        // index 0,0,0 to 2,0,dim-1)
        private void backBottomLeftCornertoTopBackRightCorner()
        {
            rotateLayer(1, dimension - 1, true);
            rotateLayer(1, dimension - 1, true);
            rotateFrontFace(1, 0, true);
            rotateLayer(-1, dimension - 1, true);
            rotateFrontFace(-1, 0, true);
        }

        // if you're looking at the cube foldout, moves
        // index 0,dim-1,0 to 2,0,dim-1)
        private void backBottomRightCornertoTopBackRightCorner()
        {
            rotateLayer(-1, dimension - 1, true);
            rotateSide(1, dimension - 1, true);
            rotateLayer(1, dimension - 1, true);
            rotateSide(-2, dimension - 1, true);
        }

        // Repeates solvetopbackrightcornerpiece four times
        private void solveCorners()
        {
            for (int i = 0; i < 4; i++)
            {
                solveTopBackRightCornerPiece();
                rotateCubeClockwise(true);

            }
        }

        /************************************************************************************
         * SECOND LAYER METHODS
         * **********************************************************************************
         */

        // moves top/front edge piece to the right/left edge spot THIS CAN DO
        // EVERYTHING, YOU DON'T NEED MOVE TOP FRONT TO LEFT I'VE INCLUDED IT ANYWAYS
        private void moveTopFrontEdgePiecetoRight()
        {
            int myBase = dimension * dimension;
            int colorRight = faces[getPosition(3, 1, 1)] / myBase;
            int colorFront = faces[getPosition(5, 1, 1)] / myBase;
            List<EdgeCubie> cubie = getEdgeCubie(colorRight, colorFront);
            int faceFrontCubie;
            int faceFrontCubieNo;
            if (cubie[0].index1 / myBase == colorFront)
            {
                faceFrontCubie = getFaceOrientation(cubie[0].index1);
                faceFrontCubieNo = cubie[0].index1;
            }
            else
            {
                faceFrontCubie = getFaceOrientation(cubie[0].index2);
                faceFrontCubieNo = cubie[0].index2;
            }
            // Move it to its place

            // on back face somewhere
            if (faceFrontCubie == 0)
            {
                // if cubie is on the "left" edge
                if (faces.IndexOf(faceFrontCubieNo) % dimension == 0)
                {
                    // Get the edge piece out of there
                    rotateCubeCounterClockwise(true);
                    rotateCubeCounterClockwise(true);
                    rightEdgePieceLayerTwo();

                    // return to origional orientation
                    rotateCubeClockwise(true);
                    rotateCubeClockwise(true);

                    // Do this method (now that it's out of its edge spot)
                    moveTopFrontEdgePiecetoRight();
                }
                // if cubie is on the "right edge"
                else if ((faces.IndexOf(faceFrontCubieNo) + 1) % dimension == 0)
                {
                    // Get the edge piece out of there
                    rotateCubeCounterClockwise(true);
                    rotateCubeCounterClockwise(true);
                    leftEdgePieceLayerTwo();

                    // return to origional orientation
                    rotateCubeClockwise(true);
                    rotateCubeClockwise(true);

                    // Do this method (now that it's out of its edge spot)
                    moveTopFrontEdgePiecetoRight();
                }
                else
                {
                    rotateLayer(1, 0, true);
                    rotateLayer(1, 0, true);
                    rightEdgePieceLayerTwo();
                    // ENDS METHOD
                }
                // else, cubie is bordering top and middle
                // printCubeNums();
            }

            else if (faceFrontCubie == 1)
            {
                // if cubie is on the "left" edge
                if (faces.IndexOf(faceFrontCubieNo) < 1 * myBase + dimension)
                {
                    // Get the edge piece out of there
                    rotateCubeCounterClockwise(true);
                    leftEdgePieceLayerTwo();

                    // return to origional orientation
                    rotateCubeClockwise(true);

                    // Do this method (now that it's out of its edge spot)
                    moveTopFrontEdgePiecetoRight();

                }
                // if cubie is on the "right edge"
                else if ((faces.IndexOf(faceFrontCubieNo) + 1) % dimension == 0)
                {
                    rotateLayer(-1, 0, true);
                    rightEdgePieceLayerTwo();
                    // ENDS METHOD

                }
                else
                {
                    // Get the edge piece out of there
                    rotateCubeCounterClockwise(true);
                    rightEdgePieceLayerTwo();

                    // return to origional orientation
                    rotateCubeClockwise(true);

                    // Do this method (now that it's out of its edge spot)
                    moveTopFrontEdgePiecetoRight();
                }
                // else, cubie is bordering top and middle
                // printCubeNums();
            }

            else if (faceFrontCubie == 2)
            {
                // if cubie is on the "left" edge
                if (faces.IndexOf(faceFrontCubieNo) < 2 * myBase + dimension)
                {

                    // Only exception is when face is on top, then we have to use the right
                    // algorithm
                    rotateLayer(1, 0, true);
                    rotateCubeClockwise(true);
                    leftEdgePieceLayerTwo();
                    rotateCubeCounterClockwise(true);
                }
                // if cubie is on the "right edge"
                else if ((faces.IndexOf(faceFrontCubieNo) + 1) % dimension == 0)
                {
                    rotateCubeClockwise(true);
                    leftEdgePieceLayerTwo();
                    rotateCubeCounterClockwise(true);
                }
                else if (faces.IndexOf(faceFrontCubieNo) % dimension == 0)
                {
                    rotateLayer(-1, 0, true);
                    rotateLayer(-1, 0, true);
                    rotateCubeClockwise(true);
                    leftEdgePieceLayerTwo();
                    rotateCubeCounterClockwise(true);
                }

                else
                {
                    rotateLayer(-1, 0, true);
                    rotateCubeClockwise(true);
                    leftEdgePieceLayerTwo();
                    rotateCubeCounterClockwise(true);
                }
            }

            else if (faceFrontCubie == 3)
            {
                // if cubie is on the "left" edge
                if (faces.IndexOf(faceFrontCubieNo) < 3 * myBase + dimension)
                {
                    // Get the edge piece out of there
                    rotateCubeClockwise(true);
                    rightEdgePieceLayerTwo();

                    // return to origional orientation
                    rotateCubeCounterClockwise(true);

                    // Do this method (now that it's out of its edge spot)
                    moveTopFrontEdgePiecetoRight();
                }
                // if cubie is on the "right edge"
                else if (faces.IndexOf(faceFrontCubieNo) % dimension == 0)
                {
                    rotateLayer(1, 0, true);
                    rightEdgePieceLayerTwo();
                    // ENDS METHOD

                }
                else
                {
                    // Get the edge piece out of there
                    rotateCubeClockwise(true);
                    leftEdgePieceLayerTwo();

                    // return to origional orientation
                    rotateCubeCounterClockwise(true);

                    // Do this method (now that it's out of its edge spot)
                    moveTopFrontEdgePiecetoRight();
                }
                // else, cubie is bordering top and middle
                // printCubeNums();
            }

            else if (faceFrontCubie == 5)
            {
                // if cubie is on the "left" edge
                if (faces.IndexOf(faceFrontCubieNo) < 5 * myBase + dimension)
                {
                    rightEdgePieceLayerTwo();
                    // ENDS METHOD
                }
                // if cubie is on the "right edge"
                else if (faces.IndexOf(faceFrontCubieNo) % dimension == 0)
                {
                    leftEdgePieceLayerTwo();
                    moveTopFrontEdgePiecetoRight();
                }
            }

        }

        // does movetopfront... four times while rotating cube
        private void solveSecondLayer()
        {
            for (int i = 0; i < 4; i++)
            {
                moveTopFrontEdgePiecetoRight();
                rotateCubeClockwise(true);
            }
        }

        // Algorithm for top front to right front edge
        private void rightEdgePieceLayerTwo()
        {
            // U R U' R' U' F' U F
            rotateLayer(1, 0, true);
            rotateSide(1, dimension - 1, true);
            rotateLayer(-1, 0, true);
            rotateSide(-1, dimension - 1, true);
            rotateLayer(-1, 0, true);
            rotateFrontFace(-1, dimension - 1, true);
            rotateLayer(1, 0, true);
            rotateFrontFace(1, dimension - 1, true);
        }

        // Algorithm for top front to left front edge
        private void leftEdgePieceLayerTwo()
        {
            // U' L' U L U F U' F'
            rotateLayer(-1, 0, true);
            rotateSide(1, 0, true);
            rotateLayer(1, 0, true);
            rotateSide(-1, 0, true);
            rotateLayer(1, 0, true);
            rotateFrontFace(1, dimension - 1, true);
            rotateLayer(-1, 0, true);
            rotateFrontFace(-1, dimension - 1, true);
        }

        /************************************************************************************
         * THIRD LAYER METHODS
         * **********************************************************************************
         */

        // Step one
        // -----------------------------------------------------

        // Solves the cross on top (doesn't alighn edge pieces to right place though)
        private void solveThirdLayerCross()
        {
            // how many top level squares are here, if theres one, do
            // algorithmthirdlayercross in any orientation and then do this method again
            int myBase = dimension * dimension;

            // 10 01 dim - 1 dim - 2 dim - 2 dim -1
            int colorTopFace = faces[getPosition(2, 1, 1)] / myBase;
            int colorLeftEdge = faces[getPosition(2, 1, 0)] / myBase;
            int colorRightEdge = faces[getPosition(2, 1, dimension - 1)] / myBase;
            int colorBottomEdge = faces[getPosition(2, dimension - 1, 1)] / myBase;
            int colorTopEdge = faces[getPosition(2, 0, 1)] / myBase;

            int noTopLayerFaces = ((colorTopFace == colorLeftEdge) ? 1 : 0) + ((colorTopFace == colorRightEdge) ? 1 : 0)
                    + ((colorTopFace == colorBottomEdge) ? 1 : 0) + ((colorTopFace == colorTopEdge) ? 1 : 0);

            /*
             * if(dimension % 2 == 0 && noTopLayerFaces == 1){ parityOLL(); }
             */
            /*
            printCube();
            if (dimension % 2 == 0 && noTopLayerFaces == 1) {
                alogirthmThirdLayerCross();
                printCube();
                boolean inPlace = colorBottomEdge == colorTopFace;
                while (!inPlace) {
                    rotateCubeClockwise();
                    colorBottomEdge = faces.get(getPosition(2, dimension - 1, 1)) / base;
                    inPlace = colorBottomEdge == colorTopFace;
                }
                parityPLL();
                printCube();

            }
            */
            if (noTopLayerFaces == 0)
            {
                alogirthmThirdLayerCross();
                solveThirdLayerCross();
                return;
            }
            /*
            if (noTopLayerFaces == 1) {

                rotateCubeClockwise();
                printCube();
                alogirthmThirdLayerCross();
                printCube();
                return;
            }*/
            else if (noTopLayerFaces == 4)
            {
                return;
            }

            // For both l orientation and line, the bottom is not the same color while the
            // left piece is
            bool correctOrientation = (colorLeftEdge == colorTopFace) && (colorBottomEdge != colorTopFace);
            while (!correctOrientation)
            {
                rotateCubeClockwise(true);
                colorLeftEdge = faces[getPosition(2, 1, 0)] / myBase;
                colorRightEdge = faces[getPosition(2, 1, dimension - 1)] / myBase;
                colorBottomEdge = faces[getPosition(2, dimension - 1, 1)] / myBase;
                colorTopEdge = faces[getPosition(2, 0, 1)] / myBase;
                correctOrientation = (colorLeftEdge == colorTopFace) && (colorBottomEdge != colorTopFace);
            }

            int noRepetitions = 0;
            colorTopEdge = faces[getPosition(2, 0, 1)] / myBase;

            if (colorLeftEdge == colorRightEdge)
            {
                if (colorTopEdge == colorTopFace && dimension % 2 == 0)
                {
                    parityOLL();
                    return;
                }
                else
                {
                    noRepetitions = 1;
                }
            }
            else
            {
                noRepetitions = 2;
            }

            for (int i = 0; i < noRepetitions; i++)
            {
                alogirthmThirdLayerCross();
            }
        }

        // algorithm for the above
        private void alogirthmThirdLayerCross()
        {
            rotateFrontFace(1, dimension - 1, true);
            rotateSide(1, dimension - 1, true);
            rotateLayer(1, 0, true);
            rotateSide(-1, dimension - 1, true);
            rotateLayer(-1, 0, true);
            rotateFrontFace(-1, dimension - 1, true);
        }

        //Parity algorithms
        /**
         *For even cubes, there's no way of knowing whether an edge piece is fully solved (unlike odd dimension cubes)
         *sometimes (50% chance) we will unintentionally flip an edge piece when trying to solve it
         *for that we need an algorithm that will flip the edge piece again which is actually very long
         */
        public void parityOLL()
        {
            for (int i = 1; i < dimension / 2; i++)
            {
                rotateSide(-1, dimension - 1 - i, true);
            }

            rotateLayer(1, 0, true);
            rotateLayer(1, 0, true);

            for (int i = 1; i < dimension / 2; i++)
            {
                rotateSide(-1, i, true);
            }

            rotateFrontFace(1, dimension - 1, true);
            rotateFrontFace(1, dimension - 1, true);

            for (int i = 1; i < dimension / 2; i++)
            {
                rotateSide(1, i, true);
            }

            rotateFrontFace(1, dimension - 1, true);
            rotateFrontFace(1, dimension - 1, true);

            for (int i = 1; i < dimension / 2; i++)
            {
                rotateSide(-1, dimension - 1 - i, true);
                rotateSide(-1, dimension - 1 - i, true);
            }

            rotateLayer(1, 0, true);
            rotateLayer(1, 0, true);

            for (int i = 1; i < dimension / 2; i++)
            {
                rotateSide(1, dimension - 1 - i, true);
            }

            rotateLayer(1, 0, true);
            rotateLayer(1, 0, true);

            for (int i = 1; i < dimension / 2; i++)
            {
                rotateSide(-1, dimension - 1 - i, true);
            }

            rotateLayer(1, 0, true);
            rotateLayer(1, 0, true);

            rotateFrontFace(1, dimension - 1, true);
            rotateFrontFace(1, dimension - 1, true);

            for (int i = 1; i < dimension / 2; i++)
            {
                rotateSide(1, dimension - 1 - i, true);
                rotateSide(1, dimension - 1 - i, true);

            }

            rotateFrontFace(1, dimension - 1, true);
            rotateFrontFace(1, dimension - 1, true);

        }

        public void parityPLL()
        {
            for (int i = 1; i < dimension / 2; i++)
            {
                rotateSide(1, dimension - 1 - i, true);
                rotateSide(1, dimension - 1 - i, true);
            }

            rotateLayer(1, 0, true);
            rotateLayer(1, 0, true);

            for (int i = 1; i < dimension / 2; i++)
            {
                rotateSide(1, dimension - 1 - i, true);
                rotateSide(1, dimension - 1 - i, true);
            }

            for (int i = 0; i < dimension / 2; i++)
            {
                rotateLayer(1, i, true);
                rotateLayer(1, i, true);
            }

            for (int i = 1; i < dimension / 2; i++)
            {
                rotateSide(1, dimension - 1 - i, true);
                rotateSide(1, dimension - 1 - i, true);
            }

            for (int i = 0; i < dimension / 2; i++)
            {
                rotateLayer(1, i, true);
                rotateLayer(1, i, true);
            }

        }

        public void solveEvenViaOLL()
        {
            if (dimension % 2 == 1)
            {
                return;
            }
            int myBase = dimension * dimension;
            int colorTop = faces[getPosition(2, 1, 1)] / myBase;
            int currentColor;
            for (int i = 0; i < 4; i++)
            {
                currentColor = faces[getPosition(2, dimension - 1, 1)] / myBase;
                if (currentColor != colorTop)
                {
                    parityOLL();
                }
                rotateCubeClockwise(true);
            }
        }

        // Aligns the edge pieces
        private void alignThirdLayerCross()
        {
            solveEvenViaOLL();
            // align so that front equals top
            // three cases:
            // all match: return
            // cross match: do algorithm, do this again return
            // touching faces match turn cube until front and top dont match do algorithm do
            // this again return
            // no match do the algorithm do this again return
            int myBase = dimension * dimension;
            bool leftMatch = (faces[getPosition(1, 1, 1)]
                    / myBase) == (faces[getPosition(1, 1, dimension - 1)] / myBase);
            bool rightMatch = (faces[getPosition(3, 1, 1)] / myBase) == (faces[getPosition(3, 1, 0)]
                    / myBase);
            bool frontMatch = (faces[getPosition(5, 1, 1)] / myBase) == (faces[getPosition(5, 0, 1)]
                    / myBase);
            bool backMatch = (faces[getPosition(0, 1, 1)]
                    / myBase) == (faces[getPosition(0, dimension - 1, 1)] / myBase);
            int noMatching = ((leftMatch ? 1 : 0) + (rightMatch ? 1 : 0) + (frontMatch ? 1 : 0) + (backMatch ? 1 : 0));
            int failSafe = 0;

            while (failSafe < 4 && noMatching < 2)
            {
                rotateLayer(1, 0, true);
                leftMatch = (faces[getPosition(1, 1, 1)]
                        / myBase) == (faces[getPosition(1, 1, dimension - 1)] / myBase);
                rightMatch = (faces[getPosition(3, 1, 1)] / myBase) == (faces[getPosition(3, 1, 0)] / myBase);
                frontMatch = (faces[getPosition(5, 1, 1)] / myBase) == (faces[getPosition(5, 0, 1)] / myBase);
                backMatch = (faces[getPosition(0, 1, 1)]
                        / myBase) == (faces[getPosition(0, dimension - 1, 1)] / myBase);
                noMatching = ((leftMatch ? 1 : 0) + (rightMatch ? 1 : 0) + (frontMatch ? 1 : 0) + (backMatch ? 1 : 0));

                failSafe++;
            }

            if (noMatching == 4)
            {
                return;
            }
            else if (frontMatch && backMatch || noMatching < 2 || (rightMatch && leftMatch))
            {
                /*
                printCube();
                if (dimension % 2 == 0 && faces.get(getPosition(2, dimension - 1, 1))
                        / base != faces.get(getPosition(2, dimension - 2, 1)) / base) {
                    parityPLL();
                }
                */
                algorithmMatchEdgePiecesThirdLayer();
                alignThirdLayerCross();
                return;
            }
            else
            {
                while (frontMatch || !rightMatch)
                {
                    rotateCubeCounterClockwise(true);
                    rightMatch = (faces[getPosition(3, 1, 1)] / myBase) == (faces[getPosition(3, 1, 0)]
                            / myBase);
                    frontMatch = (faces[getPosition(5, 1, 1)] / myBase) == (faces[getPosition(5, 0, 1)]
                            / myBase);
                }
                backMatch = (faces[getPosition(0, 1, 1)]
                        / myBase) == (faces[getPosition(0, dimension - 1, 1)] / myBase);
                /*
                        if(!backMatch){
                    parityOLL();
                    return;
                }
                */

                algorithmMatchEdgePiecesThirdLayer();
                rotateLayer(1, 0, true);
            }

        }

        // Algorithm for above
        private void algorithmMatchEdgePiecesThirdLayer()
        {
            rotateSide(1, dimension - 1, true);
            rotateLayer(1, 0, true);
            rotateSide(-1, dimension - 1, true);
            rotateLayer(1, 0, true);
            rotateSide(1, dimension - 1, true);
            rotateLayer(1, 0, true);
            rotateLayer(1, 0, true);
            rotateSide(-1, dimension - 1, true);
        }
        // -----------------------------------------------------

        // step two
        // -----------------------------------------------------

        // returns whether top front right corner piece is in right place (regardless of
        // orientation)
        private bool checkTopFrontRightCornerPiece()
        {
            int myBase = dimension * dimension;

            int colorTop = faces[getPosition(2, 1, 1)] / myBase;
            int colorFront = faces[getPosition(5, 1, 1)] / myBase;
            int colorRight = faces[getPosition(3, 1, 1)] / myBase;

            List<int> colorsTopRightFront = new List<int>();
            colorsTopRightFront.Add(colorTop);
            colorsTopRightFront.Add(colorFront);
            colorsTopRightFront.Add(colorRight);
            colorsTopRightFront.Sort(); // Collections.Sort(colorsTopRightFront);

            List<int> colorsTopRightFrontCompare = new List<int>();
            colorsTopRightFrontCompare.Add(faces[getPosition(2, dimension - 1, dimension - 1)] / myBase);
            colorsTopRightFrontCompare.Add(faces[getPosition(3, dimension - 1, 0)] / myBase);
            colorsTopRightFrontCompare.Add(faces[getPosition(5, 0, dimension - 1)] / myBase);
            colorsTopRightFrontCompare.Sort(); // Collections.sort(colorsTopRightFrontCompare);
                                               // TODO return colorsTopRightFront.Equals(colorsTopRightFrontCompare);
            return Common.CompareTwoList(colorsTopRightFront, colorsTopRightFrontCompare);
        }

        // puts third layer coreners in correct spot (regardless of orientation of
        // pieces)
        private void orientThirdLayerCorners()
        {
            int numMatches = 0;
            bool matcher = checkTopFrontRightCornerPiece();

            for (int i = 0; i < 4; i++)
            {
                matcher = checkTopFrontRightCornerPiece();
                if (matcher)
                {
                    numMatches++;
                }
                rotateCubeClockwise(true);

            }

            if (numMatches == 4)
            {
                return;
                /*
                 * }
                 * 
                 * else if(numMatches == 2){ parityPLL(); orientThirdLayerCorners(); return;
                 */
            }
            else if (numMatches == 0)
            {
                thirdLayerCornerAlgorithm();
                orientThirdLayerCorners();
                return;
            }
            else
            {
                while (!matcher)
                {
                    rotateCubeClockwise(true);
                    matcher = checkTopFrontRightCornerPiece();
                }
                if (dimension % 2 == 0 && numMatches == 2)
                {
                    while (matcher)
                    {
                        rotateCubeClockwise(true);
                        matcher = checkTopFrontRightCornerPiece();
                    }
                    parityPLL();
                    alignThirdLayerCross();
                    orientThirdLayerCorners();
                    return;
                }
                thirdLayerCornerAlgorithm();
                // sometimes need to do it again
                orientThirdLayerCorners();
                return;
            }

        }

        // algorithm for above
        private void thirdLayerCornerAlgorithm()
        {
            rotateLayer(1, 0, true);
            rotateSide(1, dimension - 1, true);
            rotateLayer(-1, 0, true);
            rotateSide(1, 0, true);
            rotateLayer(1, 0, true);
            rotateSide(-1, dimension - 1, true);
            rotateLayer(-1, 0, true);
            rotateSide(-1, 0, true);
        }
        // -----------------------------------------------------

        // step three
        // -----------------------------------------------------
        // tests whether corneres are in right orientation
        private bool thirdLayerColorAlignmentTest()
        {
            int myBase = dimension * dimension;
            int bottomCorner = faces[getPosition(2, dimension - 1, dimension - 1)] / myBase;
            int frontFace = faces[getPosition(2, 1, 1)] / myBase;
            return frontFace == bottomCorner;
        }

        // Orients third layer corners
        private void solveThirdLayerCorners()
        {
            bool status = thirdLayerColorAlignmentTest();
            for (int i = 0; i < 4; i++)
            {
                while (!status)
                {
                    lastCornerAlignmentAlgorithm();
                    status = thirdLayerColorAlignmentTest();
                }
                rotateLayer(1, 0, true);
                status = thirdLayerColorAlignmentTest();
            }

        }

        // algorithm for above
        private void lastCornerAlignmentAlgorithm()
        {
            rotateSide(-1, dimension - 1, true);
            rotateLayer(1, dimension - 1, true);
            rotateSide(1, dimension - 1, true);
            rotateLayer(-1, dimension - 1, true);

        }
        // -----------------------------------------------------

        // ---------------------------------------------TOOLS----------------------------------------


        // takes in any cube on the desired face (doesn't matter what color the cube is,
        // returns what face that cube is on)
        //THIS IS NOT THE MAIN MOVE SEQUENCE I'M USING, BUT IT CAN BE USED
        //I included it just so that classic rubiks cube people can put in 3x3 algorithms

        /*
        private void moveSequence3x3(ArrayList<String> moves) {
            for (String move : moves) {
                if (move.equals("R")) {
                    rotateSide(1, dimension - 1);
                } else if (move.equals("R'")) {
                    rotateSide(-1, dimension - 1);
                } else if (move.equals("L")) {
                    // rotate Side rotates clockwise with respect to the right face, you have to
                    // switch 1 with -1 (see B)
                    rotateSide(-1, 0);
                } else if (move.equals("L'")) {
                    rotateSide(1, 0);
                } else if (move.equals("U")) {
                    rotateLayer(1, dimension - 1);
                } else if (move.equals("U'")) {
                    rotateLayer(-1, dimension - 1);
                } else if (move.equals("T")) {
                    rotateLayer(1, 0);
                } else if (move.equals("U'")) {
                    rotateLayer(-1, 0);
                } else if (move.equals("B")) {

                    // When rotating the back, rotate FrontFace assumes you are still looking at the
                    // cube
                    // All major cube algorithms turn back clockwise when you look at back,
                    // rotateFrontFace
                    // always turns clockwise if you're looking at it, this I switched 1 with -1
                    rotateFrontFace(-1, 0);
                } else if (move.equals("B'")) {
                    rotateFrontFace(1, 0);
                } else if (move.equals("F")) {
                    rotateFrontFace(1, dimension - 1);
                } else if (move.equals("F'")) {
                    rotateFrontFace(-1, dimension - 1);
                } else if (move.equals("D")) {
                    rotateLayer(1, dimension - 1);
                } else if (move.equals("D'")) {
                    rotateLayer(-1, dimension - 1);
                } else if (move.equals("X")) {
                    rotateCubeUp();
                } else if (move.equals("X'")) {
                    rotateCubeDown();
                } else if (move.equals("Y")) {
                    rotateCubeCounterClockwise();
                } else if (move.equals("Y'")) {
                    rotateCubeCounterClockwise();
                } else if (move.equals("Z")) {
                    rotateCubeDown();
                    rotateCubeCounterClockwise();
                } else if (move.equals("Z'")) {
                    rotateCubeUp();
                    rotateCubeClockwise();

                }
            }
        }
        */

        private void moveSequence3x3(string move)
        {

            if (move.Equals("R"))
            {
                rotateSide(1, dimension - 1, true);
            }
            else if (move.Equals("R'"))
            {
                rotateSide(-1, dimension - 1, true);
            }
            else if (move.Equals("L"))
            {
                // rotate Side rotates clockwise with respect to the right face, you have to
                // switch 1 with -1 (see B)
                rotateSide(-1, 0, true);
            }
            else if (move.Equals("L'"))
            {
                rotateSide(1, 0, true);
            }
            else if (move.Equals("U"))
            {
                rotateLayer(1, 0, true);
            }
            else if (move.Equals("U'"))
            {
                rotateLayer(-1, 0, true);
            }
            else if (move.Equals("B"))
            {

                // When rotating the back, rotate FrontFace assumes you are still looking at the
                // cube
                // All major cube algorithms turn back clockwise when you look at back,
                // rotateFrontFace
                // always turns clockwise if you're looking at it, this I switched 1 with -1
                rotateFrontFace(-1, 0, true);
            }
            else if (move.Equals("B'"))
            {
                rotateFrontFace(1, 0, true);
            }
            else if (move.Equals("F"))
            {
                rotateFrontFace(1, dimension - 1, true);
            }
            else if (move.Equals("F'"))
            {
                rotateFrontFace(-1, dimension - 1, true);
            }
            else if (move.Equals("D"))
            {
                rotateLayer(1, dimension - 1, true);
            }
            else if (move.Equals("D'"))
            {
                rotateLayer(-1, dimension - 1, true);
            }
            else if (move.Equals("X"))
            {
                rotateCubeUp(true);
            }
            else if (move.Equals("X'"))
            {
                rotateCubeDown(true);
            }
            else if (move.Equals("Y"))
            {
                rotateCubeCounterClockwise(true);
            }
            else if (move.Equals("Y'"))
            {
                rotateCubeCounterClockwise(true);
            }
            else if (move.Equals("Z"))
            {
                rotateCubeDown(true);
                rotateCubeCounterClockwise(true);
            }
            else if (move.Equals("Z'"))
            {
                rotateCubeUp(true);
                rotateCubeClockwise(true);

            }
        }

        /**
         * Fuckin hey bruh, these methods solve the cube bruh
         */
        private void solveFirstLayer()
        {
            // solves first layer edge pieces
            solveCross();

            // solves first layer corner pieces
            solveCorners();
        }

        private void solveThirdLayer()
        {
            // solves the third layer cross
            solveThirdLayerCross();

            // aligns the edge pieces on the third layer
            alignThirdLayerCross();

            // aligns the corner pieces on the third layer
            orientThirdLayerCorners();

            // flips the corner pieces to the correct orientation
            solveThirdLayerCorners();
        }

        public void solve()
        {
            // Technically, because Im using recursion in a lot of steps, if you skip or
            // switch these, the code will enter an infinite recursive loop
            // so you must solve first second then third

            // solves first layer
            solveFirstLayer();

            // flips the cube (not entirely necessary, could have solved bottom layer above,
            // I did it exactly how I would solve it though)
            rotateCubeDown(true);
            rotateCubeDown(true);

            // solves the middle layer
            solveSecondLayer();

            // solves third layer
            solveThirdLayer();

            testOLLParity();

        }

        // Run this to see a n x n cube being solved (assuming front and edge faces are
        // already solved)
        public static void testnxn(int n)
        {
            // shows the cube being sovled while timing scramble and solve
            Cube3x3 myCube3x3 = new Cube3x3(n);
            // print the origional cube
            Debug.Log("Cube OG at dimension: " + n);
            myCube3x3.printCube();

            // Timing the scramble
            long startTime = Common.nanoTime();

            // scramble the cube 1000000 times (for large nxn cubes, you could remove Y and
            // X from scrambleCube)
            myCube3x3.scrambleCube3x3(1000000);

            long endTime = Common.nanoTime();

            // get difference of two nanoTime values
            long timeElapsed = endTime - startTime;

            // print the scrambled cube
            Debug.Log("Scrambled Cube at 1000000 moves (only outside edges moved)");
            myCube3x3.printCube();

            Debug.Log("Execution time of scramble in nanoseconds  : " + timeElapsed);

            Debug.Log("Execution time of scramble in milliseconds : " + timeElapsed / 1000000);

            // Timing the scramble
            startTime = Common.nanoTime();

            // solve the scrambled cube
            // Check the sequence of steps in the method solve
            myCube3x3.solve();

            endTime = Common.nanoTime();

            // get difference of two nanoTime values
            timeElapsed = endTime - startTime;
            Debug.Log("solved 3x3");
            myCube3x3.printCube();

            Debug.Log("Execution time of solve in nanoseconds  : " + timeElapsed);

            Debug.Log("Execution time of solve in milliseconds : " + timeElapsed / 1000000);

        }

        public void solveCubenxn(Cubenxn cube)
        {
            cube.reduceCubeto3x3();
            if (!cube.reduced)
            {
                Debug.Log("Cube is not reduced for some reason");
                return;
            }

        }

        public void testOLLParity()
        {
            int myBase = dimension * dimension;
            if (dimension % 2 == 1)
            {
                return;
            }
            for (int i = 0; i < 4; i++)
            {
                if (faces[getPosition(2, dimension - 1, 1)]
                        / myBase != faces[getPosition(2, dimension - 2, 1)] / myBase)
                {
                    parityOLL();
                    return;
                }
            }
        }

    }
}