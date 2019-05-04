using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants;

public class GameCursor : MonoBehaviour {

	[SerializeField] private AudioSource audioSource;
	[SerializeField] private AudioClip[] audioclips;

	private SpriteRenderer spriteComponent;
	private static readonly int MOVE_SOUND = 0;
	private static readonly int OK_SOUND = 1;
	private static readonly int FAIL_SOUND = 2;

	void Awake() {
		spriteComponent = this.GetComponent<SpriteRenderer> ();
		spriteComponent.enabled = false;
	}

	public void setCursorInCard(Card card) {
		this.transform.SetParent(card.getGridSpace().transform, false);
		this.transform.localPosition = new Vector3 (CURSOR.SPACE_X, this.transform.localPosition.y, this.transform.localPosition.z);
	}

	public void setCursorInSlot(GridSpace slot) {
		this.transform.localPosition = new Vector3 (0, 0, this.transform.localPosition.z);
		this.transform.SetParent(slot.transform, false);
		//this.transform.localPosition = new Vector3 (CURSOR.SPACE_X, this.transform.localPosition.y, this.transform.localPosition.z);
	}

	public void moveCursor(Card card) {
		setCursorInCard(card);
		playMoveSound ();
	}

	public void showCursor(bool enable) {
		spriteComponent.enabled = enable;
	}

	public void playMoveSound() {
		audioSource.clip = audioclips [MOVE_SOUND];
		audioSource.Play ();
	}

	public void playOkSound() {
		audioSource.clip = audioclips [OK_SOUND];
		audioSource.Play ();
	}

	public void playFailSound() {
		audioSource.clip = audioclips [FAIL_SOUND];
		audioSource.Play ();
	}
		
}
