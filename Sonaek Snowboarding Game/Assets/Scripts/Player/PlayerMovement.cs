using System.Collections;
using System.Collections.Generic;
using UnityEngine.Scripting;
using UnityEngine;
using UnityEditor.Timeline;

<<<<<<< Updated upstream
=======
public enum TrickType
{
    Frontside180,
    Backside180
}

public enum TrickDirection
{
    Frontside,
    Backside
}

public enum Stances
{
    Regular,
    Goofy
}

public enum StancesRelative
{
    Regular,
    Switch,
    Fakie
}

>>>>>>> Stashed changes
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
    public float rotationSpeed; // This is the speed in which the upper body will rotate for 180s and stuff

<<<<<<< Updated upstream
    private float xRotation; // dont worry about this
    private float MaxVelocity = 65; // The max velocity the player can go
    private bool inAir; // If the player is in the air
    private bool isPowersliding; // If the player is powersliding bool is true
    public LayerMask GroundLayerFaggot; // Incase you want to get the ground layer idk
=======
    public LayerMask GroundLayerFaggot; // Incase you want to get the ground layer idk
    public float jumpHeight; // The height you can jump on your board!
    public float groundDistance; // The max distance the ground has to be for the game to register the snowboarder to be on the ground

    public GameManager gameManager;
    public Vector3 snowboardCenterOfGravity; // The center of gravity of the snowboard
    public Stances stanceOfSnowboarder; // The stance of the snowboarder

    private float MaxVelocity = 65; // The max velocity the player can go
    private bool inAir; // If the player is in the air
    private bool isPowersliding; // If the player is powersliding bool is true
    private StancesRelative relativeStance = StancesRelative.Regular;
>>>>>>> Stashed changes

    void Start()
    {
        speed = speedOfSnowboarder;

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

        bool hit = Physics.Raycast(snowboardRef.transform.position, Vector3.down, 1);
        Debug.DrawRay(snowboardRef.transform.position, Vector3.down, Color.red, 1);
        player.velocity = Vector3.ClampMagnitude(player.velocity, MaxVelocity);
        // transform.up = hit.normal;

        if (hit == true) //Check if player hit ground FROM raycast (can be buggyish, might revamp later)
        {
<<<<<<< Updated upstream
            print("YOUR HITTING THE GROUND");
            player.constraints = RigidbodyConstraints.None; //Resets constraints of rotation axises

            inAir = false;
        }
        else
        {
            print("You're in the air");
            transform.position = transform.position -= new Vector3(0, 4.8f) * Time.deltaTime;
            player.constraints = RigidbodyConstraints.FreezeRotationX; //Important for not flipping in air
            player.constraints = RigidbodyConstraints.FreezeRotationZ; //Important for not flipping in air
            // player.rotation.SetEulerAngles(0, 0, 0);
            inAir = true;
        } 

=======
            //Debug.Log("YOUR HITTING THE GROUND");
        }
        else
        {
            //Debug.Log("You're in the air");
        } 

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

    public void Jump()
    {
        player.AddForce(Vector3.up * jumpHeight * Time.deltaTime);
    }

    void Keybinds()
    {
        if (Input.GetKey(KeyCode.Space) && !inAir)
        {
            Jump();
        }
        else if (Input.GetKey(KeyCode.D) && !inAir)
        {
            GetComponent<TrickSystem>().GetTrick(TrickType.Frontside180).DoTrick();
        }

>>>>>>> Stashed changes
        // Move Forward
        if (Input.GetKey(KeyCode.W) && !inAir)
        {
            if(player.GetRelativePointVelocity(player.transform.forward).z <= 0)
            {
                speed = 1000;
            }

            player.AddForce(player.transform.forward * speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.S) && !inAir)
        {
            // Set powersliding to true
            isPowersliding = true;

            // INSERT ANIMATION HERE
            animator.SetBool("Powerslide", true);
            // !INSERT ANIMATION HERE
        }

        if (Input.GetKeyUp(KeyCode.S) && !inAir)
        {
            // Set powersliding to false
            isPowersliding = false;

            // INSERT ANIMATION HERE
            animator.SetBool("Powerslide", false);
            // !INSERT ANIMATION HERE
        }

        if(inAir)
        {
            player.drag = airDrag;
        }
        else if(!inAir && isPowersliding)
        {
            player.drag = powerslideDrag;
        }
        else if(!inAir)
        {
            player.drag = groundDrag;
        }
    }
}