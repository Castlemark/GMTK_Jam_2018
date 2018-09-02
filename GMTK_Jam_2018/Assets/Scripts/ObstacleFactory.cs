using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFactory : MonoBehaviour {

    public GameObject stompObject;
    public float stompRate;
    private Timer stompTimer;

    // Use this for initialization
    void Start () {
        stompTimer = this.GetComponent<Timer>();
    }
	
	// Update is called once per frame
	void Update () {
		
        if (stompTimer.GetElapsedTime() > stompRate)
        {
            Instantiate(stompObject,
                        new Vector3(Random.Range(-1.01f, 1.367f), Random.Range(-0.65f, 0.63f), -1f),
                        Quaternion.identity);
            stompTimer.ResetTimer();
            Debug.Log("new stomp");
        }

	}
}
