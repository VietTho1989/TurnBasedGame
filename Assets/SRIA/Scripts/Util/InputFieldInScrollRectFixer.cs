using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using frame8.Logic.Misc.Other.Extensions;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace frame8.ScrollRectItemsAdapter.Util
{
	/// <summary>
	/// Utility that allows dragging a ScrollRect even if the PointerDown event has started inside a child InputField (which cancels the dragging by default)
	/// </summary>
	public class InputFieldInScrollRectFixer : MonoBehaviour
	{
		InputField _InputField;
		Button _Button;


		IEnumerator Start()
		{
			_InputField = GetComponent<InputField>();

			var go = new GameObject("InputFieldFixer");
			var goRT = go.AddComponent<RectTransform>();
			goRT.SetParent(_InputField.transform, false);
			goRT.SetAsLastSibling();
			goRT.anchorMin = Vector2.zero;
			goRT.anchorMax = Vector2.one;
			goRT.sizeDelta = Vector2.zero;

			var image = go.AddComponent<Image>();
			image.color = Color.clear;

			_Button = go.AddComponent<Button>();
			_Button.transition = Selectable.Transition.None;

			_Button.onClick.AddListener(() =>
			{
				_InputField.enabled = true;
				_InputField.ActivateInputField();
				_Button.gameObject.SetActive(false);
			});

			_InputField.onEndEdit.AddListener(_ =>
			{
				_InputField.enabled = false;
				_Button.gameObject.SetActive(true);
			});

			yield return null;

			// Initially disabled
			_InputField.enabled = false;
		}
	}
}
