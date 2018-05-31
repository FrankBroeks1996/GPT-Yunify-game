using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public int Damage = 1;
    public float Speed = 10f;
    public float TimeAlive = 2f;
	
	// Update is called once per frame
	void Update () {
        TimeAlive -= Time.deltaTime;
        if(TimeAlive <= 0)
        {
            Destroy(gameObject);
        }

        gameObject.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
	}

    void OnCollisionEnter(Collision objectHit)
    {
        Debug.Log("HIT!");
        if (objectHit.gameObject.tag == "Enemy")
        {
            objectHit.gameObject.GetComponent<EnemyScript>().Health -= Damage;
            Destroy(gameObject);
        }
    }
}
