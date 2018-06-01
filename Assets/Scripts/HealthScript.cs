using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{

    public int Health = 5;

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
            if(transform.tag == "Player")
            {
                ChangeSceneHandler.changeSceneHandler.ChangeToGameOverScreen();
            }
        }
    }
}
