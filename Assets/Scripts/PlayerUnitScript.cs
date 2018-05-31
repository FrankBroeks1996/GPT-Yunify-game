using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameManagerScript.Instance().AddPlayer(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnDestroy()
    {
        GameManagerScript.Instance().RemovePlayer(this.gameObject);
    }
}
