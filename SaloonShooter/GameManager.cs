using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
  

    private void Start()
    {
      
    }

    private void Update()
    {
        //if ((Input.touchCount == 1) &&
        // (Input.GetTouch(0).phase == TouchPhase.Began))
        //{
        //    SceneManager.LoadScene("1");
        //}
    }
	
    public void StartGame()
    {
        {
            SceneManager.LoadScene(1);
        }
    }
}
