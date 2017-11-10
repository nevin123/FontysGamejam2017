using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StPeter : MonoBehaviour {

    /// <summary>
    /// The quote text.
    /// </summary>
    public Text textUI;

    public Canvas canvas;

    public Image image;

    public Sprite[] textBalloons;
	/// <summary>
	/// The duration of the quote.
	/// </summary>
	public float QuoteDuration;

	/// <summary>
	/// The go to heaven quotes.
	/// </summary>
	public string[] GoToHeavenQuotes;

	/// <summary>
	/// The go to hell quotes.
	/// </summary>
	public string[] GoToHellQuotes;

	/// <summary>
	/// The go to heaven quotes.
	/// </summary>
	private Queue<string> goToHeavenQuotes = new Queue<string>();

	/// <summary>
	/// The go to hell quotes.
	/// </summary>
	private Queue<string> goToHellQuotes = new Queue<string>();


    /// <summary>
    /// Start this instance.
    /// </summary>
    void Start()
    {
        canvas.enabled = false;
        foreach (string quote in GoToHeavenQuotes) goToHeavenQuotes.Enqueue(quote);
        foreach (string quote in GoToHellQuotes) goToHellQuotes.Enqueue(quote);
    }
	
	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () {}

	/// <summary>
	/// Sets the quote.
	/// </summary>
	/// <param name="quote">Quote.</param>
	public void SetQuote(Place place) {
        string quote = null;

        switch (place)
        {
            case Place.Heaven:
                quote = getQuote(ref goToHeavenQuotes);
                image.sprite = textBalloons[0];
                break;
            case Place.Hell:
                quote = getQuote(ref goToHellQuotes);
                image.sprite = textBalloons[1];
                break;
        }

        if (quote != null)
            StartCoroutine(setQuote(quote, QuoteDuration));
	}

    private string getQuote(ref Queue<string> quotes)
    {
        string quote = quotes.Dequeue();
        quotes.Enqueue(quote);

        return quote;
    }
	
	/// <summary>
	/// Sets the quote.
	/// </summary>
	/// <returns>The quote.</returns>
	/// <param name="quote">Quote.</param>
	/// <param name="duration">Duration.</param>
	private IEnumerator setQuote(string quote, float duration) {
		textUI.text = quote;
        canvas.enabled = true;
		yield return new WaitForSeconds (duration);
        canvas.enabled = false;
		textUI.text = "";
	}
}
