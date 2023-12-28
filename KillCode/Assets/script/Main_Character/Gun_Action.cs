using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Action : MonoBehaviour
{
    public LayerMask enemy;
    public int bullet = 10;
    GameObject obj;
    public Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();

    }
    // Update is called once per frame
    void Update()
    {
        if (bullet == 0)
        {

        }

        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("Shoot");
                action();
                Debug.Log("���� źȯ ��:" + bullet);
            }
            
            if (Input.GetKey(KeyCode.R)||bullet == 0)
            {   
                bullet = 0;
                Debug.Log("������");
                Invoke("reload", 3f);
            }
        }
        
    }

    void reload()
    {
        bullet = 10;
        Debug.Log("źȯ ���� �Ϸ�");
    }

    void action()
    {
        bullet -= 1;
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitdata;

        if (Physics.Raycast(ray, out hitdata, 10, enemy))
        {
            Debug.Log("hit");
            obj = hitdata.transform.gameObject;
            obj.GetComponent<Enemy_hp>().decrease_hp();
        }
        else
        {
            Debug.Log("None");
        }
    }

}
