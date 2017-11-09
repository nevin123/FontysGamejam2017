using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public GameObject JudgementSpot;
    public GameManager GM;
    private float Judgement;
    private bool locked = false;

	// Use this for initialization
	void Start () {
	}

    public void SetUnlocked()
    {
        this.locked = false;
    }

	// Update is called once per frame
	void Update () {
        if (locked) return;

        Judgement = Input.GetAxis("Judgement");
        
        if(Judgement == 1)
        {
            GM.SendNextEntityTo(JudgementSpot.GetComponentInChildren<Entity>(), Place.Heaven);
            locked = true;
        }
        else if(Judgement == -1)
        {
            GM.SendNextEntityTo(JudgementSpot.GetComponentInChildren<Entity>(), Place.Hell);
            locked = true;
        }
	}
}
