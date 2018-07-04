using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreNumber;
    private int score = 0;
    
    public Text HSText;
    public int HSCounter;
    // Use this for initialization
    void Start () {
        scoreNumber.text = score.ToString();
    }
	
	// Update is called once per frame
	void Update () {

       
}
    

    public void ScoreIncrease()
    {
        score++;
        scoreNumber.text = score.ToString();
        if (score > HSCounter)
        {
            HSCounter = score;
            Debug.Log(HSCounter);


        }


    }
}
