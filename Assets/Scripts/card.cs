using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {

	[SerializeField] private Sprite image;

	private string cardName;
	private Texture cardTexture;
	private int topValue, rightValue, bottomValue, leftValue; 
	private GridSpace gridSpace;


	public string getCardName() {
		return cardName;
	}

	public void setGridSpace(GridSpace gridSpace) {
		this.gridSpace = gridSpace;
	}

	public GridSpace getGridSpace() {
		return gridSpace;
	}

	/*
	 * settings before the game starts (AKA constructor)
	 */
	void Awake() {
		this.gameObject.SetActive (false);
	}

	/**
	 * Sets the Card properties up
	 * arg: [string name] name of the card
	 * 		[int topValue] top value of the card
	 * 		[int rightValue] right value of the card
	 * 		[int bottomValue] bottom value of the card
	 * 		[int leftValue] left value of the card
	 */ 
	public void setUp(string cardName, Texture cardTexture, int topValue, int rightValue, int bottomValue, int leftValue) {
		this.cardName = cardName;
		this.cardTexture = cardTexture;
		setTexture ();
		this.topValue = topValue;
		this.rightValue = rightValue;
		this.bottomValue = bottomValue;
		this.leftValue = leftValue;
		Debug.Log ("Card '" + cardName + "' created");
	}

	private void setTexture() {
		this.GetComponent<Renderer> ().material.mainTexture = cardTexture;
	}

	/*
	 * Activates or deactivates a list of cards
	 * arg: [List<Card> cards] set of cards
	 * 		[bool Active] true or false value for activate/deactivate
	 */
	public static void setActiveCards(List<Card> cards, bool active) {
		for (int i = 0; i < cards.Count; i++) {
			cards [i].gameObject.SetActive (active);
		}
	}

}
