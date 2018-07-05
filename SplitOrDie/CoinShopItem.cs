using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinShopItem : MonoBehaviour
{
    private string itemID;
    public Image productIcon;

    string[] allProductsID = new string[] { "50coins", "100coins", "200coins"};

    public Sprite[] allProductsImages;

    Dictionary<string, Sprite> dict = new Dictionary<string, Sprite>();
    Dictionary<string, int> dict3 = new Dictionary<string, int>();
    public int coinsNumber;
    public int[] allCoinsNumber;
    public Text coinsNumberText;

    void Start()
    {

        for (int i = 0; i < allProductsID.Length; i++)
        {
            dict.Add(allProductsID[i], allProductsImages[i]);
        }

        for (int i = 0; i < allCoinsNumber.Length; i++)
        {
            dict3.Add(allProductsID[i], allCoinsNumber[i]);
        }

        if (dict.ContainsKey(itemID))
        {
            productIcon.sprite = dict[itemID];
        }
        if (dict3.ContainsKey(itemID))
        {
            coinsNumber = dict3[itemID];
            coinsNumberText.text ="+ " + coinsNumber.ToString();
        }
    }

    public void BuyItem()
    {
        Purchaser.Instance.BuyItem(itemID);
    }

    public void SetItemID(string _id)
    {
        itemID = _id;
    }
}