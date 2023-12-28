using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_find : MonoBehaviour
{
    public float radius = 5f;
    private float map_range = 100f;

    void Start()
    {
        gameObject.GetComponent<Enemy_mv>().enabled = false;
        InvokeRepeating("UpdateTarget", 0f, 0.2f);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, radius);
    }
    

    void UpdateTarget()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        
        foreach (Collider col in colliders)
        {
            if (col.tag == "Player" || (GetComponent<Enemy_hp>().hp != 10))
            {
                Collider[] enemy = Physics.OverlapSphere(transform.position, map_range, 1 << 6);
                foreach (Collider enm in enemy)
                {
                    enm.GetComponent<Enemy_mv>().enabled = true;
                    enm.GetComponent<Enemy_mv>().triger = 1;
                    gameObject.GetComponent<Enemy_find>().enabled = false;
                }
            }

        }
    }
}
