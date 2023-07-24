using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Collider2D coll;
    private bool pickable;

    public bool Pickable { get => pickable; set => pickable = value; }


    // Start is called before the first frame update
    void Start()
    {
        Pickable = false;
        coll = GetComponent<Collider2D>();
        ItemManager.instance.AddItem(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Pickable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Pickable = false;
        }
    }
}
