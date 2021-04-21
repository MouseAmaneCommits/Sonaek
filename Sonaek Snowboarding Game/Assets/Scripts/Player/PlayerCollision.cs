using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Last edited by Christian Sadykbayev
public class PlayerCollision : MonoBehaviour
{
    public Rigidbody rb;
    public string obstacleTag = "Obstacle";
    public GameObject playerCapsule;
    public float velocityThreshold;
    public float forceMultiplier;

    public GameManager gameManager;
    public PlayerMovement pm;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Multiplying by 1000 cause yes
        if (collision.gameObject.tag == "Obstacle" && rb.GetRelativePointVelocity(rb.transform.forward).z*1000 >= velocityThreshold && pm.snowboarding)
        {
            Vector3 dir = collision.contacts[0].point - transform.position;
            dir = dir.normalized;
            gameManager.GameOver();
            Rigidbody capsuleRb = playerCapsule.AddComponent<Rigidbody>();
            capsuleRb.AddForce(dir * (velocityThreshold * forceMultiplier), ForceMode.Impulse);
        }
    }
}
