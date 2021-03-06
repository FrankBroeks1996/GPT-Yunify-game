﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.UI;

public class CustomNetworkManager : NetworkManager {
    
    public GameObject MatchListPnl;

    private float timer = 5f;

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            if (MatchListPnl != null)
                RefreshMatches();
        }
    }

    public void StartMatchHosting(Text matchName)
    {
        StartMatchMaker();
        matchMaker.CreateMatch(matchName.text, 2, true, "", "", "", 0, 0, OnMatchCreated);
    }

    private void OnMatchCreated(bool success, string extendedInfo, MatchInfo responseData)
    {
        if (success == true)
        {
            base.StartHost(responseData);
            RefreshMatches();
        }
    }

    private void RefreshMatches()
    {
        if (matchMaker == null)
            StartMatchMaker();

        matchMaker.ListMatches(0, 10, "", true, 0, 0, HandleListMatchesComplete);

        timer = 5f;
    }

    private void HandleListMatchesComplete(bool success, string extendedinfo, List<MatchInfoSnapshot> responsedata)
    { 
        MatchListPnl.GetComponent<FillMatchListScript>().AvailableMatchesList_OnAvailableMatchesChanged(responsedata);
    }

    public void JoinMatch(MatchInfoSnapshot match)
    {
        if (matchMaker == null)
            StartMatchMaker();
        
        matchMaker.JoinMatch(match.networkId, "", "", "", 0, 0, HandleJoinedMatch);
    }

    private void HandleJoinedMatch(bool success, string extendedinfo, MatchInfo responsedata)
    {
        if (success)
        {
            StartClient(responsedata);
        }
    }
}
