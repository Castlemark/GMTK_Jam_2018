﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceController : MonoBehaviour
{
    public float countdown_time;

    private Timer timer;
    private float elapsedTime;
    private int player;

    private PlayerController1 playerController1;
    private PlayerController2 playerController2;
    private FinishTrigger trigger;
    private Animator animator;

    // Use this for initialization
    void Start() {

        playerController1 = GameObject.Find("player_1").GetComponent<PlayerController1>();
        playerController2 = GameObject.Find("player_2").GetComponent<PlayerController2>();
        trigger = GameObject.Find("finish_trigger").GetComponent<FinishTrigger>();
        timer = gameObject.GetComponent<Timer>();
        animator = GameObject.Find("win_message").GetComponent<Animator>();

        player = 0;

        this.Inmobilize();
    }

    // Update is called once per frame
    void LateUpdate()
    {

        this.Mobilize();
        elapsedTime = timer.GetElapsedTime();
        if (elapsedTime < countdown_time) {
            this.Inmobilize();
        }

        if (trigger.SomeoneHasFinished()) {
            this.Inmobilize();
            //display victory text, wait 5 seconds and wait for enter to return to screen
            switch (trigger.victorious_player)
            {
                case 1:
                    player = 1;
                    Debug.Log("Player 1 wins!");
                    break;

                case 2:
                    player = 2;
                    Debug.Log("Player 2 wins!");
                    break;
            }
            animator.SetInteger("player", player);

            if (Input.GetKey(KeyCode.Space)) {
                Application.LoadLevel("MainMenu");
            }
        }
    }

    public void Inmobilize() {
        playerController1.can_move = false;
        playerController2.can_move = false;
    }

    public void Mobilize() {
        playerController1.can_move = true;
        playerController2.can_move = true;
    }
}
