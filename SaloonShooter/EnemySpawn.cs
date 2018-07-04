using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public GameObject[] spawnPoints;
    public int score = 0;
    public int lives = 3;
    public int scoreMultiplyer;
    [HideInInspector] public Collider2D[] spawnCols;
    [HideInInspector] public GameObject[] charInstances;
    [HideInInspector] public SpawnStatus[] spawnStatus;
    [SerializeField] private UIMamager uiManager;
    [SerializeField] private GameObject[] enemy;
    [SerializeField] private GameObject[] ally;
    [SerializeField] private float spawnSpeed = 2.0f;
    [SerializeField] private int chanceOfAlly = 20;
    [SerializeField] private float spawnspeed = 0;
    [SerializeField] private int minEnemy = 0;
    [SerializeField] private int maxEnemy = 0;
    [SerializeField] private long threshold = 200;
    private bool waitForSpawn = false;
    private int[] randomPoints = { 20, 25, 30 };   // ziceam sa faca un random intre cele 3 valori;
    private float timer;
    private int chance;
    private int randomPos;
    private int allyPos;
    private int enemyPos; 
    private short thresholdCount = 0;

    public float spawnWait = 0.12f;
    public float startWait = 0;
    private float waveWait;

    


    private void Start()
    {
        
        scoreMultiplyer = 1;
        waveWait = 1f;
        spawnStatus = new SpawnStatus[spawnPoints.Length];
        charInstances = new GameObject[spawnPoints.Length];
        spawnCols = new Collider2D[spawnPoints.Length];
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            spawnStatus[i] = spawnPoints[i].GetComponent<SpawnStatus>();
            spawnCols[i] = spawnStatus[i].myCollider;
        }
        
        minEnemy = 1;
        maxEnemy = 2;
        StaticVariables.enemyShootSpeed = 3.00f;
 
        StartCoroutine(SpawnWaves());

    }

    private void Update()
    {
        if (!isGameFinished)
        {
            ////timer += Time.deltaTime;
            Debug.Log(StaticVariables.lives);
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                if (charInstances[i] == null)
                {
                    spawnStatus[i].isUsed = false;
                    spawnStatus[i].hold = "";
                }
            }
            Debug.Log("Multiplyer: " + scoreMultiplyer);
            //diff lvl creation
            LevelDifficulty();
   
        }
        else
        {
            uiManager.GetComponent<UIMamager>().dieText.gameObject.SetActive(true);
        }

    }

    private void FillWithEnemies()
    {
        if (haveSpace && !isGameFinished)
        {
            enemyPos = Random.Range(0, spawnPoints.Length);
            if (spawnStatus[enemyPos].isUsed == false && waitForSpawn == false)
            {
                waitForSpawn = true;
                spawnStatus[enemyPos].isUsed = true;
                StaticVariables.characterCount++;
                charInstances[enemyPos] = Instantiate(enemy[Random.Range(0, enemy.Length)], spawnPoints[enemyPos].transform.position, Quaternion.identity);
                spawnStatus[enemyPos].hold = "enemy";
                waitForSpawn = false;
            }
            else
            {
                if (haveSpace)
                {
                    FillWithEnemies();
                }
            }
        }
    }

    private void FillWithAllies()
    {
        if (haveSpace && !isGameFinished)
        {
            allyPos = Random.Range(0, spawnPoints.Length);
            if (spawnStatus[allyPos].isUsed == false && waitForSpawn == false)
            {
                waitForSpawn = true;
                spawnStatus[allyPos].isUsed = true;
                StaticVariables.characterCount++;
                charInstances[allyPos] = Instantiate(ally[Random.Range(0, enemy.Length)], spawnPoints[allyPos].transform.position, Quaternion.identity);
                spawnStatus[allyPos].hold = "ally";
                waitForSpawn = false;
            }
            else
            {
                if (haveSpace)
                {
                    FillWithAllies();
                }
            }
        }
    }

    private bool haveSpace
    {
        get
        {
            return StaticVariables.characterCount < spawnPoints.Length;
        }
    }

    private bool isGameFinished
    {
        get
        {
            return StaticVariables.lives <= 0;
        }
    }

    private void SpawnEnemy(int _minEnemy, int _maxEnemy, float _shootSpeed)
    {
        if (haveSpace && !isGameFinished)
        {
                chance = Random.Range(0, 100);
                    if (chance <= chanceOfAlly)
                    {
                        FillWithAllies();
                    }
                    else
                    {
                        FillWithEnemies();
                     }

        }
    }

    private void LevelDifficulty()
    {
        if (score > threshold)
        {
            threshold *= 2;
            thresholdCount++;
            StaticVariables.enemyShootSpeed -= (float)(StaticVariables.enemyShootSpeed * 0.20f);
            if (thresholdCount % 2 == 0 && thresholdCount != 0 && (minEnemy < 5 && maxEnemy < 6))
            {
                minEnemy++;
                maxEnemy++;
            }
        }
    }

    public void IncreaseScore()
    {
        score += (randomPoints[Random.Range(0,randomPoints.Length)]) * scoreMultiplyer;
        //sm.SM();
       
    }

    IEnumerator SpawnWaves()
    {
       yield return new WaitForSeconds(startWait);
        
       
        while (true)
        {
            int tmpNumberOfChar;
            tmpNumberOfChar = Random.Range(minEnemy, maxEnemy + 1);
            // Only pick a new spawn point once per wave
            //  int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Debug.Log("Min Enemy: " + minEnemy + "Max Enemy: " + maxEnemy);
            for (int i = 0; i < tmpNumberOfChar; i++)
            {
                // here would pick a new spawn point for each new enemy
                SpawnEnemy(minEnemy, maxEnemy, StaticVariables.enemyShootSpeed);

                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            Debug.Log(waveWait);
        }
    }
}