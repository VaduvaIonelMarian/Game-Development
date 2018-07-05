using UnityEngine;
using System.Collections;

public class DetectCollison : MonoBehaviour
{

    Collider playerCollider;

    private void OnTriggerEnter(Collider other)

    {
        if (other.tag == "Player")
        {
           // Debug.Log(GameManager.Instance.watchedAd);
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


                if (gameObject.tag == "BigObstacle")
            {
                GameManager.Instance.DiedFromBigObstacle();
                
            }
            else if (gameObject.tag == "SmallObstacle")
            {
                GameManager.Instance.DiedFromSmallObstacle();

            }
            //else if(gameObject.tag == "Wall")
            //{
            //    GameManager.Instance.DiedFromWall();
            //}

        }
    }

}
 
