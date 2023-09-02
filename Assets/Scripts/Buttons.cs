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
    /// 场景从menu传送到显示选地点
    /// </summary>
    public void ChangeToSelection()
    {
        StartCoroutine(DoShowDialog());
    }

    /// <summary>
    /// 小游戏界面清除
    /// </summary>
    public void ResumeFromPuzzle(GameObject obj)
    {
        PuzzleChecker puzzleChecker = obj.GetComponent<PuzzleChecker>();
        if (!puzzleChecker.isok())
        {
            return;
        }
        PlayerManager.instance.Resume();
        NPCManager.instance.GetController(1).ShowMark();
        ArrowManager.instance.GetArrow(0).SetActive(false);
        Destroy(obj);
    }

    public void CloseWindows(GameObject obj)
    {
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

    IEnumerator DoShowDialog()
    {
        MenuManager.instance.ShowBackGround();
        yield return new WaitForSeconds(5f);
        MenuManager.instance.HideBackGroumd();
        MenuManager.instance.menu.SetActive(false);
        MenuManager.instance.map.SetActive(true);
        yield return null;
    }


}
