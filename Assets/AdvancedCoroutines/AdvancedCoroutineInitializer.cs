// <copyright file="AdvancedCoroutineInitializer.cs" company="Parallax Pixels">
// Copyright (c) 2016 All Rights Reserved
// </copyright>
// <author>Michael Kulikov</author>
// <date>07/05/2016 19:09:58 AM </date>

#if(UNITY_EDITOR)
using System.Linq;
using AdvancedCoroutines;
using UnityEditor;


[InitializeOnLoad]
public class AdvancedCoroutineInitializer
{
    static AdvancedCoroutineInitializer()
    {
        string monoContoller = typeof(AdvancedCoroutinesMonoContoller).Name;
        string cameraMonoController = typeof (AdvancedCoroutinesCameraMonoController).Name;

        ApplyExecutionOrderToScript(monoContoller, 26667);
        ApplyExecutionOrderToScript(cameraMonoController, 26668);
    }

    public static void ApplyExecutionOrderToScript(string sctiptName, int exucutionIndex)
    {
        MonoScript monoScript = MonoImporter.GetAllRuntimeMonoScripts().Single(script => script.name == sctiptName);
        if (monoScript)
        {
            if (MonoImporter.GetExecutionOrder(monoScript) != exucutionIndex)
            {
                MonoImporter.SetExecutionOrder(monoScript, exucutionIndex);
            }
        }
    }
}

#endif