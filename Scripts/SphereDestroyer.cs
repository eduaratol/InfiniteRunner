using UnityEngine;

public class SphereDestroyer : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Spheres>() != null)
        {
            Destroy(other.gameObject);
        }
    }
}