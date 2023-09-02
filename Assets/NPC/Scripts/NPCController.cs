using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : DeviceBase
{
    [SerializeField] private NPCParameter so_Npc;
    [SerializeField] private GameObject excalmatoryMark;
    public override void Active()
    {
        for(int i = 0; i < so_Npc.indexs.Count; i++)
        {
            if (DialogManager.instance.GetDialogIndex() == so_Npc.indexs[i])
            {
                DialogManager.instance.ShowDialog();
                return;
            }
        }
        PlayerManager.instance.Resume();
    }

    public void ShowMark()
    {
        excalmatoryMark.SetActive(true);
    }

    public void HideMark()
    {
        excalmatoryMark.SetActive(false);
    }

    public bool IsNow()
    {
        for (int i = 0; i < so_Npc.indexs.Count; i++)
        {
            if (DialogManager.instance.GetDialogIndex() == so_Npc.indexs[i])
            {
                return true;
            }
        }
        return false;
    }
}
