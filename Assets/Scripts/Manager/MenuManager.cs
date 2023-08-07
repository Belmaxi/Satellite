using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    static public MenuManager instance;
    public GameObject menu;
    public GameObject map;

    private void Awake()
    {
        instance = this; 
    }

}
