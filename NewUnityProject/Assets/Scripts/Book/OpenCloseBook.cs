﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ThirdPersonCamera
{
public class OpenCloseBook : MonoBehaviour {

	public GameObject canvas;
	public bool isBookOpen;
	//public GameObject buttonOuvrirBook;

		GameObject canvasMainCamera;

		public GameObject mainCamera;
		public GameObject SecondCamera;

		DropCube DC;

	public FreeForm FF;

	public GameObject player;

	// Use this for initialization
	void Start () {
		canvas.SetActive (false);
			canvasMainCamera = GameObject.Find ("Canvas Book Notification MainCamera");
			mainCamera.SetActive (true);
			SecondCamera.SetActive (false);

			DC = GameObject.Find ("Player").GetComponent<DropCube> ();
	}
	
	// Update is called once per frame
	void Update () {
			if (Input.GetButtonDown ("OpenBook") && !isBookOpen && DC.isCubeOnGround == false) {
			canvas.SetActive (true);
			mainCamera.SetActive (false);
			SecondCamera.SetActive (true);
			canvasMainCamera.SetActive (false);
			//buttonOuvrirBook.SetActive (false);
			isBookOpen = true;
			player.gameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter> ().enabled = false;
			player.gameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl> ().enabled = false;
			player.gameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl> ().v = 0;
			player.gameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl> ().h = 0;

				//FF.lockMouseCursor = false;
		} else 
			if (Input.GetButtonDown ("OpenBook") && isBookOpen) {
				//buttonOuvrirBook.SetActive (true);
				mainCamera.SetActive (true);
				SecondCamera.SetActive (false);
				canvasMainCamera.SetActive (true);
				canvas.SetActive (false);
				isBookOpen = false;
				player.gameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter> ().enabled = true;
				player.gameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl> ().enabled = true;

				//FF.lockMouseCursor = true;
		}
	}
	}
}
