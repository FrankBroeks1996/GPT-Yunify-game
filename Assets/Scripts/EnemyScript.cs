using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public int Damage = 1;
    public int Score = 1;

    void OnCollisionEnter(Collision objectHit)
    {
        if(objectHit.transform.tag == "Player")
        {
            objectHit.transform.parent.parent.GetComponent<PlayerStatsScript>().Health -= Damage;
            Destroy(gameObject);
        }
    }
}
