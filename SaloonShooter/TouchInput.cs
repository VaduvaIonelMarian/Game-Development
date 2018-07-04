using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    [SerializeField]private UIMamager uiManager;
    [SerializeField] private EnemySpawn enemySpawn;
    private RaycastHit2D hit;

    private void Start()
    {
        uiManager = uiManager.GetComponent<UIMamager>();
        enemySpawn = enemySpawn.GetComponent<EnemySpawn>();
    }

    private void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 touchPos = new Vector2(wp.x, wp.y);
            //Do the things for touch
            OnTouchActions(touchPos);

        }
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    Vector2 touchPos = new Vector2(wp.x, wp.y);

        //    //Do the things for touch
        //    OnTouchActions(touchPos);

        //}
    }


    private void OnTouchActions(Vector2 _touchPos)
    {
        for (int i = 0; i < enemySpawn.spawnPoints.Length; i++)
        {
            if (enemySpawn.spawnCols[i] == Physics2D.OverlapPoint(_touchPos))
            {
                if (enemySpawn.charInstances[i] != null)
                {
                    if (enemySpawn.spawnStatus[i].hold == "enemy")
                    {
                        enemySpawn.IncreaseScore();
                        uiManager.SetScoreOnScreen();
                        StaticVariables.characterCount--;
                        StaticVariables.hitInRow++;
                        enemySpawn.spawnStatus[i].isUsed = false;
                        enemySpawn.spawnStatus[i].hold = "";
                        Destroy(enemySpawn.charInstances[i]);
                    }

                    if (enemySpawn.spawnStatus[i].hold == "ally")
                    {
                        
                        StaticVariables.hitInRow = 0;
                        StaticVariables.lives--;
                        StaticVariables.characterCount--;
                        enemySpawn.spawnStatus[i].isUsed = false;
                        enemySpawn.spawnStatus[i].hold = "";
                        Destroy(enemySpawn.charInstances[i]);
                    }
                }
            }
        }
    }
}