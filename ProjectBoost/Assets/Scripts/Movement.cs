using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [SerializeField] int thrustingSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] ParticleSystem boostParticle;
    [SerializeField] ParticleSystem boostleftParticle;
    [SerializeField] ParticleSystem boostrightParticle;
    [SerializeField] Slider fuelValue;
    [SerializeField] int fuelUse;
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
            DoThrusting();
            FuelSystem();
        }
        else
        {
            StopThrusting();
        }
    }
    void RotationAcces()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotatingLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotatingRight();
        }
        else
        {
            StopRotating();
        }

    }

    void DoThrusting()
    {
        rdb.AddRelativeForce(Vector3.up * thrustingSpeed * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioManagement.SfxBoostPlay();
        }
        if (!boostParticle.isPlaying)
        {
            boostParticle.Play();
        }
    }

    void FuelSystem()
    {
        fuelValue.value -= fuelUse * Time.deltaTime;
    }

    void StopThrusting()
    {
        audioSource.Stop();
        boostParticle.Stop();
    }


    void RotatingLeft()
    {
        Dorotate(rotationSpeed);
        if (!boostrightParticle.isPlaying)
        {
            boostrightParticle.Play();
        }
    }

    void RotatingRight()
    {
        Dorotate(-rotationSpeed);
        if (!boostleftParticle.isPlaying)
        {
            boostleftParticle.Play();
        }
    }

    void StopRotating()
    {
        boostrightParticle.Stop();
        boostleftParticle.Stop();
    }
    void Dorotate(float arahrotasi)
    {
        rdb.freezeRotation = true;
        transform.Rotate(Vector3.forward * arahrotasi * Time.deltaTime);
        rdb.freezeRotation = false;
    }
}
