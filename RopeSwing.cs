using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSwing : MonoBehaviour {

    public static HingeJoint2D hinge;

    void OnTriggerEnter2D(Collider2D collider)
    {


        Debug.Log("BeforeCollision");
        if (collider.gameObject.tag == "Player" && hinge == null)
        {
            Debug.Log("collsion");
            hinge = gameObject.AddComponent<HingeJoint2D>();
            hinge.connectedBody = collider.gameObject.GetComponent<Rigidbody2D>();
            Invoke("Freedom" , 1);
        }

    }


    void Freedom()
    {
        Destroy(hinge);
        Debug.Log("FREEEDOOOM!");
    }
}
