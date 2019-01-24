using UnityEngine;
using System.Text;
using System.Collections;
using AdvancedCoroutines;

public class ChatRoomUITest : MonoBehaviour
{

	private Routine checkSendMessage;

	public IEnumerator TaskSendMessage()
	{
		while (true) {
			float waitTime = 1;
			{
				float randomTime = Random.Range (5, 7);
				Debug.LogError ("waitTime: " + randomTime);
				waitTime = randomTime;
			}
			yield return new Wait (waitTime);
			// Get message
			string message = "";
			{
				StringBuilder builder = new StringBuilder ();
				builder.Append ("" + Time.time + ": ");
				{
					int index = Random.Range (0, 40);
					for (int i = 0; i < index; i++) {
						builder.Append ("" + i);
					}
				}
				message = builder.ToString ();
			}
			// Send
			{
				ChatRoomUI chatRoomUI = this.GetComponent<ChatRoomUI> ();
				if (chatRoomUI != null) {
					chatRoomUI.sendMessage (message);
				} else {
					Debug.LogError ("chatRoomUI null");
				}
			}
		}
	}

	void OnEnable()
	{
		if (Routine.IsNull (checkSendMessage)) {
			checkSendMessage = CoroutineManager.StartCoroutine (TaskSendMessage(), this.gameObject);
		} else {
			Debug.LogError ("Why routine != null");
		}
		if (!Routine.IsNull (checkSendMessage)) {
			if (checkSendMessage.IsPaused ()) {
				checkSendMessage.Resume ();
			} else {
				Debug.Log ("Why routine not pause");
			}
		} else {
			Debug.LogError ("waitTimeRoutine null");
		}
	}

	void OnDisable() {
		if (!Routine.IsNull (checkSendMessage)) {
			if (!checkSendMessage.IsPaused ()) {
				checkSendMessage.Pause ();
			} else {
				Debug.LogError ("Why routine not working");
			}
		} else {
			Debug.LogError ("findAIRoutine null");
		}
	}

	void OnDestroy() {
		if (!Routine.IsNull (checkSendMessage)) {
			CoroutineManager.StopCoroutine (checkSendMessage);
		} else {
			// Debug.LogError ("Why routine null");
		}
	}

}