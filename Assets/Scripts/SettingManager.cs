using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingManager : MonoBehaviour {
    public static SettingManager instance;

    public float difficulty = 1f;
    public float unitHealth = 1f;
    public float unitSpeed = 5.0f;
    public float spawnSpeed = 1f;

    public float playerHealth = 5f;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
        }
        unitHealth = unitHealth * difficulty;
        unitSpeed = unitSpeed * difficulty;
        spawnSpeed = spawnSpeed * difficulty;
    }



}
