using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour {

    private float xRange = 1.5f;
    public GameObject coinPrefab;
    public Text coinText;
    private int coin = 0;
    public int contor = 2;
    public int coinContor = 1;

    private void Start()
    {
        coinText.text = coin.ToString();
        Vector2 newPosition = new Vector2(Random.insideUnitCircle.x * xRange, Random.insideUnitCircle.y * xRange);

        Instantiate(coinPrefab, newPosition, Quaternion.identity);
    }
    private void Update()
    {
        if (coinContor==0)
        {
            SpawnRandom();
           
        }
    }
    public void SpawnRandom()
    {
        for (int i = 0; i < contor; i++)
        {
            Vector2 newPosition = new Vector2(Random.insideUnitCircle.x * xRange, Random.insideUnitCircle.y * xRange);

            Instantiate(coinPrefab, newPosition, Quaternion.identity);
        }
        contor++;
        coinContor = contor - 1;

    }
    public void CoinIncrease()
    {
        coin++;
        //contor++;
        coinText.text = coin.ToString();
    }
}
