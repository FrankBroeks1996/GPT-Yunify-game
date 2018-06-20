using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUIScript : MonoBehaviour {

    public static StartUIScript instance;

    public GameObject EnterNameScreen;
    public GameObject MainScreen;
    public GameObject HostingSettingsScreen;
    public GameObject MatchesScreen;
    public GameObject LobbyScreen;

    public Slider DifficultySlider;
    public GameObject StartGameBtn;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void SwitchToHostingScreen()
    {
        DisableAllScreens();
        HostingSettingsScreen.SetActive(true);
    }

    public void SwitchToMainScreen()
    {
        DisableAllScreens();
        MainScreen.SetActive(true);
    }

    public void SwitchToMatchesScreen()
    {
        DisableAllScreens();
        StartGameBtn.SetActive(false);
        MatchesScreen.SetActive(true);
    }

    public void SwitchToLobbyScreen()
    {
        DisableAllScreens();
        LobbyScreen.SetActive(true);
    }

    public void SwitchToSettingsScreen()
    {
        DisableAllScreens();
        StartGameBtn.SetActive(true);
        HostingSettingsScreen.SetActive(true);
    }

    public void SaveSettings()
    {
        SettingManager.instance.difficulty = DifficultySlider.value;
        DisableAllScreens();
        SwitchToLobbyScreen();
    }

    public void SavePlayerName(Text playerText)
    {
        PlayerPrefs.SetString("playerName", playerText.text);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SwitchToGame()
    {
        ChangeSceneHandler.changeSceneHandler.ChangeToGameScreen();
    }

    private void DisableAllScreens()
    {
        HostingSettingsScreen.SetActive(false);
        MainScreen.SetActive(false);
        LobbyScreen.SetActive(false);
        MatchesScreen.SetActive(false);
        EnterNameScreen.SetActive(false);
    }
}
