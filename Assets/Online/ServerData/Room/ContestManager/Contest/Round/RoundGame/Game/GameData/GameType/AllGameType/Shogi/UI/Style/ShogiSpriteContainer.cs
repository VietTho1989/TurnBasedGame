using UnityEngine;

namespace Shogi
{
    public class ShogiSpriteContainer : MonoBehaviour
    {

        private static ShogiSpriteContainer instance;

        void Awake()
        {
            instance = this;
        }

        public static ShogiSpriteContainer get()
        {
            return instance;
        }

        #region Normal

        public Sprite NormalBPawn;
        public Sprite NormalBLance;
        public Sprite NormalBKnight;
        public Sprite NormalBSilver;
        public Sprite NormalBBishop;
        public Sprite NormalBRook;
        public Sprite NormalBGold;
        public Sprite NormalBKing;
        public Sprite NormalBProPawn;
        public Sprite NormalBProLance;
        public Sprite NormalBProKnight;
        public Sprite NormalBProSilver;
        public Sprite NormalBHorse;
        public Sprite NormalBDragon;

        public Sprite NormalWPawn;
        public Sprite NormalWLance;
        public Sprite NormalWKnight;
        public Sprite NormalWSilver;
        public Sprite NormalWBishop;
        public Sprite NormalWRook;
        public Sprite NormalWGold;
        public Sprite NormalWKing;
        public Sprite NormalWProPawn;
        public Sprite NormalWProLance;
        public Sprite NormalWProKnight;
        public Sprite NormalWProSilver;
        public Sprite NormalWHorse;
        public Sprite NormalWDragon;

        #endregion

        #region Western

        public Sprite WesternBPawn;
        public Sprite WesternBLance;
        public Sprite WesternBKnight;
        public Sprite WesternBSilver;
        public Sprite WesternBBishop;
        public Sprite WesternBRook;
        public Sprite WesternBGold;
        public Sprite WesternBKing;
        public Sprite WesternBProPawn;
        public Sprite WesternBProLance;
        public Sprite WesternBProKnight;
        public Sprite WesternBProSilver;
        public Sprite WesternBHorse;
        public Sprite WesternBDragon;

        public Sprite WesternWPawn;
        public Sprite WesternWLance;
        public Sprite WesternWKnight;
        public Sprite WesternWSilver;
        public Sprite WesternWBishop;
        public Sprite WesternWRook;
        public Sprite WesternWGold;
        public Sprite WesternWKing;
        public Sprite WesternWProPawn;
        public Sprite WesternWProLance;
        public Sprite WesternWProKnight;
        public Sprite WesternWProSilver;
        public Sprite WesternWHorse;
        public Sprite WesternWDragon;

        #endregion

        public Sprite PieceNone;

        public Sprite getSpriteForHandPiece(Setting.Style style, Common.HandPiece handPiece, Common.Color color)
        {
            switch (style)
            {
                case Setting.Style.Normal:
                    {
                        switch (color)
                        {
                            case Common.Color.Black:
                                {
                                    switch (handPiece)
                                    {
                                        case Common.HandPiece.HPawn:
                                            return NormalBPawn;
                                        case Common.HandPiece.HLance:
                                            return NormalBLance;
                                        case Common.HandPiece.HKnight:
                                            return NormalBKnight;
                                        case Common.HandPiece.HSilver:
                                            return NormalBSilver;
                                        case Common.HandPiece.HGold:
                                            return NormalBGold;
                                        case Common.HandPiece.HBishop:
                                            return NormalBBishop;
                                        case Common.HandPiece.HRook:
                                            return NormalBRook;
                                        default:
                                            Debug.LogError("unknown handPiece: " + handPiece + "; " + this);
                                            return PieceNone;
                                    }
                                }
                            case Common.Color.White:
                                {
                                    switch (handPiece)
                                    {
                                        case Common.HandPiece.HPawn:
                                            return NormalWPawn;
                                        case Common.HandPiece.HLance:
                                            return NormalWLance;
                                        case Common.HandPiece.HKnight:
                                            return NormalWKnight;
                                        case Common.HandPiece.HSilver:
                                            return NormalWSilver;
                                        case Common.HandPiece.HGold:
                                            return NormalWGold;
                                        case Common.HandPiece.HBishop:
                                            return NormalWBishop;
                                        case Common.HandPiece.HRook:
                                            return NormalWRook;
                                        default:
                                            Debug.LogError("unknown handPiece: " + handPiece + "; " + this);
                                            return PieceNone;
                                    }
                                }
                            default:
                                Debug.LogError("unknown color: " + color + "; " + this);
                                return PieceNone;
                        }
                    }
                case Setting.Style.Western:
                    {
                        switch (color)
                        {
                            case Common.Color.Black:
                                {
                                    switch (handPiece)
                                    {
                                        case Common.HandPiece.HPawn:
                                            return WesternBPawn;
                                        case Common.HandPiece.HLance:
                                            return WesternBLance;
                                        case Common.HandPiece.HKnight:
                                            return WesternBKnight;
                                        case Common.HandPiece.HSilver:
                                            return WesternBSilver;
                                        case Common.HandPiece.HGold:
                                            return WesternBGold;
                                        case Common.HandPiece.HBishop:
                                            return WesternBBishop;
                                        case Common.HandPiece.HRook:
                                            return WesternBRook;
                                        default:
                                            Debug.LogError("unknown handPiece: " + handPiece + "; " + this);
                                            return PieceNone;
                                    }
                                }
                            case Common.Color.White:
                                {
                                    switch (handPiece)
                                    {
                                        case Common.HandPiece.HPawn:
                                            return WesternWPawn;
                                        case Common.HandPiece.HLance:
                                            return WesternWLance;
                                        case Common.HandPiece.HKnight:
                                            return WesternWKnight;
                                        case Common.HandPiece.HSilver:
                                            return WesternWSilver;
                                        case Common.HandPiece.HGold:
                                            return WesternWGold;
                                        case Common.HandPiece.HBishop:
                                            return WesternWBishop;
                                        case Common.HandPiece.HRook:
                                            return WesternWRook;
                                        default:
                                            Debug.LogError("unknown handPiece: " + handPiece + "; " + this);
                                            return PieceNone;
                                    }
                                }
                            default:
                                Debug.LogError("unknown color: " + color + "; " + this);
                                return PieceNone;
                        }
                    }
                default:
                    Debug.LogError("unknown style: " + style);
                    return PieceNone;
            }
        }

        public Sprite getSprite(Setting.Style style, Common.Piece piece)
        {
            switch (style)
            {
                case Setting.Style.Normal:
                    {
                        switch (piece)
                        {
                            case Common.Piece.Empty:
                                return PieceNone;
                            case Common.Piece.BPawn:
                                return NormalBPawn;
                            case Common.Piece.BLance:
                                return NormalBLance;
                            case Common.Piece.BKnight:
                                return NormalBKnight;
                            case Common.Piece.BSilver:
                                return NormalBSilver;
                            case Common.Piece.BBishop:
                                return NormalBBishop;
                            case Common.Piece.BRook:
                                return NormalBRook;
                            case Common.Piece.BGold:
                                return NormalBGold;
                            case Common.Piece.BKing:
                                return NormalBKing;
                            case Common.Piece.BProPawn:
                                return NormalBProPawn;
                            case Common.Piece.BProLance:
                                return NormalBProLance;
                            case Common.Piece.BProKnight:
                                return NormalBProKnight;
                            case Common.Piece.BProSilver:
                                return NormalBProSilver;
                            case Common.Piece.BHorse:
                                return NormalBHorse;
                            case Common.Piece.BDragon:
                                return NormalBDragon;
                            case Common.Piece.WPawn:
                                return NormalWPawn;
                            case Common.Piece.WLance:
                                return NormalWLance;
                            case Common.Piece.WKnight:
                                return NormalWKnight;
                            case Common.Piece.WSilver:
                                return NormalWSilver;
                            case Common.Piece.WBishop:
                                return NormalWBishop;
                            case Common.Piece.WRook:
                                return NormalWRook;
                            case Common.Piece.WGold:
                                return NormalWGold;
                            case Common.Piece.WKing:
                                return NormalWKing;
                            case Common.Piece.WProPawn:
                                return NormalWProPawn;
                            case Common.Piece.WProLance:
                                return NormalWProLance;
                            case Common.Piece.WProKnight:
                                return NormalWProKnight;
                            case Common.Piece.WProSilver:
                                return NormalWProSilver;
                            case Common.Piece.WHorse:
                                return NormalWHorse;
                            case Common.Piece.WDragon:
                                return NormalWDragon;
                            default:
                                Debug.LogError("unknown piece type: " + piece + ", " + this);
                                return PieceNone;
                        }
                    }
                case Setting.Style.Western:
                    {
                        switch (piece)
                        {
                            case Common.Piece.Empty:
                                return PieceNone;
                            case Common.Piece.BPawn:
                                return WesternBPawn;
                            case Common.Piece.BLance:
                                return WesternBLance;
                            case Common.Piece.BKnight:
                                return WesternBKnight;
                            case Common.Piece.BSilver:
                                return WesternBSilver;
                            case Common.Piece.BBishop:
                                return WesternBBishop;
                            case Common.Piece.BRook:
                                return WesternBRook;
                            case Common.Piece.BGold:
                                return WesternBGold;
                            case Common.Piece.BKing:
                                return WesternBKing;
                            case Common.Piece.BProPawn:
                                return WesternBProPawn;
                            case Common.Piece.BProLance:
                                return WesternBProLance;
                            case Common.Piece.BProKnight:
                                return WesternBProKnight;
                            case Common.Piece.BProSilver:
                                return WesternBProSilver;
                            case Common.Piece.BHorse:
                                return WesternBHorse;
                            case Common.Piece.BDragon:
                                return WesternBDragon;
                            case Common.Piece.WPawn:
                                return WesternWPawn;
                            case Common.Piece.WLance:
                                return WesternWLance;
                            case Common.Piece.WKnight:
                                return WesternWKnight;
                            case Common.Piece.WSilver:
                                return WesternWSilver;
                            case Common.Piece.WBishop:
                                return WesternWBishop;
                            case Common.Piece.WRook:
                                return WesternWRook;
                            case Common.Piece.WGold:
                                return WesternWGold;
                            case Common.Piece.WKing:
                                return WesternWKing;
                            case Common.Piece.WProPawn:
                                return WesternWProPawn;
                            case Common.Piece.WProLance:
                                return WesternWProLance;
                            case Common.Piece.WProKnight:
                                return WesternWProKnight;
                            case Common.Piece.WProSilver:
                                return WesternWProSilver;
                            case Common.Piece.WHorse:
                                return WesternWHorse;
                            case Common.Piece.WDragon:
                                return WesternWDragon;
                            default:
                                Debug.LogError("unknown piece type: " + piece + ", " + this);
                                return PieceNone;
                        }
                    }
                default:
                    Debug.LogError("unknown style: " + style);
                    return PieceNone;
            }
        }

    }
}