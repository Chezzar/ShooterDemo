using UnityEngine;
using System.Collections;

public class Enemie_Zombie : MonoBehaviour {

	public GameObject char_;
	public Vector3 distance_char;
	public float distance;

	public float mov_x = 2f;
	public float mov_z = 3f;

	public int estado = 0;
	
	public bool activo_x_der;
	public bool activo_x_izq;
	public bool activ_z_arriba;
	public bool activ_z_abajo;

	bool unavez = true;

	public int rand_giro;
	public int rand_direccion;

	public float espera;
	
	Vector3 derecha = new Vector3(0,90,0);
	Vector3 izquierda = new Vector3(0,-90,0);
	Vector3 arriba = new Vector3(0,0,0);
	Vector3 abajo = new Vector3(0,180,0);

	// Use this for initialization
	void Start () {

		char_ = GameObject.FindGameObjectWithTag ("Player");

		Char_mov.reduce += reduce_vida;

		StartCoroutine (follow_char());
	
	}
	
	// Update is called once per frame
	void Update () {



		if (estado == 0) {
			if (activo_x_der) {
				this.transform.position = new Vector3 (this.transform.position.x + Time.deltaTime * mov_x, this.transform.position.y, this.transform.position.z);
				this.transform.rotation = Quaternion.Euler (derecha);
			}
		
			if (activo_x_izq) {
				this.transform.position = new Vector3 (this.transform.position.x - Time.deltaTime * mov_x, this.transform.position.y, this.transform.position.z);
				this.transform.rotation = Quaternion.Euler (izquierda);
			}
		
			if (activ_z_arriba) {
				this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z + Time.deltaTime * mov_z);
				this.transform.rotation = Quaternion.Euler (arriba);
			}
		
			if (activ_z_abajo) {
				this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z - Time.deltaTime * mov_z);
				this.transform.rotation = Quaternion.Euler (abajo);
			}
		

			rand_giro = Random.Range (0, 8);
			rand_direccion = Random.Range (0, 4);

			espera += Time.deltaTime;

			if (espera > 3.1f)
				espera = 0;

			if (espera > 3) {
				if (rand_direccion == 0) {
					activo_x_der = true;
					activo_x_izq = false;
					activ_z_arriba = false;
					activ_z_abajo = false;
				} else if (rand_direccion == 1) {
					activo_x_izq = true;
					activo_x_der = false;
					activ_z_arriba = false;
					activ_z_abajo = false;
				} else if (rand_direccion == 2) {
					activ_z_arriba = true;
					activo_x_der = false;
					activo_x_izq = false;
					activ_z_abajo = false;
				} else if (rand_direccion == 3) {
					activ_z_abajo = true;
					activo_x_der = false;
					activo_x_izq = false;
					activ_z_arriba = false;
				}

			}
		} 

		if (estado == 1) {

			transform.LookAt (char_.transform.position);
			int velovidad = Random.Range (4,8);
			transform.Translate (Vector3.forward * Time.deltaTime * velovidad);
		}

		if (distance < 20)
			estado = 1;

		else if (distance >= 20)
			estado = 0;



		//if (distance_char.magnitude >= 5) {
		//	estado = 0;
		//}

		distance_char = char_.transform.position - this.transform.position;

		distance = distance_char.magnitude;
	
	}

	IEnumerator follow_char (){



		yield return null;
	}

	public void reduce_vida(){

	}

	void OnTriggerEnter(Collider node){
		if (node.tag == "Weapon") {
				this.GetComponent<Rigidbody>().AddForce(node.transform.forward * 200);
		}

		if (node.tag == "Barda") {
			if(activo_x_der){
				activo_x_izq = true;
				activo_x_der = false;
				activ_z_arriba = false;
				activ_z_abajo = false;
			}

			if(activo_x_izq){
				activo_x_der = true;
				activo_x_izq = false;
				activ_z_arriba = false;
				activ_z_abajo = false;
			}

			if(activ_z_abajo){
				activ_z_arriba = true;
				activo_x_der = false;
				activo_x_izq = false;
				activ_z_abajo = false;
			}

			if(activ_z_arriba){
				activ_z_abajo = true;
				activo_x_der = false;
				activo_x_izq = false;
				activ_z_arriba = false;
			}
		}
	}


}
