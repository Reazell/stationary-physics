using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jetpackScript : MonoBehaviour {

    public ParticleSystem particles;
    public Rigidbody rb;
    [Range(1f, 100f)] public float speed;
    
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            JetPackEnabled();
        }
        else
        {
            JetPackDisabled();
        }

        
	}

    public void JetPackEnabled()
    {
        particles.enableEmission = true;
        //rb.AddForce(Vector3.up * speed, ForceMode.Acceleration);
        rb.AddForce(transform.forward * speed, ForceMode.Acceleration);
        rb.AddForce(transform.up * speed, ForceMode.Acceleration);
    }

    public void JetPackDisabled()
    {
        particles.enableEmission = false;
    }
}
