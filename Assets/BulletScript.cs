using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public float Speed = 10f;
    public float TimeAlive = 2f;
	
	// Update is called once per frame
	void Update () {
        TimeAlive -= Time.deltaTime;
        Debug.Log(TimeAlive);
        if(TimeAlive <= 0)
        {
            Destroy(gameObject);
        }

        gameObject.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
	}
}
