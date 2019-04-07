using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TxtLanguage : Data
{

    public VP<string> defaultTxt;

    public LP<Locale> locales;

    public Locale findLocale(Language.Type type)
    {
        return this.locales.vs.Find(local => local.type.v == type);
    }

    #region Constructor

    public enum Property
    {
        defaultTxt,
        locales
    }

    public TxtLanguage() : base()
    {
        this.defaultTxt = new VP<string>(this, (byte)Property.defaultTxt, "");
        this.locales = new LP<Locale>(this, (byte)Property.locales);
    }

    #endregion

    public void add(Language.Type type, string txt)
    {
        Locale locale = this.findLocale(type);
        if (locale != null)
        {
            // Debug.LogError ("locale not null: " + this);
            locale.txt.v = txt;
        }
        else
        {
            locale = new Locale();
            {
                locale.uid = this.locales.makeId();
                locale.type.v = type;
                locale.txt.v = txt;
            }
            this.locales.add(locale);
        }
    }

    public string get(string defaultTxt)
    {
        return get(Setting.get().language.v, defaultTxt);
    }

    private string get(Language.Type type, string defaultTxt)
    {
        Locale locale = this.findLocale(type);
        if (locale != null)
        {
            if (!string.IsNullOrEmpty(locale.txt.v))
            {
                return locale.txt.v;
            }
            else
            {
                Debug.LogError("why locale text null");
                return defaultTxt;
            }
        }
        else
        {
            // Debug.LogError ("type null: " + this);
            return defaultTxt;
        }
    }

}