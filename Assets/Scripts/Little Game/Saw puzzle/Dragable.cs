using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dragable : MonoBehaviour,IDragHandler,IPointerUpHandler,IPointerDownHandler
{
    private RectTransform rectTransform;
    private Vector3 startPos;
    public Vector3 targetPos;

    private bool isTargeted = false;

    public bool IsTargeted { get => isTargeted; set => isTargeted = value; }

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startPos = transform.localPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 pos;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, eventData.position, eventData.enterEventCamera, out pos);
        rectTransform.position = pos;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if((targetPos - transform.localPosition).magnitude <= 50f)
        {
            transform.localPosition = targetPos;
            IsTargeted = true;
        }
        else
        {
            transform.localPosition = startPos;
            IsTargeted = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData) { }
}
