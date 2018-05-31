using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public int Health = 5;
	
	// Update is called once per frame
	void Update () {
		if(Health <= 0)
        {
            Destroy(gameObject);
        }
	}
}
