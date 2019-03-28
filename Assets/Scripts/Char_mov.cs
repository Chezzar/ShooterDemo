using UnityEngine;
using System.Collections;

public class Char_mov : MonoBehaviour {

	//private CharacterController controler;

	public delegate void reduccion_vida ();
	public static event reduccion_vida reduce;

	public float mov_x = 2f;
	public float mov_z = 3f;

	public Camera camara;
	public float axis_x, axis_y;

	bool activo_x_der;
	bool activo_x_izq;
	bool activ_z_arriba;
	bool activ_z_abajo;

	public bool dead = false;

	Vector3 derecha = new Vector3(0,90,0);
	Vector3 izquierda = new Vector3(0,-90,0);
	Vector3 arriba = new Vector3(0,0,0);
	Vector3 abajo = new Vector3(0,180,0);

	public bool grounded = true;
	public GameObject ground;
	// Use this for initialization
	void Start () {

		Cursor.visible = false;
	
	}
	
	// Update is called once per frame
	void Update () {


		if (!dead) {
			axis_x = Input.GetAxis ("Mouse X");
			axis_y = Input.GetAxis ("Mouse Y");
		}

		funcionalidad_2 ();

		if (Input.GetKeyDown ("space") && grounded && !dead)
			jump ();
	
	}

	void jump(){

		this.transform.GetComponent<Rigidbody> ().AddForce(new Vector3(0,300,0));
		grounded = false;
	}

	void funcionalidad_2(){

		this.transform.Rotate (new Vector3(0,axis_x * 3,0));
		camara.transform.Rotate (new Vector3 (-axis_y, 0 ,0)); 


		if (Input.GetKey ("d") && !dead) {
			this.transform.Translate (new Vector3(0.1f, 0, 0));
		}


		if (Input.GetKey ("a") && !dead) {
			this.transform.Translate (new Vector3 (-0.1f, 0, 0));
		}


		if (Input.GetKey ("w") && !dead) {
			this.transform.Translate (new Vector3 (0, 0, 0.1f));
		}


		if (Input.GetKey ("s") && !dead) {
			this.transform.Translate (new Vector3 (0, 0,-0.1f));
		}
	}


	void funcionalidad_1(){

		if (reduce != null)
			reduce ();

		if (activo_x_der) {
			this.transform.position = new Vector3 (this.transform.position.x + Time.deltaTime * mov_x, this.transform.position.y, this.transform.position.z);
			this.transform.rotation = Quaternion.Euler(derecha);
		}

		if (activo_x_izq) {
			this.transform.position = new Vector3 (this.transform.position.x - Time.deltaTime * mov_x, this.transform.position.y, this.transform.position.z);
			this.transform.rotation = Quaternion.Euler(izquierda);
		}

		if (activ_z_arriba) {
			this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z + Time.deltaTime * mov_z);
			this.transform.rotation = Quaternion.Euler(arriba);
		}

		if (activ_z_abajo) {
			this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z - Time.deltaTime * mov_z);
			this.transform.rotation = Quaternion.Euler(abajo);
		}



		if (Input.GetKey ("right")) {
			activo_x_der = true;
			activo_x_izq = false;
			activ_z_arriba = false;
			activ_z_abajo = false;
		}


		if (Input.GetKey ("left")) {
			activo_x_der = false;
			activo_x_izq = true;
			activ_z_arriba = false;
			activ_z_abajo = false;
		}


		if (Input.GetKey ("up")) {
			activo_x_der = false;
			activo_x_izq = false;
			activ_z_arriba = true;
			activ_z_abajo = false;
		}


		if (Input.GetKey ("down")) {
			activo_x_der = false;
			activo_x_izq = false;
			activ_z_arriba = false;
			activ_z_abajo = true;
		}

	}

	void OnTriggerEnter(Collider node){

		if (node.tag == "Enemy") {
			//this.GetComponent<Rigidbody>().AddForce(this.transform.forward * 600);
		}
			
	}

	void OnTriggerStay(Collider node){

		if (node.tag == "Floor")
			grounded = true;
	}
}
