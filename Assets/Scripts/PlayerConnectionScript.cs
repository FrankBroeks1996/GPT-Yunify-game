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
        CmdSpawnPlayerUnit();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    [Command]
    void CmdSpawnPlayerUnit()
    {
        if(PlayerPrefab != null)
        {
            GameObject go = Instantiate(PlayerPrefab);
            NetworkServer.Spawn(go);
        }
    }
}
