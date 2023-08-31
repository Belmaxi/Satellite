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
            if (controllers[i].IsNow())
            {
                controllers[i].ShowMark();
            }
            else
            {
                controllers[i].HideMark();
            }
        }
    }
}
