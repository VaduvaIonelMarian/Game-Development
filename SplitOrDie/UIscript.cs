using UnityEngine;
using UnityEngine.UI;

public class UIscript : MonoBehaviour
{

    public static UIscript Instance { get; private set; }

    // Use this for initialization
    void Start()
    {
        Instance = this;
    }

    public void ShowLeaderboards()
    {
        PlayGameScript.ShowLeaderboardsUI();
    }


}