using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour {

    public float speed;
    public bool can_move;

    private Vector2 moveVelocity;
    private Rigidbody2D rigidbody;
    private Animator animator;
    private float horizontal;
    private float vertical;
    private int directionality;

	// Use this for initialization
	void Start () {
        can_move = true;

        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        directionality = 0;
        this.ResetValues();
        if (can_move)
        {
            if (Input.GetKey(KeyCode.W))
            {
                vertical = 1.0f;
                directionality = 3;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                vertical = -1.0f;
                directionality = 4;
            }

            if (Input.GetKey(KeyCode.D))
            {
                horizontal = 1.0f;
                directionality = 1;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                horizontal = -1.0f;
                directionality = 2;
            }
        }
        animator.SetInteger("Directionality", directionality);

        Vector2 moveInput = new Vector2(horizontal, vertical);
        moveVelocity = moveInput.normalized * speed;
    }

    void FixedUpdate(){
        rigidbody.MovePosition(rigidbody.position + moveVelocity * Time.fixedDeltaTime);
    }

    private void ResetValues()
    {
        horizontal = 0.0f;
        vertical = 0.0f;
    }

    private void Inmobilize()
    {
        this.can_move = false;
    }

    public void Mobilize()
    {
        this.can_move = true;
    }
}
