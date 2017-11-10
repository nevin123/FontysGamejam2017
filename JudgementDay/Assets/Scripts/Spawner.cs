using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public EntityManager EM;
    public GameObject[] Spots;
    public GameObject JudgementSpot;

    private bool wait = false;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnPeople()
    {
        StartCoroutine("WaitBeforeWalking");
    }

    IEnumerator WaitBeforeWalking()
    {
        for (int i = 0; i < 5; i++)
        {
			GameObject nextEntityGameObject = EM.GetNextEntity ();

			if (nextEntityGameObject == null) continue;
			
			Entity nextEntity = nextEntityGameObject.GetComponent<Entity>();
            EM.EntityList.Add(nextEntity);
            if (nextEntity != null)
            {
                if (!wait)
                {
                    nextEntity.SetPosition(Spots[i], Place.Purgatory);
                    yield return new WaitForSeconds(0.5f);
                }
            }
        }
        StopCoroutine("WaitBeforeWalking");
    }
}
