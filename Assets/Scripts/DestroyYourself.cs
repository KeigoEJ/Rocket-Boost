using UnityEngine;

public class DestroyYourself : MonoBehaviour
{
    [SerializeField] ParticleSystem gainFuel;
    [SerializeField] AudioClip getFuel;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void DestroyMySelf()
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.PlayOneShot(getFuel);
            gainFuel.Play();
            Invoke("DestroyMySelf", 0.5f);
        }
    }
}
