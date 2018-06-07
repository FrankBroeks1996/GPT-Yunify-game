using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{

    public float Health = 5;
    public UnitType unit;

    void Awake()
    {
        if(unit == UnitType.UNIT_PLAYER)
        {
            this.Health = SettingManager.instance.playerHealth;
        }
        if(unit == UnitType.UNIT_MONSTER_BASIC)
        {
            this.Health = SettingManager.instance.unitHealth;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

public enum UnitType
{
    UNIT_PLAYER,
    UNIT_MONSTER_BASIC
}
