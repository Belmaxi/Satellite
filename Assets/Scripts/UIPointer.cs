using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class UIPointer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Image image;
    public float delay = 0.07f;
    public GameObject introduction;
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
        introduction.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = new Vector2(1f, 1f);
        //πÿ±’ΩÈ…‹
        introduction.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        StopAllCoroutines();
        SceneManager.LoadScene("Main");   
    }
}
