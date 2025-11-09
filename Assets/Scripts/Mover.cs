using UnityEngine;
using UnityEngine.InputSystem;

public class Mover : MonoBehaviour
{
    [SerializeField] InputAction FB;
    [SerializeField] InputAction RL;
    [SerializeField] float speed = 10f;

    void OnEnable()
    {
        FB.Enable();
        RL.Enable();
    }

    void FixedUpdate()
    {
        ForwardBack();
        RightLeft();
    }

    private void ForwardBack()
    {
        float movementInput = FB.ReadValue<float>();
        if (movementInput < 0)
        {
            DecideForwardBack(speed);
        }
        else if (movementInput > 0)
        {
            DecideForwardBack(-speed);
        }
    }

    private void RightLeft()
    {
        float StrafeInput = RL.ReadValue<float>();
        if (StrafeInput < 0)
        {
            DecideRightLeft(speed);
        }
        else if (StrafeInput > 0)
        {
            DecideRightLeft(-speed);
        }
    }
    
    private void DecideRightLeft(float boost)
    {
        gameObject.transform.Translate(Vector3.right * Time.fixedDeltaTime * boost);
    }

    private void DecideForwardBack(float speedoo)
    {
        gameObject.transform.Translate(Vector3.forward * Time.fixedDeltaTime * speedoo);
    }
}