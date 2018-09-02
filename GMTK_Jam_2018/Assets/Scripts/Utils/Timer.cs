using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float timer;

    void Start()
    {
        timer = 0.0f;
    }

    void Update()
    {
        timer += Time.deltaTime;
    }

    public float GetElapsedTime(){
        return timer;
    }

    public void ResetTimer() {
        timer = 0.0f;
    }
}