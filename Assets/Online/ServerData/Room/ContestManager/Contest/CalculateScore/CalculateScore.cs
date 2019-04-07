using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class CalculateScore : Data
{

    public enum Type
    {
        Sum,
        WinLoseDraw
    }

    #region txt

    private static readonly TxtLanguage txtSum = new TxtLanguage("Game count");
    private static readonly TxtLanguage txtWinLoseDraw = new TxtLanguage("Win, lose, draw score");

    static CalculateScore()
    {
        txtSum.add(Language.Type.vi, "Số trận");
        txtWinLoseDraw.add(Language.Type.vi, "Điểm thắng, thua, hoà");
    }

    public static List<string> getStrTypes()
    {
        List<string> ret = new List<string>();
        {
            ret.Add(txtSum.get());
            ret.Add(txtWinLoseDraw.get());
        }
        return ret;
    }

    #endregion

    public abstract Type getType();

    public abstract class UIData : Data
    {

        public abstract Type getType();

    }

}