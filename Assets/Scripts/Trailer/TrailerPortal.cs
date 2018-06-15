using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailerPortal : MonoBehaviour {
    public GameObject spawnObject;
    public float rotateSpeed;
    public float scaleSpeed;
    public GameObject targetLooker;
    bool halfWay;


	// Use this for initialization
	void Start () {
        halfWay = false;
        StartCoroutine(ScaleOverTime(scaleSpeed, 100f));
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up * rotateSpeed * 10 * Time.deltaTime);
        if (halfWay)
        {
            StartCoroutine(ScaleOverTime(scaleSpeed, 0f));
        }
	}

    IEnumerator ScaleOverTime(float time, float scale)
    {
        Vector3 originalScale = transform.localScale;
        Vector3 destinationScale = new Vector3(scale, scale, scale);
        float currentTime = 0.0f;

        do
        {
            transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);

        if (!halfWay)
        {
            GameObject monster = Instantiate(spawnObject, GetComponentInChildren<Transform>().position, GetComponentInChildren<Transform>().rotation);
            monster.GetComponent<TrailerMonster>().target = targetLooker.transform;
            monster.transform.LookAt(targetLooker.transform);
            halfWay = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
