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
        Destroy(obj);
    }

    public void CloseWindows(GameObject obj)
    {
        Destroy(obj);
        PlayerManager.instance.Resume();
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
        print(1);
        yield return new WaitForSeconds(5f);
        print(1);
        MenuManager.instance.HideBackGroumd();
        MenuManager.instance.menu.SetActive(false);
        MenuManager.instance.map.SetActive(true);
        yield return null;
    }


}
