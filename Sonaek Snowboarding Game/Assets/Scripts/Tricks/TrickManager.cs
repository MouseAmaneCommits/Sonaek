using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrickManager : MonoBehaviour
{
    public List<Trick> tricks;
    public PlayerMovement playerMovement;
    public MouseLook mouseLook;
    private float totalYRotation = 0;

    // Update is called once per frame
    void Update()
    {
        // If we are in the air.
        if (!playerMovement.isGrounded())
        {

            totalYRotation += Input.GetAxis("Mouse X") * mouseLook.mouseSensitivity * Time.deltaTime;
            foreach (Trick trick in tricks)
            {
                if (totalYRotation >= trick.requiredYSpin && trick.requiredYSpin != 0)
                {
                    Debug.Log("Trick done.");
                    tricks.Remove(trick);
                }
            }
        }
        else
        {
            totalYRotation = 0;
        }
    }
}
