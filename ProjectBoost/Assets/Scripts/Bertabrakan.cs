using UnityEngine;
using UnityEngine.SceneManagement;

public class Bertabrakan : MonoBehaviour
{
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
                Debug.Log("Finish");
                break;
            default :
                SceneLoader();
                Debug.Log("You Die");
                break;
        }
    }

    void SceneLoader()
    {
        int CurrentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentScene);
    }
}
