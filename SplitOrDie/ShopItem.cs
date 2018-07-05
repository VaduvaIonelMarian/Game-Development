using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{

    public Image productIcon;
    public Image productIconOverlay;

    public GameObject useButton;
    public GameObject buyButton;

    public GameObject usedButton;

    public Sprite usedItemOverlay;
    public Sprite boughtItemOverlay;
    public Sprite notBoughtItemOverlay;

    public string itemID;

    public int wasBought;

    public bool isInUse;

    string[] allProductsID = new string[] {"defaultSkin", "footballSkin", "tennisSkin", "basketballSkin", "lavaBall", "marbleBall" , "poolBall", "galaxyBall" };
    public int[] allProductsPrice;

    public int itemPrice;

    public Material[] allProductsMaterial;
    public Sprite[] allProductsImages;

    Dictionary<string, Sprite> dict = new Dictionary<string, Sprite>();
    Dictionary<string, Material> dict2 = new Dictionary<string, Material>();
    Dictionary<string, int> dict3 = new Dictionary<string, int>();

    private Material firstMaterial;
    public Material ballMaterial;
    private string materialPref;
    private string overlayPref;

    public Text priceText;

    void Start()
    {
        


        for (int i = 0; i < allProductsID.Length; i++)
        {
            dict.Add(allProductsID[i], allProductsImages[i]);
        }

        for (int i = 0; i < allProductsMaterial.Length; i++)
        {
            dict2.Add(allProductsID[i], allProductsMaterial[i]);
        }

        for (int i = 0; i < allProductsPrice.Length; i++)
        {
            dict3.Add(allProductsID[i], allProductsPrice[i]);
        }

        if (dict.ContainsKey(itemID))
        {
            productIcon.sprite = dict[itemID];
        }

        if (dict3.ContainsKey(itemID))
        {
            itemPrice = dict3[itemID];
            priceText.text = itemPrice.ToString();
        }

        materialPref = PlayerPrefs.GetString("materialChoice");
        if (materialPref != "")
        {
            firstMaterial = dict2[materialPref];
            GameManager.Instance.SetBallMaterial(firstMaterial);
        }
        else
        {
            GameManager.Instance.SetBallMaterial(ballMaterial);
        }
    }

    public void BuyItem()
    {
        /*      AICI TREBUIE BAGATA CONDITIA SA AIBA DESTULE COINS      */
        //if(GameManager.Instance.currentCoins >= itemPrice)
        // {
        if (GameManager.Instance.RequestCoins(itemPrice))
        {
            PlayerPrefs.SetInt(itemID + "bought", 1);
            productIconOverlay.sprite = boughtItemOverlay;
            buyButton.SetActive(false);
            useButton.SetActive(true);

            priceText.enabled = false;
            GameManager.Instance.ReduceCoins(itemPrice);
        }
        //}

        //else{
        //    Debug.Log("Not enough coins");
        //}
    }

    public void UseMaterial()
    {
        if (dict2.ContainsKey(itemID))
        {
            GameManager.Instance.SetBallMaterial(dict2[itemID]);
            PlayerPrefs.SetString("materialChoice", itemID);
            GameManager.Instance.SetInUse(itemID);
            PlayerPrefs.SetString("overlayUse", itemID);
        }
    }

    public void SetItemID(string _id)
    {
        itemID = _id;

        if(itemID == "defaultSkin")
        {
            PlayerPrefs.SetInt(itemID + "bought", 1);
        }
        wasBought = PlayerPrefs.GetInt(itemID + "bought");

        overlayPref = PlayerPrefs.GetString("overlayUse");

        if(overlayPref == "" && itemID == "defaultSkin")
        {
            productIconOverlay.sprite = usedItemOverlay;
            useButton.SetActive(false);
            buyButton.SetActive(false);
            priceText.enabled = false;

            usedButton.SetActive(true);

        }

        else if (overlayPref == itemID)
        {
            productIconOverlay.sprite = usedItemOverlay;
            useButton.SetActive(false);
            buyButton.SetActive(false);
            priceText.enabled = false;

            usedButton.SetActive(true);
        }

        else
        {
            if (wasBought != 1)
            {
                productIconOverlay.sprite = notBoughtItemOverlay;
                buyButton.SetActive(true);
                useButton.SetActive(false);
                usedButton.SetActive(false);
            }
            else
            {
                productIconOverlay.sprite = boughtItemOverlay;
                buyButton.SetActive(false);
                useButton.SetActive(true);
                priceText.enabled = false;

                usedButton.SetActive(false);

            }
        }

    }

    public bool CompareItemID(string _id)
    {
        if (itemID == _id)
            return true;
        else
            return false;
    }

    public void SetOverlay()
    {
        if (isInUse)
        {
            productIconOverlay.sprite = usedItemOverlay;
            buyButton.SetActive(false);
            useButton.SetActive(false);
            usedButton.SetActive(true);


        }
        else
        {
            wasBought = PlayerPrefs.GetInt(itemID + "bought");
            if (wasBought != 1)
            {
                productIconOverlay.sprite = notBoughtItemOverlay;
                buyButton.SetActive(true);
                useButton.SetActive(false);
                usedButton.SetActive(false);

            }
            else
            {
                productIconOverlay.sprite = boughtItemOverlay;
                buyButton.SetActive(false);
                useButton.SetActive(true);
                usedButton.SetActive(false);

            }
        }
    }

}