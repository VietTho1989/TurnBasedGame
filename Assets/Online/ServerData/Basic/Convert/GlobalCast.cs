using UnityEngine;
using System.Collections;

public class GlobalCast<T>
{

	public static CastingConvert<string, T> CastingString = new CastingConvert<string, T>();

	public static CastingConvert<bool, T> CastingBool = new CastingConvert<bool, T> ();

	public static CastingConvert<System.Single, T> CastingSingle = new CastingConvert<System.Single, T> ();

	public static CastingConvert<User.ACCOUNT_TYPE, T> CastingAccountType = new CastingConvert<User.ACCOUNT_TYPE, T> ();

	public static DataIdentity.MyByte.Cast<T> CastingMyByte = new DataIdentity.MyByte.Cast<T>();
	public static DataIdentity.MySByte.Cast<T> CastingMySByte = new DataIdentity.MySByte.Cast<T>();
	public static DataIdentity.MyUShort.Cast<T> CastingMyUShort = new DataIdentity.MyUShort.Cast<T> ();
	public static CastingConvert<System.Int64, T> CastingInt64 = new CastingConvert<System.Int64, T>();
	public static CastingConvert<System.UInt64, T> CastingUInt64 = new CastingConvert<System.UInt64, T>();
	public static DataIdentity.MyUInt64.Cast<T> CastingMyUInt64 = new DataIdentity.MyUInt64.Cast<T>();
	public static DataIdentity.MyInt64.Cast<T> CastingMyInt64 = new DataIdentity.MyInt64.Cast<T>();
	public static CastingConvert<System.Int32, T> CastingInt32 = new CastingConvert<System.Int32, T>();
	public static CastingConvert<System.UInt32, T> CastingUInt32 = new CastingConvert<System.UInt32, T>();

	public static CastingConvert<ChatNormalContent.Message, T> CastingChatNormalContentMessage = new CastingConvert<ChatNormalContent.Message, T>();

	public static CastingConvert<Shogi.Common.BitBoard, T> CastingShogi_Common_BitBoard = new CastingConvert<Shogi.Common.BitBoard, T>();
	public static CastingConvert<Shogi.Common.Piece, T> CastingShogi_Common_Piece = new CastingConvert<Shogi.Common.Piece, T>();

	public static CastingConvert<Janggi.Common.Pos, T> CastingJanggi_Common_Pos = new CastingConvert<Janggi.Common.Pos, T>();
	// public static CastingConvert<GameType.Type, T> CastingGameType = new CastingConvert<GameType.Type, T>();

}