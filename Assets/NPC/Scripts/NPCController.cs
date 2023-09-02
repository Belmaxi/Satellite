using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : DeviceBase
{
    [SerializeField] private NPCParameter so_Npc;
    [SerializeField] private GameObject excalmatoryMark;
    private bool canChat = true;
    public override void Active()
    {
        if (!canChat)
        {
            PlayerManager.instance.Resume();
            return;
        }
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
        canChat = true;
    }

    public void HideMark()
    {
        excalmatoryMark.SetActive(false);
        canChat = false;
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
