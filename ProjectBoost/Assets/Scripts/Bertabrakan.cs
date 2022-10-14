using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bertabrakan : MonoBehaviour
{
    [SerializeField] int delay = 2;


    [HideInInspector] public AudioManagement audioManagement;
    AudioSource audioSource;

    bool isTransitioning = false;

    private void Awake()
    {
        audioManagement = GameObject.Find("AudioManagement").GetComponent<AudioManagement>();
        audioSource = GameObject.Find("AudioManagement").GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if(isTransitioning)
        {
            return;
        }
        switch (other.gameObject.tag)
        {
            case "Respawn":
                Debug.Log("touch Respawn");
                break;
            case "Fuel":
                Debug.Log("touch Fuel");
                break;
            case "Finish":
                Finish();
                Debug.Log("Finish");
                break;
            default :
                Crasing();
                Debug.Log("You Die");
                break;
        }
    }

    void Finish()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioManagement.sfxSucces();
        //add some particle
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", delay);
    }

    void Crasing()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioManagement.sfxExplode();
        //add some particle
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadScene", delay);
    }

    void LoadNextLevel()
    {
        int CurrentScene = SceneManager.GetActiveScene().buildIndex;
        int NextScene = CurrentScene + 1;
        if(NextScene == SceneManager.sceneCountInBuildSettings)
        {
            NextScene = 0;
        }
        SceneManager.LoadScene(NextScene);
    }

    void ReloadScene()
    {
        int CurrentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentScene);
    }
}
