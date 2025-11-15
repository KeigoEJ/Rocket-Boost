using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class QuitApplication : MonoBehaviour
{
    [SerializeField] InputAction quitGame;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void OnEnable()
    {
        quitGame.Enable();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(quitGame.IsPressed())
        {
            Debug.Log("Quit Pressed");
            Application.Quit();
        }
    }
}
