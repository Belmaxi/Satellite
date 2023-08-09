using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dragable : MonoBehaviour,IDragHandler
{
    private RectTransform rectTransform;
    // Use this for initialization
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 pos;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, eventData.position, eventData.enterEventCamera, out pos);
        rectTransform.position = pos;
    }
}
