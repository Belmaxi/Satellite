using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Buttons : MonoBehaviour
{
    private Button button;

    /// <summary>
    /// 场景从menu传送到main
    /// </summary>
    public void ChangeToSelection()
    {
        MenuManager.instance.menu.SetActive(false);
        MenuManager.instance.map.SetActive(true);
    }

    /// <summary>
    /// 小游戏界面清除
    /// </summary>
    public void ResumeFromPuzzle(GameObject obj, GameObject[] puzzles)
    {
        foreach (GameObject puzzle in puzzles)
        {
            Dragable drag = puzzle.GetComponent<Dragable>();
            if (!drag.IsTargeted)
            {
                return;
            }
        }
        PlayerManager.instance.Resume();
        Destroy(obj);
        
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
