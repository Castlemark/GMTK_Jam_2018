using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceController : MonoBehaviour
{
    private Timer timer;
    private float elapsedTime;

    private PlayerController1 playerController1;
    private PlayerController2 playerController2;
    private FinishTrigger trigger;

    // Use this for initialization
    void Start() {

        playerController1 = GameObject.Find("player_1").GetComponent<PlayerController1>();
        playerController2 = GameObject.Find("player_2").GetComponent<PlayerController2>();
        trigger = GameObject.Find("finish_trigger").GetComponent<FinishTrigger>();
        timer = gameObject.GetComponent<Timer>();

        this.Inmobilize();
    }

    // Update is called once per frame
    void LateUpdate()
    {

        this.Mobilize();
        elapsedTime = timer.GetElapsedTime();
        if (elapsedTime < 3.0f) {
            this.Inmobilize();
        }

        if (trigger.SomeoneHasFinished()) {
            this.Inmobilize();
            //display victory text, wait 5 seconds and wait for enter to return to screen
            switch (trigger.victorious_player)
            {
                case 1:
                    Debug.Log("Player 1 wins!");
                    break;

                case 2:
                    Debug.Log("Player 2 wins!");
                    break;
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
