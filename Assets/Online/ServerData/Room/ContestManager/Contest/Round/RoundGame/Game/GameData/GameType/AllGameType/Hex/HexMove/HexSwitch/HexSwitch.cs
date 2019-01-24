using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace HEX
{
	public class HexSwitch : GameMove
	{

		#region Constructor

		public enum Property
		{

		}

		public HexSwitch() : base()
		{

		}

		#endregion

		#region implement base

		public override Type getType()
		{
			return Type.HexSwitch;
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			if (gameType is Hex) {
				Hex hex = gameType as Hex;
				// Make animation
				HexSwitchAnimation hexSwitchAnimation = new HexSwitchAnimation();
				{
					hexSwitchAnimation.boardSize.v = hex.boardSize.v;
					hexSwitchAnimation.board.vs.AddRange (hex.board.vs);
				}
				return hexSwitchAnimation;
			} else {
				Debug.LogError ("why not hex: " + gameType + "; " + this);
				return null;
			}
		}

		public override string print()
		{
			return "Switch Side";
		}

		public override void getInforBeforeProcess (GameType gameType)
		{

		}

		#endregion

	}
}