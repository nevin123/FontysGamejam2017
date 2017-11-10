using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityQuoteManager : MonoBehaviour {

	public string[] GoodHeavenQuotes;
	public string[] EvilHeavenQuotes;
	public string[] NeutralQuotes;
	public string[] GoodHellQuotes;
	public string[] EvilHellQuotes;

	private Queue<string> goodHeavenQuotes;
	private Queue<string> evilHeavenQuotes;
	private Queue<string> neutralQuotes;
	private Queue<string> goodHellQuotes;
	private Queue<string> evilHellQuotes;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
		foreach (string quote in GoodHeavenQuotes) goodHeavenQuotes.Enqueue(quote);
		foreach (string quote in EvilHeavenQuotes) evilHeavenQuotes.Enqueue(quote);
		foreach (string quote in NeutralQuotes) neutralQuotes.Enqueue(quote);
		foreach (string quote in GoodHellQuotes) goodHellQuotes.Enqueue(quote);
		foreach (string quote in EvilHellQuotes) evilHellQuotes.Enqueue(quote);
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
			case QuoteType.GoodHeaven:
				return getQuote(ref goodHeavenQuotes);
			case QuoteType.EvilHeaven:
				return getQuote(ref evilHeavenQuotes);
			case QuoteType.Neutral:
				return getQuote(ref neutralQuotes);
			case QuoteType.GoodHell:
				return getQuote(ref goodHellQuotes);
			case QuoteType.EvilHell:
				return getQuote(ref evilHellQuotes);
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
