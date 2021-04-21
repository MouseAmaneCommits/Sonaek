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
#if DEBUG
        UpdateText(Mathf.Round(player.velocity.magnitude));
#endif
    }

    void UpdateText(float t)
    {
        text.text = "Speed: " + t;
    }
}
