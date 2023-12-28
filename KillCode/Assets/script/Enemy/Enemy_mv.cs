using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_mv : MonoBehaviour
{
    NavMeshAgent agent;

    public int triger = 0;
    public int l_or_s = 0;
    public LayerMask obstacle;

    [SerializeField]
    public GameObject player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    
    void FixedUpdate()
    {
        if (l_or_s == 0 && triger == 1 && player != null) agent.SetDestination(player.transform.position);
        else if (l_or_s == 1 && triger == 1 && player != null) Long_range();

    }

    void Long_range()
    {
        Vector3 e_to_p_dir = (player.transform.position - transform.position).normalized; e_to_p_dir.y = 0f;
        Vector3 p_to_e_dir = (transform.position - player.transform.position).normalized; p_to_e_dir.y = 0f;

        Ray ray = new Ray(transform.position, e_to_p_dir);
        RaycastHit hitdata;

        if (Physics.Raycast(ray, out hitdata, 100, obstacle))
        {
            agent.SetDestination(player.transform.position + p_to_e_dir * 5f);
        }
        
    }

}
