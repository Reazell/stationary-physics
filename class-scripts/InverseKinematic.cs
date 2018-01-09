using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class InverseKinematic : MonoBehaviour
{
    Animator animator;
    public bool ikActive = false;
    public Transform rightHandObj = null;
    public Transform leftHandObj = null;
    Rigidbody rb;


    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void OnAnimatorIK()
    {
        if (animator)
        {


            if (ikActive)
            {





                if (rightHandObj != null)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                    animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                    animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
                    animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation);
                }

                if (leftHandObj != null)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                    animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
                    animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandObj.position);
                    animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandObj.rotation);
                }

            }


            else
            {
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
                animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
                animator.SetLookAtWeight(0);
            }
        }
    }


    void CheckForSteps()
    {
        RaycastHit hit;
        RaycastHit headHit;
        Debug.DrawRay(transform.position, transform.forward, Color.red, 1.0f);
        Debug.DrawRay(transform.position + new Vector3(0, 0.4f, 0), transform.forward, Color.red, 1.0f);
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1.0f) && !Physics.Raycast(transform.position + new Vector3(0, 0.4f, 0), transform.forward, out headHit, 1.0f))
        {
            Debug.Log("Hitting");
            if (Vector3.Dot(Vector3.up, hit.normal) < 0.7f)
            {
                rb.GetComponent<Rigidbody>().AddForce(transform.up, ForceMode.VelocityChange);
            }
        }
    }
}
