using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUIScript : MonoBehaviour {

    public GameObject EnterNameScreen;
    public GameObject MainScreen;
    public GameObject HostingSettingsScreen;
    public GameObject MatchesScreen;
    public GameObject LobbyScreen;

    public Slider DifficultySlider;

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
        HostingSettingsScreen.SetActive(true);
    }

    public void SaveSettings()
    {
        SettingManager.instance.difficulty = DifficultySlider.value;
        DisableAllScreens();
        SwitchToHostingScreen();
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
