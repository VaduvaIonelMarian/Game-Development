using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour {
    public bool isNight=false;
	
	void Update () {
        transform.RotateAround(Vector3.zero, Vector3.right, 0.5f * Time.deltaTime);
        transform.LookAt(Vector3.zero);
        if (transform.position.y <= -500)
        {
            isNight = true;
        }
        else
        {
            isNight = false;
        }
	}
}
