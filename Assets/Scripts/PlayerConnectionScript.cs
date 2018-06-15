using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerConnectionScript : NetworkBehaviour {

    public GameObject PlayerPrefab;
	// Use this for initialization
	void Start () {
        if (!isLocalPlayer)
            return;

        Debug.Log("PlayerConnectionObject::Start -- Spawning playerUnit..");
        CmdSpawnPlayerUnit(PlayerPrefs.GetString("playerName"));
	}

    [Command]
    void CmdSpawnPlayerUnit(string playerName)
    {
        if(PlayerPrefab != null)
        {
            GameObject go = Instantiate(PlayerPrefab);
            go.GetComponent<PlayerUnitScript>().PlayerName = playerName;
            NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
        }
    }
}
