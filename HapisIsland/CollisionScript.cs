using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour {
    public bool hitTree = false;
    public bool hitBananaTree = false;
    public bool hitCoconutTree = false;
    public bool hitEnemy = false;
    
  

   

	private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Tree")
        {
           
            hitTree = true;
           

        }
        if (other.tag == "BananaTree")
        {
            hitBananaTree = true;
           

        }
        if (other.tag == "CoconutTree")
        {
            hitCoconutTree = true;


        }
        if (other.tag == "Enemy")
        {
            hitEnemy = true;


        }
    }
   
   



}
