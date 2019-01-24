using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace frame8.ScrollRectItemsAdapter.Editor
{
    static class MenuItems
	{
		[MenuItem("frame8/SRIA/Code reference")]
		public static void OpenDoc()
		{ Application.OpenURL("http://thefallengames.com/unityassetstore/optimizedscrollviewadapter/doc"); }

		[MenuItem("frame8/SRIA/Quick start tutorial (YouTube)")]
		public static void OpenTutorial()
		{ Application.OpenURL("https://youtu.be/rcgnF16JybY"); }

		[MenuItem("frame8/SRIA/Thank you!")]
		public static void OpenThankYou()
		{ Application.OpenURL("http://thefallengames.com/unityassetstore/optimizedscrollviewadapter/thankyou"); }
	}
}
