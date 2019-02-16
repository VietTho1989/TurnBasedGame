using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public bool dragOnSurfaces = true;

    private GameObject dragGameObject;
    private RectTransform dragPlane;

    public void OnBeginDrag(PointerEventData eventData)
    {
        var canvas = FindInParents<Canvas>(gameObject);
        if (canvas == null)
            return;

        // We have clicked something that can be dragged.
        // What we want to do is create an icon for this.
        dragGameObject = this.gameObject;

        dragGameObject.transform.SetParent(canvas.transform, false);
        dragGameObject.transform.SetAsLastSibling();

        if (dragOnSurfaces)
            dragPlane = transform as RectTransform;
        else
            dragPlane = canvas.transform as RectTransform;

        SetDraggedPosition(eventData);
    }

    public void OnDrag(PointerEventData data)
    {
        if (dragGameObject != null)
            SetDraggedPosition(data);
    }

    private void SetDraggedPosition(PointerEventData data)
    {
        if (dragOnSurfaces && data.pointerEnter != null && data.pointerEnter.transform as RectTransform != null)
            dragPlane = data.pointerEnter.transform as RectTransform;

        var rt = dragGameObject.GetComponent<RectTransform>();
        Vector3 globalMousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(dragPlane, data.position, data.pressEventCamera, out globalMousePos))
        {
            rt.position = globalMousePos;
            rt.rotation = dragPlane.rotation;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (dragGameObject != null)
        {
            // Destroy(dragGameObject);
        }
    }

    static public T FindInParents<T>(GameObject go) where T : Component
    {
        if (go == null) return null;
        var comp = go.GetComponent<T>();

        if (comp != null)
            return comp;

        Transform t = go.transform.parent;
        while (t != null && comp == null)
        {
            comp = t.gameObject.GetComponent<T>();
            t = t.parent;
        }
        return comp;
    }

}
