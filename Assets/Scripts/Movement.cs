using UnityEngine;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;
    [SerializeField] float thrustStrenght = 50f;
    [SerializeField] float rotationStreght = 10f;
    [SerializeField] AudioClip mainEngineSFX;
    [SerializeField] ParticleSystem mainEngineParticle;
    [SerializeField] ParticleSystem leftEngineParticle;
    [SerializeField] ParticleSystem righEngineParticle;
    AudioSource audioSource;
    Rigidbody rb;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        thrust.Enable();
        rotation.Enable();
    }

    void FixedUpdate()
    {
        ProcessThrusting();
        ProcessRotation();
    }

    private void ProcessThrusting()
    {
        if (thrust.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * thrustStrenght * Time.fixedDeltaTime);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngineSFX);
            }

            if (!mainEngineParticle.isPlaying)
            {
                mainEngineParticle.Play();
            }
        }
        else
        {
            audioSource.Stop();
            mainEngineParticle.Stop();
        }
    }

    private void ProcessRotation()
    {
        float rotationInput = rotation.ReadValue<float>();

        if (rotationInput < 0)
        {
            ApplyRotation(rotationStreght);
            if (!righEngineParticle.isPlaying)
            {
                leftEngineParticle.Stop();
                righEngineParticle.Play();
            }
        }
        else if (rotationInput > 0)
        {
            ApplyRotation(-rotationStreght);
            if (!leftEngineParticle.isPlaying)
            {
                righEngineParticle.Stop();
                leftEngineParticle.Play();
            }
        }
        else
        {
            righEngineParticle.Stop();
            leftEngineParticle.Stop();
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationThisFrame);
        rb.freezeRotation = false;
    }
}
