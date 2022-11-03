using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    Vector3 startingVector;
    [SerializeField] Vector3 movementVector;
    float movementFloat;
    [SerializeField] float period;
    // Start is called before the first frame update
    void Start()
    {
        startingVector = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float cycle = Time.time / period;

        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(tau * cycle);

        movementFloat = (rawSinWave + 1f) / 2f;

        Vector3 offset = movementVector * movementFloat;
        transform.position = startingVector + offset;
    }
}
