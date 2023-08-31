using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : DeviceBase
{
    [SerializeField] private NPCParameter so_Npc;
    public override void Active()
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
