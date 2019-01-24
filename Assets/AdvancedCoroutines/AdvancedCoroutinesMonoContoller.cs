// <copyright file="AdvancedCoroutinesMonoContoller.cs" company="Parallax Pixels">
// Copyright (c) 2016 All Rights Reserved
// </copyright>
// <author>Michael Kulikov</author>
// <date>07/05/2016 19:09:58 AM </date>

using System.Collections.Generic;
using UnityEngine;

namespace AdvancedCoroutines
{
    public class AdvancedCoroutinesMonoContoller : MonoBehaviour
    {
        private List<CameraData> _camerasScripts;
        private int _postRenderMass;

        private void Awake()
        {
            _camerasScripts = new List<CameraData>();
            for (int i = 0; i < Camera.allCamerasCount; i++)
            {
                CreateCameraScript(Camera.allCameras[i]);
            }
        }

        private void Update()
        {
            _postRenderMass = 0;
            CheckCameras();
            CoroutineManager.Update(Time.deltaTime);
        }

        private void LateUpdate()
        {
            CoroutineManager.LateUpdate();
            if (_camerasScripts.Count == 0)
            {
                CoroutineManager.OnPostRender();
            }
        }

        public void PostRender()
        {
            _postRenderMass++;
            int neededCount = NeededCount();
            if (_postRenderMass >= neededCount)
            {
                CoroutineManager.OnPostRender();
            }
        }

        private void CheckCameras()
        {
            int currentCamerasCount = Camera.allCamerasCount;
            if (_camerasScripts.Count != currentCamerasCount)
            {
                _camerasScripts.Clear();
                for (int i = 0; i < currentCamerasCount; i++)
                {
                    CreateCameraScript(Camera.allCameras[i]);
                }
            }
        }

        private void CreateCameraScript(Camera cam)
        {
            GameObject camGO = cam.gameObject;
            AdvancedCoroutinesCameraMonoController script;
            script = camGO.GetComponent<AdvancedCoroutinesCameraMonoController>();
            if (script == null)
            {
                script = camGO.AddComponent<AdvancedCoroutinesCameraMonoController>();
                script.hideFlags = HideFlags.HideInInspector | HideFlags.HideInHierarchy;
                script.monoContoller = this;
            }
            CameraData camData;

            camData.cameraScript = script;
            camData.isEnabled = true;
            
            _camerasScripts.Add(camData);
        }

        public void CameraDestroyed(AdvancedCoroutinesCameraMonoController link)
        {
            for (int i = 0; i < _camerasScripts.Count; i++)
            {
                if (_camerasScripts[i].cameraScript.Equals(link))
                {
                    _camerasScripts.RemoveAt(i);
                    break;
                }
            }
        }

        public void CameraEnabled(AdvancedCoroutinesCameraMonoController link)
        {
            for (int i = 0; i < _camerasScripts.Count; i++)
            {
                if (_camerasScripts[i].cameraScript.Equals(link))
                {
                    CameraData camData = _camerasScripts[i];
                    camData.isEnabled = true;
                    _camerasScripts[i] = camData;
                    break;
                }
            }
        }

        public void CameraDisabled(AdvancedCoroutinesCameraMonoController link)
        {
            for (var i = 0; i < _camerasScripts.Count; i++)
            {
                if (_camerasScripts[i].cameraScript.Equals(link))
                {
                    CameraData camData = _camerasScripts[i];
                    camData.isEnabled = false;
                    _camerasScripts[i] = camData;
                    break;
                }
            }
        }

        private int NeededCount()
        {
            var neededCount = 0;

            for (var i = 0; i < _camerasScripts.Count; i++)
            {
                if (_camerasScripts[i].isEnabled)
                    neededCount++;
            }
            return neededCount;
        }

        public struct CameraData
        {
            public AdvancedCoroutinesCameraMonoController cameraScript;
            public bool isEnabled;
        }
    }
}