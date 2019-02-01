using UnityEngine;
using System.Collections;

public class Computer : GamePlayer.Inform
{
	
	public bool isCanRequest(uint userId)
	{
		// TODO Can hoan thien
		return true;
	}

	#region name

	public VP<string> computerName;

	public void requestChangeName(uint userId, string newComputerName){
		Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
		if (needRequest.canRequest) {
			if (!needRequest.needIdentity) {
				this.changeName (userId, newComputerName);
			} else {
				DataIdentity dataIdentity = null;
				if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
					if (dataIdentity is ComputerIdentity) {
						ComputerIdentity computerIdentity = dataIdentity as ComputerIdentity;
						computerIdentity.requestChangeName (userId, newComputerName);
					} else {
						Debug.LogError ("Why isn't correct identity");
					}
				} else {
					Debug.LogError ("cannot find dataIdentity");
				}
			}
		} else {
			Debug.LogError ("You cannot request: " + this);
		}
	}

	public void changeName(uint userId, string newComputerName){
		if (isCanRequest (userId)) {
			this.computerName.v = newComputerName;
		} else {
			Debug.LogError ("cannot request: " + userId + "; " + this);
		}
	}

	#endregion

	#region avatarUrl

	public VP<string> avatarUrl;

	public void requestChangeAvatarUrl(uint userId, string newAvatarUrl){
		Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
		if (needRequest.canRequest) {
			if (!needRequest.needIdentity) {
				this.changeAvatarUrl (userId, newAvatarUrl);
			} else {
				DataIdentity dataIdentity = null;
				if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
					if (dataIdentity is ComputerIdentity) {
						ComputerIdentity computerIdentity = dataIdentity as ComputerIdentity;
						computerIdentity.requestChangeAvatarUrl (userId, newAvatarUrl);
					} else {
						Debug.LogError ("Why isn't correct identity");
					}
				} else {
					Debug.LogError ("cannot find dataIdentity");
				}
			}
		} else {
			Debug.LogError ("You cannot request: " + this);
		}
	}

	public void changeAvatarUrl(uint userId, string newAvatarUrl){
		if (isCanRequest (userId)) {
			this.avatarUrl.v = newAvatarUrl;
		} else {
			Debug.LogError ("cannot request: " + userId + "; " + this);
		}
	}

	#endregion

	#region AI

	public abstract class AI : Data
	{
		
		public abstract GameType.Type getType ();

        public static AI makeDefaultAI(GameType.Type gameType)
        {
            switch (gameType)
            {
                case GameType.Type.CHESS:
                    return new Chess.ChessAI();
                case GameType.Type.Shatranj:
                    return new Shatranj.ShatranjAI();
                case GameType.Type.Makruk:
                    return new Makruk.MakrukAI();
                case GameType.Type.Seirawan:
                    return new Seirawan.SeirawanAI();
                case GameType.Type.FairyChess:
                    return new FairyChess.FairyChessAI();

                case GameType.Type.Xiangqi:
                    return new Xiangqi.XiangqiAI();
                case GameType.Type.CO_TUONG_UP:
                    return new CoTuongUp.CoTuongUpAI();
                case GameType.Type.Janggi:
                    return new Janggi.JanggiAI();
                case GameType.Type.Banqi:
                    return new Banqi.BanqiAI();

                case GameType.Type.Weiqi:
                    return new Weiqi.WeiqiAI();
                case GameType.Type.SHOGI:
                    return new Shogi.ShogiAI();
                case GameType.Type.Reversi:
                    return new Reversi.ReversiAI();
                case GameType.Type.Gomoku:
                    return new Gomoku.GomokuAI();

                case GameType.Type.InternationalDraught:
                    return new InternationalDraught.InternationalDraughtAI();
                case GameType.Type.EnglishDraught:
                    return new EnglishDraught.EnglishDraughtAI();
                case GameType.Type.RussianDraught:
                    return new RussianDraught.RussianDraughtAI();
                case GameType.Type.ChineseCheckers:
                    return new ChineseCheckers.ChineseCheckersAI();

                case GameType.Type.MineSweeper:
                    return new MineSweeper.MineSweeperAI();
                case GameType.Type.Hex:
                    return new HEX.HexAI();
                case GameType.Type.Solitaire:
                    return new Solitaire.SolitaireAI();
                case GameType.Type.Sudoku:
                    return new Sudoku.SudokuAI();
                case GameType.Type.Khet:
                    return new Khet.KhetAI();
                case GameType.Type.NineMenMorris:
                    return new NineMenMorris.NineMenMorrisAI();
                default:
                    Debug.LogError("unknown gameType: " + gameType);
                    break;
            }
            return null;
        }

		public bool isCanRequest(uint userId)
		{
			return true;
		}

	}

	public VP<AI> ai;

	#endregion

	#region Constructor

	public enum Property
	{
		computerName,
		avatarUrl,
		ai
	}

	public Computer() : base()
	{
		this.computerName = new VP<string> (this, (byte)Property.computerName, "Easy");
		this.avatarUrl = new VP<string> (this, (byte)Property.avatarUrl, "");
		this.ai = new VP<AI> (this, (byte)Property.ai, null);
	}

	#endregion

	public override string getPlayerName ()
	{
		return this.computerName.v;
	}

	public override Type getType ()
	{
		return GamePlayer.Inform.Type.Computer;
	}
}