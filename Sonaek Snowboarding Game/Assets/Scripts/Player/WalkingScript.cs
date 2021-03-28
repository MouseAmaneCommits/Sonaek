using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingScript : MonoBehaviour
{
    public Rigidbody rb;
    public float movementSpeed;
    public float maxSpeed;
    public float airDrag;
    public float runningMultiplier;
    public float stoppingMultiplier;

    public void Walk()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        rb.drag = airDrag;

        rb.AddForce(runningMultiplier * vertical * (transform.forward * movementSpeed * Time.deltaTime));
        rb.AddForce(runningMultiplier * horizontal * (transform.right * movementSpeed * Time.deltaTime));

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

        if (vertical == 0 && horizontal == 0)
        {
            rb.drag = airDrag * 2;
            rb.AddForce(-(rb.velocity * stoppingMultiplier));
        }
    }
}
