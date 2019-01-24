using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using frame8.Logic.Misc.Other.Extensions;
using UnityEngine.EventSystems;

namespace frame8.ScrollRectItemsAdapter.Util.PullToRefresh
{
    /// <summary>
    /// <para> Implementation of <see cref="PullToRefreshGizmo"/> that uses a rotating image to show the pull progress. </para>
    /// <para>The image is rotated by the amount of distance traveled by the click/finger.</para>
    /// <para>When enough pulling distance is covered (more exactly, the one between <see cref="_StartingPoint"/> and <see cref="_EndingPoint"/>) the gizmo enters the "ready to refresh" state,</para>
    /// <para>the rotation amount applied is damped by <see cref="_ExcessPullRotationDamping"/> (i.e. a value of 1f won't apply any furter rotation, </para>
    /// <para>while a value of 0f will apply the same amount of rotation per distance traveled by the click/finger as before the "ready to refresh" state).</para>
    /// <para>When <see cref="OnRefreshed(bool)"/> is called with true, the gizmo will disappear; if it'll be called with false, </para>
    /// <para>it'll start auto-rotating with a speed of <see cref="_AutoRotationDegreesPerSec"/> degrees per second, until <see cref="IsShown"/> is set to false.</para>
    /// <para>This last use-case is very common for when the refresh event actually takes time (i.e. retrieving items from a server).</para>
    /// </summary>
    public class PullToRefreshRotateGizmo : PullToRefreshGizmo
    {
#pragma warning disable 0649
        [SerializeField]
        RectTransform _StartingPoint, _EndingPoint;
#pragma warning restore 0649

        [SerializeField]
        [Range(0f, 1f)]
        float _ExcessPullRotationDamping = .95f;

        [SerializeField]
        float _AutoRotationDegreesPerSec = 200;

        bool _WaitingForManualHide;


        /// <summary>Calls base implementation + resets the rotation to default each time is assigned, regardless if true or false</summary>
        public override bool IsShown
        {
            get { return base.IsShown; }

            set
            {
                base.IsShown = value;

                // Reset to default rotation
                transform.localRotation = Quaternion.Euler(_InitialLocalRotation);

                if (!value)
                    _WaitingForManualHide = false;
            }
        }



        Vector3 _InitialLocalRotation;


        internal override void Awake()
        {
            base.Awake();
            _InitialLocalRotation = transform.localRotation.eulerAngles;
        }


        void Update()
        {
            if (_WaitingForManualHide)
            {
                SetLocalZRotation((transform.localEulerAngles.z - Time.deltaTime * _AutoRotationDegreesPerSec) % 360);
            }
        }

        internal override void OnPull(float power)
        {
            base.OnPull(power);

            var powerClamped01 = Mathf.Clamp01(power);
            float excess = Mathf.Max(0f, power - 1f);

            float dampedExcess = excess * (1f - _ExcessPullRotationDamping);

            SetLocalZRotation((_InitialLocalRotation.z - 360 * (powerClamped01 + dampedExcess)) % 360);
            
            //transform.position = LerpUnclamped(_StartingPoint.position, _EndingPoint.position, power <= 1f ? (power - (1f - power/2)*(1f-power/2)) : (1 - 1/(1 + excess) ));
            transform.position = LerpUnclamped(_StartingPoint.position, _EndingPoint.position, 2 - 2 / (1 + powerClamped01));
        }

        internal override void OnRefreshCancelled()
        {
            base.OnRefreshCancelled();

            _WaitingForManualHide = false;
        }

        internal override void OnRefreshed(bool autoHide)
        {
            base.OnRefreshed(autoHide);

            _WaitingForManualHide = !autoHide;
        }

        Vector3 LerpUnclamped(Vector3 from, Vector3 to, float t) { return (1f - t) * from + t * to ; }

        void SetLocalZRotation(float zRotation)
        {
            var rotE = transform.localRotation.eulerAngles;
            rotE.z = zRotation;
            transform.localRotation = Quaternion.Euler(rotE);
        }
    }
}