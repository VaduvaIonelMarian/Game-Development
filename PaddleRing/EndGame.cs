using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {
	private Animator anim;
	private bool IsDead=false;
	private Rigidbody2D rb2d;
    public GameObject restartButton;
    public GameObject menuButton;
    public ScoreManager scoreM;
    public Interact interact;
    public GameObject highScoreAnim;

    private bool displayHsOnce = true;
    // Use this for initialization
    void Start () {
		anim = GetComponent<Animator> ();
        rb2d = GetComponent<Rigidbody2D>();
        restartButton.SetActive(false);
        menuButton.SetActive(false);
        scoreM =GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        interact = GetComponent<Interact>();
        highScoreAnim.SetActive(false);
       // PlayerPrefs.SetInt("HighScore", 0);

	}
	
	// Update is called once per frame
	void Update () {
		if (IsDead) {
			Die();
            

		}
        CheckForHighScore();
	}

	private void OnTriggerEnter2D(Collider2D other){
	
		if (other.tag == "Ring") {
            IsDead = true;
			
		}

	}

	private void Die(){
		anim.SetTrigger("Explode");
		rb2d.velocity = Vector2.zero;
		StartCoroutine ("WaitForAnimation");
       // PUPUnityAds.deathCounts++;
      //  Debug.Log(PUPUnityAds.deathCounts);
        IsDead = false;
        


	}

	private IEnumerator WaitForAnimation(){
		yield return new WaitForSeconds (0.6f);
		Destroy (gameObject);
        restartButton.SetActive(true);
        menuButton.SetActive(true);
        Time.timeScale = 0;

    }
    private void CheckForHighScore()
    {
        
        if (PlayerPrefs.GetInt("HighScore") < scoreM.HSCounter)
        {
            PlayerPrefs.SetInt("HighScore", scoreM.HSCounter);
            if (displayHsOnce)
            {
                StartCoroutine("WaitForHighscore");
                displayHsOnce = false;
            }

        }
    }

    private IEnumerator WaitForHighscore()
    {
        highScoreAnim.SetActive(true);
        yield return new WaitForSeconds(1.8f);
        Destroy(highScoreAnim);
    }
}
