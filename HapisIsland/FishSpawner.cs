using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour {
    public Transform[] dest;
    public GameObject fish;
    public int fishNumber = 10;
    private float fishTimeSpawner=180f;
    void Start () {
        for (int i = 0; i < dest.Length; i+=2)
        {
            Instantiate(fish, dest[i].position, Quaternion.identity);
        }
    }
	
	// Update is called once per frame
	void Update () {
        
        if (fishNumber <= 9)
        {
            fishTimeSpawner -= Time.deltaTime;
            if (fishTimeSpawner <= 0)
            {
                
                Instantiate(fish, dest[Random.Range(0, dest.Length)].position, Quaternion.identity);
                fishNumber += 1;
                fishTimeSpawner = 180f;
            }

           

        }
        
       
    }

   
}
