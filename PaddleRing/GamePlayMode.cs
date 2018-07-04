using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayMode : MonoBehaviour {
    public static GamePlayMode instance = null;
    public bool tap;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance!=this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(instance);
    }
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	
   
}
