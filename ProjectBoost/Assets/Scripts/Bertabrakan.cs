using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bertabrakan : MonoBehaviour
{
    [SerializeField] int delay;

    private void OnCollisionEnter(Collision other)
    {
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
        //add some sfx
        //add some particle
        Invoke("LoadNextLevel", delay);
    }

    void Crasing()
    {
        //add some sfx
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
