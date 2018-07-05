using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSwim : MonoBehaviour {

    public Transform[] dest;
    private bool isMoving = false;
    private float speed = 3f;
    private Transform newDest;
    private float turnSpeed = 5f;
    
    


    private void Start()
    {
        GetComponent<Animation>().Play();
       


    }
    private void Update()
    {
       
        if (isMoving == false)
        {
            newDest = dest[Random.Range(0, dest.Length)];
            isMoving = true;
        }

        transform.position = Vector3.MoveTowards(transform.position, newDest.position, speed * Time.deltaTime);
        
        Turn(newDest.position);

        if (transform.position == newDest.position)
        {
            isMoving = false;
        }
    }
    private void Turn(Vector3 target)
    {
        Vector3 targetDir = target - transform.position;
        targetDir.y = 0;
        float step = turnSpeed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
        Debug.DrawRay(transform.position, newDir, Color.red);
        transform.rotation = Quaternion.LookRotation(newDir);
    }


}
