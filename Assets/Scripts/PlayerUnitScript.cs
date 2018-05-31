using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameManagerScript.instance.AddPlayer(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnDestroy()
    {
        GameManagerScript.instance.RemovePlayer(this.gameObject);
    }
}
