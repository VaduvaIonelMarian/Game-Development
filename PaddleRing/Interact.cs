using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour {

    public GameObject ballPrefab;
    public Transform spawnPoint;
    public int ballContor=1;
    public GameObject[] paddels;
    private int i = 2;
    
    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Minus")
        {
            if ((transform.localScale.x >= 0.2f) && (transform.localScale.y >= 0.2f) && (transform.localScale.z == 1f))
            {
                transform.localScale -= new Vector3(0.1f, 0.1f, 0);
             
            }
            
            
                Destroy(other.gameObject);
            
        }
        if (other.tag == "Plus")
        {
            if ((transform.localScale.x <= 2f) && (transform.localScale.y <= 2f) && (transform.localScale.z == 1f))
            {
                transform.localScale += new Vector3(0.1f, 0.1f, 0);
               
            }
            
            
                Destroy(other.gameObject);
           
        }
    /*    if (other.tag == "Multiple")
        {
            Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);

            Destroy(other.gameObject);

            ballContor++;
        }*/
        if (other.tag == "Divide")
        {
            
        }
        if (other.tag == "Maximize")
        {
            if (i <= 3)
            {
                paddels[i].SetActive(false);
                paddels[i + 1].SetActive(true);
                i++;
                
            }
            Destroy(other.gameObject);
        }
        if (other.tag == "Minimize")
        {
            if (i >= 1)
            {
                paddels[i].SetActive(false);
                paddels[i-1].SetActive(true);
                i--;

            }
            Destroy(other.gameObject);
        }
    }
}
