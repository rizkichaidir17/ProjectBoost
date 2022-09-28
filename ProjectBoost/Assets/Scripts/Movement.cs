using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputAcces();
    }

    void InputAcces()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, movementSpeed, 0));
        } if(Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(-movementSpeed, 0, 0));
        }if(Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(movementSpeed, 0, 0));
        }
    }
}
