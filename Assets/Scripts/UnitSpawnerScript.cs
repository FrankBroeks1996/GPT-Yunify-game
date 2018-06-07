using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UnitSpawnerScript : NetworkBehaviour
{

    NetworkIdentity ni;
    public GameObject enemyPrefab;
    public float difficulty = 1f;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("CmdSpawnEnemy", 1f, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }
    Vector3 FindSpawnLocation()
    {
        Vector3 location;
        if (GameManagerScript.instance.GetTarget() != null)
        {
            location = GameManagerScript.instance.GetTarget().transform.position;
            switch (Random.Range(1, 4))
            {
                case 1:
                    location.x += 10;
                    break;
                case 2:
                    location.z += 10;
                    break;
                case 3:
                    location.x -= 10;
                    break;
                case 4:
                    location.z -= 10;
                    break;
            }
            return location;
        }
        return Vector3.zero;
    }

    [Command]
    void CmdSpawnEnemy()
    {
        if (enemyPrefab != null)
        {
            if (NetworkServer.active)
            {
                Vector3 v3 = FindSpawnLocation();
                GameObject go = Instantiate(enemyPrefab, v3, Quaternion.identity);
                NetworkServer.Spawn(go);
            }
        }
    }
}
