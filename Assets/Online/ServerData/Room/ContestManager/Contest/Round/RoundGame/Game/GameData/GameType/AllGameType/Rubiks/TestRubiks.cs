using UnityEngine;
using System.Threading;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace Rubiks
{
    public class TestRubiks : MonoBehaviour
    {

        private static bool isDestroy = false;

        // Start is called before the first frame update
        void Start()
        {
            {
                Work w = new Work();
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(DoWork), w);
                    // w.DoWork();
                }
            }
        }

        private class Work
        {

            public void DoWork()
            {
                int dim = 10;
                int scramble = 100;

                Cubenxn myCube = new Cubenxn(dim);
                Debug.Log("============= Origional Cube at " + dim + " dimension=============");
                Debug.Log(myCube.printCube());

                long startTime = Common.nanoTime();

                myCube.scrambleNxN(scramble);
                {
                    myCube.scrambleAlgorithm.Clear();
                }

                // TODO Them vao test cube
                Cube testSolveCube = new Cube(myCube.dimension);
                {
                    testSolveCube.faces.Clear();
                    testSolveCube.faces.AddRange(myCube.faces);
                }

                long endTime = Common.nanoTime();

                long timeElapsed = endTime - startTime;

                Debug.Log("Scrambled cube at " + scramble + " moves");


                Debug.Log(myCube.printCube());

                Debug.Log("Execution time of scramble in nanoseconds : " + timeElapsed);

                Debug.Log("Execution time of scramble in milliseconds : " + timeElapsed / 1000000);
                startTime = Common.nanoTime();

                Cube solvedCube = myCube.solveCube(myCube);

                endTime = Common.nanoTime();

                // get difference of two nanoTime values
                timeElapsed = endTime - startTime;
                Debug.Log("============ Solved cube =============");
                Debug.Log(solvedCube.printCube());

                Debug.Log("Execution time of reduction in nanoseconds  : " + timeElapsed);

                Debug.Log("Execution time of reduction in milliseconds : " + timeElapsed / 1000000);

                // test solve cube
                {
                    Debug.Log("test solve cube");
                    Debug.Log(testSolveCube.printCube());
                    testSolveCube.moveSequenceNxN(solvedCube.algorithm);
                }
            }

        }

        static void DoWork(object work)
        {
            if (work is Work)
            {
                ((Work)work).DoWork();
            }
            else
            {
                Debug.LogError("why not work: " + work);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnDestroy()
        {
            isDestroy = true;
        }

    }
}