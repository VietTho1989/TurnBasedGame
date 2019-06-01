using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Rubiks
{
    public class Common
    {

        public static readonly System.Random random = new System.Random();

        public static bool CompareTwoList<T>(List<T> A, List<T> B)
        {
            if (A.Count == B.Count)
            {
                bool ret = true;
                {
                    for (int i = 0; i < A.Count; i++)
                    {
                        if (!A[i].Equals(B[i]))
                        {
                            ret = false;
                            break;
                        }
                    }
                }
                return ret;
            }
            else
            {
                return false;
            }
        }

        public static long nanoTime()
        {
            long nano = 10000L * Stopwatch.GetTimestamp();
            nano /= TimeSpan.TicksPerMillisecond;
            nano *= 100L;
            return nano;
        }

    }
}