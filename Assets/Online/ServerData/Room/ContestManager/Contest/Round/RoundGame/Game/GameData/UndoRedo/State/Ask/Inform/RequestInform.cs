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

        #region txt

        private static readonly TxtLanguage txtLastYourTurn = new TxtLanguage();
        private static readonly TxtLanguage txtLastTurn = new TxtLanguage();

        static RequestInform()
        {
            txtLastYourTurn.add(Language.Type.vi, "Lượt Trước Của Bạn");
            txtLastTurn.add(Language.Type.vi, "Lượt Trước");
        }

        public static List<string> getStrTypes()
        {
            List<string> ret = new List<string>();
            {
                ret.Add(txtLastYourTurn.get("Last Your Turn"));
                ret.Add(txtLastTurn.get("Last Turn"));
            }
            return ret;
        }

        #endregion

        public abstract Type getType();

		public abstract int getIndex();

		public abstract bool isRequestCorrect(History history);

        public abstract UndoRedoRequest.Operation getOperation();

	}
}