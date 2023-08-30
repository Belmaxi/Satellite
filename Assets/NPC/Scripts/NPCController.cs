using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public int[] indexs;
    void Update()
    {
        if((transform.position - PlayerManager.instance.GetPosition()).magnitude < 10f && Input.GetKeyDown(KeyCode.E))
        {
            print(DialogManager.instance.GetDialogIndex());
            for(int i = 0; i < indexs.Length; i++)
            {
                print(indexs[i]);
                if (DialogManager.instance.GetDialogIndex() == indexs[i])
                {
                    DialogManager.instance.ShowDialog();
                    break;
                }
            }
        }
    }
}
