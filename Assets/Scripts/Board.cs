using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants;

public class Board : MonoBehaviour {

	[SerializeField] private Card card;
	[SerializeField] private GridSpace space;
	[SerializeField] private Canvas canvas;

	private static int boardLength = BOARD.LENGTH;
	private static int gridSpaceWidth = BOARD.GRID_SPACE_X;
	private static int gridSpaceHeight = BOARD.GRID_SPACE_Y;
	private GridSpace[,] gridSpaces = new GridSpace[boardLength,boardLength];


	/**
	 * Sets the Board properties up
	 */
	public void setUp() {
		createBoardSpaces (boardLength);
		Debug.Log ("Board " + boardLength + "x" + boardLength + " created");
	}

	public GridSpace getGridSpace(int x, int y) {
		return gridSpaces [x,y];
	}

	public GridSpace[,] getGridSpaces() {
		return gridSpaces;
	}

	public int getBoardLength() {
		return boardLength;
	}

	/**
	 * Put a card in a given position of the board
	 * arg: [Card card] card to put in the board
	 * 		[int x] position in the Y axis
	 * 		[int y] position in the X axis
	 */
	public void putCardInPosition(Card card, int x, int y) {
		card.transform.SetParent(gridSpaces[x,y].transform, false);
	}

	/**
	 * TODO: refactor with the method above so it takes a Gameobject
	 */
	public void putCursorInPosition(GameCursor cursor, int x, int y) {
		cursor.transform.SetParent(gridSpaces[x,y].transform, false);
	}

	/**
	 * Put a set of cards into the board in order
	 * arg: [Card[] cards] array of cards
	 */
	public void putCardsInOrder(Card[] cards) {
		for (int i = 0, cardCount = 0; i < boardLength; i++) {
			for (int j = 0; j < boardLength; j++) {
				if (cardCount < cards.Length) {
					putCardInPosition (cards [cardCount], i, j);
					cardCount++;
				}
			}
		}
	}

	/**
	 * Put a set of cards into the board in order
	 * arg: [List<Card> cards] list of cards
	 */
	public void putCardsInOrder(List<Card> cards) {
		for (int i = 0, cardCount = 0; i < boardLength; i++) {
			for (int j = 0; j < boardLength; j++) {
				if (cardCount < cards.Count) {
					putCardInPosition (cards [cardCount], i, j);
					cardCount++;
				}
			}
		}
	}

	/**
	 * Create the spaces for putting the cards into the board
	 * arg: [int boardLength] dimensions of the board (boardLength x boardLength)
	 */
	private void createBoardSpaces(int boardLength) {

		for (int i = 0, width = -gridSpaceWidth, height = gridSpaceHeight; 
			i < boardLength; 
			i++, width = -gridSpaceWidth, height -= gridSpaceHeight) {

			for (int j = 0;
				j < boardLength;
				j++, width += gridSpaceWidth) {

				GridSpace spaceCopy = Instantiate (space) as GridSpace;
				spaceCopy.transform.position = new Vector3 (width, height, spaceCopy.transform.position.z);
				spaceCopy.transform.SetParent(canvas.transform, false);
				spaceCopy.X = i;
				spaceCopy.Y = j;
				gridSpaces [i, j] = spaceCopy;
			}
		}
	}
}
