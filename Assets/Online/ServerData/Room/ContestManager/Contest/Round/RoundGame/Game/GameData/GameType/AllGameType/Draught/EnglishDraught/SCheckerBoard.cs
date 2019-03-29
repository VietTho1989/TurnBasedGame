using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace EnglishDraught
{
    public class SCheckerBoard : Data
    {

        /** uint64_t WP*/
        public VP<System.UInt64> WP;

        /** uint64_t BP*/
        public VP<System.UInt64> BP;

        /** uint64_t K*/
        public VP<System.UInt64> K;

        #region Constructor

        public enum Property
        {
            WP,
            BP,
            K
        }

        public SCheckerBoard() : base()
        {
            this.WP = new VP<ulong>(this, (byte)Property.WP, 0);
            this.BP = new VP<ulong>(this, (byte)Property.BP, 0);
            this.K = new VP<ulong>(this, (byte)Property.K, 0);
        }

        #endregion

        #region Convert

        public static byte[] convertToBytes(SCheckerBoard sCheckerBoard)
        {
            byte[] byteArray;
            using (MemoryStream memStream = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(memStream))
                {
                    // write value
                    {
                        /** uint64_t WP*/
                        writer.Write(sCheckerBoard.WP.v);
                        /** uint64_t BP*/
                        writer.Write(sCheckerBoard.BP.v);
                        /** uint64_t K*/
                        writer.Write(sCheckerBoard.K.v);
                    }
                    // write to byteArray
                    byteArray = memStream.ToArray();
                }
            }
            return byteArray;
        }

        public static int parse(SCheckerBoard sCheckerBoard, byte[] byteArray, int start)
        {
            // TODO co the LittleEdian va BigEndian khac nhau se co loi
            int count = start;
            int index = 0;
            bool isParseCorrect = true;
            while (count < byteArray.Length)
            {
                bool alreadyPassAll = false;
                switch (index)
                {
                    case 0:
                        /** uint64_t WP*/
                        {
                            int size = sizeof(System.UInt64);
                            if (count + size <= byteArray.Length)
                            {
                                sCheckerBoard.WP.v = BitConverter.ToUInt64(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("error, array not enough length: WP: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 1:
                        /** uint64_t BP*/
                        {
                            int size = sizeof(System.UInt64);
                            if (count + size <= byteArray.Length)
                            {
                                sCheckerBoard.BP.v = BitConverter.ToUInt64(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("error, array not enough length: BP: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 2:
                        /** uint64_t K*/
                        {
                            int size = sizeof(System.UInt64);
                            if (count + size <= byteArray.Length)
                            {
                                sCheckerBoard.K.v = BitConverter.ToUInt64(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("error, array not enough length: K: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    default:
                        alreadyPassAll = true;
                        break;
                }
                index++;
                if (!isParseCorrect)
                {
                    Debug.LogError("not parse correct");
                    break;
                }
                if (alreadyPassAll)
                {
                    break;
                }
            }
            // return
            if (!isParseCorrect)
            {
                Debug.LogError("parse node fail: " + count + "; " + byteArray.Length + "; " + start);
                return -1;
            }
            else
            {
                // Debug.Log ("parse node success: " + count + "; " + byteArray.Length + "; " + start);
                return (count - start);
            }
        }

        #endregion

    }
}