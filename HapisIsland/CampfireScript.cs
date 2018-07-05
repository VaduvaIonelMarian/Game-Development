using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampfireScript : MonoBehaviour {

    public Transform campFirePosition;
  
    public GameObject campFire;
    private bool canBuild = true;
    public Crafting crafting;
    private Renderer rend;

    private void Start()
    {  rend = GetComponent<Renderer>();
       rend.material.color = Color.blue;
       
    }
   private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Terrain" || other.tag == "TreeCollider" || other.tag=="CampFire" || other.tag=="House")
        {
            rend.material.color = Color.red;
            canBuild = false;

        }

    }
    private void OnTriggerExit(Collider other)
    {
       
            rend.material.color = Color.blue;
            canBuild = true;

       

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canBuild)
        {
            Instantiate(campFire, campFirePosition.position , Quaternion.Euler(new Vector3(-90,0,0)));
            crafting.campFirePrefab.SetActive(false);
        }
       
    }




}
