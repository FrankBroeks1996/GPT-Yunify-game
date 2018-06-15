using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ChangeSceneHandler : NetworkBehaviour {

    public static ChangeSceneHandler changeSceneHandler;

    void Awake()
    {
        if(changeSceneHandler == null)
        {
            DontDestroyOnLoad(this);
            changeSceneHandler = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeToGameOverScreen()
    {
        new NetworkManager().ServerChangeScene("GameOverScene");
    }

    public void ChangeToGameScreen()
    {
        if (hasAuthority)
        {
            new NetworkManager().ServerChangeScene("SampleScene");
        }
        else
        {
            CmdRestartGame();
        }
    }

    [Command]
    public void CmdRestartGame()
    {
        new NetworkManager().ServerChangeScene("SampleScene");
    }
}
