using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// LAST EDITED ---- CHRISTIAN SADYKBAYEV
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody player;
    public float speed;

    
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            player.AddForce(player.transform.forward * speed * Time.deltaTime);
        }
    }
}