using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillLobbyListScript : MonoBehaviour {

    public GameObject PlayerTextPrefab;
    

    private void Update()
    {
        FillLobbyList();
    }

    public void FillLobbyList()
    {
        ClearExistingButtons();
        CreateNewPlayerNamePanels();
    }

    private void ClearExistingButtons()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void CreateNewPlayerNamePanels()
    {
        foreach (GameObject playerUnit in GameManagerScript.instance.PlayerUnits)
        {
            GameObject playerNameText = Instantiate(PlayerTextPrefab);
            playerNameText.GetComponentInChildren<Text>().text = playerUnit.GetComponent<PlayerUnitScript>().PlayerName;
            playerNameText.transform.SetParent(transform);
            playerNameText.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
