using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackCollision : MonoBehaviour {

    public bool hitPlayer = false;


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {

            hitPlayer = true;


        }
    }
}
