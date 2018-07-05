using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampfireGroundCollision : MonoBehaviour
{

    public GameObject campfire;
    public VitalsScript vitals;
    public bool IsWarm = false;


    private void Start()
    {
        vitals = GameObject.FindGameObjectWithTag("Player").GetComponent<VitalsScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Terrain")
        {


            campfire.GetComponent<Rigidbody>().isKinematic = true;

        }
        if (other.tag == "Player")
        {
            IsWarm = true;
        }



    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            IsWarm = false;
        }
    }

    private void Update()
    {
        if (IsWarm)
        {
            vitals.currentTemp += Time.deltaTime * vitals.temperatureCooldown*4;
        }
    }
}
