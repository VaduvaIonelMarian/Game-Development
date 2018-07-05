using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseGroundCollision : MonoBehaviour {

    public GameObject house;




    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Terrain")
        {


            house.GetComponent<Rigidbody>().isKinematic = true;

        }


    }
}
