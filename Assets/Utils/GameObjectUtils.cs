using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameObjectUtils : MonoBehaviour 
{

	public static int compareHierachy(Transform A, Transform B)
	{
		int ret = 0;
		{
			if (A != null && B != null && A != B) {
				// get A parent list
				List<Transform> aParentList = new List<Transform> ();
				{
					Transform parent = A;
					while (parent != null) {
						aParentList.Add (parent);
						parent = A.parent;
					}
				}
				// get B parent list
				List<Transform> bParentList = new List<Transform> ();
				{
					Transform parent = B;
					while (parent != null) {
						bParentList.Add (parent);
						parent = B.parent;
					}
				}
				// Process
				{
					if (aParentList.Contains (B)) {
						return -1;
					} else if (bParentList.Contains (A)) {
						return 1;
					} else {
						// find the common parent
						Transform commonParent = null;
						{
							foreach (Transform check in aParentList) {
								if (bParentList.Contains (check)) {
									commonParent = check;
									break;
								}
							}
						}
						// process
						if (commonParent != null) {
							// find beforeA
							Transform beforeA = null;
							{
								int index = aParentList.IndexOf (commonParent);
								if (index - 1 >= 0 && index - 1 < aParentList.Count) {
									beforeA = aParentList [index - 1];
								}
							}
							// find beforeB
							Transform beforeB = null;
							{
								int index = bParentList.IndexOf (commonParent);
								if (index - 1 >= 0 && index - 1 < bParentList.Count) {
									beforeB = bParentList [index - 1];
								}
							}
							// compare
							if (beforeA != null && beforeB != null) {
								ret = beforeA.GetSiblingIndex ().CompareTo (beforeB.GetSiblingIndex ());
							} else {
								Debug.LogError ("beforeA, beforeB null: " + commonParent);
							}
						} else {
							Debug.LogError ("common parent null");
						}
					}
				}
			} else {
				Debug.LogError ("A, B null");
			}
		}
		return ret;
	}

}