// <copyright file="AdvancedCoroutinesDebugModes.cs" company="Parallax Pixels">
// Copyright (c) 2016 All Rights Reserved
// </copyright>
// <author>Michael Kulikov</author>
// <date>07/05/2016 19:09:58 AM </date>

using System.Collections.Generic;
using System.Linq;
using UnityEditor;

namespace AdvancedCoroutines.Editor
{
    public class AdvancedCoroutinesDebugModes
    {
        const string ADVANCED_COROUTINES_STAT = "ADVANCED_COROUTINES_STAT";

        [MenuItem("Window/Advanced Coroutines/Debug Mode/Enable")]
        static void EnableDebugMode()
        {
            var definedSymbols = GetDefinedSymbols();
            definedSymbols.Add(ADVANCED_COROUTINES_STAT);
            SaveDefinedSymbolsToPlayerSettings(definedSymbols);
        } 

        [MenuItem("Window/Advanced Coroutines/Debug Mode/Disable")]
        static void DisableDebugMode()
        {
            var definedSymbols = GetDefinedSymbols();
            definedSymbols.Remove(ADVANCED_COROUTINES_STAT);
            SaveDefinedSymbolsToPlayerSettings(definedSymbols);
        } 

        private static List<string> GetDefinedSymbols()
        {
            return PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup).Split(';').ToList();;
        }

        private static void SaveDefinedSymbolsToPlayerSettings(List<string> definedSymbols)
        {
            string[] newDefinedSymbolsArray = definedSymbols.ToArray();
            string newDefinedSymbols = string.Join(";", newDefinedSymbolsArray);
            PlayerSettings.SetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup, newDefinedSymbols);
        }
    }
}