using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[System.Serializable]
public class Trick180 : Trick
{
    // you change these values in the inspector
    public TrickDirection trickDirection;
    public PlayerMovement player;
    public float rotationalSpeed;

    public override void PreformTrick()
    {
        Debug.Log("TRICK STARTED");
        player.Jump();
    }

    public override void UpdateTrick()
    {
        Debug.Log("TRICK DOING");
        if (player.transform.rotation.y == 180)
        {
            doTrick = false;
            Debug.Log("TRICK ENDED");
        }
        if (trickDirection == TrickDirection.Frontside)
            player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, Quaternion.Euler(0, 180, 0), rotationalSpeed * Time.deltaTime);
        if (trickDirection == TrickDirection.Backside)
            player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, Quaternion.Euler(0, 180, 0), rotationalSpeed * Time.deltaTime);
    }
}
