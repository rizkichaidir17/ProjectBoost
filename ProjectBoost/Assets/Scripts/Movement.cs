using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] int thrustingSpeed;
    [SerializeField] float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ThrustingAcces();
        RotationAcces();
    }

    void ThrustingAcces()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * thrustingSpeed * Time.deltaTime);
        }
    }
    void RotationAcces()
    {
        if(Input.GetKey(KeyCode.A))
        {
            Dorotate(rotationSpeed);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            Dorotate(-rotationSpeed);
        }

        void Dorotate(float arahrotasi)
        {
            transform.Rotate(Vector3.forward * arahrotasi * Time.deltaTime);
        }
    }
}
