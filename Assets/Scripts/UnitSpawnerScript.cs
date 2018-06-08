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
    public float maxCoinSpawnDistance = 10f;
    public float minCoinSpawnDistance = 2f;
    private Direction dir;
    
    void Start()
    {
        InvokeRepeating("CmdSpawnEnemy", 1, SettingManager.instance.spawnSpeed);
        InvokeRepeating("CmdSpawnCoin", 1, 1f);
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

    /// <summary>
    /// Method used to find a location within 4 variable walls available in the walls array list.
    /// the location is determined depending on the renderer bounds of the wall and the min and max coinspawndistance variables.
    /// </summary>
    /// <returns></returns>
    Vector3 FindCoinSpawnLocation()
    {
        Vector3 location;
        Renderer r = GetWall();
        if(r != null)
        {
            if(dir == Direction.NORTH)
            {
                return location = RandomSpawnLocation(r.bounds.min.x, r.bounds.min.y, r.bounds.max.x, r.bounds.min.y, r.bounds.min.z - minCoinSpawnDistance, r.bounds.min.z - maxCoinSpawnDistance);
            }
            if(dir == Direction.SOUTH)
            {
                return location = RandomSpawnLocation(r.bounds.min.x, r.bounds.min.y, r.bounds.max.x, r.bounds.min.y, r.bounds.min.z + minCoinSpawnDistance, r.bounds.min.z + maxCoinSpawnDistance);
            }
            if(dir == Direction.WEST)
            {
                return location = RandomSpawnLocation(r.bounds.min.x + minCoinSpawnDistance, r.bounds.min.y, r.bounds.min.x + maxCoinSpawnDistance, r.bounds.min.y, r.bounds.min.z, r.bounds.max.z);
            }
            if(dir == Direction.EAST)
            {
                return location = RandomSpawnLocation(r.bounds.min.x - minCoinSpawnDistance, r.bounds.min.y, r.bounds.max.x - maxCoinSpawnDistance, r.bounds.min.y, r.bounds.min.z, r.bounds.max.z);
            }
            return Vector3.zero;
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
                dir = walls[0].GetComponent<DirectionScript>().direction;
                return walls[0].GetComponent<Renderer>();
            case 2:
                dir = walls[1].GetComponent<DirectionScript>().direction;
                return walls[1].GetComponent<Renderer>();
            case 3:
                dir = walls[2].GetComponent<DirectionScript>().direction;
                return walls[2].GetComponent<Renderer>();
            case 4:
                dir = walls[3].GetComponent<DirectionScript>().direction;
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
            Vector3 v3 = FindCoinSpawnLocation();
            v3.y = 2.5f;
            GameObject go = Instantiate(coinPrefab, v3, Quaternion.Euler(90, 0, 0));
            NetworkServer.Spawn(go);
        }
    }
}
public enum Direction
{
    NORTH,
    SOUTH,
    WEST,
    EAST
}
