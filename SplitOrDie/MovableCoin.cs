using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableCoin : MonoBehaviour
{
    public Transform backLimit;

    private void Update()
    {
      

        if (!GameManager.Instance.isDead)
        {
            if (transform.position.z >= backLimit.position.z)
            {
                transform.Translate(-Vector3.forward * GameManager.Instance.moveSpeed * Time.deltaTime);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Destroy(gameObject);
            GameManager.Instance.IncrementCoins();
            
        }
    }

}