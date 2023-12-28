using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Move : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float time = 3f;
    private Rigidbody rb;
    private float xRotateMove;
    public float rotatespeed = 10f;
    private int trigger = 0;
    private int time_trigger = 0;
    

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (time_trigger != 0 && time > 0f) { time -= Time.deltaTime; }
        else { time = 3f; time_trigger = 0; }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Dash();
        Lookmouse2();
        if (trigger == 0) { Main_mv(); }
    }

    void Main_mv()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.TransformDirection(horizontalInput, 0f, verticalInput);
        moveDirection.Normalize();

        rb.velocity = moveDirection * moveSpeed;
    }
    void Dash()
    {

        Vector3 movedirection;

        if (trigger != 0 || time != 3f) {} // time 조건에다가 무조건 초기값(제한시간) 넣어주기
        else
        {
            if (Input.GetKey(KeyCode.W) == true && Input.GetKey(KeyCode.A) == true && Input.GetKey(KeyCode.Space) == true)
            {
                if (trigger == 0)
                {
                    movedirection = (transform.forward-transform.right).normalized;
                    StartCoroutine(Dash_col(movedirection));
                    Debug.Log("w");
                }
            }

            else if (Input.GetKey(KeyCode.W) == true && Input.GetKey(KeyCode.D) == true && Input.GetKey(KeyCode.Space) == true)
            {
                if (trigger == 0)
                {
                    movedirection = (transform.forward + transform.right).normalized;
                    StartCoroutine(Dash_col(movedirection));
                    Debug.Log("w");
                }
            }

            else if (Input.GetKey(KeyCode.S) == true && Input.GetKey(KeyCode.A) == true && Input.GetKey(KeyCode.Space) == true)
            {
                if (trigger == 0)
                {
                    movedirection = (-transform.forward - transform.right).normalized;
                    StartCoroutine(Dash_col(movedirection));
                    Debug.Log("w");
                }
            }

            else if (Input.GetKey(KeyCode.S) == true && Input.GetKey(KeyCode.D) == true && Input.GetKey(KeyCode.Space) == true)
            {
                if (trigger == 0)
                {
                    movedirection = (-transform.forward + transform.right).normalized;
                    StartCoroutine(Dash_col(movedirection));
                    Debug.Log("w");
                }
            }

            else if (Input.GetKey(KeyCode.W) == true && Input.GetKey(KeyCode.Space) == true)
            {
                if (trigger == 0)
                {
                    movedirection = transform.forward;
                    StartCoroutine(Dash_col(movedirection));
                    Debug.Log("w");
                }
            }
            else if (Input.GetKey(KeyCode.A) == true && Input.GetKey(KeyCode.Space) == true)
            {
                if (trigger == 0)
                {
                    movedirection = -transform.right;
                    StartCoroutine(Dash_col(movedirection));
                    Debug.Log("a");
                }
            }
            else if(Input.GetKey(KeyCode.D) == true && Input.GetKey(KeyCode.Space) == true)
            {
                if (trigger == 0)
                {
                    movedirection = transform.right;
                    StartCoroutine(Dash_col(movedirection));
                    Debug.Log("d");
                }

            }
            else if (Input.GetKey(KeyCode.S) == true && Input.GetKey(KeyCode.Space) == true)
            {
                if (trigger == 0)
                {
                    movedirection = -transform.forward;
                    StartCoroutine(Dash_col(movedirection));
                    Debug.Log("s");
                }
            }
            if (Input.GetKey(KeyCode.W) == true && Input.GetKey(KeyCode.Space) == true)
            {
                if (trigger == 0)
                {
                    movedirection = transform.forward;
                    StartCoroutine(Dash_col(movedirection));
                    Debug.Log("w");
                }
            }
            

        }
    }

    public void Lookmouse2()
    {
        
        xRotateMove = Input.GetAxis("Mouse X") * rotatespeed;

        transform.RotateAround(transform.position, Vector3.up, xRotateMove);

    }

    IEnumerator Dash_col(Vector3 movedirection)
    {
        float speed = 5f;
        Vector3 Dashpos = transform.position + movedirection * speed;
        trigger = 1;
        time_trigger = 1;

        while (Vector3.Distance(transform.position, Dashpos) > 1f)
        {
            transform.position = Vector3.Lerp(transform.position, Dashpos, 5 * Time.deltaTime);
            yield return null;
        }

        trigger = 0;
        yield return null;
    }
}

