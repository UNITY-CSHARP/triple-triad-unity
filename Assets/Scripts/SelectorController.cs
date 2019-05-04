using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Constants;
using UnityEditor;

public class SelectorController : MonoBehaviour {

	[SerializeField] private CardSelector cardSelector;
	[SerializeField] private BoardSelector boardSelector;
	[SerializeField] private Board board;
	[SerializeField] private GameCursor cursor;
	[SerializeField] private Canvas canvas;
	[SerializeField] private Image uiImage;
	[SerializeField] private Text text;

	private int pointedCardIndex = 0;
	private int selectedCardIndex;
	public Player CurrentPlayer { get; set; } 
	private List<Card> currentPlayerHand;
	private GameCursor boardCursor;
	public bool isCardSelector;
	public bool isBoardSelector;
	private GridSpace currentSlot;
	private bool failed;

	void Awake() {
		this.gameObject.SetActive (false);
	}

	void Start () {
		isCardSelector = true;
		isBoardSelector = false;
		failed = false;
		currentPlayerHand = CurrentPlayer.getHand ();
		currentPlayerHand [pointedCardIndex].transform.localPosition = new Vector3 (currentPlayerHand [pointedCardIndex].transform.localPosition.x - PLAYER.HAND_SPACE_OFFSET_X, currentPlayerHand [pointedCardIndex].transform.localPosition.y);
		cursor.setCursorInCard (currentPlayerHand [pointedCardIndex]);
		cursor.showCursor (true);
	}

	void Update () {

		//Cambiar estos IF por un switch (intentarlo vaya)

		if (currentPlayerHand.Count > 0 && isCardSelector) {

			text.text = currentPlayerHand [pointedCardIndex].getCardName();
			uiImage.gameObject.SetActive (true);

			pointedCardIndex = cardSelector.pointAtCard (cursor, currentPlayerHand, pointedCardIndex);

			selectedCardIndex = cardSelector.selectCard (CurrentPlayer, cursor, currentPlayerHand, pointedCardIndex, board);

			if (selectedCardIndex != -1) {
				isCardSelector = false;
				isBoardSelector = true;
				boardCursor = Instantiate (cursor) as GameCursor;
				currentSlot = findFirstEmptyGrid (board);
				boardCursor.setCursorInSlot (currentSlot);
				boardCursor.showCursor(true);
				changeCursorAlfa (cursor, 0.5f);
				uiImage.gameObject.SetActive (false);
			}
		}

		else if (currentPlayerHand.Count > 0 && isBoardSelector) {

			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				if (currentSlot.X - 1 >= 0) {
					board.putCursorInPosition (boardCursor, currentSlot.X - 1, currentSlot.Y);
					currentSlot = board.getGridSpace (currentSlot.X - 1, currentSlot.Y);
					boardCursor.playMoveSound ();
				}
			}

			if (Input.GetKeyDown (KeyCode.DownArrow)) {
				if (currentSlot.X + 1 < board.getBoardLength()) {
					board.putCursorInPosition (boardCursor, currentSlot.X+1, currentSlot.Y);
					currentSlot = board.getGridSpace (currentSlot.X + 1, currentSlot.Y);
					boardCursor.playMoveSound ();
				}
			}

			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				if (currentSlot.Y + 1 < board.getBoardLength()) {
					board.putCursorInPosition (boardCursor, currentSlot.X, currentSlot.Y+1);
					currentSlot = board.getGridSpace (currentSlot.X, currentSlot.Y + 1);
					boardCursor.playMoveSound ();
				}
			}

			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				if (currentSlot.Y - 1 >= 0) {
					board.putCursorInPosition (boardCursor, currentSlot.X, currentSlot.Y-1);
					currentSlot = board.getGridSpace (currentSlot.X, currentSlot.Y - 1);
					boardCursor.playMoveSound ();
				}
			}

			if (Input.GetKeyDown (KeyCode.Return)) {

				if (!board.getGridSpace (currentSlot.X, currentSlot.Y).containsCard()) {
					currentPlayerHand [selectedCardIndex].transform.localPosition = new Vector3 (0, 0);

					board.putCardInPosition (currentPlayerHand [selectedCardIndex], currentSlot.X, currentSlot.Y);
					currentPlayerHand.RemoveAt (selectedCardIndex);
					cursor.playOkSound ();

					Destroy (boardCursor.gameObject);
					changeCursorAlfa (cursor, 1f);

					if(currentPlayerHand.Count > 0)
						resetCursorPosition (CurrentPlayer, cursor, currentPlayerHand);

					failed = false;

					isBoardSelector = false;

					if(currentPlayerHand.Count > 0)
						isCardSelector = true;

					pointedCardIndex = 0;
					selectedCardIndex = -1;
				} 

				else {
					cursor.playFailSound ();
					failed = true;
				}
			}
		}

		else if (!isCardSelector && !isBoardSelector) {
			cursor.showCursor (false);
			uiImage.gameObject.SetActive (false);
		}
	}


	private void changeCursorAlfa(GameCursor cursor, float alfa) {
		Color temp = cursor.GetComponent<SpriteRenderer>().color;
		temp.a = alfa;
		cursor.GetComponent<SpriteRenderer>().color = temp;
	}

	private GridSpace findFirstEmptyGrid (Board board) {
		for(int i = 0; i < board.getBoardLength(); i++) {
			for (int j = 0; j < board.getBoardLength(); j++) {
				if (board.getGridSpace (i, j).isEmpty()) 
					return board.getGridSpace (i, j);
			}
		}

		return null;
	}

	private void resetCursorPosition(Player CurrentPlayer, GameCursor cursor, List<Card> currentPlayerHand) {
		int firstCardIndex = 0;
		CurrentPlayer.reorganizeHand ();
		cursor.setCursorInCard (currentPlayerHand [firstCardIndex]);
		currentPlayerHand [firstCardIndex].transform.localPosition = new Vector3 (currentPlayerHand [firstCardIndex].transform.localPosition.x - PLAYER.HAND_SPACE_OFFSET_X, currentPlayerHand [firstCardIndex].transform.localPosition.y);
	}
}
