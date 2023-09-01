using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : DeviceBase
{
    public override void Active()
    {
        Instantiate(popObject);
    }
}
