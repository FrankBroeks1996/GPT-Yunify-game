﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CamGyroScript : NetworkBehaviour {

    GameObject camParent;
    // Use this for initialization
    void Start()
    {
        camParent = new GameObject("CamParent");
        camParent.transform.position = this.transform.position;
        camParent.transform.parent = this.transform.parent;
        this.transform.parent = camParent.transform;
        
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponentInParent<PlayerUnitScript>().)
            return;
        camParent.transform.Rotate(0, -Input.gyro.rotationRateUnbiased.y, 0);
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