using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerUnitScript : NetworkBehaviour {

    [SyncVar]
    public string PlayerName;
    
	// Use this for initialization
	void Start () {
        GameManagerScript.instance.AddPlayer(this.gameObject);
	}

    void OnDestroy()
    {
        GameManagerScript.instance.RemovePlayer(this.gameObject);
    }
}
