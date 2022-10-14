using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] int thrustingSpeed;
    [SerializeField] float rotationSpeed;

    Rigidbody rdb;
    AudioSource audioSource;

    [HideInInspector]public AudioManagement audioManagement;

    private void Awake()
    {
        audioManagement = GameObject.Find("AudioManagement").GetComponent<AudioManagement>();
        audioSource = GameObject.Find("AudioManagement").GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rdb = GetComponent<Rigidbody>();
        
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
            rdb.AddRelativeForce(Vector3.up * thrustingSpeed * Time.deltaTime);
            if(!audioSource.isPlaying)
            {
                audioManagement.SfxBoostPlay();
            }
           
        }
        else
        {
            audioSource.Stop();
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
            rdb.freezeRotation = true;
            transform.Rotate(Vector3.forward * arahrotasi * Time.deltaTime);
            rdb.freezeRotation = false;
        }
    }
}
