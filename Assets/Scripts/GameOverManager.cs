using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GameOverManager : NetworkBehaviour {

    public Button RestartBtn;

    private ChangeSceneHandler changeSceneHandler;

    void Awake()
    {
        changeSceneHandler = FindObjectOfType<ChangeSceneHandler>();
        RestartBtn.onClick.AddListener(() => changeSceneHandler.ChangeToGameScreen());
    }

    private void Start()
    {
        if (isServer)
            RestartBtn.gameObject.SetActive(true);
    }
}
