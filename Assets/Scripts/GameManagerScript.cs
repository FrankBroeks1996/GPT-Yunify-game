using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    public static GameManagerScript instance;
    public List<GameObject> PlayerUnits;

    void Awake()
    {
        if (instance == null)
        {
            Debug.Log("creating instance");
            instance = this;
            PlayerUnits = new List<GameObject>();
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddPlayer(GameObject g)
    {
        if (PlayerUnits != null)
        {
            PlayerUnits.Add(g);
            Debug.Log(PlayerUnits.Count);
            Debug.Log("adding player");
        }

    }

    public void RemovePlayer(GameObject g)
    {
        if (PlayerUnits != null)
            PlayerUnits.Remove(g);
    }

    public GameObject GetTarget()
    {

        if (PlayerUnits != null && PlayerUnits.Count > 0)
        {
            Debug.Log(PlayerUnits.Count);
            return PlayerUnits[Random.Range(0, PlayerUnits.Count - 1)];
        }
        else
            return null;
    }
}
