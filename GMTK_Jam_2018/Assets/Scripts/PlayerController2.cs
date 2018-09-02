using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{

    public float speed;
    public bool can_move;
    public bool is_slipping;

    private Vector2 moveVelocity;
    private Rigidbody2D rigidbody;
    private Animator animator;
    private float horizontal;
    private float vertical;
    private int directionality;
    

    // Use this for initialization
    void Start() {
        can_move = true;

        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

        if (is_slipping)
        {
            speed = 0.3f;
            directionality = 0;
        }
        else
        {
            speed = 0.1f;
            directionality = 0;
            this.ResetValues();
            if (can_move)
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    vertical = 1.0f;
                    directionality = 3;
                }
                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    vertical = -1.0f;
                    directionality = 4;
                }

                if (Input.GetKey(KeyCode.RightArrow))
                {
                    horizontal = 1.0f;
                    directionality = 1;
                }
                else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    horizontal = -1.0f;
                    directionality = 2;
                }
            }
        }

        animator.SetInteger("Directionality", directionality);
        Vector2 moveInput = new Vector2(horizontal, vertical);
        moveVelocity = moveInput.normalized * speed;
    }

    void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + moveVelocity * Time.fixedDeltaTime);
    }

    private void ResetValues()
    {
        horizontal = 0.0f;
        vertical = 0.0f;
    }

    public void Inmobilize()
    {
        this.can_move = false;
    }

    public void Mobilize()
    {
        this.can_move = true;
    }
}
