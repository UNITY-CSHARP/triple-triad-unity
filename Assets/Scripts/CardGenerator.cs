using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGenerator : MonoBehaviour {

	[SerializeField] Card card;
	Texture2D[] cardTextures;

	void Start () {
		cardTextures = Resources.LoadAll<Texture2D>("Cards");
		foreach (Texture2D t in cardTextures)
			Debug.Log("Card '" + t.name + "' loaded");
	}

	/*
	 * Generates the specified number of cards in a list.
	 * Return: [List<Card>] List of cards
	 */ 
	public List<Card> generateCards(int numberOfCards) {

		List<Card> generatedCards = new List<Card> ();
		Card cardCopy;

		for (int i = 0; i < numberOfCards; i++) {
			cardCopy = Instantiate (card) as Card;
			cardCopy.GetComponent<Renderer> ().material.mainTexture = cardTextures [i];

			// TODO: name and values should be retrieved from a data base
			cardCopy.setUp (cardTextures [i].name.ToUpper(), cardTextures [i], 8, 6, 9, 2);
			generatedCards.Add (cardCopy);
		}

		return generatedCards;
	} 
	

}
