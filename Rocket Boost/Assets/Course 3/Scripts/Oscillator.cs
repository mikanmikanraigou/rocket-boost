using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 starting_position;
    [SerializeField] Vector3 end_position;
    float movementFactor;
    [SerializeField] float period = 2f;
    // Start is called before the first frame update
    void Start()
    {
        starting_position = transform.position;
        Debug.Log("starting pos: " + starting_position);
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon ){ return; };
        float cycles = Time.time / period; //growing over time 

        const float tau = Mathf.PI * 2f;
        float rawSinWave = Mathf.Sin(cycles * tau);

        movementFactor = (rawSinWave + 1f) / 2f;

        Vector3 offset = end_position * movementFactor;
        transform.position = starting_position + offset;
    }
}
