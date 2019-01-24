// <copyright file="AdvancedCoroutinesCameraMonoController.cs" company="Parallax Pixels">
// Copyright (c) 2016 All Rights Reserved
// </copyright>
// <author>Michael Kulikov</author>
// <date>07/05/2016 19:09:58 AM </date>

using UnityEngine;

namespace AdvancedCoroutines
{
    public class AdvancedCoroutinesCameraMonoController : MonoBehaviour
    {
        public AdvancedCoroutinesMonoContoller monoContoller;

        public void OnPostRender()
        {
            monoContoller.PostRender();
        }

        public void OnEnable()
        {
            if(monoContoller)
                monoContoller.CameraEnabled(this);
        }
        
        public void OnDisable()
        {
            monoContoller.CameraDisabled(this);
        }
        
        public void OnDestroy()
        {
            monoContoller.CameraDestroyed(this);
        }
    }
}