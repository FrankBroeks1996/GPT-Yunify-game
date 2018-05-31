using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public int Damage = 1;

    void OnCollisionEnter(Collision objectHit)
    {
        Debug.Log("triggered");
        if(objectHit.gameObject.tag == "Player")
        {
            objectHit.transform.parent.GetComponent<HealthScript>().Health -= Damage;
            Destroy(gameObject);
        }
    }
}
