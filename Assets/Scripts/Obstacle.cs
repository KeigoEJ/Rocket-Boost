using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float rotateStreght = 10f;
    [SerializeField] bool isRotating = true;

    void Update()
    {
        KuruKuru();
    }

    void KuruKuru()
    {
        if (isRotating)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * rotateStreght);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isRotating = false;
        }
    }
}
