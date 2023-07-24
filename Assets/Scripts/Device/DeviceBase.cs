using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DeviceBase : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Active();
        }
    }

    public abstract void Active();
}
