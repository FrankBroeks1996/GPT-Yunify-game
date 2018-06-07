using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerStatsScript : NetworkBehaviour {

    public int Health = 5;
    [SyncVar]
    public int Score = 0;

    void Update()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
            ChangeSceneHandler.changeSceneHandler.ChangeToGameOverScreen();
        }
    }
}
