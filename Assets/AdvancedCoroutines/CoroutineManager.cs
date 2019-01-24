// <copyright file="CoroutineManager.cs" company="Parallax Pixels">
// Copyright (c) 2016 All Rights Reserved
// </copyright>
// <author>Michael Kulikov</author>
// <date>07/05/2016 19:09:58 AM </date>

using System.Collections;
using AdvancedCoroutines.Core;
using AdvancedCoroutines.Extentions;
using UnityEngine;
using Object = UnityEngine.Object;
#if(ADVANCED_COROUTINES_STAT)
using AdvancedCoroutines.Statistics;
#endif

namespace AdvancedCoroutines
{
    public static class CoroutineManager
    {
        private static readonly AdvancedCoroutinesCoreDll _dll;

        static CoroutineManager()
        {
            InitializeMonoController();
            _dll = new AdvancedCoroutinesCoreDll(AdvancedCoroutinesExtention.ExtentionMethod);

            #if(ADVANCED_COROUTINES_STAT)
            Statistics.AdvancedCoroutinesStatistics.IsActive = true;
            #endif
        }

        private static void InitializeMonoController()
        {
            GameObject monoControllerHolder = new GameObject
            {
                hideFlags = HideFlags.HideInHierarchy | HideFlags.HideInInspector
            };
            Object.DontDestroyOnLoad(monoControllerHolder);
            monoControllerHolder.AddComponent<AdvancedCoroutinesMonoContoller>();
        }
        
        public static void Update(float deltaTime)
        {
            _dll.Update(deltaTime);
        }

        public static void LateUpdate()
        {
            _dll.LateUpdate();
        }

        public static void OnPostRender()
        {
            _dll.OnPostRender();
        }

        /// <summary>
        /// Start new standalone coroutine
        /// </summary>
        /// <param name="enumerator">Method returning 'IEnumerator' in most cases</param>
        /// <returns>New StandaloneRoutine object</returns>
        /// <example>
        /// <code>
        /// IEnumerator CoroutineMethod()
        /// {
        ///     yield return new Wait(1f);
        ///     yield return new Wait(Wait.WaitType.ForEndOfUpdate);
        ///     yield return new Wait(Wait.WaitType.ForNextFrame);
        /// }
        /// 
        /// StartCoroutine(CoroutineMethod());
        /// </code>
        /// </example>
        public static Routine StartStandaloneCoroutine(IEnumerator enumerator)
        {
            Routine standaloneRoutine = _dll.StartCoroutine(enumerator, null);
            if(standaloneRoutine == null) return null;

#if(ADVANCED_COROUTINES_STAT)
            AdvancedCoroutinesStatistics.Add(standaloneRoutine, StackTraceUtility.ExtractStackTrace());
#endif
            return standaloneRoutine;
        }

        /// <summary>
        /// Start coroutine attached to certain 'object'. Can be stopped by StopCoroutine() and StopAllCoroutines()
        /// </summary>
        /// <param name="enumerator">Method returning 'IEnumerator' in most cases</param>
        /// <param name="o">object which StartCoroutine was executed from. gameObject for example</param>
        /// <returns>New Routine object</returns>
        /// /// <example>
        /// <code>
        /// IEnumerator CoroutineMethod()
        /// {
        ///     yield return new Wait(1f);
        ///     yield return new Wait(Wait.WaitType.ForEndOfUpdate);
        ///     yield return new Wait(Wait.WaitType.ForNextFrame);
        /// }
        /// 
        /// StartCoroutine(CoroutineMethod(), gameObject);
        /// </code>
        /// </example>
        public static Routine StartCoroutine(IEnumerator enumerator, GameObject o)
        {
            Routine routine = _dll.StartCoroutine(enumerator, o);
            if(routine == null) return null;

#if(ADVANCED_COROUTINES_STAT)
            AdvancedCoroutinesStatistics.Add(routine, StackTraceUtility.ExtractStackTrace());
#endif
            return routine;
        }

        /// <summary>
        /// Stop coroutine
        /// </summary>
        /// <param name="routine">Routine object to stop</param>
        public static void StopCoroutine(Routine routine)
        {
            _dll.StopCoroutine(routine);
        }

        /// <summary>
        /// Stop all coroutines executed from certain GameObject
        /// </summary>
        /// <param name="o">object which coroutines was executed from. gameObject for example</param>
        public static void StopAllCoroutines(object o)
        {
            _dll.StopAllCoroutines(o);
        }
    }
}