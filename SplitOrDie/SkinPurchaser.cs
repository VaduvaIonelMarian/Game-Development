using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinPurchaser : MonoBehaviour {

    public static SkinPurchaser Instance { set; get; }

    public static string PRODUCT_DEFAULT_SKIN = "defaultSkin";
    public static string PRODUCT_FOOTBALL_SKIN = "footballSkin";
    public static string PRODUCT_TENNIS_SKIN = "tennisSkin";
    public static string PRODUCT_BASKETBALL_SKIN = "basketballSkin";
    public static string PRODUCT_LAVA_SKIN = "lavaSkin";
    public static string PRODUCT_MARBLE_SKIN = "marbleSkin";
    public static string PRODUCT_POOL_BALL = "poolBall";
    public static string PRODUCT_GALAXY_BALL = "galaxyBall";

    public static string PRODUCT_NOADS = "noAds";

    string[] allProducts = new string[] {"defaultSkin", "footballSkin", "tennisSkin", "basketballSkin", "lavaBall", "marbleBall", "poolBall", "galaxyBall" };

    public GameObject shopItem;
    public Transform shopItemsContainer;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < allProducts.Length; i++)
        {
            GameObject item = Instantiate(shopItem) as GameObject;
            item.transform.SetParent(shopItemsContainer);
            item.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            item.transform.localPosition = new Vector3(item.transform.position.x, item.transform.position.y, 1.0f);

            ShopItem shop = item.GetComponent<ShopItem>();

            shop.SetItemID(allProducts[i]);
        }
    }

    public void SetUse(string _key)
    {
        for (int i = 0; i < shopItemsContainer.transform.childCount; i++)
        {
            GameObject Go = shopItemsContainer.gameObject.transform.GetChild(i).gameObject;
            ShopItem shop = Go.GetComponent<ShopItem>();
            if (shop.CompareItemID(_key))
            {
                shop.isInUse = true;
            }
            else
            {
                shop.isInUse = false;
            }

            shop.SetOverlay();
        }
    }
}