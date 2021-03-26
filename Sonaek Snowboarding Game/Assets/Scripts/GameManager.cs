using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isAlive = true;

    public GameObject player;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

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
