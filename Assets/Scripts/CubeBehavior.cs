using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehavior : MonoBehaviour {
	public GameObject cubePrefab;
	public bool plane;


	void OnMouseDown() {
		GameController.ProcessClick (gameObject);
	}

}