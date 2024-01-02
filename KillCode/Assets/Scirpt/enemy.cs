using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public SphereCollider sphereCollider;
    public MeshRenderer mate;
    public int hp = 10;

    void Awake()
    {
        sphereCollider = gameObject.GetComponent<SphereCollider>();
        sphereCollider.enabled = false;
        mate = gameObject.GetComponent<MeshRenderer>();
        gameObject.SetActive(true);
    }

    public void hit(int damage)
    {
        hp -= damage;
        mate.material.color = Color.red;
        Invoke("changeColor",0.3f);

        if(hp <= 0)
        {
            int bombs = Random.Range(0, 9);
            if (bombs < 3)
            {
                Debug.Log("아이템 드랍!");
            }
            else if (bombs >= 3)
            {
                Debug.Log("터짐");
                sphereCollider.enabled = true;
                Explode(); 
            }
            gameObject.SetActive(false);
        }
        if(hp > 0)
        {
            gameObject.SetActive(true);
            sphereCollider.enabled = false;
        }
    }

    void changeColor()
    {
        mate.material.color = Color.white;
    }

    void Explode()
    {
        Collider[] coll = Physics.OverlapSphere(transform.position, 3.0f);

        foreach(Collider nearbyObject in coll)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(1000f,transform.position, 3.0f);
            }
        }
    }
}
