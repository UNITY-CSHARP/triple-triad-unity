using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpace : MonoBehaviour {

	public int X {get; set;}
	public int Y {get; set;}

	public bool isEmpty() {
		
		if (this.transform.childCount > 0) {
			return false;
		} 

		else {
			return true;
		}
	}

	public bool containsCard() {

		if (this.transform.childCount > 1) {
			return true;
		} 

		else {
			return false;
		} 
	}

}
