using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UndoRedo
{
	public abstract class RequestInform : Data
	{

		public enum Type
		{
			LastYourTurn,
			LastTurn
		}

		public abstract Type getType();

		public abstract int getIndex();

		public abstract bool isRequestCorrect(History history);

        public abstract UndoRedoRequest.Operation getOperation();

	}
}