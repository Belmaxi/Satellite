using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempController : MonoBehaviour
{
    private Scrollbar bar;
    public float speed = 1f;
    public float power = 0.1f;

    public float downLimit = 0.5f;
    public float upLimit = 0.9f;

    private float timer = 0f;
    private void Start()
    {
        bar = GetComponentInChildren<Scrollbar>();
        bar.size = 0.7f;
        timer = 0f;
    }
    void Update()
    {
        bar.size -= speed * Time.deltaTime;
        if(bar.size <= downLimit || bar.size >= upLimit)
        {
            Destroy(gameObject.transform.parent.gameObject);
            PlayerManager.instance.Resume();
        }
        Jump();
        if (isok())
        {
            Destroy(gameObject.transform.parent.gameObject);
            PlayerManager.instance.Resume();
            LittleGameManager.instance.Achieve(AchieveState.mengp);
        }

    }

    void Jump()
    {
        timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.J))
        {
            bar.size += power;
        }
    }

    bool isok()
    {
        if(timer > 10f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
