using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public abstract class ContestManagerContent : Data
	{

		public enum Type
		{
			Single,
			RoundRobin,
			Elimination
		}

        #region txt

        private static readonly TxtLanguage txtSingle = new TxtLanguage("Single");
        private static readonly TxtLanguage txtRoundRobin = new TxtLanguage("Round-robin");
        private static readonly TxtLanguage txtElimination = new TxtLanguage("Elimination");

        static ContestManagerContent()
        {
            txtSingle.add(Language.Type.vi, "Đơn");
            txtRoundRobin.add(Language.Type.vi, "Vòng Tròn");
            txtElimination.add(Language.Type.vi, "Loại");
        }

        public static List<string> getStrTypes()
        {
            List<string> ret = new List<string>();
            {
                ret.Add(txtSingle.get());
                ret.Add(txtRoundRobin.get());
                ret.Add(txtElimination.get());
            }
            return ret;
        }

        #endregion

        public abstract Type getType();

		public abstract class UIData : Data
		{

			public abstract Type getType();

			public abstract bool processEvent(Event e);

		}

		public abstract ContestManagerContentFactory makeContentFactory();

		public abstract GameType.Type getGameTypeType();

	}
}