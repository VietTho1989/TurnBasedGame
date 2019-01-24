using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class InputEvent
{

	public static bool isBackEvent(Event e)
	{
		if (e.isKey && e.type == EventType.KeyUp) {
			switch (e.keyCode) {
			case KeyCode.Backspace:
			case KeyCode.Escape:
				{
					return true;
				}
			default:
				break;
			}
		}
		return false;
	}

	public static bool isTab(Event e)
	{
		if (e.isKey && e.type == EventType.KeyUp) {
			switch (e.keyCode) {
			case KeyCode.Tab:
			case KeyCode.Q:
				{
					// TODO can xem xet lai q
					return true;
				}
			default:
				break;
			}
		}
		return false;
	}

	public static bool isArrow(Event e)
	{
		if (e.isKey && e.type == EventType.KeyUp) {
			switch (e.keyCode) {
			case KeyCode.LeftArrow:
			case KeyCode.RightArrow:
			case KeyCode.UpArrow:
			case KeyCode.DownArrow:
				return true;
			default:
				break;
			}
		}
		return false;
	}

	public static bool isEnter(Event e)
	{
		if (e.isKey && e.type == EventType.KeyUp) {
			switch (e.keyCode) {
			case KeyCode.Return:
			case KeyCode.KeypadEnter:
				return true;
			default:
				break;
			}
		}
		return false;
	}

	public static bool isNextTab(Event e)
	{
		if (e.isKey && e.type == EventType.KeyUp) {
			switch (e.keyCode) {
			case KeyCode.Tab:
				{
					return true;
				}
			default:
				break;
			}
		}
		return false;
	}

	public static bool isBackTab(Event e)
	{
		if (e.isKey && e.type == EventType.KeyUp) {
			switch (e.keyCode) {
			case KeyCode.Q:
				{
					// TODO Can xem xet lai q
					return true;
				}
			default:
				break;
			}
		}
		return false;
	}

}