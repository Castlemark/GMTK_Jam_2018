using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilObstacle : MonoBehaviour {

    private PlayerController1 playerController1;
    private PlayerController2 playerController2;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("enter oli");

        if (other.name.Equals("player_1"))
        {
            playerController1 = GameObject.Find("player_1").GetComponent<PlayerController1>();
            playerController1.is_slipping = true;
        }
        else
        {
            playerController2 = GameObject.Find("player_2").GetComponent<PlayerController2>();
            playerController2.is_slipping = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("leaves oli");

        if (collision.name.Equals("player_1"))
        {
            playerController1 = GameObject.Find("player_1").GetComponent<PlayerController1>();
            playerController1.is_slipping = false;
        }
        else
        {
            playerController2 = GameObject.Find("player_2").GetComponent<PlayerController2>();
            playerController2.is_slipping = false;
        }
    }
}
