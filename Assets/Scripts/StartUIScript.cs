using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUIScript : MonoBehaviour {

    public GameObject MainScreen;
    public GameObject HostingScreen;
    public GameObject MatchesScreen;

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

    public void SwitchToGame()
    {
        ChangeSceneHandler.changeSceneHandler.ChangeToGameScreen();
    }

    private void DisableAllScreens()
    {
        MainScreen.SetActive(false);
        HostingScreen.SetActive(false);
        MatchesScreen.SetActive(false);
    }
}
