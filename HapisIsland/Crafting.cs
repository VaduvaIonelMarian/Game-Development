using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.ImageEffects;

public class Crafting : MonoBehaviour {

    public Inventory inventory;
    public Texture campFireIcon;
    public Texture houseIcon;
    public Texture bandageIcon;
    public Texture ropeIcon;
    public Blur blur;

    private bool showGUI = false;

    public GameObject campFirePrefab;
    public GameObject HousePrefab;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            showGUI = !showGUI;

        }
        if (showGUI == true)
        {
            blur.enabled = true;
            // Time.timeScale = 0.0f;
            GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            blur.enabled = false;
        }
    }

    private void OnGUI()
    {
        if (showGUI == true)
        {
            GUI.BeginGroup(new Rect(Screen.width / 2 +150, Screen.height / 2 - 300, 300, 300));
            GUI.Box(new Rect(0, 0, 300, 300), "Crafting Menu");


            if (GUI.Button(new Rect(65, 70, 50, 50), campFireIcon))
            {
               
                if (inventory.wood >= 200&& inventory.stone>=10)
                {
                    campFirePrefab.SetActive(true);
                    inventory.wood -= 200;
                    inventory.stone -= 10;
                }
            }
            if (GUI.Button(new Rect(185, 70, 50, 50), houseIcon))
            {
                if (inventory.wood >= 500 && inventory.stone >= 100)
                {
                    HousePrefab.SetActive(true);
                    inventory.wood -= 500;
                    inventory.stone -= 100;
                }


            }
            if (GUI.Button(new Rect(65, 190, 50, 50),bandageIcon ))
            {
                if (inventory.cloth >= 3)
                {
                    inventory.bandage +=1;
                    inventory.cloth-=3;
                }
            }
            if (GUI.Button(new Rect(185, 190, 50, 50), ropeIcon))
            {
                if (inventory.cloth >= 5)
                {
                    inventory.rope += 1;
                    inventory.cloth -= 5;
                }
            }
            

            GUI.EndGroup();
            
                
            
            
        }
    }
}
