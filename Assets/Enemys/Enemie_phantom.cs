using UnityEngine;
using System.Collections;

public class Enemie_phantom : MonoBehaviour {

	public float mov_x = 2f;
	public float mov_z = 3f;
	
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
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
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
		
		rand_giro = Random.Range (0, 8);
		rand_direccion = Random.Range (0, 4);
		
		espera += Time.deltaTime;

		if(espera > 0 && espera < 0.9f)
			this.GetComponent<Renderer> ().material.color = new Color(this.GetComponent<Renderer>().material.color.r,
			                                                          this.GetComponent<Renderer>().material.color.g,
			                                                          this.GetComponent<Renderer>().material.color.b,0.3f);

		if (espera > 3.1f) {
			espera = 0;
			this.GetComponent<Renderer> ().material.color = new Color(this.GetComponent<Renderer>().material.color.r,
			                                                            this.GetComponent<Renderer>().material.color.g,
			                                                            this.GetComponent<Renderer>().material.color.b,0.3f);
			this.transform.GetComponent<BoxCollider>().enabled = false;
		}

		if (espera > 0.9f && espera < 3.1f) {
			this.GetComponent<Renderer> ().material.color= new Color(this.GetComponent<Renderer>().material.color.r,
			                                                         this.GetComponent<Renderer>().material.color.g,
			                                                         this.GetComponent<Renderer>().material.color.b,1f);
			this.transform.GetComponent<BoxCollider> ().enabled = true;
		}
		
		if (espera > 3) {
			if (rand_direccion == 0){
				activo_x_der = true;
				activo_x_izq = false;
				activ_z_arriba = false;
				activ_z_abajo = false;
			}
			else if (rand_direccion == 1){
				activo_x_izq = true;
				activo_x_der = false;
				activ_z_arriba = false;
				activ_z_abajo = false;
			}
			else if (rand_direccion == 2){
				activ_z_arriba = true;
				activo_x_der = false;
				activo_x_izq = false;
				activ_z_abajo = false;
			}
			else if (rand_direccion == 3){
				activ_z_abajo = true;
				activo_x_der = false;
				activo_x_izq = false;
				activ_z_arriba = false;
			}
			
		}
		
		
	}
	
	void OnTriggerEnter(Collider node){
		if (node.tag == "Weapon") {
			this.GetComponent<Rigidbody>().AddForce(-node.transform.forward *1000);
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
