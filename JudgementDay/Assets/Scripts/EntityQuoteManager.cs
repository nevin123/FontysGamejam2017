using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityQuoteManager : MonoBehaviour {

	public string[] HappyQuotes;
	public string[] NeutralQuotes;
	public string[] SadQuotes;

	private Queue<string> happyQuotes;

	private Queue<string> neutralQuotes;

	private Queue<string> sadQuotes;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
		foreach (string quote in HappyQuotes) happyQuotes.Enqueue(quote);
		foreach (string quote in NeutralQuotes) neutralQuotes.Enqueue(quote);
		foreach (string quote in SadQuotes) sadQuotes.Enqueue(quote);
	}
	
	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () {}

	/// <summary>
	/// Gets the quote.
	/// </summary>
	/// <returns>The quote.</returns>
	/// <param name="quoteType">Quote type.</param>
	public string GetQuote(QuoteType quoteType) {
		switch (quoteType) {
			case QuoteType.Happy:
				return getQuote(ref happyQuotes);
			case QuoteType.Neutral:
				return getQuote(ref neutralQuotes);
			case QuoteType.Sad:
				return getQuote(ref sadQuotes);
		}

		return null;
	}

	/// <summary>
	/// Gets the quote from a queue reference.
	/// </summary>
	/// <returns>The quote.</returns>
	/// <param name="queue">Queue.</param>
	private string getQuote(ref Queue<string> queue) {
		string quote = queue.Dequeue();
		queue.Enqueue (quote);
		return quote;
	}
}
