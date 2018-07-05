using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Inventory : MonoBehaviour {
   
    public int wood = 0;
    public int cloth = 0;
    public int stone = 0;
    public int rope = 0;
    public int berries = 0;
    public int water = 0;
    public int fish = 0;
    public int cookedfish = 0;
    public int bandage = 0;
    public int banana = 0;
    public int coconut = 0;
    public int mushroom=0;
    private bool showGUI = false;
    private VitalsScript vitals;
    

    void Start()
    {
        showGUI = false;
        vitals = GameObject.FindGameObjectWithTag("Player").GetComponent<VitalsScript>();
    }

    // Use this for initialization
   void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            showGUI = !showGUI;
          
        }
        if (showGUI == true)
        {
            Time.timeScale = 0.0f;
            GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if (showGUI == false)
        {
            Time.timeScale = 1.0f;
            GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().enabled = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
	
	// Update is called once per frame
	void OnGUI() { 
        
        if (showGUI == true)
        {
            
            GUI.BeginGroup(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 350, 500, 500));

            GUI.Box(new Rect(0, 0, 500, 500), "INVENTORY");

            GUI.Label(new Rect(50,50,50,50 ), "Wood");
            GUI.Box(new Rect(90, 50, 40, 20), "" + wood);

            GUI.Label(new Rect(150, 50, 50, 50), "Stone");
            GUI.Box(new Rect(190, 50, 40, 20), "" + stone);

            GUI.Label(new Rect(250, 50, 50, 50), "Cloth");
            GUI.Box(new Rect(290, 50, 40, 20), "" + cloth);

            GUI.Label(new Rect(350, 50, 50, 50), "Rope");
            GUI.Box(new Rect(390, 50, 40, 20), "" + rope);

            GUI.Label(new Rect(30, 100, 50, 50), "Fish");
            GUI.Box(new Rect(110, 100, 40, 20), "" + fish);
            GUI.Label(new Rect(350, 100, 120, 20), "+10 Hunger");
            if(GUI.Button(new Rect(200, 100,120,20),"Eat Fish"))
            {
                
                
                if (fish <= 0)
                {
                    fish = 0;
                }else
                {
                    vitals.hunger += 10;
                    fish--;
                }
            }

            GUI.Label(new Rect(30, 138, 50, 50), "Cooked");
            GUI.Label(new Rect(39, 153, 50, 50), "Fish");
            GUI.Box(new Rect(110, 145, 40, 20), "" +cookedfish );
            GUI.Label(new Rect(350, 145, 120, 20), "+20 Hunger");
            if (GUI.Button(new Rect(200, 145, 120, 20), "Eat  Cooked Fish"))
            {
                

                if (cookedfish <= 0)
                {
                    cookedfish = 0;
                }
                else
                {
                    vitals.hunger += 20;
                    cookedfish--;
                }
            }

            GUI.Label(new Rect(30, 190, 50, 50), "Berries");
            GUI.Box(new Rect(110, 190, 40, 20), "" + berries);
            GUI.Label(new Rect(350, 190, 120, 20), "+5 Hunger");
            if (GUI.Button(new Rect(200, 190, 120, 20), "Eat Berries"))
            {
                

                if (berries <= 0)
                {
                    berries = 0;
                }
                else
                {
                    vitals.hunger += 5;
                    berries--;
                }
            }

            GUI.Label(new Rect(30, 235, 50, 50), "Water");
            GUI.Box(new Rect(110, 235, 40, 20), "" + water);
            GUI.Label(new Rect(350, 235, 120, 20), "+20 Thirst");
            if (GUI.Button(new Rect(200, 235, 120, 20), "Drink Water"))
            {
                

                if (water <= 0)
                {
                    water = 0;
                }
                else
                {
                    vitals.thirst += 20;
                    water--;
                }
            }

            GUI.Label(new Rect(30, 280, 52, 50), "Banana");
            GUI.Box(new Rect(110, 280, 40, 20), "" + banana);
            GUI.Label(new Rect(350, 280, 120, 20), "+7 Hunger");
            if (GUI.Button(new Rect(200, 280, 120, 20), "Eat Banana"))
            {
                if (banana <= 0)
                {
                    banana = 0;
                }
                else
                {
                    vitals.hunger += 7;
                    banana--;
                }
                
            }
            GUI.Label(new Rect(30, 325, 52, 50), "Coconut");
            GUI.Box(new Rect(110, 325, 40, 20), "" + coconut);
            GUI.Label(new Rect(350, 325, 120, 20), "+7 Hunger");
            if (GUI.Button(new Rect(200, 325, 120, 20), "Eat Coconut"))
            {
                if (coconut <= 0)
                {
                    coconut = 0;
                }
                else
                {
                    vitals.hunger += 7;
                    coconut--;
                }

            }

            GUI.Label(new Rect(30, 370, 70, 50), "Mushroom");
            GUI.Box(new Rect(110, 370, 40, 20), "" + mushroom);
            GUI.Label(new Rect(350, 370, 120, 20), "+5 Hunger");
            if (GUI.Button(new Rect(200, 370, 120, 20), "Eat Mushroom"))
            {
                if (mushroom <= 0)
                {
                    mushroom = 0;
                }
                else
                {
                    vitals.hunger += 5;
                    mushroom--;
                }

            }

            GUI.Label(new Rect(30, 415, 52, 50), "Bandage");
            GUI.Box(new Rect(110, 415, 40, 20), "" + bandage);
            GUI.Label(new Rect(350, 415, 120, 20), "+10 Health");
            if (GUI.Button(new Rect(200, 415, 120, 20), "Heal"))
            {
                if (bandage <= 0)
                {
                    bandage = 0;
                }
                else
                {
                    vitals.health += 10;
                    bandage--;
                }

            }

            GUI.EndGroup();
        }
	}
}
