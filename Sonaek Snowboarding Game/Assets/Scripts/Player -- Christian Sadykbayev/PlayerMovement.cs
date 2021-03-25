using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// LAST EDITED ---- CHRISTIAN SADYKBAYEV
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody player;
    public float speed;
    public float turnSpeed;
    private float xRotation;

    
    void Start()
    {
        
    }

    public void resetPool(Rigidbody rg)
    {
        rg.velocity = Vector3.zero;
        rg.angularVelocity = Vector3.zero;
    }

    void Update()
    {
        // Move Forward
        if(Input.GetKey(KeyCode.W))
        {
            player.AddForce(player.transform.forward * speed * Time.deltaTime);
        }

        // STOP
        if(Input.GetKey(KeyCode.S))
        {
            // INSERT ANIMATION HERE

            // !INSERT ANIMATION HERE

            
        }
    }
}
