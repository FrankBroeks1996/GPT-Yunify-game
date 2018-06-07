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
        InvokeRepeating("CmdSpawnEnemy", 1, 1f);
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
                    location.x += 30;
                    break;
                case 2:
                    location.z += 30;
                    break;
                case 3:
                    location.x -= 30;
                    break;
                case 4:
                    location.z -= 30;
                    break;
            }
            return location;
        }
        return Vector3.zero;
    }

    public GameObject[] walls;
    public GameObject testcube;
    Vector3 FindSpawnLocation2()
    {
        Vector3 location;
        Renderer r = null;
        if (walls == null || walls.Length < 4)
        {
            return new Vector3();
        }
        switch (Random.Range(1, 5))
        {
            case 1:
                r = walls[0].GetComponent<Renderer>();
                break;
            case 2:
                r = walls[1].GetComponent<Renderer>();
                break;
            case 3:
                r = walls[2].GetComponent<Renderer>();
                break;
            case 4:
                r = walls[3].GetComponent<Renderer>();
                break;
        }


        //r.boundsmin == bottom left
        //r.bounds.max == top right
        if (r != null)
        {
            return location = RandomSpawnLocation(r.bounds.min.x, r.bounds.min.y, r.bounds.max.x, r.bounds.max.y, r.bounds.min.z, r.bounds.max.z);
        }
        location = Vector3.zero;
        return location;
    }

    Vector3 RandomSpawnLocation(float bottomLeftx, float bottomLeftY, float toprightx, float toprighty, float bottomleftz, float toprightz)
    {
        float x = Random.Range(bottomLeftx, toprightx);
        float y = Random.Range(bottomLeftY, toprighty);
        float z = Random.Range(bottomleftz, toprightz);
        Debug.Log(x);
        Debug.Log(y);
        return new Vector3(x, y, z);
    }

    [Command]
    void CmdSpawnEnemy()
    {
        Debug.Log("hi");
        if (enemyPrefab != null)
        {
            Vector3 v3 = FindSpawnLocation2();
            GameObject go = Instantiate(enemyPrefab, v3, Quaternion.identity);
            NetworkServer.Spawn(go);
        }
    }
}
