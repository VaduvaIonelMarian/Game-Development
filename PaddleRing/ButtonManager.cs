using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LeftRight()
    {
        GamePlayMode.instance.tap = true;
    }
    public void Drag()
    {
        GamePlayMode.instance.tap = false;
    }
    public void GameScene()
    {
        SceneManager.LoadScene(1);
    }
    public void ShopScene()
    {
        SceneManager.LoadScene(2);
    }

    



}
