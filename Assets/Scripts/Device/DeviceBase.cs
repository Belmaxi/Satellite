using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DeviceBase : MonoBehaviour
{
    public GameObject popObject;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && (PlayerManager.instance.GetPosition() - transform.position).magnitude < 5f)
        {
            PlayerManager.instance.Stop();
            Active();
        }
    }

    public abstract void Active();
}
