using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolAudioScript : MonoBehaviour {
    public AudioSource audioSource;
    private bool inWater = false;
	private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            inWater = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inWater = false;
        }
    }
    private void Update()

    {
       
        
        if (Input.GetKeyDown(KeyCode.W) && inWater)
        {
            audioSource.Play();
        }
        if (!inWater||Input.GetKeyUp(KeyCode.W))
        {
            audioSource.Stop();
        }
        
    }
}
