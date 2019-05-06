using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Image))]
public class UrlImage : MonoBehaviour
{

    private Image Image;

    public Image image
    {
        get
        {
            if (Image == null)
            {
                Image = this.GetComponent<Image>();
            }
            return Image;
        }
    }

    private string url = "";
    private string loadingPath = "";
    private string errorPath = "";

    public void setUrl(string url, string loadingPath, string errorPath)
    {
        if (this.url != url || this.loadingPath != loadingPath || this.errorPath != errorPath)
        {
            this.url = url;
            this.loadingPath = loadingPath;
            this.errorPath = errorPath;
            // Set
            Image image = this.GetComponent<Image>();
            UIUtils.SetUrlImageView(image, url, loadingPath, errorPath);
        }
        else
        {
            // Debug.LogError ("the same path: " + this);
        }
    }

    private Sprite loadingSprite = null;
    private Sprite errorSprite = null;

    public void setUrl(string url, Sprite loadingSprite, Sprite errorSprite)
    {
        if (this.url != url || this.loadingSprite != loadingSprite || this.errorSprite != errorSprite)
        {
            this.url = url;
            this.loadingSprite = loadingSprite;
            this.errorSprite = errorSprite;
            // Set
            try
            {
                if (image != null)
                {
                    UIUtils.SetUrlImageView(image, url, loadingSprite, errorSprite);
                }
                else
                {
                    Debug.LogError("image null");
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
            }
        }
        else
        {
            // Debug.LogError("the same path: " + this);
        }
    }

}