using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject cubePrefab;
	new Vector3 cubePosition;
	public GameObject currentCube;
	public static GameObject activePlane;
	public static GameObject cloud;
	public static int airplaneX, airplaneY;

	// Use this for initialization
	void Start () {

		// starting location of airplane
		airplaneX = 0;
		airplaneY = 8;

		for (int y = 0; y < 9; y++) {
			for (int x = 0; x < 16; x++) {
				cubePosition = new Vector3 (x * 2 - 16, y * 2 - 10, 0);
				currentCube = Instantiate (cubePrefab, cubePosition, Quaternion.identity);

				if (x == airplaneX && y == airplaneY) {
					currentCube.GetComponent<Renderer> ().material.color = Color.red;
					currentCube.GetComponent<CubeBehavior> ().plane = true;
					activePlane = currentCube;
				}

			}
		}

	}

//	If the player clicks the active airplane, it should deactivate.
//	If the player clicks clear sky (a white cube) while there is an active airplane,
//	the airplane should teleport to that location (i.e. the cube that was previously
//	red should now be white, and the clicked cube should now be red).
//	If the player clicks a white cube while there is no active airplane, nothing happens.

	public static void ProcessClick (GameObject currentCube) {

		// deactivate active plane
		if (currentCube == activePlane && currentCube.GetComponent<CubeBehavior>().plane){
			currentCube.GetComponent<Renderer> ().material.color = Color.blue;
			activePlane = null;
		}
		// activate deactivated plane
		else if (currentCube != activePlane && currentCube.GetComponent<CubeBehavior>().plane) {
			currentCube.GetComponent<Renderer> ().material.color = Color.red;
			activePlane = currentCube;
		} 

		// else if we click on a cloud, if a plane is active, the cloud becomes activePlane, and activePlane becomes cloud
		else if (currentCube.GetComponent<CubeBehavior> ().plane == false) {

			if (activePlane != null) {
				activePlane.GetComponent<Renderer> ().material.color = Color.white;
				activePlane.GetComponent<CubeBehavior> ().plane = false;
				activePlane = null;

				currentCube.GetComponent<Renderer> ().material.color = Color.red;
				currentCube.GetComponent<CubeBehavior> ().plane = true;
				activePlane = currentCube;

		}


		}


	}




	// Update is called once per frame
	void Update () {

	}
}


// if currentCube is not a plane (white cube), and player clicks on it, it should turn into a red cube
//if (currentCube == cloud) {
//	currentCube.GetComponent<Renderer> ().material.color = Color.white;
//	currentCube = null;
//} else {
//	currentCube.GetComponent<Renderer> ().material.color = Color.red;
//	activePlane = currentCube;
//}

// if clicked on, deactivate activePlane (red cube) by changing it to a blue cube

//if (currentCube == activePlane) {
//	currentCube.GetComponent<Renderer> ().material.color = Color.blue;
//	currentCube = deactivatedPlane;
//} 
