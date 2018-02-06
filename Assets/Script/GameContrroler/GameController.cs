using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {


    static public bool gameIsPaused = false;

	void Start ()
    {
        Application.targetFrameRate = 60;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(gameIsPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
	}
}
