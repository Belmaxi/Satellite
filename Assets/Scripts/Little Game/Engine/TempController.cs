using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempController : MonoBehaviour
{
    public float startPosition;
    public float endPosition;
    public float range = 10f;
    /// <summary>
    /// ÷∏’Î
    /// </summary>
    public GameObject arrow;
    public GameObject highLight;
    public GameObject line;

    private Vector2 pos;
    private int successTime;
    private int errorTime;

    private bool onError = false;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && !onError)
        {
            if(Mathf.Abs(arrow.transform.localPosition.x - highLight.transform.localPosition.x) <= range)
            {
                successTime++;
                highLight.transform.localPosition = GetNewPosition();
                print("flash");
            }
            else
            {
                errorTime++;
                if(errorTime == 2)
                {
                    gameObject.SetActive(false);
                }
                StartCoroutine(DoColorChange());
            }
        }
    }
    public void Init()
    {
        onError = false;
        successTime = 0;
        errorTime = 0;
        highLight.transform.localPosition = GetNewPosition();
    }

    private Vector3 GetNewPosition()
    {
        float randX = Random.Range(startPosition, endPosition);
        float y = highLight.transform.localPosition.y;
        float z = highLight.transform.localPosition.z;
        return new Vector3(randX, y, z);
    }
    IEnumerator DoColorChange()
    {
        onError = true;
        Image image = line.GetComponent<Image>();
        image.color = Color.red;
        float tmp = arrow.GetComponent<Arrow>().speed;
        arrow.GetComponent<Arrow>().speed = 0f;
        yield return new WaitForSeconds(2f);
        image.color = Color.white;
        arrow.GetComponent<Arrow>().speed = tmp;
        onError = false;
        yield return null;
    }
}
