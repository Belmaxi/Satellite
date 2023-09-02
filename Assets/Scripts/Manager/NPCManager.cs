using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    static public NPCManager instance;

    [SerializeField]
    private List<NPCController> controllers;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UpdateMark();
    }

    public void UpdateMark()
    {
        for(int i = 0; i < controllers.Count; i++)
        {
            switch (DialogManager.instance.GetDialogIndex()){
                case 2:
                    {
                        controllers[i].HideMark();
                        ArrowManager.instance.GetArrow(0).SetActive(true);
                        break;
                    }
                case 3:
                    {
                        controllers[i].HideMark();
                        ArrowManager.instance.GetArrow(1).SetActive(true);
                        break;
                    }
                case 5:
                    {
                        controllers[i].HideMark();
                        break;
                    }
                case 6:
                    {
                        controllers[i].HideMark();
                        ArrowManager.instance.GetArrow(3).SetActive(true);
                        break;
                    }
                case 8:
                    {
                        controllers[i].HideMark();
                        ArrowManager.instance.GetArrow(2).SetActive(true);
                        break;
                    }
                default:
                    {
                        if (controllers[i].IsNow())
                        {
                            controllers[i].ShowMark();
                        }
                        else
                        {
                            controllers[i].HideMark();
                        }
                        break;
                    }
            }
        }
    }

    public NPCController GetController(int index)
    {
        return controllers[index];
    }
}
