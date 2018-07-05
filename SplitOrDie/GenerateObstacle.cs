using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObstacle : MonoBehaviour {

    public GameObject[] obstacles;

	void Start () {

        int n = 6;
        for (int i = 0; i < 5; i++)
        {        
            int j = Random.Range(0, 16);
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, n);
            Instantiate(obstacles[j], pos, transform.rotation);
            n += 6;
        }
    }
	
    public void SpawnObstacle(Transform _pos)
    {
        int j = Random.Range(0, 16);
        Vector3 randObs = new Vector3(_pos.position.x, _pos.position.y, _pos.position.z + Random.Range(0f, 0.5f));
        Instantiate(obstacles[j], randObs, transform.rotation);
    }
}
