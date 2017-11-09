using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {


    public GameObject[] Spots;
    public GameObject Entity;

	// Use this for initialization
	void Start () {
		foreach(GameObject s in Spots)
        {
            Instantiate(Entity, s.transform);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
