using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

    static GameManagerScript instance;

    public static GameManagerScript Instance()
    {
        if(instance == null)
        {
            instance = new GameManagerScript();
        }
        return instance;
    }

    public List<GameObject> PlayerUnits;

	// Use this for initialization
	void Start () {
        PlayerUnits = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddPlayer(GameObject g)
    {
        if (PlayerUnits != null)
            PlayerUnits.Add(g);
    }

    public void RemovePlayer(GameObject g)
    {
        if (PlayerUnits != null)
            PlayerUnits.Remove(g);
    }

    public GameObject GetTarget()
    {
        if (PlayerUnits != null)
            return PlayerUnits[Random.Range(0, PlayerUnits.Count - 1)];
        else
            return null;
    }
}
