using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsSpawner : MonoBehaviour {

    public GameObject[] powerUps;
    public float spawnTimmer = 10f;
    private float xRange = 1.5f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        spawnTimmer -= Time.deltaTime;
        if (spawnTimmer <= 0)
        {
            Vector2 newPosition = new Vector2(Random.insideUnitCircle.x * xRange, Random.insideUnitCircle.y * xRange);
            int randomPU = Random.Range(0, powerUps.Length);

            GameObject powerUpInstance= Instantiate(powerUps[randomPU], newPosition, Quaternion.identity);
            spawnTimmer = 10f;
            StartCoroutine(DestroyPowerUp(powerUpInstance));

        }


		
	}

    private IEnumerator DestroyPowerUp(GameObject a)
    {
        yield return new WaitForSeconds(8f);
        Destroy(a);

    }
}
