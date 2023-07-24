using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;
    private List<GameObject> items = new List<GameObject>();
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        List<GameObject> list = GetPickableItems();
        foreach (var item in list)
        {
            print(item);
        }
    }

    public void AddItem(GameObject item)
    {
        items.Add(item);
    }

    private List<GameObject> GetPickableItems()
    {
        List<GameObject> list = new List<GameObject>();
        foreach (var item in items)
        {
            Item itemScript = item.GetComponent<Item>();
            if (itemScript.Pickable)
            {
                list.Add(item);
            }
        }
        return list;
    }
}
