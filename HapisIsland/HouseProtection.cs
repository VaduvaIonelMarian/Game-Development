using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseProtection : MonoBehaviour {

    public bool insideHouse = false;
    public VitalsScript vitals;
    private float healthIncreaser=0.10f;

    private void Start()
    {
        vitals = GameObject.FindGameObjectWithTag("Player").GetComponent<VitalsScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            insideHouse = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            insideHouse = false;
        }
    }
    private void Update()
    {
        if (insideHouse)
        {
            vitals.health += Time.deltaTime*healthIncreaser;
        }
    }

}
