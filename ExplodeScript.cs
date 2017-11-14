using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeScript : MonoBehaviour {

    public float radius = 5.0f;
    public float power = 10.0f;
    public GameObject explosion;
	void Start () {
        explosion.SetActive(false);
        Invoke("Explode", 3);
	}

    void ExplodeStop()
    {
        explosion.SetActive(false);
    }
    void Explode()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
            }
        }
        explosion.SetActive(true);
        GetComponent<MeshRenderer>().enabled = false;
        Invoke("ExplodeStop", 3.0f);
    }
}
