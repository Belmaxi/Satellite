using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Vector2 startPosition;
    public Vector2 endPosition;
    public float speed = 1f;

    private float lerp;


    private float timer;

    public float Lerp { get => lerp;}

    private void Start()
    {
        transform.localPosition = startPosition;
        timer = 0f;
    }
    private void Update()
    {
        lerp = (Mathf.Sin(timer) + 1f) / 2;
        transform.localPosition = Vector2.Lerp(startPosition, endPosition, lerp);
        timer += speed * Time.deltaTime;
    }
}
