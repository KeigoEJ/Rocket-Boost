using UnityEngine;
using UnityEngine.InputSystem;

public class LandingPadThrust : MonoBehaviour
{
    [SerializeField] InputAction thrusting;
    Rigidbody rb;
    [SerializeField] float thrustSretght = 1000f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        thrusting.Enable();
    }
    void FixedUpdate()
    {
        ThrustBegin();
    }
    
    void ThrustBegin()
    {
        if(thrusting.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * Time.deltaTime * thrustSretght);
            Debug.Log(thrusting.IsPressed());
        }
    }
}
