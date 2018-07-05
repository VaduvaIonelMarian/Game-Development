using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionSides : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)

    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
         //   Debug.Log(GameManager.Instance.watchedAd);
            if (GameManager.Instance.watchedAd)
            {
                GameManager.Instance.isDead = true;
                GameManager.Instance.DontWatchAdToContinue();
            }
            else if (!GameManager.Instance.watchedAd)
            {
                GameManager.Instance.isDead = true;
                GameManager.Instance.ActivateContinueCanvas();
            }
        }

        else if (gameObject.tag == "Wall")
        {
           // Debug.Log("wall");
           GameManager.Instance.DiedFromWall();
        }
    }
}