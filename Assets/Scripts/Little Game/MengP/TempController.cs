using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempController : MonoBehaviour
{
    private Scrollbar bar;
    public float speed = 1f;
    public float power = 0.1f;
    private void Start()
    {
        bar = GetComponentInChildren<Scrollbar>();
        bar.size = 0.7f;
    }
    void Update()
    {
        bar.size -= speed * Time.deltaTime;
        Jump();
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            bar.size += power;
        }
    }

}
