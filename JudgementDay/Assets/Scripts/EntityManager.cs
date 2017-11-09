using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Entity manager.
/// </summary>
public class EntityManager : MonoBehaviour {

	/// <summary>
	/// The available entities.
	/// </summary>
	public GameObject[] AvailableEntities;

	/// <summary>
	/// The entity container.
	/// </summary>
	public Transform EntityContainer;

	/// <summary>
	/// The entities.
	/// </summary>
	private Queue<GameObject> entities = new Queue<GameObject> (new GameObject[] { });

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
		for (int i = 0; i < 10; i++) {
			GameObject entity = (GameObject)Instantiate (AvailableEntities [Random.Range(0, this.AvailableEntities.Length)], EntityContainer);
            entity.transform.name = entity.transform.name.Split ('(') [0];

			this.entities.Enqueue(entity);
		}
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () {}

	/// <summary>
	/// Gets the next entity.
	/// </summary>
	/// <returns>The next entity.</returns>
	public GameObject GetNextEntity() {
		if (this.entities.Count > 0) {
			return this.entities.Dequeue ();
		}

		return null;
	}
}
