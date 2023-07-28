using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal enum State
{
    Idel,
    Walk,
    Run,
    Collect,
    Work,
    Picking
}
public class PlayerController : MonoBehaviour
{
    State state = State.Idel;
    public float speed =15f;
    private Rigidbody2D rb;
    private bool isPicked = false;
    private Item pick;
    public Camera cameraInScene;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PickItem();
        }
        cameraInScene.transform.position = new Vector3(transform.position.x,transform.position.y,-10);
    }

    private void FixedUpdate()
    {
        Move();
        
    }

    void FSM()
    {
        switch(state)
        {
            case State.Idel:
                break;
            case State.Walk:
                break;
            case State.Run:
                break;
            case State.Collect:
                break;
            case State.Work:
                break;
            case State.Picking:
                break;
        }
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(horizontal, vertical) * speed * Time.deltaTime);
        if(pick != null)
        {
            pick.gameObject.transform.position = transform.position;
        }
    }

    void PickItem()
    {
        if (isPicked)
        {
            print("Something in your hand");
            pick = null;
            isPicked = false;
            return;
        }
        List<Item> list = ItemManager.instance.GetPickableItems();
        if(list.Count == 0) {
            print("No Item To Pick");
            return;
        }
        isPicked= true;
        pick = list[0];
    }
}
