using UnityEngine;
using System.Collections;

public class Enemie_fly : MonoBehaviour {

	public GameObject char_;
	
	public float mov_x = 2f;
	public float mov_z = 3f;
	public float velocidad = 0.2f;
	
	public bool activo_x_der;
	public bool activo_x_izq;
	public bool activ_z_arriba;
	public bool activ_z_abajo;

	public float nuevo_x;
	public float nuevo_y;
	public float referencia_estatica;
	public float referencia_estatica_y;
	public float resta;
	
	bool unavez = true;
	public bool unavez_atack = true;
	public bool atack = false;
	
	public int rand_giro;
	public int rand_direccion;
	
	public float espera;
	public float tiempo_subida_bajada;
	
	Vector3 derecha = new Vector3(0,-90,0);
	Vector3 izquierda = new Vector3(0,90,0);
	Vector3 arriba = new Vector3(0,-180,0);
	Vector3 abajo = new Vector3(0,0,0);
	
	// Use this for initialization
	void Start () {

		nuevo_x = this.transform.position.x;
		nuevo_y = this.transform.position.y;
		referencia_estatica = nuevo_x;
		referencia_estatica_y = nuevo_y;
		resta = (nuevo_x * nuevo_x) - nuevo_y;

		nuevo_x = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
		//derecha - abajo
		//StartCoroutine(Prueba ());

		//izquierda - arriba
		/*
		if (nuevo_x < 4)
			nuevo_x += Time.deltaTime;
		else 
			nuevo_x = -4;
			this.transform.position = new Vector3 (this.transform.position.x,nuevo_y,nuevo_x);
			*/



		if (!atack) {
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
		}

		if (atack) {
			StartCoroutine( Prueba());
		}
		else
			StopCoroutine( Prueba());


		rand_giro = Random.Range (0,8);
		rand_direccion = Random.Range (0,4);
		
		espera += Time.deltaTime;
		
		if (espera > 3.1f)
			espera = 0;


		if (espera > 3 && !atack) {
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

	IEnumerator Prueba(){

		tiempo_subida_bajada += Time.deltaTime;


		if (activo_x_izq) {

			atack = true;

			if (tiempo_subida_bajada < 3) {

				this.transform.position = new Vector3 (this.transform.position.x - Mathf.Cos ((45 * Mathf.PI) / 180) * Time.deltaTime * velocidad,
			                                      this.transform.position.y - Mathf.Sin ((45 * Mathf.PI) / 180) * Time.deltaTime * velocidad,
			                                      this.transform.position.z
				);
				//nuevo_y = (nuevo_x * nuevo_x) + 2 * nuevo_x + 2 ;
			} else if (tiempo_subida_bajada > 3 && tiempo_subida_bajada < 4) {
				this.transform.position = new Vector3 (this.transform.position.x - Mathf.Cos ((45 * Mathf.PI) / 180) * Time.deltaTime * velocidad,
			                                       this.transform.position.y,
			                                       this.transform.position.z
				);
			} else if (tiempo_subida_bajada > 4 && tiempo_subida_bajada < 7) {
				this.transform.position = new Vector3 (this.transform.position.x - Mathf.Cos ((45 * Mathf.PI) / 180) * Time.deltaTime * velocidad,
			                                       this.transform.position.y + Mathf.Sin ((45 * Mathf.PI) / 180) * Time.deltaTime * velocidad,
			                                       this.transform.position.z
				);
			} else if (tiempo_subida_bajada >= 7){
				tiempo_subida_bajada = 0;
				this.transform.position = this.transform.position;
				atack = false;
			}

		}else if (activo_x_der) {

			atack = true;

			if (tiempo_subida_bajada < 3) {
				
				this.transform.position = new Vector3 (this.transform.position.x + Mathf.Cos ((45 * Mathf.PI) / 180) * Time.deltaTime * velocidad,
				                                       this.transform.position.y - Mathf.Sin ((45 * Mathf.PI) / 180) * Time.deltaTime * velocidad,
				                                       this.transform.position.z
				                                       );
				//nuevo_y = (nuevo_x * nuevo_x) + 2 * nuevo_x + 2 ;
			} else if (tiempo_subida_bajada > 3 && tiempo_subida_bajada < 4) {
				this.transform.position = new Vector3 (this.transform.position.x + Mathf.Cos ((45 * Mathf.PI) / 180) * Time.deltaTime * velocidad,
				                                       this.transform.position.y,
				                                       this.transform.position.z
				                                       );
			} else if (tiempo_subida_bajada > 4 && tiempo_subida_bajada < 7) {
				this.transform.position = new Vector3 (this.transform.position.x + Mathf.Cos ((45 * Mathf.PI) / 180) * Time.deltaTime * velocidad,
				                                       this.transform.position.y + Mathf.Sin ((45 * Mathf.PI) / 180) * Time.deltaTime * velocidad,
				                                       this.transform.position.z
				                                       );
			} else if (tiempo_subida_bajada >= 7){
				tiempo_subida_bajada = 0;
				this.transform.position = this.transform.position;
				atack = false;
			}
		}else if (activ_z_abajo) {
			
			atack = true;
			
			if (tiempo_subida_bajada < 3) {
				
				this.transform.position = new Vector3 (this.transform.position.x,
				                                       this.transform.position.y - Mathf.Sin ((45 * Mathf.PI) / 180) * Time.deltaTime * velocidad,
				                                       this.transform.position.z - Mathf.Cos ((45 * Mathf.PI) / 180) * Time.deltaTime * velocidad
				                                       );
				//nuevo_y = (nuevo_x * nuevo_x) + 2 * nuevo_x + 2 ;
			} else if (tiempo_subida_bajada > 3 && tiempo_subida_bajada < 4) {
				this.transform.position = new Vector3 (this.transform.position.x,
				                                       this.transform.position.y,
				                                       this.transform.position.z - Mathf.Cos ((45 * Mathf.PI) / 180) * Time.deltaTime * velocidad
				                                       );
			} else if (tiempo_subida_bajada > 4 && tiempo_subida_bajada < 7) {
				this.transform.position = new Vector3 (this.transform.position.x,
				                                       this.transform.position.y + Mathf.Sin ((45 * Mathf.PI) / 180) * Time.deltaTime * velocidad,
				                                       this.transform.position.z - Mathf.Cos ((45 * Mathf.PI) / 180) * Time.deltaTime * velocidad
				                                       );
			} else if (tiempo_subida_bajada >= 7){
				tiempo_subida_bajada = 0;
				this.transform.position = this.transform.position;
				atack = false;
			}
			
		}else if (activ_z_arriba) {
			
			atack = true;
			
			if (tiempo_subida_bajada < 3) {
				
				this.transform.position = new Vector3 (this.transform.position.x,
				                                       this.transform.position.y - Mathf.Sin ((45 * Mathf.PI) / 180) * Time.deltaTime * velocidad,
				                                       this.transform.position.z + Mathf.Cos ((45 * Mathf.PI) / 180) * Time.deltaTime * velocidad
				                                       );
				//nuevo_y = (nuevo_x * nuevo_x) + 2 * nuevo_x + 2 ;
			} else if (tiempo_subida_bajada > 3 && tiempo_subida_bajada < 4) {
				this.transform.position = new Vector3 (this.transform.position.x,
				                                       this.transform.position.y,
				                                       this.transform.position.z + Mathf.Cos ((45 * Mathf.PI) / 180) * Time.deltaTime * velocidad
				                                       );
			} else if (tiempo_subida_bajada > 4 && tiempo_subida_bajada < 7) {
				this.transform.position = new Vector3 (this.transform.position.x,
				                                       this.transform.position.y + Mathf.Sin ((45 * Mathf.PI) / 180) * Time.deltaTime * velocidad,
				                                       this.transform.position.z + Mathf.Cos ((45 * Mathf.PI) / 180) * Time.deltaTime * velocidad
				                                       );
			} else if (tiempo_subida_bajada >= 7){
				tiempo_subida_bajada = 0;
				this.transform.position = this.transform.position;
				atack = false;
			}
		}
		/*
		if (nuevo_x <= referencia_estatica && nuevo_x >= -referencia_estatica) {
			nuevo_x -= Time.deltaTime;
			//nuevo_y = Mathf.Sin((nuevo_x * Mathf.PI)/180)+5;
			nuevo_y = (nuevo_x * nuevo_x);
			//nuevo_y = (nuevo_x * nuevo_x) + 2 * nuevo_x + 2 ;
			nuevo_y -= resta;
			if (nuevo_y <= 0)
				nuevo_y = 0.3f;

			this.transform.position = new Vector3 (nuevo_x, nuevo_y, this.transform.position.z);
		} else if (nuevo_x == 0)
			;
		else if (nuevo_x >= -referencia_estatica)
			;*/


		yield return null;
	}

	IEnumerator Atack(){

		Debug.Log (nuevo_x);
		Debug.Log (nuevo_y);
		//captura punto actual
		if (unavez_atack &&(activo_x_der || activo_x_izq)) {
			nuevo_x = this.transform.position.x;
			referencia_estatica = this.transform.position.x;
			unavez_atack  = false;
		}

		if (unavez_atack &&(activ_z_abajo || activ_z_arriba)) {
			nuevo_x = this.transform.position.z;
			referencia_estatica = this.transform.position.z;
			unavez_atack  = false;
		}
		//captura punto actual

		nuevo_y = -((nuevo_x * nuevo_x) + nuevo_x);// formula parabola sin traslacion 


		//rango de la parabola
		//derecha - abajo
		if (activo_x_der || activ_z_abajo) {

			if (nuevo_x > referencia_estatica - 1)
				nuevo_x -= Time.deltaTime;
			else{
				atack = false;
				unavez_atack = true;
			}
		}
		
		//izquierda - arriba
		if (activo_x_izq || activ_z_arriba) {
			if (nuevo_x < referencia_estatica + 1)
				nuevo_x += Time.deltaTime;
			else{
				atack = false;
				unavez_atack = true;
			}
		}

		//rango de la parabola


		//mover objeto
		if(activo_x_der || activo_x_izq)
			this.transform.position = new Vector3 (nuevo_x,nuevo_y,this.transform.position.z);

		else if(activ_z_abajo || activ_z_arriba)
			this.transform.position = new Vector3 (this.transform.position.x,nuevo_y,nuevo_x);

		//mover objeto

		yield return null;
	}
	
	void OnTriggerEnter(Collider node){
		if (node.tag == "Weapon") {
			this.GetComponent<Rigidbody>().AddForce(-node.transform.forward *1000);
			Destroy (this.gameObject);
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
