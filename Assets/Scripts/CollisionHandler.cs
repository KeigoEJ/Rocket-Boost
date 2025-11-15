using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] AudioClip successSFX;
    [SerializeField] AudioClip crashSFX;
    [SerializeField] ParticleSystem successParticle;
    [SerializeField] ParticleSystem crashParticle;
    AudioSource audioSource;

    bool isControllable = true;
    bool isCollidable = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isControllable = true;
    }

    void Update()
    {
        RespondToDebugKeys();
    }
    
    //Remember to delete the debug fuction before deploy the project
    void RespondToDebugKeys()
    {
        if(Keyboard.current.lKey.wasPressedThisFrame)
        {
           LoadNextScene(); 
        }
        else if(Keyboard.current.cKey.wasPressedThisFrame)
        {
            isCollidable = !isCollidable;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (!isControllable || !isCollidable)
            return;

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("You bumped to Friendly");
                break;
            case "Fuel":
                Debug.Log("You bumped into Fuel");
                break;
            case "Finish":
                StartSuccesSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    void LoadNextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;

        if (nextScene == SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
        }
        
        SceneManager.LoadScene(nextScene);
    }

    void ReloadLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    void StartCrashSequence()
    {
        isControllable = false;
        audioSource.Stop();
        audioSource.PlayOneShot(crashSFX);
        crashParticle.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void StartSuccesSequence()
    {
        isControllable = false;
        audioSource.Stop();
        audioSource.PlayOneShot(successSFX);
        successParticle.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextScene", levelLoadDelay);
    }
}
