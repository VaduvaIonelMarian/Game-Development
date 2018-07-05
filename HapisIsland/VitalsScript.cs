using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VitalsScript : MonoBehaviour {

    public AudioSource drowning;

    public Transform player;

    public Image healthImage;
    public Image thirstImage;
    public Image hungerImage;
    public Image temperatureImage;
    public GameObject attentionImage;
    public DayNightCycle dayNight;

    public float health = 100;
    public float thirst = 100;
    public float hunger = 100;
    public float normalTemp = 30;
    public float freezingTemp = 0;
    public float currentTemp;

    public float healthCooldown = 0.10f;
    public float hungerCooldown = 0.10f;
    public float thirstCooldown = 0.15f;
    public float temperatureCooldown = 0.20f;

    public Text healthText;
    public Text thirstText;
    public Text hungerText;
    public Text degrees;
   

    // Use this for initialization
    void Start () {
        healthText.text = "100";
        thirstText.text = "100";
        hungerText.text = "100";
        attentionImage.SetActive(false);
        player = GetComponent<Transform>();
        currentTemp = normalTemp;
    }
	
	// Update is called once per frame
	void Update () {
        healthImage.fillAmount = health / 100;
        thirstImage.fillAmount = thirst / 100;
        hungerImage.fillAmount = hunger / 100;

        

        healthText.text = Mathf.RoundToInt(health).ToString();
        thirstText.text = Mathf.RoundToInt(thirst).ToString();
        hungerText.text = Mathf.RoundToInt(hunger).ToString();

        if (health <= 0)
        {
          //  Die();
        }
        if (health >= 100)
        {
            health = 100;
        }

        if (thirst <= 0 && hunger <= 0)
        {
            health -= Time.deltaTime * healthCooldown*2;
        }
        if(thirst<=0 || hunger <= 0)
        {
            health -= Time.deltaTime * healthCooldown;
        }

        if (thirst <= 0)
        {
            thirst = 0;
        }else if(thirst > 0)
        {
            thirst -= Time.deltaTime * thirstCooldown;
        }

        if (thirst >= 100)
        {
            thirst = 100;
        }

        if (hunger <= 0)
        {
            hunger = 0;
        }else if (hunger > 0)
        {
            hunger -= Time.deltaTime * hungerCooldown;
        }

        if (hunger >= 100)
        {
            hunger = 100;
        }

        if (player.position.y<=1.9f)
        {
            attentionImage.SetActive(true);
            StartCoroutine(Drowning());
            
        }
        else
        {
            attentionImage.SetActive(false);
        }
        
        if (currentTemp <= freezingTemp)
        {
            temperatureImage.color = Color.blue;
            health -= Time.deltaTime * healthCooldown;
            

        }
        else
        {
            temperatureImage.color = Color.green;
        }
		if (dayNight.isNight) {
			currentTemp -= Time.deltaTime * temperatureCooldown;
            
		} else
		
		{
			currentTemp += Time.deltaTime * temperatureCooldown;

		}

        if (currentTemp <= -20)
        {
            currentTemp = -20;
        }
        if (currentTemp >= 35)
        {
            currentTemp = 35;
        }
        degrees.text = currentTemp.ToString("00 °C");



    }
    IEnumerator Drowning()
    {
        yield return new WaitForSeconds(10);
        if (player.position.y <= 1.9f)
        {
            health -= Time.deltaTime * healthCooldown;
            drowning.Play();
        }
        else
        {
           drowning.Stop();
        }
    }
}

