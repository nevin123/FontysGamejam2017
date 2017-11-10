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

    void FixedUpdate()
    {
    }


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
            this.transform.DOMove(nextPosition.transform.position, time).OnComplete(() => { MoveInHeavenOrHell(); });
        }
        else if(currentPlace == Place.Hell)
        {
            this.transform.DOShakePosition(1,0.01f,10,90).OnComplete(() => {
                Debug.Log("complete");
                float time = Vector2.Distance(this.transform.position, nextPosition.transform.position) / 1.5f;
                this.transform.DOMove(nextPosition.transform.position, time).OnComplete(() => { MoveInHeavenOrHell(); });
            });
            
        }
        //this.transform.position = parent.transform.position;
    }

    public void MoveInHeavenOrHell()
    {
        Vector2 nextLocation = new Vector2(Random.Range(-1.17f, 0.69f), 0);
        this.GetComponent<SpriteRenderer>().flipX = !(nextLocation.x > this.transform.position.x);
        float time = 0f;
        if (isGood && CurrentPlace == Place.Heaven){
            time = Vector2.Distance(new Vector2(this.transform.position.x, 0), nextLocation) / 0.2f;
        }else if(isGood && CurrentPlace == Place.Hell){
            time = Vector2.Distance(new Vector2(this.transform.position.x, 0), nextLocation) / 0.5f;
        }else if(!isGood && CurrentPlace == Place.Heaven){
            time = Vector2.Distance(new Vector2(this.transform.position.x, 0), nextLocation) / 0.2f;
        }
        else if(!isGood && CurrentPlace == Place.Hell){
            time = Vector2.Distance(new Vector2(this.transform.position.x, 0), nextLocation) / 0.2f;
        }
        this.transform.DOMoveX(nextLocation.x, time).SetEase(Ease.Linear).OnComplete(() => { MoveInHeavenOrHell(); });
    }

    /// <summary>
    /// Returns a <see cref="System.String"/> that represents the current <see cref="Entity"/>.
    /// </summary>
    /// <returns>A <see cref="System.String"/> that represents the current <see cref="Entity"/>.</returns>
    public string ToString() {
		return "Type: " + this.Type + ", Item: " + this.Item + ", is " + (this.isGood ? "good" : "evil");
	}
}
