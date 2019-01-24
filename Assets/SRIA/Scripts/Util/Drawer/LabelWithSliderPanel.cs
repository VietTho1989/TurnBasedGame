
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using frame8.Logic.Misc.Other.Extensions;
using UnityEngine.Events;

namespace frame8.ScrollRectItemsAdapter.Util.Drawer
{
	public class LabelWithSliderPanel : MonoBehaviour
	{
		public Text labelText, minLabelText, maxLabelText;
		public Slider slider;


		public void Init(string label, string minLabel, string maxLabel)
		{
			labelText.text = label;
			minLabelText.text = minLabel;
			maxLabelText.text = maxLabel;
		}

		internal void Set(float min, float max, float val)
		{
			slider.minValue = min;
			slider.maxValue = max;
			slider.onValueChanged.Invoke(slider.value = val);
		}
	}
}
