using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public EntityManager EM;
    public GameObject[] Spots;
    public GameObject JudgementSpot;
    public GameObject Entity;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < 5; i++)
        {
            EM.GetNextEntity().GetComponent<Entity>().SetPosition(Spots[i]);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
