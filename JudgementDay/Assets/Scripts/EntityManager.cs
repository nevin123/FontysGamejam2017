using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour {

	public List<Entity> AvailableEntities = new List<Entity>();

	public Transform EntityContainer;

	private Queue<Entity> entities = new Queue<Entity> (new Entity[] { });

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 10; i++) {
			Entity entity = Instantiate (AvailableEntities [0]);
			entity.Item = ItemType.Knife;
			entity.Type = EntityType.Biker;
			entity.transform.SetParent (this.EntityContainer.transform);

			this.entities.Enqueue(entity);
		}
	}

	// Update is called once per frame
	void Update () {
	}
}
