using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Click_des : MonoBehaviour {

	public string cadena;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void funcion(){

		if(this.transform.root.Find ("Toggle").transform.GetComponent<Toggle>().isOn)
			cadena = this.transform.root.Find ("InputField").GetComponent<Input_des>().error;

		this.transform.root.Find ("Text").transform.GetComponent<Text> ().text = cadena;
	}
}
