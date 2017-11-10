using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Game manager.
/// </summary>
public class GameManager : MonoBehaviour {

	/// <summary>
	/// The good choice score increase.
	/// </summary>
	public int GoodChoiceScoreIncrease;

    public InputManager IM;
    /// <summary>
    /// This has the spots for the entities
    /// </summary>
    public Spawner spawner;

    public GameObject HeavenSpot;

    public GameObject HellSpot;

    /// <summary>
    /// Manages the entities
    /// </summary>
    public EntityManager EM;

	/// <summary>
	/// The bad choice score increase.
	/// </summary>
	public int BadChoiceScoreIncrease;

	/// <summary>
	/// The score.
	/// </summary>
	private int score = 0;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
        spawner.SpawnPeople();
        StartCoroutine("WaitForMove");
    }
	
	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () {}

    /// <summary>
    /// Update the positions of the enitity on the spots
    /// </summary>
    public void UpdatePositions()
    {
        StartCoroutine("WaitBeforeWalking");
    }

    public void SendToJudgement()
    {
        Entity JudgementPlace = spawner.Spots[0].GetComponentInChildren<Entity>();
        if (JudgementPlace != null)
        {
            JudgementPlace.SetPosition(spawner.JudgementSpot, Place.Purgatory);
        }
        StartCoroutine("WaitForUpdate");
    }

	/// <summary>
	/// Sends the next entity to the given place.
	/// </summary>
	/// <param name="place">The place to send the entity to.</param>
	public void SendNextEntityTo(Entity nextEntity, Place place) {
		if (nextEntity) {
			switch (place) {
				case Place.Heaven:
                    nextEntity.SetPosition(HeavenSpot, Place.Heaven);
					break;
				case Place.Hell:
                    nextEntity.SetPosition(HellSpot, Place.Hell);
					break;
			}
            StartCoroutine("WaitForMove");
		} else {
			Debug.Log ("No more entities...");
		}
	}

    IEnumerator WaitForMove()
    {
        yield return new WaitForSeconds(3f);
        SendToJudgement();
        StopCoroutine("WaitForMove");
    }

    IEnumerator WaitForUpdate()
    {
        yield return new WaitForSeconds(1f);
        UpdatePositions();
        IM.SetUnlocked();
        StopCoroutine("WaitForUpdate");
    }

    IEnumerator WaitBeforeWalking()
    {
        for (int i = 0; i < 4; i++)
        {
            Entity EntityAtSpot = spawner.Spots[i + 1].GetComponentInChildren<Entity>();
            if (EntityAtSpot != null)
            {
                EntityAtSpot.SetPosition(spawner.Spots[i].gameObject, Place.Purgatory);
                yield return new WaitForSeconds(0.5f);
            }
        }
        GameObject NextEntity = EM.GetNextEntity();
        if (NextEntity != null)
        {
            NextEntity.GetComponent<Entity>().SetPosition(spawner.Spots[4], Place.Purgatory);
        }
        StopCoroutine("WaitBeforeWalking");
    }
}
