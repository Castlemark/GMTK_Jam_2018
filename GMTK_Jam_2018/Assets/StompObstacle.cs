using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompObstacle : MonoBehaviour {

    private Timer timer;
    private bool isPlayer1;

    private PlayerController1 playerController1;
    private PlayerController2 playerController2;

    // Use this for initialization
    void Start () {
        playerController1 = GameObject.Find("player_1").GetComponent<PlayerController1>();
        playerController2 = GameObject.Find("player_2").GetComponent<PlayerController2>();

        timer = this.GetComponent<Timer>();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.name.Equals("player_1")) {
            isPlayer1 = true;
       } else {
            isPlayer1 = false;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(timer.GetElapsedTime() > 3.9f) {
            if (isPlayer1)
            {
                playerController1.stunLock();
            } else {
                //playerController2.stunLock();
            }
        }
    }

    public void DestroySelf()
    {
        Object.Destroy(this.gameObject);
    }
}
