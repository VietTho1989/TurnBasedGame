using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class PrintRectTransform : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        print();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void print()
    {
        RectTransform rectTransform = this.GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            Debug.LogError("anchoredPosition: " + rectTransform.anchoredPosition
            + "; anchorMin: " + rectTransform.anchorMin
            + "; anchorMax: " + rectTransform.anchorMax
            + "; pivot: " + rectTransform.pivot
             + "; offsetMin: " + rectTransform.offsetMin
             + "; offsetMax: " + rectTransform.offsetMax
            + "; sizeDelta: " + rectTransform.sizeDelta
            + "; localRotation: " + rectTransform.localRotation
            + "; localScale: " + rectTransform.localScale);
        }
        else
        {
            Debug.LogError("rect null");
        }
    }

}