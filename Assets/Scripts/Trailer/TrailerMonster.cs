﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailerMonster : MonoBehaviour {

    // The target marker.
    public Transform target;
    // Angular speed in radians per sec.
    public float speed;

    void Update()
    {
        Vector3 targetDir = target.position - transform.position;
        // The step size is equal to speed times frame time.
        float step = speed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        Debug.DrawRay(transform.position, newDir, Color.red);
        // Move our position a step closer to the target.
        transform.rotation = Quaternion.LookRotation(newDir);
    }
}
