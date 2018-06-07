using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {

    float timer = 5f;


    // Update is called once per frame
    void Update () {
        timer -= Time.deltaTime;
        if(timer < 0f)
        {
            Destroy(this.gameObject);
        }
	}
}
