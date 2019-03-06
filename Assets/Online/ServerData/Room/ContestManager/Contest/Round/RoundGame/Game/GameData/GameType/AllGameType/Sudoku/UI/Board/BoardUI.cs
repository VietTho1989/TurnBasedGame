using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Sudoku
{
	public class BoardUI : UIBehavior<BoardUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			public VP<ReferenceData<Sudoku>> sudoku;

			public LP<PieceUI.UIData> pieces;

			#region Constructor

			public enum Property
			{
				sudoku,
				pieces
			}

			public UIData() : base()
			{
				this.sudoku = new VP<ReferenceData<Sudoku>>(this, (byte)Property.sudoku, new ReferenceData<Sudoku>(null));
				this.pieces = new LP<PieceUI.UIData>(this, (byte)Property.pieces);
			}

			#endregion

		}

		#endregion

		#region Refresh

		#region txt

		public Text tvCannotSolve;
		public static readonly TxtLanguage txtCannotSolve = new TxtLanguage ();

		static BoardUI()
		{
			txtCannotSolve.add (Language.Type.vi, "Không Thể Giải Được");
		}

		#endregion

		public GameObject cannotSolveIndicator;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					Sudoku sudoku = this.data.sudoku.v.data;
					if (sudoku != null) {
						// check load full
						bool isLoadFull = true;
						{
							// sudoku
							if (isLoadFull) {
								isLoadFull = sudoku.isLoadFull ();
							}
							// animation
							if (isLoadFull) {
								isLoadFull = AnimationManager.IsLoadFull (this.data);
							}
						}
						// process
						if (isLoadFull) {
							// pieces
							{
								// get old
								List<PieceUI.UIData> oldPieces = new List<PieceUI.UIData> ();
								{
									oldPieces.AddRange (this.data.pieces.vs);
								}
								// update
								{
									for (int y = 0; y < 9; y++)
										for (int x = 0; x < 9; x++) {
											// find piece
											PieceUI.UIData pieceUIData = null;
											bool needAdd = false;
											{
												// find old
												foreach (PieceUI.UIData check in oldPieces) {
													if (check.x.v == x && check.y.v == y) {
														pieceUIData = check;
														break;
													}
												}
												// make new
												if (pieceUIData == null) {
													pieceUIData = new PieceUI.UIData ();
													{
														pieceUIData.uid = this.data.pieces.makeId ();
													}
													needAdd = true;
												} else {
													oldPieces.Remove (pieceUIData);
												}
											}
											// update
											{
												pieceUIData.x.v = x;
												pieceUIData.y.v = y;
												// board
												{
													byte board = 0;
													{
														int index = 9 * y + x;
														if (index >= 0 && index < sudoku.board.vs.Count) {
															board = sudoku.board.vs [index];
														} else {
															Debug.LogError ("index error: " + index + ", " + sudoku.board.vs.Count);
														}
													}
													pieceUIData.board.v = board;
												}
												// userSolve
												{
													byte userSolve = 0;
													{
														int index = 9 * y + x;
														if (index >= 0 && index < sudoku.userSolve.vs.Count) {
															userSolve = sudoku.userSolve.vs [index];
														} else {
															// Debug.LogError ("index error: " + index + ", " + sudoku.userSolve.vs.Count);
														}
													}
													pieceUIData.userSolve.v = userSolve;
												}
											}
											// add
											if (needAdd) {
												this.data.pieces.add (pieceUIData);
											}
										}
								}
								// remove old
								foreach (PieceUI.UIData oldPiece in oldPieces) {
									this.data.pieces.remove (oldPiece);
								}
							}
							// cannotSolve
							if (cannotSolveIndicator != null) {
								bool canSolve = true;
								{
									AISolve aiSolve = sudoku.aiSolve.v;
									if (aiSolve != null) {
										if (aiSolve.getType () == AISolve.Type.HaveSove) {
											AIHaveSolve aiHaveSolve = aiSolve as AIHaveSolve;
											if (aiHaveSolve.board.vs.Count < 81) {
												canSolve = false;
											}
										}
									} else {
										Debug.LogError ("aiSolve null");
									}
								}
								cannotSolveIndicator.SetActive (!canSolve);
							} else {
								Debug.LogError ("cannotSolveIndicator null");
							}
							// txt
							{
								if (tvCannotSolve != null) {
									tvCannotSolve.text = txtCannotSolve.get ("Cannot Solve");
								} else {
									Debug.LogError ("tvCannotSolve null");
								}
							}
						} else {
							Debug.LogError ("not load full");
							dirty = true;
						}
					} else {
						// Debug.LogError ("sudoku null");
					}
				} else {
					// Debug.LogError ("sudoku null");
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return true;
		}

		#endregion

		#region implement callBacks

		private AnimationManagerCheckChange<UIData> animationManagerCheckChange = new AnimationManagerCheckChange<UIData> ();

		public PieceUI piecePrefab;
		public Transform pieceContainer;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// CheckChange
				{
					animationManagerCheckChange.needTimeChange = false;
					animationManagerCheckChange.addCallBack (this);
					animationManagerCheckChange.setData (uiData);
				}
				// Child
				{
					uiData.sudoku.allAddCallBack (this);
					uiData.pieces.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Setting
			if (data is Setting) {
				dirty = true;
				return;
			}
			// checkChange
			if (data is AnimationManagerCheckChange<UIData>) {
				dirty = true;
				return;
			}
			// Child
			{
				// sudoku
				{
					if (data is Sudoku) {
						Sudoku sudoku = data as Sudoku;
						// Child
						{
							sudoku.aiSolve.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					if (data is AISolve) {
						dirty = true;
						return;
					}
				}
				if (data is PieceUI.UIData) {
					PieceUI.UIData pieceUIData = data as PieceUI.UIData;
					// UI
					{
						UIUtils.Instantiate (pieceUIData, piecePrefab, pieceContainer);
					}
					// dirty = true;
					return;
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().removeCallBack(this);
				// CheckChange
				{
					animationManagerCheckChange.removeCallBack (this);
					animationManagerCheckChange.setData (null);
				}
				// Child
				{
					uiData.sudoku.allRemoveCallBack (this);
					uiData.pieces.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Setting
			if (data is Setting) {
				return;
			}
			// checkChange
			if (data is AnimationManagerCheckChange<UIData>) {
				return;
			}
			// Child
			{
				// sudoku
				{
					if (data is Sudoku) {
						Sudoku sudoku = data as Sudoku;
						// Child
						{
							sudoku.aiSolve.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					if (data is AISolve) {
						return;
					}
				}
				if (data is PieceUI.UIData) {
					PieceUI.UIData pieceUIData = data as PieceUI.UIData;
					// UI
					{
						pieceUIData.removeCallBackAndDestroy (typeof(PieceUI));
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
				case UIData.Property.sudoku:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.pieces:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						// dirty = true;
					}
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Setting
			if (wrapProperty.p is Setting) {
				switch ((Setting.Property)wrapProperty.n) {
				case Setting.Property.language:
					dirty = true;
					break;
				case Setting.Property.showLastMove:
					break;
				case Setting.Property.viewUrlImage:
					break;
				case Setting.Property.animationSetting:
					break;
				case Setting.Property.maxThinkCount:
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// checkChange
			if (wrapProperty.p is AnimationManagerCheckChange<UIData>) {
				dirty = true;
				return;
			}
			// Child
			{
				// sudoku
				{
					if (wrapProperty.p is Sudoku) {
						switch ((Sudoku.Property)wrapProperty.n) {
						case Sudoku.Property.board:
							dirty = true;
							break;
						case Sudoku.Property.userSolve:
							dirty = true;
							break;
						case Sudoku.Property.aiSolve:
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
					if (wrapProperty.p is AISolve) {
						AISolve aiSolve = wrapProperty.p as AISolve;
						switch (aiSolve.getType ()) {
						case AISolve.Type.NotSolve:
							break;
						case AISolve.Type.HaveSove:
							{
								switch ((AIHaveSolve.Property)wrapProperty.n) {
								case AIHaveSolve.Property.board:
									dirty = true;
									break;
								case AIHaveSolve.Property.order:
									break;
								default:
									Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
									break;
								}
							}
							break;
						default:
							Debug.LogError ("unknown type: " + aiSolve.getType () + "; " + this);
							break;
						}
						return;
					}
				}
				if (wrapProperty.p is PieceUI.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}