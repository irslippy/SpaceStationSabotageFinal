using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropelShot : MonoBehaviour
{
    //attached to the powercells that the player shoots. When the new powercell is instantiated,
    //this script adds force to the ball to make it appear as if the gun is firing
    public float shotVelocity;
    void Start()
    {

        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.AddRelativeForce(gameObject.transform.forward * shotVelocity, ForceMode.VelocityChange);

    }

    private void OnCollisionEnter(Collision collision)
    {
       Destroy(gameObject);
    }
}
