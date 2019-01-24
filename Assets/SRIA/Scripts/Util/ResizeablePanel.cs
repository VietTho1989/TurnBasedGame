using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using frame8.Logic.Misc.Other.Extensions;
using UnityEngine.Events;

namespace frame8.ScrollRectItemsAdapter.Util
{
	public class ResizeablePanel : MonoBehaviour
	{
		[SerializeField]
		bool _Expanded;

		[Tooltip("Only needed to be set if starting with _Expanded=false")]
		[SerializeField]
		float _ExpandedSize;

		[Tooltip("Only needed to be set if starting with _Expanded=true")]
		[SerializeField]
		float _NonExpandedSize;

		[SerializeField]
		float _AnimTime = 1f;

		[SerializeField]
		DIRECTION _Direction;

		[SerializeField]
		bool _RebuildNearestScrollRectParentDuringAnimation;

		[SerializeField]
		UnityEventBool onExpandedStateChanged;


		float PreferredSize
		{
			get { return _Direction == DIRECTION.HORIZONTAL ? _LayoutElement.preferredWidth : _LayoutElement.preferredHeight; }
			set { if (_Direction == DIRECTION.HORIZONTAL) _LayoutElement.preferredWidth = value; else _LayoutElement.preferredHeight = value; }
		}


		LayoutElement _LayoutElement;
		ScrollRect _NearestScrollRectInParents;
		bool _Animating;

		void Start()
		{
			Canvas.ForceUpdateCanvases();
			_LayoutElement = GetComponent<LayoutElement>();

			if (_Expanded)
			{
				if (_ExpandedSize == -1f)
					_ExpandedSize = PreferredSize;
			}
			else
			{
				if (_NonExpandedSize == -1f)
					_NonExpandedSize = PreferredSize;
			}

			var p = transform;
			while ((p = p.parent) && !_NearestScrollRectInParents)
				_NearestScrollRectInParents = p.GetComponent<ScrollRect>();
		}


		public void ToggleExpandedState()
		{
			bool expandedToSet = !_Expanded;
			float from = PreferredSize, to;
			if (expandedToSet)
			{
				to = _ExpandedSize;
			}
			else
			{
				to = _NonExpandedSize;
			}
			StartCoroutine(StartAnimating(from, to, () => { _Expanded = expandedToSet; if (onExpandedStateChanged != null) onExpandedStateChanged.Invoke(_Expanded); }));
		}

		IEnumerator StartAnimating(float from, float to, Action onDone)
		{
			float startTime = Time.time;
			float elapsed;
			float t01;
			do
			{
				yield return null; // one frame

				elapsed = Time.time - startTime;
				t01 = elapsed / _AnimTime;
				if (t01 > 1f)
					t01 = 1f;
				else
					t01 = Mathf.Sqrt(t01); // slightly fast-in, slow-out effect

				PreferredSize = from * (1f - t01) + to * t01;
				if (_RebuildNearestScrollRectParentDuringAnimation && _NearestScrollRectInParents)
					_NearestScrollRectInParents.OnScroll(new UnityEngine.EventSystems.PointerEventData(UnityEngine.EventSystems.EventSystem.current));
			}
			while (t01 < 1f);

			if (onDone != null)
				onDone();
		}


		public enum DIRECTION { HORIZONTAL, VERTICAL }


		[Serializable]
		public class UnityEventBool : UnityEvent<bool> { }
	}
}
