using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class UIPointer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Image image;
    public float delay = 0.07f;
    private void Start()
    {
        image = GetComponent<Image>();
        StartCoroutine(DoFlash(delay));
    }

    IEnumerator DoFlash(float delay)
    {
        float ini = 0f;
        while(true)
        {
            float alpha = (Mathf.Cos(ini) + 3f) / 4;
            image.color = new Color(0f,0.5f,0.5f,alpha);
            ini += delay;
            yield return new WaitForSeconds(0.01f);
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = new Vector2(1.05f, 1.05f);
        //显示介绍
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = new Vector2(1f, 1f);
        //关闭介绍
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        StopAllCoroutines();
        //正式选择
    }
}
