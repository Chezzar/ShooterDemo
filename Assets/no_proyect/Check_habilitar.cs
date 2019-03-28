using UnityEngine;
using System.Collections;

public class Check_habilitar : MonoBehaviour {

	public bool habilitar = true;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void habil(){

		habilitar = !habilitar;
	}
}
