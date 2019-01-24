// <copyright file="AdvancedCoroutinesExtention.cs" company="Parallax Pixels">
// Copyright (c) 2016 All Rights Reserved
// </copyright>
// <author>Michael Kulikov</author>
// <date>07/05/2016 19:09:58 AM </date>

using System;
using System.Globalization;
using System.Reflection;
using UnityEngine;

namespace AdvancedCoroutines.Extentions
{
    public static class AdvancedCoroutinesExtention
    {
        /// <summary>
        /// Extention method for coroutines
        /// </summary>
        /// <param name="o">Object of any type</param>
        /// <returns>Must return 'true' when coroutine needs to wait for condition and 'false' when it needs to proceed</returns>
        /// /// <example>
        /// <code>
        /// ...
        /// if(o is SomeEntity)
        /// {
        ///     return (o as SomeEntity).NeedsToWaitForSomething;
        /// }
        /// 
        /// return false;
        /// </code>
        /// </example>
        public static bool ExtentionMethod(object o)
        {
            if(o == null)
                return false;

            if(o is Routine)
            {
                return !Routine.IsNull(o as Routine);
            }

            if(o is AsyncOperation)
            {
                return !(o as AsyncOperation).isDone;
            }
            
            if (o is WWW)
            {
                return !(o as WWW).isDone;
            }
            
            if( o is Coroutine)
            {
                throw new ArgumentException("CoroutineManager can't work with Coroutine. Use Routine instead");
            }
            
            if (o is WaitForEndOfFrame)
            {
                throw new ArgumentException("CoroutineManager can't work with WaitForEndOfFrame. Use Wait(ForEndOfUpdate) or Wait(ForNextFrame) instead");
            }
            
            if (o is WaitForSeconds)
            {
                throw new ArgumentException("CoroutineManager can't work with WaitForSeconds. Use Wait(seconds) instead");
            }

            Type oType = o.GetType();
            PropertyInfo propertyInfo = oType.GetProperty("isDone");
            if(propertyInfo != null)
            {
                bool isDone = (bool)propertyInfo.GetValue(o, BindingFlags.Public, null, null, CultureInfo.CurrentCulture);
                Debug.LogWarning(
                    "AdvancedCoroutines is using reflection to work with property isDone of type " + oType + 
                    ". Add type " + oType + " to method ExtentionMethod of class AdvancedCoroutinesExtention to speedup its work");
                return !isDone;
            }
            MethodInfo methodInfo = oType.GetMethod("IsDone");
            if(methodInfo != null)
            {
                bool isDone = (bool)methodInfo.Invoke(o, BindingFlags.Public, null, null, CultureInfo.CurrentCulture);
                Debug.LogWarning(
                    "AdvancedCoroutines is using reflection to work with method IsDone of type " + oType + 
                    ". Add type " + oType + " to method ExtentionMethod of class AdvancedCoroutinesExtention to speedup its work");
                return !isDone;
            }

            throw new ArgumentException(
                "Error in 'yield return' operation. AdvancedCoroutine doesn't know type " + o.GetType()
                + ". Add type " + oType + " to method ExtentionMethod of class AdvancedCoroutinesExtention to make it work");
        }
    }
}