using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public GameObject MenuCompleto;
	public GameObject buttonAudio;
	public GameObject buttonRestar;
	public bool pausado=false;
	public bool som =true;
	public bool reiniciar=false;
	// Use this for initialization

	void Start () {
		
	}
	
	
	void Update () { }
    public void pause(){
		if(pausado){
		MenuCompleto.SetActive(false);
		pausado=false;
		}
		else{
			MenuCompleto.SetActive(true);
			pausado=true;
		}
	}
	public void áudio(){
		if(som){
			GetComponent<AudioSource>().Pause();
			som = false;
		}else{
			GetComponent<AudioSource>().Play();
			som = true;
		}
	}
	// restart na cena.
	public void restartCurrentScene(){
        if((Input.GetKey(KeyCode.B))){
		UnityEngine.SceneManagement.Scene scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene.name);}
	}
}
