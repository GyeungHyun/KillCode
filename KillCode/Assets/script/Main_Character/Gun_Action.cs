using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Action : MonoBehaviour
{
    public LayerMask enemy;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(transform.position, transform.forward, 10,enemy))
            {
                Debug.Log("À¸¾Ç");
            }
        }
    }
}
