using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace frame8.Logic.Misc.Other.Extensions
{
    public static class WWWExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>the size in bytes given by Content-Length header. -1 if N/A</returns>
        public static long GetContentLengthFromHeader(this WWW www)
        {
            string length;
            if (www.responseHeaders.TryGetValue("Content-Length", out length))
            {
                long lengthLong;
                if (long.TryParse(length, out lengthLong))
                    return lengthLong;
            }

            return -1;
        }

    }
}
