using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveBall : MonoBehaviour {
    
	private Rigidbody2D rb2d;
	private int speed = 20;
	[SerializeField] float ballForce = 6;
    public Text playText;
    private ScoreManager scoreM;





    void Start () {
        
            Time.timeScale = 0;
        
            
            rb2d = GetComponent<Rigidbody2D>();
            
            rb2d.AddForce(new Vector2(ballForce, ballForce) * speed);
            scoreM = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
            
            
            
            
        
	}


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            Time.timeScale = 1;
            playText.enabled = false;
          
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Arcs")
        {
           scoreM.ScoreIncrease();


        }
    }


}
