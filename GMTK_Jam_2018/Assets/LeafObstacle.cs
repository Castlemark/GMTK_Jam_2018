using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafObstacle : MonoBehaviour {

    private PlayerController1 playerController1;
    private PlayerController2 playerController2;

    void Start()
    {
        playerController1 = GameObject.Find("player_1").GetComponent<PlayerController1>();
        playerController2 = GameObject.Find("player_2").GetComponent<PlayerController2>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name.Equals("player_1")) {
            playerController1.Inmobilize();
            playerController1.eats_leaf = true;
        } else {
            //playerController2.eats_leaf = true;
            playerController2.Inmobilize();
        }
        StartCoroutine(waitAndDestroy());
    }

    IEnumerator waitAndDestroy() {
        yield return new WaitForSeconds(3);
        playerController1.Mobilize();
        playerController2.Mobilize();
        Object.Destroy(this.gameObject);
    }
}