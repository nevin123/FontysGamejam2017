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

    public EntityQuoteManager EMQ;

    /// <summary>
    /// The entity container.
    /// </summary>
    public Transform EntityContainer;

	/// <summary>
	/// The entities.
	/// </summary>
	private Queue<GameObject> entities = new Queue<GameObject> (new GameObject[] { });

    public List<Entity> EntityList = new List<Entity>();

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
        EMQ = GetComponent<EntityQuoteManager>();
		for (int i = 0; i < 10; i++) {
			GameObject entity = (GameObject)Instantiate (AvailableEntities [Random.Range(0, this.AvailableEntities.Length)], EntityContainer);
            entity.transform.name = entity.transform.name.Split ('(') [0];
			this.entities.Enqueue(entity);
		}

        Invoke("somebodySpeak", 3);
	}

    private void somebodySpeak()
    {
        Entity speakingEntity = EntityList[Random.Range(0, EntityList.Count)];
      
        if(speakingEntity.CurrentPlace == Place.Heaven && speakingEntity.isGood)
        {
            speakingEntity.BalloonImage.sprite = speakingEntity.Balloons[0];
            speakingEntity.Speak(EMQ.GetQuote(QuoteType.GoodHeaven));
        }else if (speakingEntity.CurrentPlace == Place.Heaven && !speakingEntity.isGood)
        {
            speakingEntity.BalloonImage.sprite = speakingEntity.Balloons[1];
            speakingEntity.Speak(EMQ.GetQuote(QuoteType.EvilHeaven));
        }
        else if (speakingEntity.CurrentPlace == Place.Hell && speakingEntity.isGood)
        {
            speakingEntity.BalloonImage.sprite = speakingEntity.Balloons[1];
            speakingEntity.Speak(EMQ.GetQuote(QuoteType.GoodHell));
        }
        else if (speakingEntity.CurrentPlace == Place.Hell && !speakingEntity.isGood)
        {
            speakingEntity.BalloonImage.sprite = speakingEntity.Balloons[0];
            speakingEntity.Speak(EMQ.GetQuote(QuoteType.EvilHell));
        }
        else if (speakingEntity.CurrentPlace == Place.Purgatory)
        {
            speakingEntity.BalloonImage.sprite = speakingEntity.Balloons[0];
            speakingEntity.Speak(EMQ.GetQuote(QuoteType.Neutral));
        }

            Invoke("somebodySpeak", Random.Range(5, 10));
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
