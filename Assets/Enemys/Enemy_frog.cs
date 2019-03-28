using UnityEngine;
using System.Collections;

public class Enemy_frog : MonoBehaviour {

	public GameObject char_;

	public int rand_direccion;

	public float tiempo = 0;
	public float limite = 0;

	Vector3 derecha = new Vector3(0,90,0);
	Vector3 izquierda = new Vector3(0,-90,0);
	Vector3 arriba = new Vector3(0,0,0);
	Vector3 abajo = new Vector3(0,180,0);

	// Use this for initialization
	void Start () {

		char_ = GameObject.FindGameObjectWithTag ("Player");
	
	}
	
	// Update is called once per frame
	void Update () {

		//this.transform.rotation = Quaternion.identity;

		transform.LookAt (char_.transform.position);
		int velovidad = Random.Range (4,8);
		transform.Translate (Vector3.forward * Time.deltaTime * velovidad);

		rand_direccion = Random.Range (0, 4);

		if ((tiempo = Espera (limite, tiempo)) == 0) {

			if (rand_direccion == 0){
				this.transform.GetComponent<Rigidbody>().AddForce(100,300,0);
				this.transform.rotation = Quaternion.Euler (derecha);
			}
			else if (rand_direccion == 1){
				this.transform.GetComponent<Rigidbody>().AddForce(-100,300,0);
				this.transform.rotation = Quaternion.Euler (izquierda);
			}
			else if (rand_direccion == 2){
				this.transform.GetComponent<Rigidbody>().AddForce(0,300,100);
				this.transform.rotation = Quaternion.Euler (arriba);
			}
			else if (rand_direccion == 3){
				this.transform.GetComponent<Rigidbody>().AddForce(0,300,-100);
				this.transform.rotation = Quaternion.Euler (abajo);
			}
		}
	
	}

	float Espera(float limit,float tiem){
		
		tiem += Time.deltaTime;
		
		if (tiem > limit)
			return 0;
		else
			return tiem;
	}

	void OnTriggerEnter(Collider node){
		if (node.tag == "Weapon") {
			//this.GetComponent<Rigidbody>().AddForce (-node.transform.forward * 1000);
			this.GetComponent<Rigidbody>().AddForce(this.transform.forward *100);
		}
	}
}
