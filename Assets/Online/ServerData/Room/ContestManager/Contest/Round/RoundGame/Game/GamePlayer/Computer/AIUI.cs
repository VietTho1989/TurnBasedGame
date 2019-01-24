using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIUI : UIBehavior<AIUI.UIData>
{

	#region UIData

	public class UIData : Data
	{
		
		public VP<EditData<Computer.AI>> editAI;

		#region Sub

		public abstract class Sub : Data
		{
			
			public abstract GameType.Type getType ();

		}

		public VP<Sub> sub;

		#endregion

		#region Constructor

		public enum Property
		{
			editAI,
			sub
		}

		public UIData() : base()
		{
			this.editAI = new VP<EditData<Computer.AI>>(this, (byte)Property.editAI, new EditData<Computer.AI>());
			this.sub = new VP<Sub>(this, (byte)Property.sub, null);
		}

		#endregion

	}

	#endregion

	#region Refresh

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				EditData<Computer.AI> editAI = this.data.editAI.v;
				if (editAI != null) {
					// update
					editAI.update ();
					// Make sub
					{
						Computer.AI show = editAI.show.v.data;
						if (show != null) {
							switch (show.getType ()) {
							case GameType.Type.CHESS:
								{
									Chess.ChessAI chessAI = show as Chess.ChessAI;
									// UIData
									Chess.ChessAIUI.UIData chessAIUIData = this.data.sub.newOrOld<Chess.ChessAIUI.UIData> ();
									{
										EditData<Chess.ChessAI> editChessAI = chessAIUIData.editAI.v;
										if (editChessAI != null) {
											// origin
											editChessAI.origin.v = new ReferenceData<Chess.ChessAI> ((Chess.ChessAI)editAI.origin.v.data);
											// show
											editChessAI.show.v = new ReferenceData<Chess.ChessAI> (chessAI);
											// compare
											editChessAI.compare.v = new ReferenceData<Chess.ChessAI> ((Chess.ChessAI)editAI.compare.v.data);
											// compareOtherType
											editChessAI.compareOtherType.v = new ReferenceData<Data>(editAI.compareOtherType.v.data);
											// canEdit
											editChessAI.canEdit.v = editAI.canEdit.v;
											// editType
											editChessAI.editType.v = editAI.editType.v;
										} else {
											Debug.LogError ("editChessAI null: " + this);
										}
									}
									this.data.sub.v = chessAIUIData;
								}
								break;
							case GameType.Type.Shatranj:
								{
									Shatranj.ShatranjAI shatranjAI = show as Shatranj.ShatranjAI;
									// UIData
									Shatranj.ShatranjAIUI.UIData shatranjAIUIData = this.data.sub.newOrOld<Shatranj.ShatranjAIUI.UIData> ();
									{
										EditData<Shatranj.ShatranjAI> editShatranjAI = shatranjAIUIData.editAI.v;
										if (editShatranjAI != null) {
											// origin
											editShatranjAI.origin.v = new ReferenceData<Shatranj.ShatranjAI>((Shatranj.ShatranjAI)editAI.origin.v.data);
											// show
											editShatranjAI.show.v = new ReferenceData<Shatranj.ShatranjAI>(shatranjAI);
											// compare
											editShatranjAI.compare.v = new ReferenceData<Shatranj.ShatranjAI> ((Shatranj.ShatranjAI)editAI.compare.v.data);
											// compareOtherType
											editShatranjAI.compareOtherType.v = new ReferenceData<Data>(editAI.compareOtherType.v.data);
											// canEdit
											editShatranjAI.canEdit.v = editAI.canEdit.v;
											// editType
											editShatranjAI.editType.v = editAI.editType.v;
										} else {
											Debug.LogError ("editShatranjAI null: " + this);
										}
									}
									this.data.sub.v = shatranjAIUIData;
								}
								break;
							case GameType.Type.Makruk:
								{
									Makruk.MakrukAI makrukAI = show as Makruk.MakrukAI;
									// UIData
									Makruk.MakrukAIUI.UIData makrukAIUIData = this.data.sub.newOrOld<Makruk.MakrukAIUI.UIData> ();
									{
										EditData<Makruk.MakrukAI> editMakrukAI = makrukAIUIData.editAI.v;
										if (editMakrukAI != null) {
											// origin
											editMakrukAI.origin.v = new ReferenceData<Makruk.MakrukAI>((Makruk.MakrukAI)editAI.origin.v.data);
											// show
											editMakrukAI.show.v = new ReferenceData<Makruk.MakrukAI>(makrukAI);
											// compare
											editMakrukAI.compare.v = new ReferenceData<Makruk.MakrukAI> ((Makruk.MakrukAI)editAI.compare.v.data);
											// compareOtherType
											editMakrukAI.compareOtherType.v = new ReferenceData<Data>(editAI.compareOtherType.v.data);
											// canEdit
											editMakrukAI.canEdit.v = editAI.canEdit.v;
											// editType
											editMakrukAI.editType.v = editAI.editType.v;
										} else {
											Debug.LogError ("editMakrukAI null: " + this);
										}
									}
									this.data.sub.v = makrukAIUIData;
								}
								break;
							case GameType.Type.Seirawan:
								{
									Seirawan.SeirawanAI seirawanAI = show as Seirawan.SeirawanAI;
									// UIData
									Seirawan.SeirawanAIUI.UIData seirawanAIUIData = this.data.sub.newOrOld<Seirawan.SeirawanAIUI.UIData> ();
									{
										EditData<Seirawan.SeirawanAI> editSeirawanAI = seirawanAIUIData.editAI.v;
										if (editSeirawanAI != null) {
											// origin
											editSeirawanAI.origin.v = new ReferenceData<Seirawan.SeirawanAI>((Seirawan.SeirawanAI)editAI.origin.v.data);
											// show
											editSeirawanAI.show.v = new ReferenceData<Seirawan.SeirawanAI>(seirawanAI);
											// compare
											editSeirawanAI.compare.v = new ReferenceData<Seirawan.SeirawanAI> ((Seirawan.SeirawanAI)editAI.compare.v.data);
											// compareOtherType
											editSeirawanAI.compareOtherType.v = new ReferenceData<Data>(editAI.compareOtherType.v.data);
											// canEdit
											editSeirawanAI.canEdit.v = editAI.canEdit.v;
											// editType
											editSeirawanAI.editType.v = editAI.editType.v;
										} else {
											Debug.LogError ("editSeirawanAI null: " + this);
										}
									}
									this.data.sub.v = seirawanAIUIData;
								}
								break;
							case GameType.Type.FairyChess:
								{
									FairyChess.FairyChessAI fairyChessAI = show as FairyChess.FairyChessAI;
									// UIData
									FairyChess.FairyChessAIUI.UIData fairyChessAIUIData = this.data.sub.newOrOld<FairyChess.FairyChessAIUI.UIData> ();
									{
										EditData<FairyChess.FairyChessAI> editFairyChessAI = fairyChessAIUIData.editAI.v;
										if (editFairyChessAI != null) {
											// origin
											editFairyChessAI.origin.v = new ReferenceData<FairyChess.FairyChessAI>((FairyChess.FairyChessAI)editAI.origin.v.data);
											// show
											editFairyChessAI.show.v = new ReferenceData<FairyChess.FairyChessAI>(fairyChessAI);
											// compare
											editFairyChessAI.compare.v = new ReferenceData<FairyChess.FairyChessAI> ((FairyChess.FairyChessAI)editAI.compare.v.data);
											// compareOtherType
											editFairyChessAI.compareOtherType.v = new ReferenceData<Data>(editAI.compareOtherType.v.data);
											// canEdit
											editFairyChessAI.canEdit.v = editAI.canEdit.v;
											// editType
											editFairyChessAI.editType.v = editAI.editType.v;
										} else {
											Debug.LogError ("editFairyChessAI null: " + this);
										}
									}
									this.data.sub.v = fairyChessAIUIData;
								}
								break;

							case GameType.Type.Xiangqi:
								{
									Xiangqi.XiangqiAI xiangqiAI = show as Xiangqi.XiangqiAI;
									// UIData
									Xiangqi.XiangqiAIUI.UIData xiangqiAIUIData = this.data.sub.newOrOld<Xiangqi.XiangqiAIUI.UIData> ();
									{
										EditData<Xiangqi.XiangqiAI> editXiangqiAI = xiangqiAIUIData.editAI.v;
										if (editXiangqiAI != null) {
											// origin
											editXiangqiAI.origin.v = new ReferenceData<Xiangqi.XiangqiAI>((Xiangqi.XiangqiAI)editAI.origin.v.data);
											// show
											editXiangqiAI.show.v = new ReferenceData<Xiangqi.XiangqiAI>(xiangqiAI);
											// compare
											editXiangqiAI.compare.v = new ReferenceData<Xiangqi.XiangqiAI> ((Xiangqi.XiangqiAI)editAI.compare.v.data);
											// compareOtherType
											editXiangqiAI.compareOtherType.v = new ReferenceData<Data>(editAI.compareOtherType.v.data);
											// canEdit
											editXiangqiAI.canEdit.v = editAI.canEdit.v;
											// editType
											editXiangqiAI.editType.v = editAI.editType.v;
										} else {
											Debug.LogError ("editReversiAI null: " + this);
										}
									}
									this.data.sub.v = xiangqiAIUIData;
								}
								break;
							case GameType.Type.CO_TUONG_UP:
								{
									CoTuongUp.CoTuongUpAI coTuongUpAI = show as CoTuongUp.CoTuongUpAI;
									// UIData
									CoTuongUp.CoTuongUpAIUI.UIData coTuongUpAIUIData = this.data.sub.newOrOld<CoTuongUp.CoTuongUpAIUI.UIData> ();
									{
										EditData<CoTuongUp.CoTuongUpAI> editCoTuongUpAI = coTuongUpAIUIData.editCoTuongUpAI.v;
										if (editCoTuongUpAI != null) {
											// origin
											editCoTuongUpAI.origin.v = new ReferenceData<CoTuongUp.CoTuongUpAI>((CoTuongUp.CoTuongUpAI)editAI.origin.v.data);
											// show
											editCoTuongUpAI.show.v = new ReferenceData<CoTuongUp.CoTuongUpAI>(coTuongUpAI);
											// compare
											editCoTuongUpAI.compare.v = new ReferenceData<CoTuongUp.CoTuongUpAI> ((CoTuongUp.CoTuongUpAI)editAI.compare.v.data);
											// compareOtherType
											editCoTuongUpAI.compareOtherType.v = new ReferenceData<Data>(editAI.compareOtherType.v.data);
											// canEdit
											editCoTuongUpAI.canEdit.v = editAI.canEdit.v;
											// editType
											editCoTuongUpAI.editType.v = editAI.editType.v;
										} else {
											Debug.LogError ("editCoTuongUpAI null: " + this);
										}
									}
									this.data.sub.v = coTuongUpAIUIData;
								}
								break;
							case GameType.Type.Janggi:
								{
									Janggi.JanggiAI janggiAI = show as Janggi.JanggiAI;
									// UIData
									Janggi.JanggiAIUI.UIData janggiAIUIData = this.data.sub.newOrOld<Janggi.JanggiAIUI.UIData> ();
									{
										EditData<Janggi.JanggiAI> editJanggiAI = janggiAIUIData.editAI.v;
										if (editJanggiAI != null) {
											// origin
											editJanggiAI.origin.v = new ReferenceData<Janggi.JanggiAI>((Janggi.JanggiAI)editAI.origin.v.data);
											// show
											editJanggiAI.show.v = new ReferenceData<Janggi.JanggiAI>(janggiAI);
											// compare
											editJanggiAI.compare.v = new ReferenceData<Janggi.JanggiAI> ((Janggi.JanggiAI)editAI.compare.v.data);
											// compareOtherType
											editJanggiAI.compareOtherType.v = new ReferenceData<Data>(editAI.compareOtherType.v.data);
											// canEdit
											editJanggiAI.canEdit.v = editAI.canEdit.v;
											// editType
											editJanggiAI.editType.v = editAI.editType.v;
										} else {
											Debug.LogError ("editJanggiAI null: " + this);
										}
									}
									this.data.sub.v = janggiAIUIData;
								}
								break;
							case GameType.Type.Banqi:
								{
									Banqi.BanqiAI banqiAI = show as Banqi.BanqiAI;
									// UIData
									Banqi.BanqiAIUI.UIData banqiAIUIData = this.data.sub.newOrOld<Banqi.BanqiAIUI.UIData> ();
									{
										EditData<Banqi.BanqiAI> editBanqiAI = banqiAIUIData.editAI.v;
										if (editBanqiAI != null) {
											// origin
											editBanqiAI.origin.v = new ReferenceData<Banqi.BanqiAI>((Banqi.BanqiAI)editAI.origin.v.data);
											// show
											editBanqiAI.show.v = new ReferenceData<Banqi.BanqiAI>(banqiAI);
											// compare
											editBanqiAI.compare.v = new ReferenceData<Banqi.BanqiAI> ((Banqi.BanqiAI)editAI.compare.v.data);
											// compareOtherType
											editBanqiAI.compareOtherType.v = new ReferenceData<Data>(editAI.compareOtherType.v.data);
											// canEdit
											editBanqiAI.canEdit.v = editAI.canEdit.v;
											// editType
											editBanqiAI.editType.v = editAI.editType.v;
										} else {
											Debug.LogError ("editBanqiAI null: " + this);
										}
									}
									this.data.sub.v = banqiAIUIData;
								}
								break;
							case GameType.Type.Weiqi:
								{
									Weiqi.WeiqiAI weiqiAI = show as Weiqi.WeiqiAI;
									// UIData
									Weiqi.WeiqiAIUI.UIData weiqiAIUIData = this.data.sub.newOrOld<Weiqi.WeiqiAIUI.UIData> ();
									{
										EditData<Weiqi.WeiqiAI> editWeiqiAI = weiqiAIUIData.editAI.v;
										if (editWeiqiAI != null) {
											// origin
											editWeiqiAI.origin.v = new ReferenceData<Weiqi.WeiqiAI>((Weiqi.WeiqiAI)editAI.origin.v.data);
											// show
											editWeiqiAI.show.v = new ReferenceData<Weiqi.WeiqiAI>(weiqiAI);
											// compare
											editWeiqiAI.compare.v = new ReferenceData<Weiqi.WeiqiAI> ((Weiqi.WeiqiAI)editAI.compare.v.data);
											// compareOtherType
											editWeiqiAI.compareOtherType.v = new ReferenceData<Data>(editAI.compareOtherType.v.data);
											// canEdit
											editWeiqiAI.canEdit.v = editAI.canEdit.v;
											// editType
											editWeiqiAI.editType.v = editAI.editType.v;
										} else {
											Debug.LogError ("editWeiqiAI null: " + this);
										}
									}
									this.data.sub.v = weiqiAIUIData;
								}
								break;
							case GameType.Type.SHOGI:
								{
									Shogi.ShogiAI shogiAI = show as Shogi.ShogiAI;
									// UIData
									Shogi.ShogiAIUI.UIData shogiAIUIData = this.data.sub.newOrOld<Shogi.ShogiAIUI.UIData> ();
									{
										EditData<Shogi.ShogiAI> editShogiAI = shogiAIUIData.editAI.v;
										if (editShogiAI != null) {
											// origin
											editShogiAI.origin.v = new ReferenceData<Shogi.ShogiAI>((Shogi.ShogiAI)editAI.origin.v.data);
											// show
											editShogiAI.show.v = new ReferenceData<Shogi.ShogiAI>(shogiAI);
											// compare
											editShogiAI.compare.v = new ReferenceData<Shogi.ShogiAI> ((Shogi.ShogiAI)editAI.compare.v.data);
											// compareOtherType
											editShogiAI.compareOtherType.v = new ReferenceData<Data>(editAI.compareOtherType.v.data);
											// canEdit
											editShogiAI.canEdit.v = editAI.canEdit.v;
											// editType
											editShogiAI.editType.v = editAI.editType.v;
										} else {
											Debug.LogError ("editShogiAI null: " + this);
										}
									}
									this.data.sub.v = shogiAIUIData;
								}
								break;
							case GameType.Type.Reversi:
								{
									Reversi.ReversiAI reversiAI = show as Reversi.ReversiAI;
									// UIData
									Reversi.ReversiAIUI.UIData reversiAIUIData = this.data.sub.newOrOld<Reversi.ReversiAIUI.UIData> ();
									{
										EditData<Reversi.ReversiAI> editReversiAI = reversiAIUIData.editAI.v;
										if (editReversiAI != null) {
											// origin
											editReversiAI.origin.v = new ReferenceData<Reversi.ReversiAI>((Reversi.ReversiAI)editAI.origin.v.data);
											// show
											editReversiAI.show.v = new ReferenceData<Reversi.ReversiAI>(reversiAI);
											// compare
											editReversiAI.compare.v = new ReferenceData<Reversi.ReversiAI> ((Reversi.ReversiAI)editAI.compare.v.data);
											// compareOtherType
											editReversiAI.compareOtherType.v = new ReferenceData<Data>(editAI.compareOtherType.v.data);
											// canEdit
											editReversiAI.canEdit.v = editAI.canEdit.v;
											// editType
											editReversiAI.editType.v = editAI.editType.v;
										} else {
											Debug.LogError ("editReversiAI null: " + this);
										}
									}
									this.data.sub.v = reversiAIUIData;
								}
								break;
							case GameType.Type.Gomoku:
								{
									Gomoku.GomokuAI gomokuAI = show as Gomoku.GomokuAI;
									// UIData
									Gomoku.GomokuAIUI.UIData gomokuAIUIData = this.data.sub.newOrOld<Gomoku.GomokuAIUI.UIData> ();
									{
										EditData<Gomoku.GomokuAI> editGomokuAI = gomokuAIUIData.editAI.v;
										if (editGomokuAI != null) {
											// origin
											editGomokuAI.origin.v = new ReferenceData<Gomoku.GomokuAI>((Gomoku.GomokuAI)editAI.origin.v.data);
											// show
											editGomokuAI.show.v = new ReferenceData<Gomoku.GomokuAI>(gomokuAI);
											// compare
											editGomokuAI.compare.v = new ReferenceData<Gomoku.GomokuAI> ((Gomoku.GomokuAI)editAI.compare.v.data);
											// compareOtherType
											editGomokuAI.compareOtherType.v = new ReferenceData<Data>(editAI.compareOtherType.v.data);
											// canEdit
											editGomokuAI.canEdit.v = editAI.canEdit.v;
											// editType
											editGomokuAI.editType.v = editAI.editType.v;
										} else {
											Debug.LogError ("editGomokuAI null: " + this);
										}
									}
									this.data.sub.v = gomokuAIUIData;
								}
								break;
							case GameType.Type.InternationalDraught:
								{
									InternationalDraught.InternationalDraughtAI internationalDraughtAI = show as InternationalDraught.InternationalDraughtAI;
									// UIData
									InternationalDraught.InternationalDraughtAIUI.UIData internationalDraughtAIUIData = this.data.sub.newOrOld<InternationalDraught.InternationalDraughtAIUI.UIData> ();
									{
										EditData<InternationalDraught.InternationalDraughtAI> editInternationalDraughtAI = internationalDraughtAIUIData.editAI.v;
										if (editInternationalDraughtAI != null) {
											// origin
											editInternationalDraughtAI.origin.v = new ReferenceData<InternationalDraught.InternationalDraughtAI>((InternationalDraught.InternationalDraughtAI)editAI.origin.v.data);
											// show
											editInternationalDraughtAI.show.v = new ReferenceData<InternationalDraught.InternationalDraughtAI>(internationalDraughtAI);
											// compare
											editInternationalDraughtAI.compare.v = new ReferenceData<InternationalDraught.InternationalDraughtAI> ((InternationalDraught.InternationalDraughtAI)editAI.compare.v.data);
											// compareOtherType
											editInternationalDraughtAI.compareOtherType.v = new ReferenceData<Data>(editAI.compareOtherType.v.data);
											// canEdit
											editInternationalDraughtAI.canEdit.v = editAI.canEdit.v;
											// editType
											editInternationalDraughtAI.editType.v = editAI.editType.v;
										} else {
											Debug.LogError ("editInternationalDraughtAI null: " + this);
										}
									}
									this.data.sub.v = internationalDraughtAIUIData;
								}
								break;
							case GameType.Type.EnglishDraught:
								{
									EnglishDraught.EnglishDraughtAI englishDraughtAI = show as EnglishDraught.EnglishDraughtAI;
									// UIData
									EnglishDraught.EnglishDraughtAIUI.UIData englishDraughtAIUIData = this.data.sub.newOrOld<EnglishDraught.EnglishDraughtAIUI.UIData> ();
									{
										EditData<EnglishDraught.EnglishDraughtAI> editEnglishDraughtAI = englishDraughtAIUIData.editAI.v;
										if (editEnglishDraughtAI != null) {
											// origin
											editEnglishDraughtAI.origin.v = new ReferenceData<EnglishDraught.EnglishDraughtAI>((EnglishDraught.EnglishDraughtAI)editAI.origin.v.data);
											// show
											editEnglishDraughtAI.show.v = new ReferenceData<EnglishDraught.EnglishDraughtAI>(englishDraughtAI);
											// compare
											editEnglishDraughtAI.compare.v = new ReferenceData<EnglishDraught.EnglishDraughtAI> ((EnglishDraught.EnglishDraughtAI)editAI.compare.v.data);
											// compareOtherType
											editEnglishDraughtAI.compareOtherType.v = new ReferenceData<Data>(editAI.compareOtherType.v.data);
											// canEdit
											editEnglishDraughtAI.canEdit.v = editAI.canEdit.v;
											// editType
											editEnglishDraughtAI.editType.v = editAI.editType.v;
										} else {
											Debug.LogError ("editEnglishDraughtAI null: " + this);
										}
									}
									this.data.sub.v = englishDraughtAIUIData;
								}
								break;
							case GameType.Type.RussianDraught:
								{
									RussianDraught.RussianDraughtAI russianDraughtAI = show as RussianDraught.RussianDraughtAI;
									// UIData
									RussianDraught.RussianDraughtAIUI.UIData russianDraughtAIUIData = this.data.sub.newOrOld<RussianDraught.RussianDraughtAIUI.UIData> ();
									{
										EditData<RussianDraught.RussianDraughtAI> editRussianDraughtAI = russianDraughtAIUIData.editAI.v;
										if (editRussianDraughtAI != null) {
											// origin
											editRussianDraughtAI.origin.v = new ReferenceData<RussianDraught.RussianDraughtAI>((RussianDraught.RussianDraughtAI)editAI.origin.v.data);
											// show
											editRussianDraughtAI.show.v = new ReferenceData<RussianDraught.RussianDraughtAI>(russianDraughtAI);
											// compare
											editRussianDraughtAI.compare.v = new ReferenceData<RussianDraught.RussianDraughtAI> ((RussianDraught.RussianDraughtAI)editAI.compare.v.data);
											// compareOtherType
											editRussianDraughtAI.compareOtherType.v = new ReferenceData<Data>(editAI.compareOtherType.v.data);
											// canEdit
											editRussianDraughtAI.canEdit.v = editAI.canEdit.v;
											// editType
											editRussianDraughtAI.editType.v = editAI.editType.v;
										} else {
											Debug.LogError ("editRussianDraughtAI null: " + this);
										}
									}
									this.data.sub.v = russianDraughtAIUIData;
								}
								break;

							case GameType.Type.MineSweeper:
								{
									MineSweeper.MineSweeperAI mineSweeperAI = show as MineSweeper.MineSweeperAI;
									// UIData
									MineSweeper.MineSweeperAIUI.UIData mineSweeperAIUIData = this.data.sub.newOrOld<MineSweeper.MineSweeperAIUI.UIData> ();
									{
										EditData<MineSweeper.MineSweeperAI> editMineSweeperAI = mineSweeperAIUIData.editAI.v;
										if (editMineSweeperAI != null) {
											// origin
											editMineSweeperAI.origin.v = new ReferenceData<MineSweeper.MineSweeperAI>((MineSweeper.MineSweeperAI)editAI.origin.v.data);
											// show
											editMineSweeperAI.show.v = new ReferenceData<MineSweeper.MineSweeperAI>(mineSweeperAI);
											// compare
											editMineSweeperAI.compare.v = new ReferenceData<MineSweeper.MineSweeperAI> ((MineSweeper.MineSweeperAI)editAI.compare.v.data);
											// compareOtherType
											editMineSweeperAI.compareOtherType.v = new ReferenceData<Data>(editAI.compareOtherType.v.data);
											// canEdit
											editMineSweeperAI.canEdit.v = editAI.canEdit.v;
											// editType
											editMineSweeperAI.editType.v = editAI.editType.v;
										} else {
											Debug.LogError ("editMineSweeperAI null: " + this);
										}
									}
									this.data.sub.v = mineSweeperAIUIData;
								}
								break;
							case GameType.Type.Hex:
								{
									HEX.HexAI hexAI = show as HEX.HexAI;
									// UIData
									HEX.HexAIUI.UIData hexAIUIData = this.data.sub.newOrOld<HEX.HexAIUI.UIData> ();
									{
										EditData<HEX.HexAI> editHexAI = hexAIUIData.editAI.v;
										if (editHexAI != null) {
											// origin
											editHexAI.origin.v = new ReferenceData<HEX.HexAI>((HEX.HexAI)editAI.origin.v.data);
											// show
											editHexAI.show.v = new ReferenceData<HEX.HexAI>(hexAI);
											// compare
											editHexAI.compare.v = new ReferenceData<HEX.HexAI> ((HEX.HexAI)editAI.compare.v.data);
											// compareOtherType
											editHexAI.compareOtherType.v = new ReferenceData<Data>(editAI.compareOtherType.v.data);
											// canEdit
											editHexAI.canEdit.v = editAI.canEdit.v;
											// editType
											editHexAI.editType.v = editAI.editType.v;
										} else {
											Debug.LogError ("editHexAI null: " + this);
										}
									}
									this.data.sub.v = hexAIUIData;
								}
								break;
							case GameType.Type.Solitaire:
								{
									Solitaire.SolitaireAI solitaireAI = show as Solitaire.SolitaireAI;
									// UIData
									Solitaire.SolitaireAIUI.UIData solitaireAIUIData = this.data.sub.newOrOld<Solitaire.SolitaireAIUI.UIData> ();
									{
										EditData<Solitaire.SolitaireAI> editSolitaireAI = solitaireAIUIData.editAI.v;
										if (editSolitaireAI != null) {
											// origin
											editSolitaireAI.origin.v = new ReferenceData<Solitaire.SolitaireAI>((Solitaire.SolitaireAI)editAI.origin.v.data);
											// show
											editSolitaireAI.show.v = new ReferenceData<Solitaire.SolitaireAI>(solitaireAI);
											// compare
											editSolitaireAI.compare.v = new ReferenceData<Solitaire.SolitaireAI> ((Solitaire.SolitaireAI)editAI.compare.v.data);
											// compareOtherType
											editSolitaireAI.compareOtherType.v = new ReferenceData<Data>(editAI.compareOtherType.v.data);
											// canEdit
											editSolitaireAI.canEdit.v = editAI.canEdit.v;
											// editType
											editSolitaireAI.editType.v = editAI.editType.v;
										} else {
											Debug.LogError ("editSolitaireAI null: " + this);
										}
									}
									this.data.sub.v = solitaireAIUIData;
								}
								break;
							case GameType.Type.Sudoku:
								{
									Sudoku.SudokuAI sudokuAI = show as Sudoku.SudokuAI;
									// UIData
									Sudoku.SudokuAIUI.UIData sudokuAIUIData = this.data.sub.newOrOld<Sudoku.SudokuAIUI.UIData> ();
									{
										EditData<Sudoku.SudokuAI> editSudokuAI = sudokuAIUIData.editAI.v;
										if (editSudokuAI != null) {
											// origin
											editSudokuAI.origin.v = new ReferenceData<Sudoku.SudokuAI>((Sudoku.SudokuAI)editAI.origin.v.data);
											// show
											editSudokuAI.show.v = new ReferenceData<Sudoku.SudokuAI>(sudokuAI);
											// compare
											editSudokuAI.compare.v = new ReferenceData<Sudoku.SudokuAI> ((Sudoku.SudokuAI)editAI.compare.v.data);
											// compareOtherType
											editSudokuAI.compareOtherType.v = new ReferenceData<Data>(editAI.compareOtherType.v.data);
											// canEdit
											editSudokuAI.canEdit.v = editAI.canEdit.v;
											// editType
											editSudokuAI.editType.v = editAI.editType.v;
										} else {
											Debug.LogError ("editSudokuAI null: " + this);
										}
									}
									this.data.sub.v = sudokuAIUIData;
								}
								break;
							case GameType.Type.Khet:
								{
									Khet.KhetAI khetAI = show as Khet.KhetAI;
									// UIData
									Khet.KhetAIUI.UIData khetAIUIData = this.data.sub.newOrOld<Khet.KhetAIUI.UIData> ();
									{
										EditData<Khet.KhetAI> editKhetAI = khetAIUIData.editAI.v;
										if (editKhetAI != null) {
											// origin
											editKhetAI.origin.v = new ReferenceData<Khet.KhetAI>((Khet.KhetAI)editAI.origin.v.data);
											// show
											editKhetAI.show.v = new ReferenceData<Khet.KhetAI>(khetAI);
											// compare
											editKhetAI.compare.v = new ReferenceData<Khet.KhetAI> ((Khet.KhetAI)editAI.compare.v.data);
											// compareOtherType
											editKhetAI.compareOtherType.v = new ReferenceData<Data>(editAI.compareOtherType.v.data);
											// canEdit
											editKhetAI.canEdit.v = editAI.canEdit.v;
											// editType
											editKhetAI.editType.v = editAI.editType.v;
										} else {
											Debug.LogError ("editKhetAI null: " + this);
										}
									}
									this.data.sub.v = khetAIUIData;
								}
								break;
							case GameType.Type.NineMenMorris:
								{
									NineMenMorris.NineMenMorrisAI nineMenMorrisAI = show as NineMenMorris.NineMenMorrisAI;
									// UIData
									NineMenMorris.NineMenMorrisAIUI.UIData nineMenMorrisAIUIData = this.data.sub.newOrOld<NineMenMorris.NineMenMorrisAIUI.UIData> ();
									{
										EditData<NineMenMorris.NineMenMorrisAI> editNineMenMorrisAI = nineMenMorrisAIUIData.editAI.v;
										if (editNineMenMorrisAI != null) {
											// origin
											editNineMenMorrisAI.origin.v = new ReferenceData<NineMenMorris.NineMenMorrisAI>((NineMenMorris.NineMenMorrisAI)editAI.origin.v.data);
											// show
											editNineMenMorrisAI.show.v = new ReferenceData<NineMenMorris.NineMenMorrisAI>(nineMenMorrisAI);
											// compare
											editNineMenMorrisAI.compare.v = new ReferenceData<NineMenMorris.NineMenMorrisAI> ((NineMenMorris.NineMenMorrisAI)editAI.compare.v.data);
											// compareOtherType
											editNineMenMorrisAI.compareOtherType.v = new ReferenceData<Data>(editAI.compareOtherType.v.data);
											// canEdit
											editNineMenMorrisAI.canEdit.v = editAI.canEdit.v;
											// editType
											editNineMenMorrisAI.editType.v = editAI.editType.v;
										} else {
											Debug.LogError ("editNineMenMorrisAI null: " + this);
										}
									}
									this.data.sub.v = nineMenMorrisAIUIData;
								}
								break;
							default:
								Debug.LogError ("unknown type: " + show.getType () + "; " + this);
								break;
							}
						} else {
							Debug.LogError ("ai null: " + this);
						}
					}
				} else {
					Debug.LogError ("editAI null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}
	}

	public override bool isShouldDisableUpdate ()
	{
		return true;
	}

	#endregion

	#region implement callBacks

	public Chess.ChessAIUI chessPrefab;
	public Shatranj.ShatranjAIUI shatranjPrefab;
	public Makruk.MakrukAIUI makrukPrefab;
	public Seirawan.SeirawanAIUI seirawanPrefab;
	public FairyChess.FairyChessAIUI fairyChessPrefab;

	public Xiangqi.XiangqiAIUI xiangqiPrefab;
	public CoTuongUp.CoTuongUpAIUI coTuongUpPrefab;
	public Janggi.JanggiAIUI janggiPrefab;
	public Banqi.BanqiAIUI banqiPrefab;

	public Weiqi.WeiqiAIUI weiqiPrefab;
	public Shogi.ShogiAIUI shogiPrefab;
	public Reversi.ReversiAIUI reversiPrefab;
	public Gomoku.GomokuAIUI gomokuPrefab;

	public InternationalDraught.InternationalDraughtAIUI internationalDraughtPrefab;
	public EnglishDraught.EnglishDraughtAIUI englishDraughtPrefab;
	public RussianDraught.RussianDraughtAIUI russianDraughtPrefab;

	public MineSweeper.MineSweeperAIUI mineSweeperPrefab;
	public HEX.HexAIUI hexPrefab;
	public Solitaire.SolitaireAIUI solitairePrefab;

	public Sudoku.SudokuAIUI sudokuPrefab;
	public Khet.KhetAIUI khetPrefab;
	public NineMenMorris.NineMenMorrisAIUI nineMenMorrisPrefab;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.editAI.allAddCallBack (this);
				uiData.sub.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			if (data is EditData<Computer.AI>) {
				dirty = true;
				return;
			}
			if (data is UIData.Sub) {
				UIData.Sub sub = data as UIData.Sub;
				// UI
				{
					switch (sub.getType ()) {
					case GameType.Type.CHESS:
						{
							Chess.ChessAIUI.UIData chessAIUIData = sub as Chess.ChessAIUI.UIData;
							UIUtils.Instantiate (chessAIUIData, chessPrefab, this.transform);
						}
						break;
					case GameType.Type.Shatranj:
						{
							Shatranj.ShatranjAIUI.UIData shatranjAIUIData = sub as Shatranj.ShatranjAIUI.UIData;
							UIUtils.Instantiate (shatranjAIUIData, shatranjPrefab, this.transform);
						}
						break;
					case GameType.Type.Makruk:
						{
							Makruk.MakrukAIUI.UIData makrukAIUIData = sub as Makruk.MakrukAIUI.UIData;
							UIUtils.Instantiate (makrukAIUIData, makrukPrefab, this.transform);
						}
						break;
					case GameType.Type.Seirawan:
						{
							Seirawan.SeirawanAIUI.UIData seirawanAIUIData = sub as Seirawan.SeirawanAIUI.UIData;
							UIUtils.Instantiate (seirawanAIUIData, seirawanPrefab, this.transform);
						}
						break;
					case GameType.Type.FairyChess:
						{
							FairyChess.FairyChessAIUI.UIData fairyChessAIUIData = sub as FairyChess.FairyChessAIUI.UIData;
							UIUtils.Instantiate (fairyChessAIUIData, fairyChessPrefab, this.transform);
						}
						break;

					case GameType.Type.Xiangqi:
						{
							Xiangqi.XiangqiAIUI.UIData xiangqiAIUIData = sub as Xiangqi.XiangqiAIUI.UIData;
							UIUtils.Instantiate (xiangqiAIUIData, xiangqiPrefab, this.transform);
						}
						break;
					case GameType.Type.CO_TUONG_UP:
						{
							CoTuongUp.CoTuongUpAIUI.UIData coTuongUpAIUIData = sub as CoTuongUp.CoTuongUpAIUI.UIData;
							UIUtils.Instantiate (coTuongUpAIUIData, coTuongUpPrefab, this.transform);
						}
						break;
					case GameType.Type.Janggi:
						{
							Janggi.JanggiAIUI.UIData janggiAIUIData = sub as Janggi.JanggiAIUI.UIData;
							UIUtils.Instantiate (janggiAIUIData, janggiPrefab, this.transform);
						}
						break;
					case GameType.Type.Banqi:
						{
							Banqi.BanqiAIUI.UIData banqiAIUIData = sub as Banqi.BanqiAIUI.UIData;
							UIUtils.Instantiate (banqiAIUIData, banqiPrefab, this.transform);
						}
						break;

					case GameType.Type.Weiqi:
						{
							Weiqi.WeiqiAIUI.UIData weiqiAIUIData = sub as Weiqi.WeiqiAIUI.UIData;
							UIUtils.Instantiate (weiqiAIUIData, weiqiPrefab, this.transform);
						}
						break;
					case GameType.Type.SHOGI:
						{
							Shogi.ShogiAIUI.UIData shogiAIUIData = sub as Shogi.ShogiAIUI.UIData;
							UIUtils.Instantiate (shogiAIUIData, shogiPrefab, this.transform);
						}
						break;
					case GameType.Type.Reversi:
						{
							Reversi.ReversiAIUI.UIData reversiAIUIData = sub as Reversi.ReversiAIUI.UIData;
							UIUtils.Instantiate (reversiAIUIData, reversiPrefab, this.transform);
						}
						break;
					case GameType.Type.Gomoku:
						{
							Gomoku.GomokuAIUI.UIData gomokuAIUIData = sub as Gomoku.GomokuAIUI.UIData;
							UIUtils.Instantiate (gomokuAIUIData, gomokuPrefab, this.transform);
						}
						break;

					case GameType.Type.InternationalDraught:
						{
							InternationalDraught.InternationalDraughtAIUI.UIData internationalDraughtAIUIData = sub as InternationalDraught.InternationalDraughtAIUI.UIData;
							UIUtils.Instantiate (internationalDraughtAIUIData, internationalDraughtPrefab, this.transform);
						}
						break;
					case GameType.Type.EnglishDraught:
						{
							EnglishDraught.EnglishDraughtAIUI.UIData englishDraughtAIUIData = sub as EnglishDraught.EnglishDraughtAIUI.UIData;
							UIUtils.Instantiate (englishDraughtAIUIData, englishDraughtPrefab, this.transform);
						}
						break;
					case GameType.Type.RussianDraught:
						{
							RussianDraught.RussianDraughtAIUI.UIData russianDraughtAIUIData = sub as RussianDraught.RussianDraughtAIUI.UIData;
							UIUtils.Instantiate (russianDraughtAIUIData, russianDraughtPrefab, this.transform);
						}
						break;

					case GameType.Type.MineSweeper:
						{
							MineSweeper.MineSweeperAIUI.UIData mineSweeperAIUIData = sub as MineSweeper.MineSweeperAIUI.UIData;
							UIUtils.Instantiate (mineSweeperAIUIData, mineSweeperPrefab, this.transform);
						}
						break;
					case GameType.Type.Hex:
						{
							HEX.HexAIUI.UIData hexAIUIData = sub as HEX.HexAIUI.UIData;
							UIUtils.Instantiate (hexAIUIData, hexPrefab, this.transform);
						}
						break;
					case GameType.Type.Solitaire:
						{
							Solitaire.SolitaireAIUI.UIData solitaireAIUIData = sub as Solitaire.SolitaireAIUI.UIData;
							UIUtils.Instantiate (solitaireAIUIData, solitairePrefab, this.transform);
						}
						break;

					case GameType.Type.Sudoku:
						{
							Sudoku.SudokuAIUI.UIData sudokuAIUIData = sub as Sudoku.SudokuAIUI.UIData;
							UIUtils.Instantiate (sudokuAIUIData, sudokuPrefab, this.transform);
						}
						break;
					case GameType.Type.Khet:
						{
							Khet.KhetAIUI.UIData khetAIUIData = sub as Khet.KhetAIUI.UIData;
							UIUtils.Instantiate (khetAIUIData, khetPrefab, this.transform);
						}
						break;
					case GameType.Type.NineMenMorris:
						{
							NineMenMorris.NineMenMorrisAIUI.UIData nineMenMorrisAIUIData = sub as NineMenMorris.NineMenMorrisAIUI.UIData;
							UIUtils.Instantiate (nineMenMorrisAIUIData, nineMenMorrisPrefab, this.transform);
						}
						break;
					default:
						Debug.LogError ("unknown type: " + sub.getType () + "; " + this);
						break;
					}
				}
				dirty = true;
				return;
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.editAI.allRemoveCallBack (this);
				uiData.sub.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		{
			if (data is EditData<Computer.AI>) {
				return;
			}
			if (data is UIData.Sub) {
				UIData.Sub sub = data as UIData.Sub;
				// UI
				{
					switch (sub.getType ()) {
					case GameType.Type.CHESS:
						{
							Chess.ChessAIUI.UIData chessAIUIData = sub as Chess.ChessAIUI.UIData;
							chessAIUIData.removeCallBackAndDestroy (typeof(Chess.ChessAIUI));
						}
						break;
					case GameType.Type.Shatranj:
						{
							Shatranj.ShatranjAIUI.UIData shatranjAIUIData = sub as Shatranj.ShatranjAIUI.UIData;
							shatranjAIUIData.removeCallBackAndDestroy (typeof(Shatranj.ShatranjAIUI));
						}
						break;
					case GameType.Type.Makruk:
						{
							Makruk.MakrukAIUI.UIData makrukAIUIData = sub as Makruk.MakrukAIUI.UIData;
							makrukAIUIData.removeCallBackAndDestroy (typeof(Makruk.MakrukAIUI));
						}
						break;
					case GameType.Type.Seirawan:
						{
							Seirawan.SeirawanAIUI.UIData seirawanAIUIData = sub as Seirawan.SeirawanAIUI.UIData;
							seirawanAIUIData.removeCallBackAndDestroy (typeof(Seirawan.SeirawanAIUI));
						}
						break;
					case GameType.Type.FairyChess:
						{
							FairyChess.FairyChessAIUI.UIData fairyChessAIUIData = sub as FairyChess.FairyChessAIUI.UIData;
							fairyChessAIUIData.removeCallBackAndDestroy (typeof(FairyChess.FairyChessAIUI));
						}
						break;

					case GameType.Type.Xiangqi:
						{
							Xiangqi.XiangqiAIUI.UIData xiangqiAIUIData = sub as Xiangqi.XiangqiAIUI.UIData;
							xiangqiAIUIData.removeCallBackAndDestroy (typeof(Xiangqi.XiangqiAIUI));
						}
						break;
					case GameType.Type.CO_TUONG_UP:
						{
							CoTuongUp.CoTuongUpAIUI.UIData coTuongUpAIUIData = sub as CoTuongUp.CoTuongUpAIUI.UIData;
							coTuongUpAIUIData.removeCallBackAndDestroy (typeof(CoTuongUp.CoTuongUpAIUI));
						}
						break;
					case GameType.Type.Janggi:
						{
							Janggi.JanggiAIUI.UIData janggiAIUIData = sub as Janggi.JanggiAIUI.UIData;
							janggiAIUIData.removeCallBackAndDestroy (typeof(Janggi.JanggiAIUI));
						}
						break;
					case GameType.Type.Banqi:
						{
							Banqi.BanqiAIUI.UIData banqiAIUIData = sub as Banqi.BanqiAIUI.UIData;
							banqiAIUIData.removeCallBackAndDestroy (typeof(Banqi.BanqiAIUI));
						}
						break;

					case GameType.Type.Weiqi:
						{
							Weiqi.WeiqiAIUI.UIData weiqiAIUIData = sub as Weiqi.WeiqiAIUI.UIData;
							weiqiAIUIData.removeCallBackAndDestroy (typeof(Weiqi.WeiqiAIUI));
						}
						break;
					case GameType.Type.SHOGI:
						{
							Shogi.ShogiAIUI.UIData shogiAIUIData = sub as Shogi.ShogiAIUI.UIData;
							shogiAIUIData.removeCallBackAndDestroy(typeof(Shogi.ShogiAIUI));
						}
						break;
					case GameType.Type.Reversi:
						{
							Reversi.ReversiAIUI.UIData reversiAIUIData = sub as Reversi.ReversiAIUI.UIData;
							reversiAIUIData.removeCallBackAndDestroy (typeof(Reversi.ReversiAIUI));
						}
						break;
					case GameType.Type.Gomoku:
						{
							Gomoku.GomokuAIUI.UIData gomokuAIUIData = sub as Gomoku.GomokuAIUI.UIData;
							gomokuAIUIData.removeCallBackAndDestroy (typeof(Gomoku.GomokuAIUI));
						}
						break;

					case GameType.Type.InternationalDraught:
						{
							InternationalDraught.InternationalDraughtAIUI.UIData internationalDraughtAIUIData = sub as InternationalDraught.InternationalDraughtAIUI.UIData;
							internationalDraughtAIUIData.removeCallBackAndDestroy (typeof(InternationalDraught.InternationalDraughtAIUI));
						}
						break;
					case GameType.Type.EnglishDraught:
						{
							EnglishDraught.EnglishDraughtAIUI.UIData englishDraughtAIUIData = sub as EnglishDraught.EnglishDraughtAIUI.UIData;
							englishDraughtAIUIData.removeCallBackAndDestroy (typeof(EnglishDraught.EnglishDraughtAIUI));
						}
						break;
					case GameType.Type.RussianDraught:
						{
							RussianDraught.RussianDraughtAIUI.UIData russianDraughtAIUIData = sub as RussianDraught.RussianDraughtAIUI.UIData;
							russianDraughtAIUIData.removeCallBackAndDestroy (typeof(RussianDraught.RussianDraughtAIUI));
						}
						break;

					case GameType.Type.MineSweeper:
						{
							MineSweeper.MineSweeperAIUI.UIData mineSweeperAIUIData = sub as MineSweeper.MineSweeperAIUI.UIData;
							mineSweeperAIUIData.removeCallBackAndDestroy (typeof(MineSweeper.MineSweeperAIUI));
						}
						break;
					case GameType.Type.Hex:
						{
							HEX.HexAIUI.UIData hexAIUIData = sub as HEX.HexAIUI.UIData;
							hexAIUIData.removeCallBackAndDestroy (typeof(HEX.HexAIUI));
						}
						break;
					case GameType.Type.Solitaire:
						{
							Solitaire.SolitaireAIUI.UIData solitaireAIUIData = sub as Solitaire.SolitaireAIUI.UIData;
							solitaireAIUIData.removeCallBackAndDestroy (typeof(Solitaire.SolitaireAIUI));
						}
						break;

					case GameType.Type.Sudoku:
						{
							Sudoku.SudokuAIUI.UIData sudokuAIUIData = sub as Sudoku.SudokuAIUI.UIData;
							sudokuAIUIData.removeCallBackAndDestroy (typeof(Sudoku.SudokuAIUI));
						}
						break;
					case GameType.Type.Khet:
						{
							Khet.KhetAIUI.UIData khetAIUIData = sub as Khet.KhetAIUI.UIData;
							khetAIUIData.removeCallBackAndDestroy (typeof(Khet.KhetAIUI));
						}
						break;
					case GameType.Type.NineMenMorris:
						{
							NineMenMorris.NineMenMorrisAIUI.UIData nineMenMorrisAIUIData = sub as NineMenMorris.NineMenMorrisAIUI.UIData;
							nineMenMorrisAIUIData.removeCallBackAndDestroy (typeof(NineMenMorris.NineMenMorrisAIUI));
						}
						break;
					default:
						Debug.LogError ("unknown type: " + sub.getType () + "; " + this);
						break;
					}
				}
				return;
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is UIData) {
			switch ((UIData.Property)wrapProperty.n) {
			case UIData.Property.editAI:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.sub:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// Child
		{
			if (wrapProperty.p is EditData<Computer.AI>) {
				switch ((EditData<Computer.AI>.Property)wrapProperty.n) {
				case EditData<Computer.AI>.Property.origin:
					dirty = true;
					break;
				case EditData<Computer.AI>.Property.show:
					dirty = true;
					break;
				case EditData<Computer.AI>.Property.compare:
					dirty = true;
					break;
				case EditData<Computer.AI>.Property.compareOtherType:
					dirty = true;
					break;
				case EditData<Computer.AI>.Property.canEdit:
					dirty = true;
					break;
				case EditData<Computer.AI>.Property.editType:
					dirty = true;
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			if (wrapProperty.p is UIData.Sub) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}