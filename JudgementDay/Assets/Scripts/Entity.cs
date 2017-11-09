using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Entity.
/// </summary>
public class Entity : MonoBehaviour {

	/// <summary>
	/// The EntityType of the biker.
	/// </summary>
	public EntityType Type;

	/// <summary>
	/// The Item the entity is holding.
	/// </summary>
	public ItemType Item;

	/// <summary>
	/// Boolean indicating if the entity is good or evil.
	/// </summary>
	public bool isGood;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start() {}

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update() {}

	/// <summary>
	/// Returns a <see cref="System.String"/> that represents the current <see cref="Entity"/>.
	/// </summary>
	/// <returns>A <see cref="System.String"/> that represents the current <see cref="Entity"/>.</returns>
	public string ToString() {
		return "Type: " + this.Type + ", Item: " + this.Item + ", is " + (this.isGood ? "good" : "evil");
	}
}
