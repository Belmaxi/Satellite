using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Collider2D coll;
    private bool pickable;
    private bool isPicked;

    public bool Pickable { get => pickable; set => pickable = value; }
    public bool IsPicked { get => isPicked; set => isPicked = value; }


    // Start is called before the first frame update
    void Start()
    {
        Pickable = false;
        coll = GetComponent<Collider2D>();
        ItemManager.instance.AddItem(this);
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

    public void Drop(Vector3 pos)
    {
        StartCoroutine(SmoothMove(pos, 0.5f));
    }

    protected IEnumerator SmoothMove(Vector3 targetPos,float timer) {
        float currTime = 0f;
        while(currTime < timer && !IsPicked)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, currTime / timer);
            currTime += 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
        yield return null;
    }

    public void Destroy()
    {
        ItemManager.instance.RemoveItem(this);
        Destroy(gameObject);
    }
}
