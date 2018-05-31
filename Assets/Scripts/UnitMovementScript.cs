using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovementScript : MonoBehaviour {

    public GameObject target;
    public float MovementSpeed = 5.0f;
	// Use this for initialization
	void Start () {
        target = GameManagerScript.Instance().GetTarget();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards(transform.position,target.transform.position , MovementSpeed * Time.deltaTime);
    }
}
