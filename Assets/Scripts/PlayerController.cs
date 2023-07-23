using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum State
{
    Idel,
    Walk,
    Run,
    Collect,
    Work
}
public class PlayerController : MonoBehaviour
{
    State state = State.Idel;
    public float speed = 1.14f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
        }
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(horizontal, vertical) * speed * Time.deltaTime);
    }
}
