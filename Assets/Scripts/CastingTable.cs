using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingTable : MonoBehaviour
{
    public List<GameObject> whiteList;
    public GameObject targetGame;

    private int cnt = 0;

    public int Cnt { get => cnt;
        set
        {
            cnt = value;
            if(cnt == 6)
            {
                PlayerManager.instance.Stop();
                Instantiate(targetGame);
            }
        }
    }

    private void Update()
    {
        foreach (GameObject obj in whiteList)
        {
            
            if(obj.tag == "Item")
            {
                Item item = obj.GetComponent<Item>();
                if(!item.IsPicked && (item.transform.position-transform.position).magnitude < 4f)
                {
                    whiteList.Remove(obj);
                    Destroy(obj);
                    Cnt++;
                    return;
                }
            }
        }
    }
}
