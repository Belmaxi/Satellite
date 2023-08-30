using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField] private NPCParameter so_Npc;
    void Update()
    {
        if((transform.position - PlayerManager.instance.GetPosition()).magnitude < 10f && Input.GetKeyDown(KeyCode.E))
        {
            for(int i = 0; i < so_Npc.indexs.Count; i++)
            {
                if (DialogManager.instance.GetDialogIndex() == so_Npc.indexs[i])
                {
                    DialogManager.instance.ShowDialog();
                    break;
                }
            }
        }
    }
}
