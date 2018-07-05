using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoins : MonoBehaviour {

    public GameObject coinPrefab;

    private int chanceOfSpawn;

	// Use this for initialization
	void Start () {

        //chanceOfSpawn = Random.Range(0, 2);
         chanceOfSpawn = 0 ;
        if (chanceOfSpawn == 0)
        {
            Vector3 offsetXZ = new Vector3(Random.Range(-1.5f, 1.5f), 0.25f, Random.Range(3.0f, 5.0f));
            GameObject coin = Instantiate(coinPrefab, transform.position + offsetXZ, transform.rotation) as GameObject;     
        }
	}
	
}
