﻿using UnityEngine;
using UnityEngine.Networking.Match;
using UnityEngine.UI;

public class JoinButton : MonoBehaviour
{
    private Text buttonText;
    private MatchInfoSnapshot match;

    private void Awake()
    {
        buttonText = GetComponentInChildren<Text>();
    }

    public void Initialize(MatchInfoSnapshot match, Transform panelTransform)
    {
        this.match = match;
        buttonText.text = match.name;
        transform.SetParent(panelTransform);
        transform.localScale = Vector3.one;
        transform.localRotation = Quaternion.identity;
        transform.localPosition = Vector3.zero;
    }

    public void JoinMatch()
    {
        FindObjectOfType<CustomNetworkManager>().JoinMatch(match);
        StartUIScript.instance.SwitchToLobbyScreen();
    }
}