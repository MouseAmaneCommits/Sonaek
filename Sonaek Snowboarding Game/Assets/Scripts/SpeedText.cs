using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedText : MonoBehaviour
{
    public Rigidbody player;
    public Text text;

    void Update()
    {
        text.text = "Speed: " + Mathf.Round(player.velocity.magnitude);    
    }
}
