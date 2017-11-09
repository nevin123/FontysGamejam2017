using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public EntityManager EM;
    public GameObject[] Spots;
    public GameObject JudgementSpot;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnPeople()
    {
        for (int i = 0; i < 5; i++)
        {
            Entity nextEntity = EM.GetNextEntity().GetComponent<Entity>();
            if (nextEntity != null)
            {
                nextEntity.SetPosition(Spots[i]);
            }
        }
    }
}
