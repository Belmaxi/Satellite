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
    private Animator m_animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PickItem();
            state = State.Collect;
        }
        cameraInScene.transform.position = new Vector3(transform.position.x,transform.position.y,-10);
    }

    private void FixedUpdate()
    {
        FSM();
        
    }

    void FSM()
    {
        switch(state)
        {
            case State.Idel:
                Move();
                break;
            case State.Walk:
                Move();
                break;
            case State.Run:
                break;
            case State.Collect:
                Move();
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
        if(horizontal == 0f && vertical == 0f)
        {
            m_animator.SetBool("Move", false);
        }
        else if(horizontal > 0)
        {
            m_animator.SetBool("Move", true);
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else
        {
            m_animator.SetBool("Move", true);
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        
        transform.Translate(new Vector2(horizontal, vertical) * speed * Time.deltaTime);
        if(pick != null)
        {
            pick.gameObject.transform.position = transform.position + new Vector3(0f, 1f, 0f);
        }
    }

    void PickItem()
    {
        if (isPicked)
        {
            print("Something in your hand");
            pick.IsPicked = false;
            pick.Drop(transform.position);
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
        list[0].IsPicked = true;
        pick = list[0];
    }
}
