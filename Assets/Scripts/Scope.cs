using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour {

	Rect scopeRect;
	Texture scopeTex;

	// Use this for initialization
	void Start () {

		float scopeSize = Screen.width * 0.1f; 

		scopeTex = Resources.Load ("UI/scope") as Texture;

		scopeRect = new Rect (Screen.width / 2 - scopeSize / 2,Screen.height /2 - scopeSize /2 ,scopeSize,scopeSize);
	}

	void OnGUI(){

		GUI.DrawTexture (scopeRect,scopeTex);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
