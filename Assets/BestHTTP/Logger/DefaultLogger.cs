﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BestHTTP.Logger
{
    /// <summary>
    /// A basic logger implementation to be able to log intelligently additional informations about the plugin's internal mechanism.
    /// </summary>
    public class DefaultLogger : BestHTTP.Logger.ILogger
    {
        public Loglevels Level { get; set; }
        public string FormatVerbose { get; set; }
        public string FormatInfo { get; set; }
        public string FormatWarn { get; set; }
        public string FormatErr { get; set; }
        public string FormatEx { get; set; }

        public DefaultLogger()
        {
            FormatVerbose = "I [{0}]: {1}";
            FormatInfo = "I [{0}]: {1}";
            FormatWarn = "W [{0}]: {1}";
            FormatErr = "Err [{0}]: {1}";
            FormatEx = "Ex [{0}]: {1} - Message: {2}  StackTrace: {3}";

            Level = UnityEngine.Debug.isDebugBuild ? Loglevels.Warning : Loglevels.Error;
        }

        public void Verbose(string division, string verb)
        {
            if (Level <= Loglevels.All)
            {
                try
                {
                    UnityEngine.Debug.Log(string.Format(FormatVerbose, division, verb));
                }
                catch
                { }
            }
        }

        public void Information(string division, string info)
        {
            if (Level <= Loglevels.Information)
            {
                try
                {
                    UnityEngine.Debug.Log(string.Format(FormatInfo, division, info));
                }
                catch
                { }
            }
        }

        public void Warning(string division, string warn)
        {
            if (Level <= Loglevels.Warning)
            {
                try
                {
                    UnityEngine.Debug.LogWarning(string.Format(FormatWarn, division, warn));
                }
                catch
                { }
            }
        }

        public void Error(string division, string err)
        {
            if (Level <= Loglevels.Error)
            {
                try
                {
                    UnityEngine.Debug.LogError(string.Format(FormatErr, division, err));
                }
                catch
                { }
            }
        }

        public void Exception(string division, string msg, Exception ex)
        {
            if (Level <= Loglevels.Exception)
            {
                try
                {
                    UnityEngine.Debug.LogError(string.Format(FormatEx, division, msg, ex != null ? ex.Message : "null", ex != null ? ex.StackTrace : "null"));
                }
                catch
                { }
            }
        }
    }
}