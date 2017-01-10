﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageDecouvertBlocageCube : MonoBehaviour {

	GameObject Player;
	GameObject CubeOnAss;
	GameObject CubeTotem;

	GameObject playerWrong;
	GameObject cam1;
	GameObject cam2;

	public GameObject prefabCube;

	GameObject ScanningPanel; 

	Transform LaunchCube;

	public bool villageAnimLaunched;
	bool EnigmaResolving;
	bool didIInstantiate;

	EndTotemEnigma EndingTotemScript;

	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("Player");
		CubeOnAss = GameObject.Find ("ArtefactOnAss");
		CubeTotem = GameObject.Find ("ActualCubeTotem");

		playerWrong = GameObject.Find ("CrounchingPlayerPuzzleTotem");
		cam1 = GameObject.Find ("Main Camera Main");
		cam2 = GameObject.Find ("CameraEnigmeTotem");

		ScanningPanel = GameObject.Find ("Scanning");

		LaunchCube = GameObject.Find ("InstantiateFromHere").GetComponent<Transform> ();

		CubeTotem.SetActive (false);
		didIInstantiate = false;

		EndingTotemScript = GameObject.Find ("EndGestionTotem").GetComponent<EndTotemEnigma>();
	}
	
	// Update is called once per frame
	void Update () {

		//si je viens d'arriver et que j'ai marcher dans le trigger oula le cube est bloqué il faut que je résolve l'énigme !!
		if (villageAnimLaunched) {
			EnigmaResolving = true;
			CubeTotem.SetActive (true);
			CubeOnAss.SetActive (false);
			Player.GetComponent<DropCube> ().enabled = false;
		}
		if (EnigmaResolving && EndingTotemScript.EnigmaIsDone) {

			Player.SetActive (true);
			playerWrong.SetActive (false);
			cam1.SetActive (true);
			cam2.SetActive (false);

			villageAnimLaunched = false;

			if (!didIInstantiate) {
				Instantiate (prefabCube, LaunchCube.position, LaunchCube.rotation);
				didIInstantiate = true;
				CubeTotem.SetActive (false);
				CubeOnAss.SetActive (false);
//				ScanningPanel.SetActive (true);
				Player.GetComponent<DropCube> ().enabled = true;
				Player.GetComponent<DropCube> ().isCubeOnGround = true;
			}
			EnigmaResolving = false;
		}
	}
}
