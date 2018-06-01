using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {

    public Button button;

    private ChangeSceneHandler changeSceneHandler;

    void Awake()
    {
        changeSceneHandler = FindObjectOfType<ChangeSceneHandler>();
        button.onClick.AddListener(() => changeSceneHandler.ChangeToGameScreen());
    }
}
