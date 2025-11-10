using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("You bumped to Friendly");
                break;
            case "Fuel":
                Debug.Log("You bumped into Fuel");
                break;
            case "Finish":
                Debug.Log("You are Finishh");
                LoadNextScene();
                break;
            default:
                Debug.Log("You bumped into obstacle");
                ReloadLevel();
                break;
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
    }
}
