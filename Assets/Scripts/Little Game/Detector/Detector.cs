using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public List<GameObject> whiteList;
    public int rightObject;
    public GameObject targetGame;

    private void Update()
    {
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
                        Destroy(obj);
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
