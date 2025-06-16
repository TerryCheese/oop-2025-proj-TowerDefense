using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBase : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is an enemy
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Game Over! Enemy has reached the player base.");
            // Load the ending scene
            LoadEndingScene();
        }
    }

    private void LoadEndingScene()
    {
        // Load the scene named "EndingScene" (make sure to replace with your actual scene name)
        SceneManager.LoadScene("EndingScene");
    }
}
