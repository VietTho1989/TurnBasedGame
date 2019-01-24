using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class SaveFen : Save.Content
{

	public GameType.Type gameType = GameType.Type.CHESS;

	public string fen = "";

	public override Type getType ()
	{
		return Type.Fen;
	}

	#region makeBinary

	public override void makeBinary (BinaryWriter writer)
	{
		writer.Write ((int)gameType);
		writer.Write (fen);
	}

	public override void parse (BinaryReader reader)
	{
		this.gameType = (GameType.Type)reader.ReadInt32 ();
		this.fen = reader.ReadString ();
	}

	#endregion

}