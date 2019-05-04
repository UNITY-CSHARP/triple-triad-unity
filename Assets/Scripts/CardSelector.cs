using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants;
using UnityEngine.UI;

public class CardSelector : MonoBehaviour {

	private int auxPointedCardIndex;
	private int selectedCardIndex;
	private bool moveArrowPressed;

	public int pointAtCard(GameCursor cursor, List<Card> currentPlayerHand, int pointedCardIndex) {

		if (currentPlayerHand.Count > 1) {
			
			if (Input.GetKeyDown (KeyCode.DownArrow)) {
				moveArrowPressed = true;
				auxPointedCardIndex = pointedCardIndex;
				pointedCardIndex = (pointedCardIndex + 1) % currentPlayerHand.Count;

				currentPlayerHand [pointedCardIndex].transform.localPosition = new Vector3 (currentPlayerHand [pointedCardIndex].transform.localPosition.x - PLAYER.HAND_SPACE_OFFSET_X, currentPlayerHand [pointedCardIndex].transform.localPosition.y);
				currentPlayerHand [auxPointedCardIndex].transform.localPosition = new Vector3 (0, 0);

			} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
				moveArrowPressed = true;
				auxPointedCardIndex = pointedCardIndex;

				if (pointedCardIndex > 0) {
					pointedCardIndex = (pointedCardIndex - 1) % currentPlayerHand.Count;
				} else {
					pointedCardIndex = currentPlayerHand.Count - 1;
				}
				
				currentPlayerHand [pointedCardIndex].transform.localPosition = new Vector3 (currentPlayerHand [pointedCardIndex].transform.localPosition.x - PLAYER.HAND_SPACE_OFFSET_X, currentPlayerHand [pointedCardIndex].transform.localPosition.y);
				currentPlayerHand [auxPointedCardIndex].transform.localPosition = new Vector3 (0, 0);
			} 

			if (moveArrowPressed) {
				cursor.moveCursor (currentPlayerHand [pointedCardIndex]);
				moveArrowPressed = false;
			}
		}

		return pointedCardIndex;
	}

	public int selectCard(Player CurrentPlayer, GameCursor cursor, List<Card> currentPlayerHand, int pointedCardIndex, Board board) {

		if (Input.GetKeyDown (KeyCode.Return)) {
			cursor.playOkSound ();
			return pointedCardIndex;
		}

		return -1;
	}

	private void resetCursorPosition(Player CurrentPlayer, GameCursor cursor, List<Card> currentPlayerHand) {
		int firstCardIndex = 0;
		CurrentPlayer.reorganizeHand ();
		cursor.setCursorInCard (currentPlayerHand [firstCardIndex]);
		currentPlayerHand [firstCardIndex].transform.localPosition = new Vector3 (currentPlayerHand [firstCardIndex].transform.localPosition.x - PLAYER.HAND_SPACE_OFFSET_X, currentPlayerHand [firstCardIndex].transform.localPosition.y);
	}


}
