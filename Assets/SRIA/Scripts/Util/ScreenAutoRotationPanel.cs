using UnityEngine;
using System.Collections;

namespace frame8.ScrollRectItemsAdapter.Util
{
    public class ScreenAutoRotationPanel : MonoBehaviour
    {
		public bool allowPortrait;


		void Awake()
		{
			Screen.autorotateToPortraitUpsideDown = false;
			Screen.autorotateToPortrait = allowPortrait;
			if (allowPortrait)
			{
				Screen.orientation = ScreenOrientation.AutoRotation;
			}
			else
			{
				Screen.orientation = ScreenOrientation.LandscapeLeft;
				gameObject.SetActive(false);
			}
		}
    }
}