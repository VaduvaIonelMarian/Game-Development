using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMamager : MonoBehaviour {

    public int score;
    public Text textScore;
    public Text dieText;
    [SerializeField] EnemySpawn enemySpawn;
    public Text comboText;

    private void Start()
    {
        textScore = textScore.GetComponent<Text>();
        dieText = dieText.GetComponent<Text>();
        comboText = comboText.GetComponent<Text>();
        dieText.gameObject.SetActive(false);
        textScore.text = "0";
        comboText.text = "X1";
    }

    private void Update()
    {
        comboText.text = "X" + enemySpawn.scoreMultiplyer.ToString();
    }

    public void SetScoreOnScreen()
    {
        textScore.text = "" + enemySpawn.score.ToString();
       
    }
}
