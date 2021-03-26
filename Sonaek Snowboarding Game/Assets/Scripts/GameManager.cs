using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isAlive = true;

    public GameObject player;

    public void GameOver()
    {
        isAlive = false;

        var scripts = player.GetComponents(typeof(MonoBehaviour));
        foreach (MonoBehaviour script in scripts)
        {
            script.enabled = false;
        }
    }
}
