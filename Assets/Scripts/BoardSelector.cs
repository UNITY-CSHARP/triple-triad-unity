using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSelector : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void initSelector(Card card, GameCursor cursor, Board board, SelectorController selectorController) {
		cursor.showCursor(true);
		cursor.setCursorInSlot (findFirstEmptyGrid (board));

		//if (Input.GetKeyDown (KeyCode.Escape))
			//selectorController.IsCardSelector = true;
			
	}

	public GridSpace findFirstEmptyGrid (Board board) {
		for(int i = 0; i < board.getBoardLength(); i++) {
			for (int j = 0; j < board.getBoardLength(); j++) {
				if (board.getGridSpace (i, j).isEmpty())
					return board.getGridSpace (i, j);
			}
		}

		return null;
	}


}
