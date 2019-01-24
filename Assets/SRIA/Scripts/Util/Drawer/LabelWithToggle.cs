
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using frame8.Logic.Misc.Other.Extensions;
using UnityEngine.Events;

namespace frame8.ScrollRectItemsAdapter.Util.Drawer
{
	public class LabelWithToggle : MonoBehaviour
	{
		public Text labelText;
		public Toggle toggle;


		public LabelWithToggle Init(string text = "")
		{
			labelText.text = text;

			return this;
		}
	}
}
