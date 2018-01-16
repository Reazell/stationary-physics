using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGenerator : MonoBehaviour {

    public Rigidbody car;
	
	void Start () {
        car.useGravity = false;
    }
	
	
	void FixedUpdate () {

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            car.velocity = new Vector3(0, 3, 4);
        }
    
        ApplyGravity(car);
	}


    void ApplyGravity(Rigidbody car)
    {
        
        var direction = (car.transform.position - transform.position).normalized;
        car.AddForce(direction*9.81f, ForceMode.Acceleration);

    }

}
