using frame8.Logic.Misc.Other.Extensions;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter
{
	public class SRIADebugger : MonoBehaviour
	{
		ISRIA _AdapterImpl;
		public Text debugText1, debugText2, debugText3, debugText4;
		public bool allowReinitializationWithOtherAdapter;

		const BindingFlags BINDING_FLAGS = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;

		void Update()
		{
			if (_AdapterImpl == null)
				return;

			debugText1.text =
				"ctSK: " + GetInternalStateFieldValue("contentPanelSkippedInsetDueToVirtualization") + "\n" +
				"ctRealSz: " + GetInternalStateFieldValue("contentPanelSize") + "\n" +
				"ctVrtSz: " + GetInternalStateFieldValue("contentPanelVirtualSize") + "\n" +
				"ctVrtIns: " + GetInternalStatePropertyValue("ContentPanelVirtualInsetFromViewportStart") + "\n" +
				"visCount: " + GetPropertyValue("VisibleItemsCount") + "\n" +
				//"rec: " + GetPropertyValue("RecyclableItemsCount") + "\n" +
				"skipTriggerCompute: " + GetFieldValue("_SkipComputeVisibilityInUpdateOrOnScroll");
		}

		internal void InitWithAdapter(ISRIA adapterImpl)
		{
			if (_AdapterImpl != null && !allowReinitializationWithOtherAdapter)
				return;

			_AdapterImpl = adapterImpl;

			Button b;
			transform.GetComponentAtPath("ComputeNowButton", out b);
			b.onClick.RemoveAllListeners();
			b.onClick.AddListener(() => Call("ComputeVisibilityForCurrentPosition", true, true, false));

			transform.GetComponentAtPath("ComputeNowButton_PlusDelta", out b);
			b.onClick.RemoveAllListeners();
			b.onClick.AddListener(() => Call("ComputeVisibilityForCurrentPosition", true, true, false, .1f));

			transform.GetComponentAtPath("ComputeNowButton_MinusDelta", out b);
			b.onClick.RemoveAllListeners();
			b.onClick.AddListener(() => Call("ComputeVisibilityForCurrentPosition", true, true, false, -.1f));

			transform.GetComponentAtPath("CorrectNowButton", out b);
			b.onClick.RemoveAllListeners();
			b.onClick.AddListener(() => Call("CorrectPositionsOfVisibleItems", true));
		}

		object GetFieldValue(string field)
		{
			var fi = GetBaseType().GetField(field, BINDING_FLAGS);
			return fi.GetValue(_AdapterImpl);
		}

		object GetPropertyValue(string prop)
		{
			var pi = GetBaseType().GetProperty(prop, BINDING_FLAGS);
			return pi.GetValue(_AdapterImpl, null);
		}

		object GetInternalStateFieldValue(string field)
		{
			var internalState = GetFieldValue("_InternalState");
			var internalStateBaseType = GetInternalStateBaseType(internalState);

			var fi = internalStateBaseType.GetField(field, BINDING_FLAGS);
			return fi.GetValue(internalState);
		}

		object GetInternalStatePropertyValue(string prop)
		{
			var internalState = GetFieldValue("_InternalState");
			var internalStateBaseType = GetInternalStateBaseType(internalState);

			var fi = internalStateBaseType.GetProperty(prop, BINDING_FLAGS);
			return fi.GetValue(internalState, null);
		}

		Type GetBaseType()
		{
			Type t = _AdapterImpl.GetType();
			while (!t.Name.Contains("SRIA") || !t.IsGenericType)
			{
				t = t.BaseType;
				//if (t == typeof(object))
				//	return;
			}

			return t;
		}

		Type GetInternalStateBaseType(object internalState)
		{
			Type t = internalState.GetType();
			while (!t.Name.Contains("InternalStateGeneric") || !t.IsGenericType)
			{
				t = t.BaseType;
				//if (t == typeof(object))
				//	return;
			}

			return t;
		}


		void Call(string methodName, params object[] parameters)
		{
			if (_AdapterImpl == null)
				return;

			Type t = GetBaseType();

			//foreach (var m in t.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
			//	if (m.Name.ToLower().Contains("compute"))
			//	Debug.Log(m);

			var mi = t.GetMethod(
				methodName,
				BINDING_FLAGS, 
				null,
				Array.ConvertAll(parameters, p => p.GetType()),
				null
				);
			mi.Invoke(_AdapterImpl, parameters);
		}



	}
}
