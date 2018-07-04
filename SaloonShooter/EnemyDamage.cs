using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    private float timer;
   


	void Update () {
        timer += Time.deltaTime;

        if(timer >= StaticVariables.enemyShootSpeed)
        {
            StaticVariables.lives--;
            timer = 0f;
            StaticVariables.hitInRow = 0;
        }

	}
}
