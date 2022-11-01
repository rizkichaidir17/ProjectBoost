using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] int thrustingSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] ParticleSystem boostParticle;
    [SerializeField] ParticleSystem boostleftParticle;
    [SerializeField] ParticleSystem boostrightParticle;
    [SerializeField] float maxFuel;
    [SerializeField] float currentFuel;
    [SerializeField] float fuelUse;
    Rigidbody rdb;
    AudioSource audioSource;

    [HideInInspector]public AudioManagement audioManagement;

    public FuelBar FuelBar;

    private void Awake()
    {
        audioManagement = GameObject.Find("AudioManagement").GetComponent<AudioManagement>();
        audioSource = GameObject.Find("AudioManagement").GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rdb = GetComponent<Rigidbody>();
        currentFuel = maxFuel;
        FuelBar.SetMaxFuel(maxFuel);
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
            FuelSystem(fuelUse);
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

    void FuelSystem(float fuelUse)
    {
        currentFuel -= fuelUse * Time.deltaTime;
        FuelBar.SetFuel(currentFuel);
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
