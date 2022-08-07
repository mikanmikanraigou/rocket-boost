using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControl : MonoBehaviour
{
    //PARAMETERS - For Tuning, Typically set in Editor
    [SerializeField] float jetThrust = 500f;
    [SerializeField] float minijetThrust = 20f;
    [SerializeField] AudioClip audioFiles;       
    [SerializeField] ParticleSystem jet_booster;
    [SerializeField] ParticleSystem left_booster;
    [SerializeField] ParticleSystem right_booster;

    //CACHE - e.g. Reference for readability or speed
    Rigidbody rb;
    AudioSource audioSource;
    ParticleSystem particleEngine;

    //STATE - private instance (member) variables
    //bool isAlive; //examples

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        particleEngine = GetComponent<ParticleSystem>(); 
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust() {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    void ProcessRotation()
    {
        //Rotate Left
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(minijetThrust);
            if (!right_booster.isPlaying)
            {
                right_booster.Play();
            }
        }  //Rotate Right
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-minijetThrust);
            if (!left_booster.isPlaying)
            {
                left_booster.Play();
            }
        }
        else
        {
            right_booster.Stop();
            left_booster.Stop();
        }
    }
    
    private void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * Time.deltaTime * jetThrust);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audioFiles, 1);
        }
        if (!jet_booster.isPlaying)
        {
            jet_booster.Play();
        }
    }


    private void StopThrusting()
    {
        audioSource.Stop();
        jet_booster.Stop();
    }


    private void ApplyRotation(float rotation)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotation * Time.deltaTime );
        rb.freezeRotation = false;
    }
}
