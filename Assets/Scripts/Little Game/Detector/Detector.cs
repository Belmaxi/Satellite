using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Detector : MonoBehaviour
{
    public List<GameObject> whiteList;

    private List<Vector3> whiteListPosition = new List<Vector3>();
    public int rightObject;
    private bool isoked = false;
    public NPCController targetNPC;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        for(int i=0;i<whiteList.Count; i++)
        {
            GameObject obj = whiteList[i];
            whiteListPosition.Add(obj.transform.position);
        }
    }

    private void Update()
    {
        if (isoked) return;
        for (int i = 0; i < whiteList.Count; i++)
        {
            GameObject obj = whiteList[i];
            if (obj.tag == "Item")
            {
                Item item = obj.GetComponent<Item>();
                if (!item.IsPicked && (item.transform.position - transform.position).magnitude < 4f)
                {
                    if (isok(i))
                    {
                        isoked = true;
                        for(int j = 0; j < whiteList.Count; j++)
                        {
                            if (whiteList[j]!=null)
                                Destroy(whiteList[j]);
                        }
                        targetNPC.ShowMark();
                        PlayerManager.instance.Resume();
                        SoundManager.instance.PlaySound("rightchoice");
                        break;
                    }
                    else
                    {
                        StartCoroutine(DoFlash(1f, Color.red, 0.02f));
                        Destroy(obj);
                        SoundManager.instance.PlaySound("error");
                        whiteList.Remove(obj);
                        break;
                    }
                }
            }
        }
    }

    bool isok(int idx)
    {
        return idx == rightObject;
    }

    protected IEnumerator DoFlash(float wantTime, Color targetColor, float delay, UnityAction fun = null)
    {
        float currTime = 0f;
        while (currTime <= wantTime)
        {
            float lerp = currTime / wantTime;
            yield return new WaitForSeconds(delay);
            currTime += delay;
            spriteRenderer.color = Color.Lerp(Color.white, targetColor, lerp);
        }
        spriteRenderer.color = Color.white;
        if (fun != null)
        {
            fun();
        }
    }
}
