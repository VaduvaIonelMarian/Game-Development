using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour {

    public static CoinManager cm=null;
   
   

    private void Awake()
    {
        if (cm == null)
            cm = GameObject.Find("CoinManager").GetComponent<CoinManager>();
        
       
            
    }
   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ball")
        {
            Destroy(gameObject);
            cm.CoinIncrease();
            
            cm.coinContor--;
        }
    }
   
}
