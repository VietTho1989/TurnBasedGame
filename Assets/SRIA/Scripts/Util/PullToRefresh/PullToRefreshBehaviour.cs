using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using frame8.Logic.Misc.Other.Extensions;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using frame8.Logic.Misc.Visual.UI.MonoBehaviours;
using frame8.Logic.Misc.Visual.UI;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;

namespace frame8.ScrollRectItemsAdapter.Util.PullToRefresh
{
    /// <summary>
    /// Attach it to your ScrollRect where the pull to refresh functionality is needed.
    /// Browse the PullToRefreshExample scene to see how the gizmo should be set up. An image is better than 1k words.
    /// </summary>
    public class PullToRefreshBehaviour : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IScrollRectProxy
	{
        #region Serialized fields
        /// <summary>The normalized distance relative to screen size. Always between 0 and 1</summary>
        [SerializeField] [Range(.1f, 1f)] [Tooltip("The normalized distance relative to screen size. Always between 0 and 1")] 
        float _PullAmountNormalized = .25f;

        /// <summary>The reference of the gizmo to use. If null, will try to GetComponentInChildren&lt;PullToRefreshGizmo&gt;()</summary>
        [SerializeField] [Tooltip("If null, will try to GetComponentInChildren()")]
        PullToRefreshGizmo _RefreshGizmo;

		//[SerializeField]
		//RectTransform.Axis _Axis;

        /// <summary>If false, you'll need to call HideGizmo() manually after pull. Subscribe to PullToRefreshBehaviour.OnRefresh event to know when a refresh event occurred. This method is used when the gizmo should do an animation while the refresh is executing (for ex., when some data is downloading)</summary>
        [SerializeField] [Tooltip("If false, you'll need to call HideGizmo() manually after pull. Subscribe to PullToRefreshBehaviour.OnRefresh event to know when a refresh event occurred")]
        bool _AutoHideRefreshGizmo = true;
#pragma warning disable 0649
        /// <summary>Quick way of playing a sound effect when the pull power reaches 1f</summary>
        [SerializeField]
        AudioClip _SoundOnPreRefresh;

        /// <summary>Quick way of playing a sound effect when the refresh occurred</summary>
        [SerializeField]
        AudioClip _SoundOnRefresh;
        #endregion
#pragma warning restore 0649

        #region Unity events
        /// <summary>Unity event (editable in inspector) fired when the refresh occurred</summary>
        public UnityEvent OnRefresh;
        /// <summary>Unity event (editable in inspector) fired when each frame the click/finger is dragged after it has touched the ScrollRect</summary>
        public UnityEventFloat OnPullProgress;
		#endregion

		/// <summary>
		/// Will be retrieved from the scrollrect. If not found, it can be assigned anytime before the first Update. 
		/// If not assigned, a default proxy will be used. The purpose of this is to allow custom implementations of ScrollRect to be used
		/// </summary>
		public IScrollRectProxy externalScrollRectProxy;

		IScrollRectProxy ScrollRectProxy { get { return externalScrollRectProxy == null ? this : externalScrollRectProxy; } }

		ScrollRect _ScrollRect;
        float _ResolvedAVGScreenSize;
        bool _PlayedPreSoundForCurrentDrag;
		bool _IgnoreCurrentDrag;

		/// <summary>Not used</summary>
		public event Action<float> ScrollPositionChanged;

		void Awake()
        {
            _ResolvedAVGScreenSize = (Screen.width + Screen.height) / 2f;
            _ScrollRect = GetComponent<ScrollRect>();
            _RefreshGizmo = GetComponentInChildren<PullToRefreshGizmo>(); // self or children
			// May be null
			externalScrollRectProxy = _ScrollRect.GetComponent(typeof(IScrollRectProxy)) as IScrollRectProxy;
		}


        void Update()
        {


        }

        #region UI callbacks
        public void OnBeginDrag(PointerEventData eventData)
		{
			_IgnoreCurrentDrag = _RefreshGizmo.IsShown;
			if (_IgnoreCurrentDrag)
				return;

			ShowGizmo();
            _PlayedPreSoundForCurrentDrag = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
			if (_IgnoreCurrentDrag)
				return;

            float pullPower = GetDragAmountNormalized(eventData);

            if (_RefreshGizmo)
                _RefreshGizmo.OnPull(pullPower);

            if (OnPullProgress != null)
                OnPullProgress.Invoke(pullPower);


            if (pullPower >= 1f && !_PlayedPreSoundForCurrentDrag)
            {
                _PlayedPreSoundForCurrentDrag = true;

                if (_SoundOnPreRefresh)
                    AudioSource.PlayClipAtPoint(_SoundOnPreRefresh, Camera.main.transform.position);
            }
            //Debug.Log("eventData.pressPosition=" + eventData.pressPosition + "\n eventData.position=" + eventData.position + "\neventData.scrollDelta="+ eventData.scrollDelta);
        }

        public void OnEndDrag(PointerEventData eventData)
		{
			if (_IgnoreCurrentDrag)
				return;

			float dragAmountNormalized = GetDragAmountNormalized(eventData);
            if (dragAmountNormalized >= 1f)
            {
                if (OnRefresh != null)
                    OnRefresh.Invoke();

                if (_RefreshGizmo)
                    _RefreshGizmo.OnRefreshed(_AutoHideRefreshGizmo);

                if (_SoundOnRefresh)
                    AudioSource.PlayClipAtPoint(_SoundOnRefresh, Camera.main.transform.position);
            }
            else
            {
                if (_RefreshGizmo)
                    _RefreshGizmo.OnRefreshCancelled();
            }

            if (_AutoHideRefreshGizmo)
                HideGizmo();
        }
        #endregion


        public void ShowGizmo()
        {
            if (_RefreshGizmo)
                _RefreshGizmo.IsShown = true;
        }

        public void HideGizmo()
        {
            if (_RefreshGizmo)
                _RefreshGizmo.IsShown = false;
        }

        float GetDragAmountNormalized(PointerEventData eventData)
        {
            float delta;
			float normPos = ScrollRectProxy.GetNormalizedPosition();

			if (_ScrollRect.vertical)
            {
                if (normPos < 1f)
                    return 0f;

                delta = Mathf.Abs(eventData.pressPosition.y - eventData.position.y); // The ScrollView is not at the beginning => consider no drag
            }
            else
            {
                if (normPos > 0f) // The ScrollView is not at the beginning => consider no drag
                    return 0f;

                delta = Mathf.Abs(eventData.pressPosition.x - eventData.position.x);
            }

            return Mathf.Abs(delta) / (_PullAmountNormalized * _ResolvedAVGScreenSize);
        }

		#region IScrollRectProxy implementation (used if _PositionChangesProxy is not manually assigned)
		public void SetNormalizedPosition(float normalizedPosition) { }

		public float GetNormalizedPosition()
		{
			if (_ScrollRect.vertical)
				return _ScrollRect.verticalNormalizedPosition;
			return _ScrollRect.horizontalNormalizedPosition;
		}

		public float GetContentSize() { throw new NotImplementedException(); }
		#endregion

		[Serializable]
        public class UnityEventFloat : UnityEvent<float> { }
    }
}