using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameManager.Match.Swap;

namespace Rights
{
	public class ChangeRights : Data
	{
		
		public VP<UndoRedoRight> undoRedoRight;

		public VP<ChangeGamePlayerRight> changeGamePlayerRight;

		public VP<ChangeUseRuleRight> changeUseRuleRight;

		#region Constructor

		public enum Property
		{
			undoRedoRight,
			changeGamePlayerRight,
			changeUseRuleRight
		}

		public ChangeRights() : base()
		{
			this.undoRedoRight = new VP<UndoRedoRight> (this, (byte)Property.undoRedoRight, new UndoRedoRight ());
			this.changeGamePlayerRight = new VP<ChangeGamePlayerRight> (this, (byte)Property.changeGamePlayerRight, new ChangeGamePlayerRight ());
			this.changeUseRuleRight = new VP<ChangeUseRuleRight> (this, (byte)Property.changeUseRuleRight, new ChangeUseRuleRight ());
		}

		#endregion

	}
}