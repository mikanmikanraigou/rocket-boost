using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollsionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem success_Particle;
    [SerializeField] ParticleSystem fail_Particle;
    [SerializeField] AudioClip audio_success;
    [SerializeField] AudioClip audio_fail;
    [SerializeField] float wait_time;

    AudioSource audioEngine;
    ParticleSystem particleEngine;

    bool isTransitioning = false;

    private void Start()
    {
        audioEngine = GetComponent<AudioSource>();
        particleEngine = GetComponent<ParticleSystem>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isTransitioning) { return; };

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Friendly Touched");
                break;
            case "Finish":
                StartSuccessSequence();
                Debug.Log("Congrats");
                break;
            case "Fuel":
                Debug.Log("Fuel Filled");
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    private void StartSuccessSequence()
    {
        isTransitioning = true;
        audioEngine.Stop();
        audioEngine.PlayOneShot(audio_success);
        success_Particle.Play();
        GetComponent<MovementControl>().enabled = false;
        Invoke("LoadNextLevel", wait_time);
    }

    private void StartCrashSequence()
    {
        isTransitioning = true;
        audioEngine.Stop();
        audioEngine.PlayOneShot(audio_fail);
        fail_Particle.Play();
        GetComponent<MovementControl>().enabled = false;
        Invoke("ReloadScene", wait_time);
    }

    private void LoadNextLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        int nextLevel = currentLevel + 1;
        if (nextLevel == SceneManager.sceneCountInBuildSettings)
        {
            nextLevel = 0;
        }
        SceneManager.LoadScene(nextLevel);
    }

    private void ReloadScene()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene( currentLevel );
    }
}
