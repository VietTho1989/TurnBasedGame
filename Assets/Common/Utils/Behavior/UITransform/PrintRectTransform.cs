using UnityEngine;
using System.Collections;

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
            Debug.LogError(string.Format("anchoredPosition: {0}; anchorMin: {1}; anchorMax: {2}; pivot: {3}; sizeDelta: {4}; rotation: {5}; scale:  {6}", 
            rectTransform.anchoredPosition,
            rectTransform.anchorMin,
            rectTransform.anchorMax,
            rectTransform.pivot,
            rectTransform.sizeDelta,
            rectTransform.localRotation,
            rectTransform.localScale));
        }
        else
        {
            Debug.LogError("rect null");
        }
    }

}