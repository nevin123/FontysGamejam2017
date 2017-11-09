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

	/// <summary>
	/// The bad choice score increase.
	/// </summary>
	public int BadChoiceScoreIncrease;

	/// <summary>
	/// The entity manager.
	/// </summary>
	public EntityManager _EntityManager;

	/// <summary>
	/// The score.
	/// </summary>
	private int score = 0;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {}
	
	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () {}

	/// <summary>
	/// Sends the next entity to the given place.
	/// </summary>
	/// <param name="place">The place to send the entity to.</param>
	public void SendNextEntityTo(Place place) {
		GameObject nextEntity = _EntityManager.GetNextEntity ();

		if (nextEntity) {
			switch (place) {
				case Place.Heaven:
					Debug.Log ("Sending " + nextEntity.GetComponent<Entity>().name + " to heaven...");
					break;
				case Place.Hell:
					Debug.Log ("Sending " + nextEntity.GetComponent<Entity>().name + " to hell...");
					break;
			}
		} else {
			Debug.Log ("No more entities...");
		}
	}
}
