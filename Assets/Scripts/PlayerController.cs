using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal enum State
{
    Idel,
    Pick,
    Stop
}
public class PlayerController : MonoBehaviour
{
    State state = State.Idel;
    public float speed = 15f;
    private Rigidbody2D rb;
    private bool isPicked = false;
    private Item pick;
    public Camera cameraInScene;
    private Animator m_animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        FSM();
        cameraInScene.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }

    void FSM()
    {
        switch (state)
        {
            case State.Idel:
                Move();
                PickItem();
                break;
            case State.Pick:
                Move();
                DropItem();
                break;
            case State.Stop:
                break;
        }
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (horizontal > 0)
        {
            m_animator.SetBool("MoveRight", true);
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else
        {
            m_animator.SetBool("MoveLeft", true);
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        transform.Translate(new Vector2(horizontal, vertical) * speed * Time.deltaTime);
        if (pick != null)
        {
            pick.gameObject.transform.position = transform.position + new Vector3(0f, 1f, 0f);
        }
    }

    void PickItem()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            List<Item> list = ItemManager.instance.GetPickableItems();
            if (list.Count == 0)
            {
                return;
            }
            state = State.Pick;
            list[0].IsPicked = true;
            pick = list[0];
        }
    }

    void DropItem()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pick.IsPicked = false;
            pick.Drop(transform.position);
            pick = null;
            state = State.Idel;
        }
    }

    public void Stop()
    {
        state = State.Stop;
    }

    public void Resume()
    {
        if (pick != null)
        {
            state = State.Idel;
        }
        else
        {
            state = State.Pick;
        }
    }
}
