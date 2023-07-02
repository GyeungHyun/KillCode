using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Move : MonoBehaviour
{   
    public GameObject main_character;
    public float positony = 10f;
    public float cameraspeed = 5f;
    Vector3 destination;

    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        destination = new Vector3(main_character.transform.position.x,
                        main_character.transform.position.y + positony,
                        main_character.transform.position.z);
        transform.position = Vector3.Lerp(transform.position, destination, Time.deltaTime * cameraspeed);
    }
}

