using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public List<GameObject> whiteList;
    public int rightObject;
    private bool isoked = false;
    public NPCController targetNPC;

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
                            if (i == j) continue;
                            Destroy(whiteList[j]);
                        }
                        targetNPC.ShowMark();
                    }
                    return;
                }
            }
        }
    }

    bool isok(int idx)
    {
        return idx == rightObject;
    }
}
