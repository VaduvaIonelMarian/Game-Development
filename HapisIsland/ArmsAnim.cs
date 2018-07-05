using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmsAnim : MonoBehaviour
{
    private bool IsRunning = false;
    public Animator anim;
    public Rigidbody rb;
    public bool HasWeapon=false;
    public CharacterController character;
    public GameObject axe;

    private void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
        
    }   
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift)&&Input.GetKey(KeyCode.W)&&character.isGrounded)
        {
            IsRunning = true;
        }else
        {
            IsRunning = false;
        }
       
        anim.SetBool("IsRunning", IsRunning);
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger ("Hit01");
            
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            anim.SetTrigger("Hit02");
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            HasWeapon = !HasWeapon;
        }
        if (HasWeapon)
        {
            axe.SetActive(true);
        }
        else
        {
            axe.SetActive(false);
        }
        anim.SetBool("HasWeapon", HasWeapon);

    

    }
   
}