using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Rubiks
{
    public class Solver
    {

        public static List<Move> solveCubeFromScramble(int dimension, List<Move> scramble)
        {
            List<Move> solver = new List<Move>();
            Cubenxn cube = new Cubenxn(dimension);
            cube.moveSequenceNxN(scramble);
            cube.algorithm.Clear();
            Cube newCube = cube.solveCube(cube);

            solver = newCube.algorithm;
            return solver;
        }

        public static List<Move> generateScramble(int dimension, int noMoves)
        {
            List<Move> scramble = new List<Move>();
            string[] possibleMoves = { "X+", "Y+", "Z+", "X-", "Y-", "Z-" };
            int randomLayer;
            int randomChooser;
            for (int i = 0; i < noMoves; i++)
            {
                randomLayer = Common.random.Next(dimension);// (int)(Math.random() * dimension);
                randomChooser = Common.random.Next(6);// (int)(Math.random() * 6);
                Move move = new Move(possibleMoves[randomChooser], randomLayer);
                scramble.Add(move);
            }
            return scramble;
        }

        public static List<Move> filterMoveSetBasic(List<Move> moveSet)
        {
            bool filtered = false;
            while (!filtered)
            {
                filtered = true;
                // check for inverses
                for (int i = 0; i < moveSet.Count - 1; i++)
                {
                    String move1 = moveSet[i].main;
                    String move2 = moveSet[i + 1].main;
                    int layerNo1 = moveSet[i].layerNo;
                    int layerNo2 = moveSet[i + 1].layerNo;
                    bool translations = moveSet[i].translation || moveSet[i + 1].translation;
                    if (!(translations) && layerNo1 == layerNo2 && move1.Substring(0, 1).Equals(move2.Substring(0, 1))
                            && !move1.Substring(1).Equals(move2.Substring(1)))
                    {
                        moveSet.RemoveAt(i);
                        moveSet.RemoveAt(i);
                        i--;
                        filtered = false;
                    }
                    else if (move1.Equals(move2) && layerNo1 == -layerNo2 && layerNo1 != 0)
                    {
                        moveSet.RemoveAt(i);
                        moveSet.RemoveAt(i);
                        i--;
                        filtered = false;
                    }
                }
                // check for 3 moves = 1 move
                for (int i = 0; i < moveSet.Count - 2; i++)
                {
                    bool translations = moveSet[i].translation || moveSet[i + 1].translation
                            || moveSet[i + 2].translation;

                    if (!(translations) && moveSet[i].equals(moveSet[i + 1])
                            && moveSet[i].equals(moveSet[i + 2]))
                    {
                        moveSet.RemoveAt(i);
                        moveSet.RemoveAt(i);
                        if (moveSet[i].main.Substring(1).Equals("-"))
                        {
                            moveSet[i].main = moveSet[i].main.Substring(0, 1) + "+";
                        }
                        else
                        {
                            moveSet[i].main = moveSet[i].main.Substring(0, 1) + "-";
                        }
                        i--;
                        filtered = false;
                    }
                    else if (moveSet[i].equals(moveSet[i + 1]) && moveSet[i].equals(moveSet[i + 2]))
                    {
                        moveSet.RemoveAt(i);
                        moveSet.RemoveAt(i);
                        moveSet[i].layerNo *= -1;
                        i--;
                        filtered = false;
                    }
                }
                // doesn't happen in 3x3s, but it does happen in larger cubes
                for (int i = 0; i < moveSet.Count - 3; i++)
                {

                    if (moveSet[i].equals(moveSet[i + 1]) && moveSet[i].equals(moveSet[i + 2])
                            && moveSet[i].equals(moveSet[i + 3]))
                    {
                        moveSet.RemoveAt(i);
                        moveSet.RemoveAt(i);
                        moveSet.RemoveAt(i);
                        moveSet.RemoveAt(i);
                        i--;
                        filtered = false;
                    }

                }

            }

            return moveSet;
        }

        /*public static void runJSObject(int dimension, int id, int scrambleNo) {
            System.out.println();
            ArrayList<Move> scramble = generateScramble(dimension, scrambleNo);
            ArrayList<Move> solver = solveCubeFromScramble(dimension, scramble);
            scramble = filterMoveSetBasic(scramble);
            solver = filterMoveSetBasic(solver);
            System.out.print("var cube" + dimension + "" + id + " = {");
            System.out.println();
            System.out.print("dimension:" + dimension + ",");
            System.out.println();
            System.out.print("scrambleMoves: [");
            for (int i = 0; i < scramble.size(); i++) {
                System.out.print("'" + scramble.get(i).main + "', ");
            }
            System.out.print("],");
            System.out.println();
            System.out.print("scrambleSlices: [");
            for (int i = 0; i < scramble.size(); i++) {
                System.out.print("" + scramble.get(i).layerNo + ", ");
            }
            System.out.print("],");
            System.out.println();
            System.out.print("solverMoves: [");
            for (int i = 0; i < solver.size(); i++) {
                System.out.print("'" + solver.get(i).main + "', ");
            }
            System.out.print("],");
            System.out.println();
            System.out.print("solverSlices: [");
            for (int i = 0; i < solver.size(); i++) {
                System.out.print("" + solver.get(i).layerNo + ", ");
            }
            System.out.print("]");
            System.out.println();
            System.out.print("};");
            System.out.println();

        }*/

    }
}