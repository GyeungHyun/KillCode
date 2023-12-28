using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_hp : MonoBehaviour
{
    NavMeshAgent agent;
    public int hp = 10;
    private float wait_seconds = 0.5f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void FixedUpdate()
    {
        if (hp == 0)
        {
            Debug.Log("delete enemy");
            Destroy(this.gameObject);
        }
    }

    public void decrease_hp()
    {
        hp -= 1;
        Debug.Log(hp);
        if (agent.speed != 0 && GetComponent<Enemy_mv>().enabled == true)
        {   
            agent.speed = 0;
            StartCoroutine(wait());
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(wait_seconds);
        agent.speed = 3.5f;
    }
}
