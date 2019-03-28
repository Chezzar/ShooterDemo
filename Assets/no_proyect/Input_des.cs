using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Input_des : MonoBehaviour {


	public string error = "error";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		error_1();
	
	}

	void error_1(){
		error = this.transform.Find ("Text").transform.GetComponent<Text> ().text.ToString ();;
		/*if(int.Parse(error) <= 0)
			Debug.Log("error");*/
	}

	void error_2(){
		this.transform.Find ("Text").transform.GetComponent<Text> ().text = error;
	}
}
