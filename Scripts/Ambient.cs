using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambient : MonoBehaviour {
	private AudioSource AmbientAudio;

	public bool gamePaused = false; // used by 'Pause' button

	void Start () {
		AmbientAudio = GetComponent<AudioSource>();
	}
	
	void PauseChoose()
    {
		if (gamePaused)
			AmbientAudio.Pause();
		else
			AmbientAudio.Play();
    }

	void Update () {
		
	}
}
