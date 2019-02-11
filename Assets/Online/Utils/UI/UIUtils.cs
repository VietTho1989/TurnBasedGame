using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityImageLoader;

public class UIUtils
{

	#region UrlImageView

	public static void SetUrlImageView(Image img, string url, string loadingPath, string errorPath)
	{
		DisplayOption.Builder builder = new DisplayOption.Builder ();
		{
			builder.isMemoryCache = true;
			builder.isDiscCache = false;
			builder.loadingImagePath = loadingPath;
			builder.loadErrorImagePath = errorPath;
		}
		ImageLoader.GetInstance ().Display (img, Setting.get ().viewUrlImage.v ? url : "", builder.Build ());
	}

	public static void SetUrlImageView(Image img, string url, Sprite loadingSprite, Sprite errorSprite)
	{
		DisplayOption.Builder builder = new DisplayOption.Builder ();
		{
			builder.isMemoryCache = true;
			builder.isDiscCache = false;
			builder.loadingSprite = loadingSprite;
			builder.loadErrorSprite = errorSprite;
		}
		ImageLoader.GetInstance ().Display (img, Setting.get ().viewUrlImage.v ? url : "", builder.Build ());
	}

	#endregion

	public static UIBehavior<T> Instantiate<T>(T data, UIBehavior<T> prefab, Transform transform) where T : Data
	{
		if (data != null) {
			if (transform != null && prefab != null) {
				UIBehavior<T> old = data.findCallBack<UIBehavior<T>> (prefab.GetType ());
				if (old == null) {
					/*UIBehavior<T> newUI = TrashMan.normalSpawnUI (prefab, transform, data);
					return newUI;*/
					UIBehavior<T> newUI = TrashMan.normalSpawn (prefab, transform);
					newUI.setData (data);
					return newUI;
				} else {
					Debug.LogError ("already have");
					return old;
				}
			} else {
				Debug.LogError ("transform or prefab null");
				return null;
			}
		} else {
			Debug.LogError ("error, Instantiate: why data null");
			return null;
		}
	}

    public static UIBehavior<T> Instantiate<T>(T data, UIBehavior<T> prefab, Transform transform, UIRectTransform uiRectTransform) where T : Data
    {
        if (data != null)
        {
            if (transform != null && prefab != null)
            {
                UIBehavior<T> old = data.findCallBack<UIBehavior<T>>(prefab.GetType());
                if (old == null)
                {
                    /*UIBehavior<T> newUI = TrashMan.normalSpawnUI (prefab, transform, data);
                    return newUI;*/
                    UIBehavior<T> newUI = TrashMan.normalSpawn(prefab, transform);
                    newUI.setData(data);
                    uiRectTransform.set((RectTransform)newUI.transform);
                    return newUI;
                }
                else
                {
                    Debug.LogError("already have");
                    return old;
                }
            }
            else
            {
                Debug.LogError("transform or prefab null");
                return null;
            }
        }
        else
        {
            Debug.LogError("error, Instantiate: why data null");
            return null;
        }
    }

    public static UIBehavior<T> Instantiate<T>(T data, UIBehavior<T> prefab, Transform transform, int siblingIndex) where T : Data
	{
		if (data != null) {
			if (transform != null && prefab != null) {
				UIBehavior<T> old = data.findCallBack<UIBehavior<T>> (prefab.GetType ());
				if (old == null) {
					UIBehavior<T> newUI = TrashMan.normalSpawn (prefab, transform);
					newUI.setData (data);
					newUI.transform.SetSiblingIndex (siblingIndex);
					return newUI;
				} else {
					Debug.LogError ("already have");
					return old;
				}
			} else {
				Debug.LogError ("transform null");
				return null;
			}
		} else {
			Debug.LogError ("error, Instantiate: why data null");
			return null;
		}
	}

	#region dropDown

	public static void RefreshDropDownOptions(Dropdown drValue, string[] options)
	{
		if (drValue.options.Count != options.Length) {
			drValue.options.Clear ();
			for (int i = 0; i < options.Length; i++) {
				Dropdown.OptionData optionData = new Dropdown.OptionData ();
				{
					optionData.text = options [i];
				}
				drValue.options.Add (optionData);
			}
		} else {
			// options
			for (int i = 0; i < options.Length; i++) {
				drValue.options [i].text = options [i];
			}
		}
	}

	#endregion

}