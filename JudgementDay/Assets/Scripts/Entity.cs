using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
	/// The text.
	/// </summary>
	public TextMesh QuoteText;

	private Transform nextPosition;

	private Place CurrentPlace;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start() {}

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update() {}

	public bool Move;

	void FixedUpdate() {
		if (Move == true) {
			this.transform.position = Vector2.Lerp (this.transform.position, nextPosition.transform.position, Time.deltaTime);
		}
	}

	/// <summary>
	/// Sets the quote.
	/// </summary>
	/// <param name="quote">Quote.</param>
	/// <param name="duration">Duration.</param>
	public void SetQuote(string quote, float duration) {
		StartCoroutine(setQuote (quote, duration));
	}

	/// <summary>
	/// Sets the quote.
	/// </summary>
	/// <returns>The quote.</returns>
	/// <param name="quote">Quote.</param>
	/// <param name="duration">Duration.</param>
	private IEnumerator setQuote(string quote, float duration) {
		QuoteText.text = quote;

		yield return new WaitForSeconds(duration);

		QuoteText.text = "";
	}

	/// <summary>
	/// Sets the position.
	/// </summary>
	/// <param name="parent">Parent.</param>
	public void SetPosition(GameObject parent, Place currentPlace)
	{
		this.transform.SetParent(parent.transform);
		nextPosition = parent.transform;
		CurrentPlace = currentPlace;
		if (currentPlace == Place.Purgatory)
		{
			float time = Vector2.Distance(this.transform.position, nextPosition.transform.position) / 0.5f;
			this.transform.DOMove(nextPosition.transform.position, time);
		}
		else if(currentPlace == Place.Heaven)
		{
			float time = Vector2.Distance(this.transform.position, nextPosition.transform.position) / 0.3f;
			this.transform.DOMove(nextPosition.transform.position, time);
		}
		else if(currentPlace == Place.Hell)
		{
			this.transform.DOShakePosition(1,0.01f,10,90).OnComplete(() => {
				Debug.Log("complete");
				float time = Vector2.Distance(this.transform.position, nextPosition.transform.position) / 1.5f;
				this.transform.DOMove(nextPosition.transform.position, time);
			});

		}
		//this.transform.position = parent.transform.position;
	}

	/// <summary>
	/// Returns a <see cref="System.String"/> that represents the current <see cref="Entity"/>.
	/// </summary>
	/// <returns>A <see cref="System.String"/> that represents the current <see cref="Entity"/>.</returns>
	public string ToString() {
		return "Type: " + this.Type + ", Item: " + this.Item + ", is " + (this.isGood ? "good" : "evil");
	}
}
