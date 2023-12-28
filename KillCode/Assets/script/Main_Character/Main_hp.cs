using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Main_hp : MonoBehaviour
{
    public int hp = 10;
    public float radius = 0.5f;
    private int trriger = 0;
    private float wait_seconds ;

    private void Awake()
    {
        wait_seconds = 5 * Time.deltaTime;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, radius);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            if (trriger == 0)
            {
                hp -= 1;
                trriger = 1;
                float knockbackSpeed = 5f;
                Collider[] colliders = Physics.OverlapSphere(transform.position, radius, 1 << 6);
                foreach (Collider col in colliders)
                {   
                    Vector3 dir = col.transform.position - transform.position; dir.y = 0f;
                    Vector3 KnockBackPos = col.transform.position + dir.normalized * knockbackSpeed;
                    StartCoroutine(knockback(col, KnockBackPos));
                    Debug.Log("¹ÐÄ¡±â");
                }
                StartCoroutine(invincible());
            }
        }
    }


    IEnumerator invincible()
    {
        
        yield return new WaitForSeconds(wait_seconds);
        trriger = 0;
    }

    IEnumerator knockback(Collider col, Vector3 Knockbackpos)
    {
        col.GetComponent<Enemy_mv>().enabled = false;
        col.GetComponent<NavMeshAgent>().enabled = false;
        float monster_radius = 0.5f;

        while (Vector3.Distance(col.transform.position, Knockbackpos)>0.5f)
        {
            Collider[] obstacles = Physics.OverlapSphere(transform.position, monster_radius, 1 << 7);
        
            col.transform.position = Vector3.Lerp(col.transform.position, Knockbackpos, 5 * Time.deltaTime);
            yield return null;
        }
        col.GetComponent<NavMeshAgent>().enabled = true;
        col.GetComponent<Enemy_mv>().enabled = true;
        yield return null;
    }
}