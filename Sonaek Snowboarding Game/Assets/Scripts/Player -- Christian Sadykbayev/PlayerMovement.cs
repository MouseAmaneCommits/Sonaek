using System.Collections;
using System.Collections.Generic;
using UnityEngine.Scripting;
using UnityEngine;

// LAST EDITED ---- Benjamin S
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody player;
    public GameObject SnowboardRef;
    public float speed;
    public float turnspeed; // Don't change this to a high amount or else its spinny boi
    private float xRotation;
    private float MaxVelocity = 65;



    void Start()
    {

        // DON'T TOUCH THIS, this is for making the board not flip when moving
        var SetSnowBoardCentreGravity = new Vector3(0, -2, 0);
        player.centerOfMass = SetSnowBoardCentreGravity;
        
    }

    public void resetPool(Rigidbody rg)
    {
        rg.velocity = Vector3.zero;
        rg.angularVelocity = Vector3.zero;
    }

    void Update()
    {

        bool hit = Physics.Raycast(SnowboardRef.transform.position, Vector3.down, 1);
        Debug.DrawRay(SnowboardRef.transform.position, Vector3.down, Color.red, 1);
        player.velocity = Vector3.ClampMagnitude(player.velocity, MaxVelocity);

        if (hit == true)
        {
            print("YOUR HITTING THE GROUND");
            player.constraints = RigidbodyConstraints.None;
        }
        else
        {
            print("You're in the air");
            transform.position = transform.position -= new Vector3(0, 0.2f);
            player.constraints = RigidbodyConstraints.FreezeRotation;
            player.rotation.SetEulerAngles(0, 0, 0);
        }

        // Move Forward
        if (Input.GetKey(KeyCode.W))
        {
            player.AddForce(player.transform.forward * speed * Time.deltaTime);
        }

        // Alternative way of Turning (NOT mouse controlled)
        if (Input.GetKey(KeyCode.A))
        {
            player.AddForce(player.transform.right * turnspeed * Time.deltaTime);
            player.transform.Rotate(0, -turnspeed, 0 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            player.AddForce(player.transform.right * turnspeed * Time.deltaTime);
            player.transform.Rotate(0, turnspeed, 0 * Time.deltaTime);
        }

        // STOP
        if (Input.GetKey(KeyCode.S))
        {
            // INSERT ANIMATION HERE

            // !INSERT ANIMATION HERE


        }
    }
}