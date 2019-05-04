using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	[SerializeField] private Board board;
	[SerializeField] private Player player;
	[SerializeField] private CardGenerator cardGenerator;
	[SerializeField] private SelectorController selectorController;


	void Start () {

		// Create cards
		//List<Card> boardCards = new List<Card> ();
		//boardCards = cardGenerator.generateCards (2);
		List<Card> handCards = new List<Card> ();
		handCards = cardGenerator.generateCards (5);

		// Set board
		board.setUp ();
		//board.putCardsInOrder (boardCards);
		//Card.setActiveCards (boardCards, true);

		// Set player
		player.setUp ("PLAYER 1", handCards);
		player.dealCards (handCards);
		Card.setActiveCards (handCards, true);

		// Set current player turn
		selectorController.CurrentPlayer = player;
		selectorController.gameObject.SetActive (true);
	}

}
