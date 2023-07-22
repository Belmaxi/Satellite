using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager
{
    private static PoolManager instance;

    private GameObject poolObj;
    public static PoolManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PoolManager();
            }
            return instance;
        }
    }

    //
    private Dictionary<GameObject, List<GameObject>> poolDataDic = new Dictionary<GameObject, List<GameObject>>();

    public GameObject GetObj(GameObject prefab)
    {
        GameObject obj = null;
        if (poolDataDic.ContainsKey(prefab) && poolDataDic[prefab].Count > 0)
        {
            obj = poolDataDic[prefab][0];
            poolDataDic[prefab].RemoveAt(0);
        }
        else
        {
            obj = GameObject.Instantiate(prefab);
        }
        obj.SetActive(true);
        obj.transform.SetParent(null);
        return obj;
    }

    public void PushObj(GameObject prefab, GameObject obj)
    {
        if (poolObj == null)
        {
            poolObj = new GameObject("PoolObj");
        }

        if (poolDataDic.ContainsKey(prefab))
        {
            poolDataDic[prefab].Add(obj);
        }
        else
        {
            poolDataDic.Add(prefab, new List<GameObject>() { obj });
        }
        if (poolObj.transform.Find(prefab.name) == false)
        {
            new GameObject(prefab.name).transform.SetParent(poolObj.transform);
        }
        obj.SetActive(false);

        obj.transform.SetParent(poolObj.transform.Find(prefab.name));
    }


    public void Clear()
    {
        poolDataDic.Clear();
    }
}
