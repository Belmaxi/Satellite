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
        SoundManager.instance.PlaySound("click");
        MenuManager.instance.ShowBackGround();
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
        SoundManager.instance.PlaySound("rightchoice");
        PlayerManager.instance.Resume();
        NPCManager.instance.GetController(1).ShowMark();
        ArrowManager.instance.GetArrow(0).SetActive(false);
        Destroy(obj);
    }

    public void CloseWindows(GameObject obj)
    {
        PlayerManager.instance.Resume();
        SoundManager.instance.PlaySound("click");
        Destroy(obj);
    }

    public void SimpleCloseWindows(GameObject obj)
    {
        SoundManager.instance.PlaySound("click");
        MenuManager.instance.map.SetActive(true);
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
        MenuManager.instance.menu.SetActive(false);
        MenuManager.instance.map.SetActive(true);
        yield return null;
    }


}
