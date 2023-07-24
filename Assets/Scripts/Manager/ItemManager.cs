using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;
    private List<Item> items = new List<Item>();
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        List<Item> list = GetPickableItems();
    }

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }

    public List<Item> GetPickableItems()
    {
        List<Item> list = new List<Item>();
        foreach (var item in items)
        {
            if (item.Pickable)
            {
                list.Add(item);
            }
        }
        return list;
    }
}
