using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPunchCollision : MonoBehaviour
{

    public bool hitEnemy = false;


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Enemy")
        {

            hitEnemy = true;


        }
    }
}
