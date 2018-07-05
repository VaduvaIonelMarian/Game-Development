using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeChop : MonoBehaviour {

    public int minDamage = 5;
    public int maxDamage = 15;
    public float attackDistance = 3.5f;
    public Text woodAmountText;
    public Text woodText;
    public GameObject woodBar;
    private float woodBarShowTimmer = 1f;


    public ArmsAnim arms;
    public CollisionScript col;
    public TreeHealth treeHealth;
    public Inventory inventory;
    public AudioSource chopSound;
    public Camera FPSCamera;

    private void Start()
    {
        woodBar.SetActive(false);
        
    }
    
    
    private void Update()

    {
        Ray ray = FPSCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, attackDistance))
        {
            if (hitInfo.collider.tag == "TreeCollider")

            {
                treeHealth = hitInfo.collider.GetComponentInParent<TreeHealth>();
               
            }
            
            
            
            
        

        }
        Debug.DrawRay(ray.origin, ray.direction * attackDistance, Color.red);






        woodBarShowTimmer -= Time.deltaTime;



        if (Input.GetMouseButton(0))
        {
            StartCoroutine(Wait());
        
        }
           

        
        if (woodBarShowTimmer <= 0)
        {
            NotWoodBar();
        }
     
    }


    private void AttackTree()
    {
       
       int damage = Random.Range(minDamage, maxDamage);
       treeHealth.normalTreeHealth -= damage;
       inventory.wood += damage;
       woodAmountText.text = damage.ToString();
       WoodBar();
       woodBarShowTimmer = 1f;


    }

    private void AttackBananaTree()
    {
        int damage = Random.Range(minDamage, maxDamage);
        treeHealth.bananaTreeHealth-= damage;
        int woodAmount = Random.Range(1, 4);
        inventory.wood += woodAmount;
        woodAmountText.text = woodAmount.ToString();
        WoodBar();
        woodBarShowTimmer = 1f;
    }
    private void AttackCoconutTree()
    {
        int damage = Random.Range(minDamage, maxDamage);
        treeHealth.coconutTreeHealth -= damage;
        int woodAmount = Random.Range(1, 4);
        inventory.wood += woodAmount;
        woodAmountText.text = woodAmount.ToString();
        WoodBar();
        woodBarShowTimmer = 1f;
    }

    private void WoodBar()

    {
        Debug.Log("woodbar");
        woodBar.SetActive(true);

    }

    public void NotWoodBar()
    {
       
       woodBar.SetActive(false);
    }

   IEnumerator Wait()
    {
        
        yield return new WaitForSeconds(1.2f);
        if (col.hitTree)
        {
            chopSound.Play();
            AttackTree();
            col.hitTree = false;

        }
        if (col.hitBananaTree)
        {
            chopSound.Play();
            AttackBananaTree();
            col.hitBananaTree = false;

        }
        if (col.hitCoconutTree)
        {
            chopSound.Play();
            AttackCoconutTree();
            col.hitCoconutTree = false;


        }

    }
   

    




}
