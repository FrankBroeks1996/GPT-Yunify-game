using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUIScript : MonoBehaviour {

    public GameObject MainScreen;
    public GameObject HostingScreen;
    public GameObject MatchesScreen;
    public GameObject SettingsScreen;

    public Slider DifficultySlider;

	public void SwitchToHostingScreen()
    {
        DisableAllScreens();
        HostingScreen.SetActive(true);
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

    public void SwitchToSettingsScreen()
    {
        DisableAllScreens();
        SettingsScreen.SetActive(true);
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
        SettingsScreen.SetActive(false);
        MainScreen.SetActive(false);
        HostingScreen.SetActive(false);
        MatchesScreen.SetActive(false);
    }
}
