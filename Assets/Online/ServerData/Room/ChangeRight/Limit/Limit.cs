using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Rights
{
    public abstract class Limit : Data
    {

        public enum Type
        {
            NoLimit,
            HaveLimit
        }

        #region txt

        private static readonly TxtLanguage txtNoLimit = new TxtLanguage();
        private static readonly TxtLanguage txtHaveLimit = new TxtLanguage();

        static Limit()
        {
            txtNoLimit.add(Language.Type.vi, "Không Giới Hạn");
            txtHaveLimit.add(Language.Type.vi, "Có Giới Hạn");
        }

        public static List<string> getStrTypes()
        {
            List<string> ret = new List<string>();
            {
                ret.Add(txtNoLimit.get("No Limit"));
                ret.Add(txtHaveLimit.get("Have Limit"));
            }
            return ret;
        }

        #endregion

        public abstract Type getType();

        public abstract bool isOverLimit(int number);

        public abstract class UIData : Data
        {

            public abstract Type getType();

        }

    }
}