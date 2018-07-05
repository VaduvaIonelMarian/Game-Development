using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackEnemy : MonoBehaviour {

    public AudioSource audiohit;
    
    public EnemyAI enemyAI;
    private int damage;
    public LeftPunchCollision PunchCol;
    public CollisionScript axeCol;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
      
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(Wait());
        }
            
        
       
        		
	}
    private void AttackEnemy()
    {
        damage = Random.Range(5, 15);
        enemyAI.TakeDamage(damage);
    }
    private void AttackEnemyWithAxe()
    {
        damage = Random.Range(15, 30);
        enemyAI.TakeDamage(damage);
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.2f);
        if (PunchCol.hitEnemy)
        {
            audiohit.Play();
            AttackEnemy();
            PunchCol.hitEnemy = false;
        }
        if (axeCol.hitEnemy)
        {
            audiohit.Play();
            AttackEnemyWithAxe();
            axeCol.hitEnemy = false;
        }

    }
}
