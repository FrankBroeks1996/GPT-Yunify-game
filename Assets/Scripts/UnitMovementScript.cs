using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovementScript : MonoBehaviour {

    public GameObject target;
    public float MovementSpeed = 5.0f;
	// Use this for initialization
	void Start () {
        target = GameManagerScript.instance.GetTarget();
        this.MovementSpeed = SettingManager.instance.unitSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, MovementSpeed * Time.deltaTime);
        }
    }
}
