using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

// Last edited: Christian Sadykbayev
public class TrickManager : MonoBehaviour
{
    public List<Trick> tricks;
    public PlayerMovement playerMovement;
    public MouseLook mouseLook;
    public PointSystem pointSystem;

    private float totalYRotation = 0;
    private float totalXRotation = 0;

    private bool inAir = false;

    void Start()
    {
        foreach(Trick trick in tricks)
        {
            trick.counter = 0;
            trick.done = false;
        }
    }

    // Update is called once per frame
    void Update()
    {


        // If we are in the air.
        if (!playerMovement.isGrounded())
        {
            inAir = true;

            totalYRotation += Input.GetAxis("Mouse X") * mouseLook.mouseSensitivity * Time.deltaTime;
            totalXRotation += Input.GetAxis("Mouse Y") * mouseLook.mouseSensitivity * Time.deltaTime;

            foreach (Trick trick in tricks)
            {
                if ( checkDidTrick(trick) /*&& !trick.done*/)
                {
                    trick.counter += 1;
                    //Debug.Log("Trick done: " + trick.name);
                    pointSystem.Points += trick.pointsReward;
                    //trick.done = true;
                }
            }
        }
        else
        {
            // If this is the first frame we are on the ground
            if (inAir)
            {
                setTricksDoneStatus(false);
            }
            inAir = false;
            totalYRotation = 0;
            totalXRotation = 0;
        }
    }

    bool checkDidTrick(Trick trick)
    {
        bool didYSpin = false;
        bool didXSpin = false;

        // Forgive me father, for i have sinned, i made extremely long if statements.

        float numSign = Mathf.Sign(trick.requiredYSpin);
        if ((totalYRotation >= trick.requiredYSpin && numSign == 1) || (totalYRotation <= trick.requiredYSpin && numSign == -1) || trick.requiredYSpin == 0)
        {
            didYSpin = true;
        }

        numSign = Mathf.Sign(trick.requiredXSpin);
        if ((totalXRotation >= trick.requiredXSpin && numSign == 1) || (totalXRotation <= trick.requiredXSpin && numSign == -1) || trick.requiredXSpin == 0)
        {
            didXSpin = true;
        }
    
        if(didXSpin && didYSpin)
        {
            totalXRotation = 0f;
            totalYRotation = 0f;
        }

        return (didXSpin && didYSpin);
    }

    void setTricksDoneStatus(bool setValue)
    {
        foreach (Trick trick in tricks)
        {
            trick.done = setValue;
        }
    }
}
