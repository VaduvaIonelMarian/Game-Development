using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{

    public float interactDistance = 6f;
    public Transform player;
    public VitalsScript vitals;
    public Inventory inventory;
    public Camera FPSCamera;

    private bool coconutPick = false;
    private bool berriesPick = false;
    private bool bannanaPick = false;
    private bool mushroomPick = false;
    private bool paddlePick = true;
    private bool stonePick = true;
    private bool fishPick = true;
    private bool clothPick = true;
    private bool bottlePick = true;


    // Update is called once per frame
    void Update()
    {
        Ray ray = FPSCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

        RaycastHit hitInfo;
        coconutPick = false;
        berriesPick = false;
        bannanaPick = false;
        paddlePick = false;
        mushroomPick = false;
        stonePick = false;
        fishPick = false;
        clothPick = false;
        bottlePick = false;


        if (Physics.Raycast(ray, out hitInfo, interactDistance))
        {
            if (hitInfo.collider.gameObject.tag == "Paddle")
            {
                paddlePick = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    paddlePick = false;
                    inventory.coconut++;
                    Destroy(hitInfo.collider.gameObject);

                }

            }
            if (hitInfo.collider.gameObject.tag == "Fish")
            {
                fishPick= true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    fishPick = false;
                    inventory.fish++;
                    Destroy(hitInfo.collider.gameObject);
                    GameObject.FindGameObjectWithTag("Destinations").GetComponent<FishSpawner>().fishNumber--;
                   

                }

            }
            if (hitInfo.collider.gameObject.tag == "Coconut")
            {
                coconutPick = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    coconutPick = false;
                    inventory.coconut++;
                    Destroy(hitInfo.collider.gameObject);

                }

            }
            if (hitInfo.collider.gameObject.tag == "Berries")
            {
                berriesPick = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    berriesPick = false;
                    inventory.berries++;
                    Destroy(hitInfo.collider.gameObject);

                }

            }
            if (hitInfo.collider.gameObject.tag == "Bannana")
            {
                bannanaPick = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    bannanaPick = false;
                    inventory.banana++;
                    Destroy(hitInfo.collider.gameObject);

                }

            }
            if (hitInfo.collider.gameObject.tag == "Mushroom")
            {
                mushroomPick = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    mushroomPick = false;
                    inventory.mushroom++;
                    Destroy(hitInfo.collider.gameObject);

                }

            }
            if (hitInfo.collider.gameObject.tag == "Stone")
            {
                stonePick = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    stonePick = false;
                    inventory.stone+=10;
                    Destroy(hitInfo.collider.gameObject);

                }

            }
            if (hitInfo.collider.gameObject.tag == "Cloth")
            {
                clothPick = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    clothPick = false;
                    inventory.cloth+=3;
                    Destroy(hitInfo.collider.gameObject);

                }

            }
            if (hitInfo.collider.gameObject.tag == "Bottle")
            {
                bottlePick = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    bottlePick = false;
                    inventory.water ++;
                    Destroy(hitInfo.collider.gameObject);

                }

            }

        }
        Debug.DrawRay(ray.origin, ray.direction * interactDistance, Color.blue);


    }
    void OnGUI()
    {
        if (coconutPick == true)
        {
            GUI.Box(new Rect(Screen.height / 2 + 100, Screen.width / 2 - 200, 120, 30), "Pickup Coconut");
        }
        if (berriesPick == true)
        {
            GUI.Box(new Rect(Screen.height / 2 + 100, Screen.width / 2 - 200, 120, 30), "Pickup Berries");
        }
        if (bannanaPick == true)
        {
            GUI.Box(new Rect(Screen.height / 2 + 100, Screen.width / 2 - 200, 120, 30), "Pickup Bannana");
        }
        if (mushroomPick == true)
        {
            GUI.Box(new Rect(Screen.height / 2 + 100, Screen.width / 2 - 200, 120, 30), "Pickup Mushroom");
        }
        if (paddlePick == true)
        {
            GUI.Box(new Rect(Screen.height / 2 + 100, Screen.width / 2 - 200, 120, 30), "Pickup Paddle");

        }
        if (stonePick == true)
        {
            GUI.Box(new Rect(Screen.height / 2 + 100, Screen.width / 2 - 200, 120, 30), "Pickup Stone");
        }
        if (fishPick == true)
        {
            GUI.Box(new Rect(Screen.height / 2 + 100, Screen.width / 2 - 200, 120, 30), "Hunt Fish");
        }
        if (clothPick == true)
        {
            GUI.Box(new Rect(Screen.height / 2 + 100, Screen.width / 2 - 200, 120, 30), "Pickup Cloth");
        }
        if (bottlePick == true)
        {
            GUI.Box(new Rect(Screen.height / 2 + 100, Screen.width / 2 - 200, 120, 30), "Pickup Bottle");
        }

    }
}
