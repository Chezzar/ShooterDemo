using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Stats_UI : MonoBehaviour {


	public GameObject spawner_1;
	public GameObject spawner_2;
	public GameObject spawner_3;
	public GameObject spawner_4;

	GameObject time_gameobject;
	GameObject life_gameobject;
	GameObject ammo_gameobject;
	GameObject score_gameobject;
	GameObject best_gameobject;
	GameObject tutorial;

	private Text life_text;
	private Text ammo_text;
	private Text score_text;
	private Text best_text;

	private GameObject quit;
	private GameObject retry;

	public float time;
	public int life_UI;
	public int ammo_UI;
	public int score_UI = 0;
	private bool menu = false;
	private float menu_wait = 0;

	Char_stats life_;
	Weapon_shoot ammo_;

	// Use this for initialization
	void Start () {

		quit = this.transform.root.Find ("Quit").gameObject;
		retry = this.transform.root.Find ("Begin").gameObject;

		quit.SetActive (false);
		retry.SetActive (false);

		tutorial = this.transform.root.Find ("Tutorial").gameObject;
		tutorial.SetActive (true);

		time_gameobject = this.transform.Find("Time").gameObject;
		life_gameobject = this.transform.Find ("Life").gameObject;
		ammo_gameobject = this.transform.Find ("Ammo").gameObject;
		score_gameobject = this.transform.Find ("Score").gameObject;
		best_gameobject = this.transform.Find ("Best").gameObject;

		life_ = GameObject.FindGameObjectWithTag ("Player").transform.GetComponent<Char_stats> ();
		ammo_ = GameObject.FindGameObjectWithTag ("Player").transform.Find("Weapon").GetComponent<Weapon_shoot> ();

		life_text = life_gameobject.GetComponent<Text> ();
		ammo_text = ammo_gameobject.GetComponent<Text> ();
		score_text = score_gameobject.GetComponent<Text>();
		best_text = best_gameobject.GetComponent<Text>();
		
	}
	
	// Update is called once per frame
	void Update () {

			
		life_UI = life_.life;
		ammo_UI = ammo_.ammo;

		life_text.text = "LIFE" + "   " + life_UI.ToString ();
		ammo_text.text = "AMMO" + "   " + ammo_UI.ToString ();
		score_text.text = "SCORE" + "   " + score_UI.ToString ();
		best_text.text = "BEST" + "   " + Global.Score.ToString ();


		if(life_UI > 1 && score_UI > 0)
			time += Time.deltaTime;

		time_gameobject.GetComponent<Text> ().text = "TIME" + "   " + time.ToString();


		if (Input.GetKey ("escape")) {
			quit_game ();
		}
			


		if (score_UI > Global.Score)
			Global.Score = score_UI;

		if (score_UI > 20)
			spawner_2.SetActive (true);

		if (score_UI > 40)
			spawner_3.SetActive (true);

		if (score_UI > 60)
			spawner_4.SetActive (true);

		if (life_UI <= 1) {
					
			life_UI = 0;

			GameObject.FindGameObjectWithTag ("Player").transform.GetComponent<Char_mov> ().dead = true;
			//GameObject.Find ("Air_camera").SetActive (true);
			quit.gameObject.SetActive (true);
			retry.gameObject.SetActive (true);

			Cursor.visible = true;
		}
	}

	public void quit_game(){

		Application.Quit ();
	}

	public void restart_game(){

		SceneManager.LoadScene ("Arena_");
	}
		
}
