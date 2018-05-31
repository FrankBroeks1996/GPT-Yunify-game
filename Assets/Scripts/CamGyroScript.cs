using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CamGyroScript : NetworkBehaviour {

    public GameObject Camera;

    // Use this for initialization
    void Start()
    {   
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.GetComponent<NetworkIdentity>().hasAuthority)
        {
            Camera.SetActive(false);
            return;
        }

        Camera.SetActive(true);

        transform.Rotate(0, -Input.gyro.rotationRateUnbiased.y, 0);
        this.transform.Rotate(-Input.gyro.rotationRateUnbiased.x, 0, 0);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Rotate(Vector3.down);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Rotate(Vector3.up);
        }
    }
}
