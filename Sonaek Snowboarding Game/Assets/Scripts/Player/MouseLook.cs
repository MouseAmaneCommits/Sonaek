using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

// Last Edited: Christian Sadykbayev
public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity;
    public Transform playerBody;
    public GameManager gameManager;
    public PlayerMovement playerMovement;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = GetMouseX();
        float mouseY = GetMouseY();

        playerBody.Rotate(Vector3.up * mouseX);

        if (!playerMovement.isGrounded() && playerMovement.snowboarding)
        {
            playerBody.Rotate(Vector3.left * mouseY);
        }
    }

    public float GetMouseX()
    {
        return Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
    }

    public float GetMouseY()
    {
        return Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
    }
}