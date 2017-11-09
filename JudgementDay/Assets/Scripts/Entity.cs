using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {

	public EntityType Type;

	public ItemType Item;

	void Start() {}

	void Update() {}

	public string ToString() {
		return this.Type + ", " + this.Item;
	}
}
