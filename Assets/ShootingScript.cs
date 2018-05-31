using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ShootingScript : NetworkBehaviour {

    public GameObject Camera;
    public GameObject BulletPrefab;
	
	// Update is called once per frame
	void Update () {
		if((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetKeyDown(KeyCode.Space) && GetComponent<NetworkIdentity>().hasAuthority)
        {
            Vector3 pos = Camera.transform.position;
            Quaternion rot = Camera.transform.rotation;
            CmdSpawnBullet(pos, rot);
        }
	}

    [Command]
    void CmdSpawnBullet(Vector3 position, Quaternion rotation)
    {
        if (BulletPrefab != null)
        {
            GameObject bullet = Instantiate(BulletPrefab);
            bullet.transform.position = position;
            bullet.transform.rotation = rotation;
            NetworkServer.Spawn(bullet);
        }
    }
}
