using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UnitSpawnerScript : NetworkBehaviour
{

    NetworkIdentity ni;
    public GameObject enemyPrefab;
    public GameObject coinPrefab;
    public GameObject[] walls;
    
    void Start()
    {
        //InvokeRepeating("CmdSpawnEnemy", 1, SettingManager.instance.spawnSpeed);
        InvokeRepeating("CmdSpawnCoin", 1, 0.1f);
    }


    public GameObject testcube;
    Vector3 FindSpawnLocation2()
    {
        Vector3 location;
        Renderer r = GetWall();
        if (r != null)
        {
            return location = RandomSpawnLocation(r.bounds.min.x, r.bounds.min.y, r.bounds.max.x, r.bounds.max.y, r.bounds.min.z, r.bounds.max.z);
        }
        location = Vector3.zero;
        return location;
    }

    Vector3 FindCoinSpawnLocation()
    {
        Vector3 location;
        Renderer r = GetWall();
        if(r != null)
        {
            return location = RandomSpawnLocation(r.bounds.min.x, r.bounds.min.y, r.bounds.max.x, r.bounds.min.y, r.bounds.min.z + 5, r.bounds.min.z + 5);
        }
        else
        {
            return Vector3.zero;
        }
    }

    Renderer GetWall()
    {
        if(walls == null || walls.Length < 4)
        {
            return null;
        }
        switch (Random.Range(1, 5))
        {
            case 1:
                return walls[0].GetComponent<Renderer>();
            case 2:
                return walls[1].GetComponent<Renderer>();
            case 3:
                return walls[2].GetComponent<Renderer>();
            case 4:
                return walls[3].GetComponent<Renderer>();
        }
        return null;

    }


    Vector3 RandomSpawnLocation(float bottomLeftx, float bottomLeftY, float toprightx, float toprighty, float bottomleftz, float toprightz)
    {
        float x = Random.Range(bottomLeftx, toprightx);
        float y = Random.Range(bottomLeftY, toprighty);
        float z = Random.Range(bottomleftz, toprightz);
        return new Vector3(x, y, z);
    }



    [Command]
    void CmdSpawnEnemy()
    {
        if (enemyPrefab != null)
        {
            Vector3 v3 = FindSpawnLocation2();
            GameObject go = Instantiate(enemyPrefab, v3, Quaternion.identity);
            NetworkServer.Spawn(go);
        }
    }

    [Command]
    void CmdSpawnCoin()
    {
        if(coinPrefab != null)
        {
            GameObject go = Instantiate(coinPrefab, FindCoinSpawnLocation(), Quaternion.identity);
            NetworkServer.Spawn(go);
        }
    }
}
