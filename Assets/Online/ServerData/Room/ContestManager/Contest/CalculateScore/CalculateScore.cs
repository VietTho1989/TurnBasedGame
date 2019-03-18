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

    private static readonly TxtLanguage txtSum = new TxtLanguage();
    private static readonly TxtLanguage txtWinLoseDraw = new TxtLanguage();

    static CalculateScore()
    {
        txtSum.add(Language.Type.vi, "Số Trận");
        txtWinLoseDraw.add(Language.Type.vi, "Điểm Thắng, Thua, Hoà");
    }

    public static List<string> getStrTypes()
    {
        List<string> ret = new List<string>();
        {
            ret.Add(txtSum.get("Game Count"));
            ret.Add(txtWinLoseDraw.get("Win, Lose, Draw Score"));
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