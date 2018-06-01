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
            changeSceneHandler = new ChangeSceneHandler();
        }
    }

    public void ChangeToGameOverScreen()
    {
        new NetworkManager().ServerChangeScene("GameOverScene");
    }

    public void ChangeToGameScreen()
    {
        new NetworkManager().ServerChangeScene("SampleScene");
    }
}
