using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_aniController : MonoBehaviour
{
    public Animator anim;
    public BoxCollider hitBox;
    public Transform transforms;
    void Start()
    {
        anim = GetComponent<Animator>();
        hitBox = GetComponent<BoxCollider>();
        transforms = GetComponent<Transform>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetTrigger("slash");
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            anim.SetTrigger("side slash");
        }

        // transforms.localEulerAngles = new Vector3(0, 0, 0);
        // transforms.localPosition = new Vector3(16.94f, 0, 11.73f);          //꼴받게 공격하면 계속 이동해서 묶어둠.
    }

    void attack()
    {
        StartCoroutine("swing");
    }

    IEnumerator swing()
    {
        hitBox.enabled = true;
        yield return new WaitForSeconds(0.3f);
        hitBox.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "enemy")
        {
            Debug.Log("enemy를 때림");
            other.gameObject.GetComponent<enemy>().hit(1);
        }
    }
}
