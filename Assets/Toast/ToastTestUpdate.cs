using UnityEngine;
using System.Text;
using System.Collections;
using AdvancedCoroutines;

public class ToastTestUpdate : MonoBehaviour
{

	private Routine checkToast;

	public IEnumerator TaskCheckToast()
	{
		while (true) {
			yield return new Wait (3f);
			int random = Random.Range (2, 20);
			StringBuilder builder = new StringBuilder ();
			{
				for (int i = 0; i < random; i++) {
					builder.Append ("" + i);
				}
			}
			Toast.showMessage (builder.ToString());
		}
	}

	void OnEnable()
	{
		if (Routine.IsNull (checkToast)) {
			checkToast = CoroutineManager.StartCoroutine (TaskCheckToast (), this.gameObject);
		} else {
			Debug.LogError ("Why routine != null");
		}
		if (!Routine.IsNull (checkToast)) {
			if (checkToast.IsPaused ()) {
				checkToast.Resume ();
			} else {
				Debug.Log ("Why routine not pause");
			}
		} else {
			Debug.LogError ("waitTimeRoutine null");
		}
	}

	void OnDisable() {
		if (!Routine.IsNull (checkToast)) {
			if (!checkToast.IsPaused ()) {
				checkToast.Pause ();
			} else {
				Debug.LogError ("Why routine not working");
			}
		} else {
			Debug.LogError ("findAIRoutine null");
		}
	}

	void OnDestroy() {
		if (!Routine.IsNull (checkToast)) {
			CoroutineManager.StopCoroutine (checkToast);
		} else {
			// Debug.LogError ("Why routine null");
		}
	}
}

