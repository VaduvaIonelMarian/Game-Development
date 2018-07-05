using UnityEngine;

public class MovableObstacle : MonoBehaviour {

    public Transform backLimit;
    public Transform resetPos;  
    public GenerateObstacle generator;

    void FixedUpdate () {

        if (GameManager.Instance.score >= 0)
        {
            GameManager.Instance.moveSpeed = 2.55f;
        }

        if (GameManager.Instance.score >= 2)
        {
            GameManager.Instance.moveSpeed = 2.6f;
        }

        if (GameManager.Instance.score >= 8)
        {
            GameManager.Instance.moveSpeed = 2.7f;
        }

        if (GameManager.Instance.score >= 10)
        {
            GameManager.Instance.moveSpeed = 2.8f;
        }

        if (GameManager.Instance.score >= 12)
        {
            GameManager.Instance.moveSpeed = 2.9f;
        }

        if (GameManager.Instance.score >= 15)
        {
            GameManager.Instance.moveSpeed = 3.0f;
        }

        if (GameManager.Instance.score >= 20)
        {
            GameManager.Instance.moveSpeed = 3.2f;
        }

        if (GameManager.Instance.score >= 30)
        {
            GameManager.Instance.moveSpeed = 3.5f;
        }

        if (GameManager.Instance.score >= 50)
        {
            GameManager.Instance.moveSpeed = 4f;
        }

        if (GameManager.Instance.score >= 80)
        {
            GameManager.Instance.moveSpeed = 4.7f;
        }

        if (GameManager.Instance.score >= 120)
        {
            GameManager.Instance.moveSpeed = 5f;
        }

        if (!GameManager.Instance.isDead) {
            if (transform.position.z >= backLimit.position.z)
            {
                 transform.Translate(-Vector3.forward  * GameManager.Instance.moveSpeed * Time.deltaTime);  
            }
            else
            {
                generator.SpawnObstacle(resetPos);
                Destroy(gameObject);
            }
        }        
    }
}
