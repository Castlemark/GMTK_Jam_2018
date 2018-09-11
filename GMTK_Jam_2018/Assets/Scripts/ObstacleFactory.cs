using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFactory : MonoBehaviour {

    public float distance_h = 2.377f;
    public float distance_v = 1.28f;

    bool[,] obstacle_layout;

    private float column_unit;
    private float row_unit;

    private int rows;
    private int columns;

    private Timer timer;

    public GameObject stompObject;
    public float stompRate;

    public GameObject rockObject;
    public float rockRate;

    public GameObject oilObject;
    public float oilRate;

    public GameObject leafObject;
    public float leafRate;

    public GameObject popcornObject;
    public float popcornRate;

    // Use this for initialization
    void Start () {
        columns = 10;
        rows = 5;
        column_unit = distance_h / columns;
        row_unit = distance_v / rows;
        obstacle_layout = new bool[columns, rows];
        timer = this.GetComponent<Timer>();
    }
	
	// Update is called once per frame
	void Update () {
		
        if (timer.GetElapsedTime() > stompRate)
        {
            Instantiate(stompObject,
                        new Vector3(Random.Range(-1.01f, 1.367f), Random.Range(-0.8f, 0.63f), -1f),
                        Quaternion.identity);
            timer.ResetTimer();
        }

        if (timer.GetElapsedTime1() > oilRate)
        {
            Instantiate(oilObject,
                        new Vector3(-1.01f + Random.Range(0, columns + 1) * column_unit, -0.8f + Random.Range(0, rows + 1) * row_unit, -1f),
                        Quaternion.identity);
            timer.ResetTimer1();
        }

        if (timer.GetElapsedTime2() > rockRate)
        {
            Instantiate(rockObject,
                        new Vector3(-1.01f + Random.Range(0, columns + 1) * column_unit, -0.8f + Random.Range(0, rows + 1) * row_unit, -1f),
                        Quaternion.identity);
            timer.ResetTimer2();
        }

        if (timer.GetElapsedTime3() > leafRate)
        {
            Instantiate(leafObject,
                        new Vector3(-1.01f + Random.Range(0, columns + 1) * column_unit, -0.8f + Random.Range(0, rows + 1) * row_unit, -1f),
                        Quaternion.identity);
            timer.ResetTimer3();
        }

        if (timer.GetElapsedTime4() > popcornRate)
        {
            Instantiate(popcornObject,
                        new Vector3(-1.01f + Random.Range(0, columns + 1) * column_unit, -0.8f + Random.Range(0, rows + 1) * row_unit, -1f),
                        Quaternion.identity);
            timer.ResetTimer4();
        }

    }
}
