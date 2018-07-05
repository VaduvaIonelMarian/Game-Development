using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRotation : MonoBehaviour {

	void Update () {

        if(!GameManager.Instance.isDead)
        transform.Rotate(400 * Time.deltaTime,0, 0);

    }
}
