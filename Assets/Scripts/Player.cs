using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants;

public class Player : MonoBehaviour {

	[SerializeField] private GridSpace space;
	[SerializeField] private Canvas canvas;

	private string name;
	private List<Card> hand;
	private static int handLength = PLAYER.HAND_LENGTH;
	private static int handSpaceX = PLAYER.HAND_SPACE_X;
	private static int handSpaceY = PLAYER.HAND_SPACE_Y;
	private static int handSpaceOffsetY = PLAYER.HAND_SPACE_OFFSET_Y;
	private GridSpace[] handSpaces = new GridSpace[handLength];

	public List<Card> getHand() {
		return hand;
	}

	/**
	 * Sets the Player properties up
	 * arg: [String name] name of the player
	 */
	public void setUp(string name, List<Card> cards){
		this.name = name;
		this.hand = cards;
		createHandSpaces (handLength);
		Debug.Log ("Player '" + name + "' created");
	}

	/**
	 * Insert a collection of cards inside the hand of the player
	 * arg: [List<Card> cards] list of cards
	 */
	public void dealCards(List<Card> cards) {
		for (int i = 0; i < cards.Count; i++) {
			cards[i].transform.SetParent(handSpaces[i].transform, false);
			cards [i].setGridSpace (handSpaces [i]);
		}
	}

	/**
	 * Reorganize available cards in the hand into the spaces so there is no empty spaces
	 */
	public void reorganizeHand() {
		dealCards (hand);
	}

	/**
	 * Create the spaces for putting the cards into the hand
	 * arg: [int handLength] size of the hand
	 */
	private void createHandSpaces(int handLength) { 

		for (int i = 0; i < handLength; i++, handSpaceY -= handSpaceOffsetY) {
			GridSpace spaceCopy = Instantiate (space) as GridSpace;
			spaceCopy.transform.position = new Vector3 (handSpaceX, handSpaceY, -i-1);
			spaceCopy.transform.SetParent(canvas.transform, false);
			handSpaces [i] = spaceCopy;
		}
	}

}
