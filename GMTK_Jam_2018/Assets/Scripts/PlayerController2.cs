using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour{

    public float speed;
    public bool can_move;
    public bool allowed_move;
    public bool eats_leaf;
    public bool eats_popcorn;
    public bool is_slipping;

    private float leaf_bonus;
    private float popcorn_penalty;

    private Vector2 moveVelocity;
    private Rigidbody2D rigidbody;
    private Animator animator;
    private float horizontal;
    private float vertical;
    private int directionality;
    
    // Use this for initialization
    void Start() {
        can_move = true;
        allowed_move = true;
        eats_leaf = false;
        eats_popcorn = false;

        leaf_bonus = 1f;
        popcorn_penalty = 1f;

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
            if (can_move && allowed_move)
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

        if (eats_leaf) {
            StartCoroutine(leafWait());
        }
        if (eats_popcorn) {
            StartCoroutine(popcornWait());
        }

        animator.SetInteger("Directionality", directionality);
        Vector2 moveInput = new Vector2(horizontal, vertical);
        moveVelocity = moveInput.normalized * speed * leaf_bonus * popcorn_penalty;
    }

    void FixedUpdate() {
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

    public void stunLock()
    {
        StartCoroutine(stunWait());
    }

    IEnumerator leafWait()
    {
        leaf_bonus = 2.0f;
        yield return new WaitForSeconds(6);
        leaf_bonus = 1.0f;
        eats_leaf = false;
    }

    IEnumerator popcornWait()
    {
        popcorn_penalty = 0.5f;
        yield return new WaitForSeconds(6);
        popcorn_penalty = 1.0f;
        eats_popcorn = false;
    }

    IEnumerator stunWait()
    {
        this.Inmobilize();
        yield return new WaitForSeconds(3);
        this.Mobilize();
    }
}
