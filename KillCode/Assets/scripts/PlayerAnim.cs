using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [Range(0,10)]
    public int test;
    public Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S))
        {
            anim.SetBool("isWalking", true);
            anim.SetFloat("Speed", 1f);
        }
        else
        {
            anim.SetBool("isWalking", false);
            anim.SetFloat("Speed", 0.2f);
        }
    }
}
