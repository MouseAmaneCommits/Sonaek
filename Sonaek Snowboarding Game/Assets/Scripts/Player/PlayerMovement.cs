using System.Collections;
using System.Collections.Generic;
using UnityEngine.Scripting;
using UnityEngine;

// LAST EDITED ---- Christian Sadykbayev
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody player; // This is a reference to the player's rigidbody
    public GameObject snowboardRef; // This is a reference to the snowboard object
    public float slowDownSpeed; // This value is the amount to slow down when you press S
    public float speedOfSnowboarder; // the max speed of snowboarder
    private float speed; // This is a reference to the speed of the player
    public float turnspeed; // Don't change this to a high amount or else its spinny boi
    public Animator animator; // The animations for the player
    public float airDrag; // The player drag will be set to this number if the player is in the air
    public float groundDrag; // The player drag will be set to this number if the player is on the ground
    public float powerslideDrag; // The player drag will be set to this number when the player is powersliding

    private float MaxVelocity = 65; // The max velocity the player can go
    private bool inAir; // If the player is in the air
    private bool isPowersliding; // If the player is powersliding bool is true
    public LayerMask GroundLayerFaggot; // Incase you want to get the ground layer idk
    public float jumpHeight; // The height you can jump on your board!
    public float groundDistance; // The max distance the ground has to be for the game to register the snowboarder to be on the ground

    public GameManager gameManager;
    public Vector3 snowboardCenterOfGravity; // The center of gravity of the snowboard

    public bool snowboarding = true;
    public WalkingScript walkingScript;

    // Snowboard position offset when switching from walking to snowboarding and vice versa.
    public Vector3 snowboardOffset;

    void Start()
    {
        speed = speedOfSnowboarder;

        player.centerOfMass = snowboardCenterOfGravity;
        
    }

    public void resetPool(Rigidbody rg)
    {
        rg.velocity = Vector3.zero;
        rg.angularVelocity = Vector3.zero;
    }
    
    public bool isGrounded()
    {
        bool hit = Physics.CheckSphere(snowboardRef.transform.position, groundDistance, GroundLayerFaggot, QueryTriggerInteraction.Collide);
        Debug.DrawRay(snowboardRef.transform.position, Vector3.down, Color.red, 1);

        return hit;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !inAir && player.velocity.magnitude <= 1)
        {
            // Pick up snowboard
            if (snowboarding)
            {
                animator.SetBool("pickupSnowboard", true);

                player.constraints = RigidbodyConstraints.FreezeRotation;
                snowboarding = false;
            }
            else
            {
                animator.SetBool("pickupSnowboard", false);

                player.constraints = RigidbodyConstraints.None;
                snowboarding = true;
            }
        }

        if (snowboarding)
        {
            inAir = !isGrounded();

            // Clamp player speed
            player.velocity = Vector3.ClampMagnitude(player.velocity, MaxVelocity);

            if (inAir)
            {
                player.drag = airDrag;
            }
            else if (!inAir && isPowersliding)
            {
                player.drag = powerslideDrag;
            }
            else if (!inAir)
            {
                player.drag = groundDrag;
            }
            Keybinds();
        }
        else
        {
            walkingScript.Walk();
        }
    }

    void Keybinds()
    {
        if (Input.GetKey(KeyCode.Space) && !inAir && snowboarding)
        {
            player.AddForce(Vector3.up * jumpHeight * Time.deltaTime);
        }
        // Move Forward
        if (Input.GetKey(KeyCode.W) && !inAir && !isPowersliding)
        {
            if (player.GetRelativePointVelocity(player.transform.forward).z <= 0)
            {
                speed = 1000;
            }

            player.AddForce(player.transform.forward * speed * Time.deltaTime);
        }

        // Alternative way of Turning (NOT mouse controlled)
        if (Input.GetKey(KeyCode.A) && !snowboarding)
        {
            player.AddForce(player.transform.right * turnspeed * Time.deltaTime);
            player.transform.Rotate(0, -turnspeed, 0 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D) && !snowboarding)
        {
            player.AddForce(player.transform.right * turnspeed * Time.deltaTime);
            player.transform.Rotate(0, turnspeed, 0 * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.S) && !inAir && snowboarding)
        {
            // Set powersliding to true
            isPowersliding = true;
            animator.SetBool("Powerslide", true);
        }
        else if (Input.GetKeyUp(KeyCode.S) && snowboarding)
        {
            // Set powersliding to false
            isPowersliding = false;
            animator.SetBool("Powerslide", false);
        }
    }
}