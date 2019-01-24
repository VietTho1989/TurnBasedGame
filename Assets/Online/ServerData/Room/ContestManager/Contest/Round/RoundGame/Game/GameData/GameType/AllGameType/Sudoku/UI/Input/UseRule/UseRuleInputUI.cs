using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace Sudoku
{
	public class UseRuleInputUI : UIBehavior<UseRuleInputUI.UIData>, IPointerDownHandler
	{

		#region UIData

		public class UIData : InputUI.UIData.Sub
		{

			public VP<ReferenceData<Sudoku>> sudoku;

			public VP<int> x;
			public VP<int> y;

			#region Constructor

			public enum Property
			{
				sudoku,
				x,
				y
			}

			public UIData() : base()
			{
				this.sudoku = new VP<ReferenceData<Sudoku>>(this, (byte)Property.sudoku, new ReferenceData<Sudoku>(null));
				this.x = new VP<int>(this, (byte)Property.x, -1);
				this.y = new VP<int>(this, (byte)Property.y, -1);
			}

			#endregion

			public override Type getType ()
			{
				return Type.UseRule;
			}

			public override bool processEvent (Event e)
			{
				bool isProcess = false;
				{

				}
				return isProcess;
			}

			public void reset()
			{
				this.x.v = -1;
				this.y.v = -1;
			}

		}

		#endregion

		#region Refresh

		public GameObject contentContainer;
		public InputField edtValue;

		public override void Awake ()
		{
			base.Awake ();
			if (edtValue != null) {
				edtValue.onEndEdit.AddListener (delegate {
					if(edtValue.gameObject.activeInHierarchy){
						if (this.data != null) {
							Sudoku sudoku = this.data.sudoku.v.data;
							if(sudoku!=null){
								string newValue = edtValue.text;
								int value = 0;
								if(int.TryParse(newValue, out value)){
									if(value>=0 && value<=9){
										// check can send input
										bool canSend = false;
										{
											if(this.data.x.v>=0 && this.data.x.v<9 && this.data.y.v>=0 && this.data.y.v<9){
												int index = 9*this.data.y.v+this.data.x.v;
												if(index>=0 && index<sudoku.board.vs.Count){
													if(sudoku.board.vs[index]==0){
														// find current value
														byte currentValue = 0;
														{
															if(index>=0 && index<sudoku.userSolve.vs.Count){
																currentValue = sudoku.userSolve.vs[index];
															}else{
																Debug.LogError("index userSolve error");
															}
														}
														// process
														if(currentValue!=value){
															canSend = true;
														}else{
															Debug.LogError("the same current value");
														}
													}
												}else{
													Debug.LogError("index error");
												}
											}else{
												Debug.LogError("outside board");
											}
										}
										// send
										if(canSend){
											ClientInput clientInput = InputUI.UIData.findClientInput(this.data);
											if(clientInput!=null){
												SudokuMove sudokuMove = new SudokuMove();
												{
													sudokuMove.x.v = (byte)this.data.x.v;
													sudokuMove.y.v = (byte)this.data.y.v;
													sudokuMove.value.v = (byte)value;
												}
												clientInput.makeSend(sudokuMove);
											}else{
												Debug.LogError("clientInput null");
											}
										}else{
											Debug.LogError("cannot send");
										}
									}else{
										Debug.LogError("value error");
									}
								}else{
									Debug.LogError("not int value: "+newValue);
								}
							}else{
								Debug.LogError("sudoku null");
							}
						} else {
							Debug.LogError ("data null: " + this);
						}
					} else {
						Debug.LogError("edtValue not active: " + this);
					}
				});
			} else {
				Debug.LogError ("edtValue null: " + this);
			}
		}

		private bool firstSet = true;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					Sudoku sudoku = this.data.sudoku.v.data;
					if (sudoku != null) {
						// contentContainer
						if (contentContainer != null) {
							byte value = 0;
							// check is show
							bool isShow = false;
							{
								if (this.data.x.v >= 0 && this.data.x.v < 9 && this.data.y.v >= 0 && this.data.y.v < 9) {
									int index = 9 * this.data.y.v + this.data.x.v;
									if (index >= 0 && index < sudoku.board.vs.Count) {
										if (sudoku.board.vs [index] == 0) {
											isShow = true;
											// get user solve
											if (index >= 0 && index < sudoku.userSolve.vs.Count) {
												value = sudoku.userSolve.vs [index];
											}
										}
									}
								} else {
									Debug.LogError ("outside board: " + this.data.x.v + ", " + this.data.y.v);
								}
							}
							// process
							if (isShow) {
								contentContainer.SetActive (true);
								// local position
								contentContainer.transform.localPosition = Common.GetLocalPos(this.data.x.v, this.data.y.v);
								// firstSet
								{
									if (firstSet) {
										firstSet = false;
										if (edtValue != null) {
											edtValue.text = "" + value;
											edtValue.ActivateInputField ();
										} else {
											Debug.LogError ("edtValue null");
										}
									}
								}
							} else {
								contentContainer.SetActive (false);
							}
						} else {
							Debug.LogError ("contentContainer null");
						}
					} else {
						Debug.LogError ("sudoku null: " + this);
					}
				} else {
					Debug.LogError ("data null: " + this);
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return false;
		}

		#endregion

		#region implement callBacks

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{
					uiData.sudoku.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			if (data is Sudoku) {
				// reset
				{
					if (this.data != null) {
						this.data.reset ();
					} else {
						Debug.LogError ("data null");
					}
				}
				firstSet = true;
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{
					uiData.sudoku.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Child
			if (data is Sudoku) {
				return;
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
				case UIData.Property.x:
					dirty = true;
					firstSet = true;
					break;
				case UIData.Property.y:
					dirty = true;
					firstSet = true;
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Child
			if (wrapProperty.p is Sudoku) {
				switch ((Sudoku.Property)wrapProperty.n) {
				case Sudoku.Property.board:
					dirty = true;
					break;
				case Sudoku.Property.userSolve:
					dirty = true;
					break;
				case Sudoku.Property.aiSolve:
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

		public void OnPointerDown(PointerEventData eventData)
		{
			int x = -1;
			int y = -1;
			{
				Vector3 localPosition = transform.InverseTransformPoint (eventData.position);
				Common.convertLocalPositionToXY (localPosition, out x, out y);
				// Debug.LogError ("localPosition: " + localPosition + ", " + x + ", " + y);
			}
			if (this.data != null) {
				if (x >= 0 && x < 9 && y >= 0 && y < 9) {
					this.data.x.v = x;
					this.data.y.v = y;
				} else {
					Debug.LogError ("x, y error");
					this.data.x.v = -1;
					this.data.y.v = -1;
				}
			} else {
				Debug.LogError ("data null");
			}
		}

	}
}