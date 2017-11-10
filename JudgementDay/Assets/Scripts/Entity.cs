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
	/// The text.
	/// </summary>
	public TextMesh QuoteText;

    private Transform nextPosition;

    private bool Move;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start() {}

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update() {}

    void FixedUpdate() {
        if (Move == true) {
            this.transform.position = Vector2.Lerp(this.transform.position, nextPosition.transform.position, Time.deltaTime);
        }
    }

	/// <summary>
	/// Sets the quote.
	/// </summary>
	/// <param name="quote">Quote.</param>
	/// <param name="duration">Duration.</param>
	public void SetQuote(string quote, float duration) {
		setQuote (quote, duration);
	}

	/// <summary>
	/// Sets the quote.
	/// </summary>
	/// <returns>The quote.</returns>
	/// <param name="quote">Quote.</param>
	/// <param name="duration">Duration.</param>
	private IEnumerable setQuote(string quote, float duration) {
		QuoteText.text = quote;

		yield return new WaitForSeconds(duration);

		QuoteText.text = "";
	}

	/// <summary>
	/// Sets the position.
	/// </summary>
	/// <param name="parent">Parent.</param>
    public void SetPosition(GameObject parent) {
        Move = true;
        this.transform.SetParent(parent.transform);
        nextPosition = parent.transform;
    }

    /// <summary>
    /// Returns a <see cref="System.String"/> that represents the current <see cref="Entity"/>.
    /// </summary>
    /// <returns>A <see cref="System.String"/> that represents the current <see cref="Entity"/>.</returns>
    public string ToString() {
		return "Type: " + this.Type + ", Item: " + this.Item + ", is " + (this.isGood ? "good" : "evil");
	}
}
