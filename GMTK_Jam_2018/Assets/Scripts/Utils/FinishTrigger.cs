using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour {

    public int victorious_player = 0;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.name.Equals("player_1")) {
            victorious_player = 1;
        } else {
            victorious_player = 2;
        }
    }

    public bool SomeoneHasFinished() {
        return victorious_player != 0;
    }
}
