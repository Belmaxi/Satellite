using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public int index;
    void Update()
    {
        if((transform.position - PlayerManager.instance.GetPosition()).magnitude < 10)
        {
            DialogManager.instance.ShowDialog(index);
        }
    }
}
