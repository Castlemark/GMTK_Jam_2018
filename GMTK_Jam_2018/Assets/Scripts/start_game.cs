using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_game : MonoBehaviour {

    public void LoadStage()
    {
        Application.LoadLevel("SampleScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}


