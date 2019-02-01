using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

namespace ChineseCheckers
{
    public class ChineseCheckersMove : GameMove
    {

        public VP<int> fromX;

        public VP<int> fromY;

        public VP<int> toX;

        public VP<int> toY;

        #region Constructor

        public enum Property
        {
            fromX,
            fromY,
            toX,
            toY
        }

        public ChineseCheckersMove() : base()
        {
            this.fromX = new VP<int>(this, (byte)Property.fromX, 0);
            this.fromY = new VP<int>(this, (byte)Property.fromY, 0);
            this.toX = new VP<int>(this, (byte)Property.toX, 0);
            this.toY = new VP<int>(this, (byte)Property.toY, 0);
        }

        #endregion

        #region Convert

        public static int GetSize()
        {
            int ret = 0;
            {
                ret += 4 * sizeof(int);
            }
            return ret;
        }

        public static byte[] convertToBytes(ChineseCheckersMove chineseCheckersMove)
        {
            byte[] byteArray;
            using (MemoryStream memStream = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(memStream))
                {
                    // write value
                    {
                        writer.Write(chineseCheckersMove.fromX.v);
                        writer.Write(chineseCheckersMove.fromY.v);
                        writer.Write(chineseCheckersMove.toX.v);
                        writer.Write(chineseCheckersMove.toY.v);
                    }
                    // write to byteArray
                    byteArray = memStream.ToArray();
                }
            }
            return byteArray;
        }

        public static int parse(ChineseCheckersMove chineseCheckersMove, byte[] byteArray, int start)
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
                        {
                            // fromX
                            int size = sizeof(int);
                            if (count + size <= byteArray.Length)
                            {
                                chineseCheckersMove.fromX.v = BitConverter.ToInt32(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("error, array not enough length: fromX: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 1:
                        {
                            // fromY
                            int size = sizeof(int);
                            if (count + size <= byteArray.Length)
                            {
                                chineseCheckersMove.fromY.v = BitConverter.ToInt32(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("error, array not enough length: fromY: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 2:
                        {
                            // toX
                            int size = sizeof(int);
                            if (count + size <= byteArray.Length)
                            {
                                chineseCheckersMove.toX.v = BitConverter.ToInt32(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("error, array not enough length: toX: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 3:
                        {
                            // toY
                            int size = sizeof(int);
                            if (count + size <= byteArray.Length)
                            {
                                chineseCheckersMove.toY.v = BitConverter.ToInt32(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("error, array not enough length: toY: " + count + "; " + byteArray.Length);
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
                Debug.LogError("parse fail: " + count + "; " + byteArray.Length + "; " + start);
                return -1;
            }
            else
            {
                // Debug.Log ("parse node success: " + count + "; " + byteArray.Length + "; " + start);
                return (count - start);
            }
        }

        #endregion

        public override Type getType()
        {
            return Type.ChineseCheckersMove;
        }

        public override MoveAnimation makeAnimation(GameType gameType)
        {
            return null;
        }

        public override string print()
        {
            return "ChineseCheckersMove: " + this.fromX.v + ", " + this.fromY.v + ", " + this.toX.v + ", " + this.toY.v;
        }

        public override void getInforBeforeProcess(GameType gameType)
        {

        }

    }
}
