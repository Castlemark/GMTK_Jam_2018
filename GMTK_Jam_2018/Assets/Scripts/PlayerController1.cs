using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour {

    public float speed;

    private Vector2 moveVelocity;
    private new Rigidbody2D rigidbody;
    private new Animator animator;
    private float horizontal;
    private float vertical;
    private int directionality;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        directionality = 0;
        this.ResetValues();
        if (Input.GetKey(KeyCode.W)){
            vertical = 1.0f;
            directionality = 3;
        } else if (Input.GetKey(KeyCode.S)) {
            vertical = -1.0f;
            directionality = 4;
        }

        if (Input.GetKey(KeyCode.D)) {
            horizontal = 1.0f;
            directionality = 1;
        }
        else if (Input.GetKey(KeyCode.A)) {
            horizontal = -1.0f;
            directionality = 2;
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
}
