using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Time.timeScale = 10;
	}

    void OnCollisionEnter()
    {
        Time.timeScale = 1;
    }
}
