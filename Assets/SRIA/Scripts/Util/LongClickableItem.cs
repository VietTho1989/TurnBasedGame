using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using frame8.Logic.Misc.Other.Extensions;
using UnityEngine.EventSystems;

namespace frame8.ScrollRectItemsAdapter.Util
{
    /// <summary>
    /// Utility to delegate the "long click" event to <see cref="longClickListener"/>
    /// It requires a graphic component (can be an image with zero alpha) that can be clicked in order to receive OnPointerDown, OnPointerUp etc.
    /// No other UI elements should be on top of this one in order to receive pointer callbacks
    /// </summary>
    [RequireComponent(typeof(Graphic))]
    public class LongClickableItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, ICancelHandler
    {
        public float longClickTime = .7f;

        public IItemLongClickListener longClickListener;

        float _PressedTime;
        bool _Pressing;

        void Update()
        {
            if (_Pressing)
            {
                if (Time.time - _PressedTime >= longClickTime)
                {
                    _Pressing = false;
                    if (longClickListener != null)
                        longClickListener.OnItemLongClicked(this);
                }
            }
        }

        #region Callbacks from Unity UI event handlers
        public void OnPointerDown(PointerEventData eventData)
        {
            _Pressing = true;
            _PressedTime = Time.time;
        }
        public void OnPointerUp(PointerEventData eventData) { _Pressing = false; }
        public void OnCancel(BaseEventData eventData) { _Pressing = false; }
        #endregion

        /// <summary>Interface to implement by the class that'll handle the long click events</summary>
        public interface IItemLongClickListener
        {
            void OnItemLongClicked(LongClickableItem longClickedItem);
        }
    }
}