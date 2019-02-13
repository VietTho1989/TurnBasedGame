using UnityEngine;
using System.Collections;

public class TransformData : Data
{

    public VP<Vector3> position;

    public VP<Quaternion> rotation;

    public VP<Vector3> scale;

    public VP<Vector2> size;

    #region Constructor

    public enum Property
    {
        position,
        rotation,
        scale,
        size
    }

    public TransformData() : base()
    {
        this.position = new VP<Vector3>(this, (byte)Property.position, new Vector3());
        this.rotation = new VP<Quaternion>(this, (byte)Property.rotation, new Quaternion());
        this.scale = new VP<Vector3>(this, (byte)Property.scale, new Vector3());
        this.size = new VP<Vector2>(this, (byte)Property.size, new Vector2());
    }

    #endregion

    public void update(Transform transform)
    {
        this.position.v = transform.localPosition;
        this.rotation.v = transform.localRotation;
        this.scale.v = transform.localScale;
        // Size
        {
            if (transform is RectTransform)
            {
                RectTransform rectTransform = transform as RectTransform;
                this.size.v = new Vector2(rectTransform.rect.width, rectTransform.rect.height);
            }
            else
            {
                Debug.LogError("why not rectTransform: " + this);
                this.size.v = new Vector2(0, 0);
            }
        }
    }

    public static void AddCallBack(Data data, ValueChangeCallBack callBack)
    {
        if (data != null)
        {
            HaveTransformData haveTransformData = data.findCallBack<HaveTransformData>();
            if (haveTransformData != null)
            {
                haveTransformData.getTransformData().addCallBack(callBack);
            }
            else
            {
                Debug.LogError("haveTransformData null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

    public static void RemoveCallBack(Data data, ValueChangeCallBack callBack)
    {
        if (data != null)
        {
            HaveTransformData haveTransformData = data.findCallBack<HaveTransformData>();
            if (haveTransformData != null)
            {
                haveTransformData.getTransformData().removeCallBack(callBack);
            }
            else
            {
                Debug.LogError("haveTransformData null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

}