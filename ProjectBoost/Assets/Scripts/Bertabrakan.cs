using UnityEngine;

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
                Debug.Log("You Die");
                break;
        }
    }
}
