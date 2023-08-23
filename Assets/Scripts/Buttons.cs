using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Buttons : MonoBehaviour
{
    private Button button;

    public void ChangeToSelection()
    {
        MenuManager.instance.menu.SetActive(false);
        MenuManager.instance.map.SetActive(true);
    }

    public void Resume()
    {

    }

    public void Exit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    
}
