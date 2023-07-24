using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideSwinger : MonoBehaviour
{
    private Slider swingerSlider;
    private float thita;
    private void Start()
    {
        swingerSlider = GetComponent<Slider>();
    }
    // Update is called once per frame
    void Update()
    {
        thita += 0.01f;
        swingerSlider.value = (Mathf.Sin(thita)+1)/2.0f;
    }
}
