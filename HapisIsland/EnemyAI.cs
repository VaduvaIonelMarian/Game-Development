using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {

    public Transform player;
    private NavMeshAgent agent;
    private Animator anim;
    public EnemyAttackCollision colision;
    public VitalsScript vitals;
    public GameObject clothPrefab;
   

    private bool isChasing = false;
	public int health=100;
   // private int damage =5;
    public float distance;
    private int startChase=30;
    private int stopChase = 60;
    private float turnSpeed = 5f;
    private int eyeDistance = 20;
    private int attackDistance = 5;
    private float radiusInsideUnityCircle = 30;
    public float timeUntilMovePosition=5f;
    private Rigidbody rb;
    public bool isMoving = false;

    


    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody> ();
	
        
      
	}
	
	// Update is called once per frame
	void Update () {
       
        
        CheckDeath();

        timeUntilMovePosition -= Time.deltaTime;

        StartCoroutine(CheckForMove());

        if (isMoving)
        {
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }
   
      

        GameObject eye = GameObject.FindGameObjectWithTag("Eye");
        Vector3 eyePosition = eye.transform.position;

        Ray ray = new Ray(eyePosition,Vector3.forward);
        RaycastHit hitInfo;
        Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.red);

        if (Physics.Raycast(ray, out hitInfo, eyeDistance))
        {
            
            if (hitInfo.collider.tag == "Player")
             {
                isChasing= true;
             }
            else
            {
                isChasing = false;
            }

        }
        
        distance = Vector3.Distance(transform.position, player.position);

        if (distance < startChase)
        {
            isChasing = true;
        }
        else if (distance >= stopChase)
        {
            isChasing = false;
        }

        if (distance <= attackDistance)
        {
            AttackPlayer();
        }
        else
        {
            anim.SetBool("IsAttacking", false);
        }
        if (distance >= 8)
        {
            agent.Resume();
            
        }



        if (isChasing)
        {
            Chase();

        }
        else
        {
            if (timeUntilMovePosition <= 0)
            {
                Turn(player.position);
                timeUntilMovePosition = Random.Range(5f, 15f);
                Patrol();
            }
        }
      
     
		
	}
   
    public void TakeDamage(int damageTaken)
    {
        health -= damageTaken;
        Debug.Log("enemy has now " + health + "health");
    }

    private void CheckDeath()
    {
        if (health <= 0)
        {
            Debug.Log("e mort");
			//Destroy (gameObject);
            
           // Instantiate(clothPrefab, transform.position+new Vector3(0, 3, -5), Quaternion.identity);
            //Instantiate(clothPrefab, transform.position+new Vector3(-4, 4, 4), Quaternion.identity);
            //Instantiate(clothPrefab, transform.position+new Vector3(4, 5, 3), Quaternion.identity);
            anim.SetTrigger("IsDead");
			agent.Stop ();
			StartCoroutine (EnemyDestroy ());


		
        }

    }

    private void Chase()
    {
        
        Turn(player.position);
        agent.SetDestination(player.position);
        
       
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
    

    private void Patrol()
    {
       
        Vector3 newPosition = transform.position + new Vector3(Random.insideUnitCircle.x * radiusInsideUnityCircle, 
                                                              transform.position.y-10, 
                                                              Random.insideUnitCircle.y * radiusInsideUnityCircle);
        Debug.Log("x is" + newPosition.x + "y is" + newPosition.z);
        Turn(newPosition);
        agent.SetDestination(newPosition);
        
       
    }       
    
    private void AttackPlayer()
    {
        anim.SetBool("IsAttacking", true);
        if (colision.hitPlayer) {
            vitals.health -= Random.Range(3, 10);
            colision.hitPlayer = false;
        }
        agent.Stop();
        anim.SetBool("IsWalking", false);
    }  

    private IEnumerator CheckForMove()
    {
        Vector3 lastPos = transform.position;
        yield return new WaitForSeconds(0.5f);
        Vector3 curPos = transform.position;
        if (curPos != lastPos)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }
	private IEnumerator EnemyDestroy(){


		yield return new WaitForSeconds (2.97f);
		Destroy (gameObject);


	}




		
          





        
    
}
