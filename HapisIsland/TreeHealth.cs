using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeHealth : MonoBehaviour {

    public int normalTreeHealth = 100;
    public int bananaTreeHealth = 100;
    public int coconutTreeHealth = 100;
    public GameObject bananaTree;
    public GameObject coconutTree;
    public GameObject bananaPack;
    public GameObject coconut;
  
    
    

   


   
    private void Update () {
         
        if (normalTreeHealth <= 0)
        {
            Destroy(gameObject);
        }
        if (bananaTreeHealth <= 0)
        {
            Destroy(gameObject);
            
            Instantiate(bananaPack, bananaTree.transform.position + new Vector3(0, 3, -5), Quaternion.identity);
            Instantiate(bananaPack, bananaTree.transform.position + new Vector3(-4, 4, 4), Quaternion.identity);
            Instantiate(bananaPack, bananaTree.transform.position + new Vector3(4, 5, 3), Quaternion.identity);

        }
        if (coconutTreeHealth <= 0)
        {
            Destroy(gameObject);
            
            Instantiate(coconut, coconutTree.transform.position + new Vector3(0, 3, -5), Quaternion.identity);
            Instantiate(coconut, coconutTree.transform.position + new Vector3(-4, 4, 4), Quaternion.identity);
            Instantiate(coconut, coconutTree.transform.position + new Vector3(4, 5, 3), Quaternion.identity);

        }


    }
    
  
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        
    }


}
