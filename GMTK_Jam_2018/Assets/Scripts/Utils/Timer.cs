using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float timer;
    private float timer1;
    private float timer2;
    private float timer3;
    private float timer4;
    private float timer5;

    void Start()
    {
        timer = 0.0f;
        timer1 = 0.0f;
        timer2 = 0.0f;
        timer3 = 0.0f;
        timer4 = 0.0f;
        timer5 = 0.0f;
    }

    void Update()
    {
        timer += Time.deltaTime;
        timer1 += Time.deltaTime;
        timer2 += Time.deltaTime;
        timer3 += Time.deltaTime;
        timer4 += Time.deltaTime;
        timer5 += Time.deltaTime;
    }

    public float GetElapsedTime(){
        return timer;
    }

    public float GetElapsedTime1()
    {
        return timer1;
    }

    public float GetElapsedTime2()
    {
        return timer2;
    }

    public float GetElapsedTime3()
    {
        return timer3;
    }

    public float GetElapsedTime4()
    {
        return timer4;
    }

    public float GetElapsedTime5()
    {
        return timer5;
    }

    public void ResetTimer() {
        timer = 0.0f;
    }

    public void ResetTimer1()
    {
        timer1 = 0.0f;
    }

    public void ResetTimer2()
    {
        timer2 = 0.0f;
    }

    public void ResetTimer3()
    {
        timer3 = 0.0f;
    }

    public void ResetTimer4()
    {
        timer4 = 0.0f;
    }

    public void ResetTimer5()
    {
        timer5 = 0.0f;
    }

}