using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoTools : MonoBehaviour {
	public VideoPlayer player;
	public GameObject MainMenu;

	// Ensure that Intro Video plays only once
	static bool EndVideoFlag = false;

	void Start () {
		if (EndVideoFlag) {
			player.Stop ();
			MainMenu.SetActive (true);
		} else
			MainMenu.SetActive (false);
	}
	
	void Update () {
		if(!EndVideoFlag)
			EndVideoFlag = CheckEndVideo ();
	}

	bool CheckEndVideo() {
		long playerCurrentFrame = player.frame;
		long playerFrameCount = System.Convert.ToInt64(player.frameCount);

		if(playerCurrentFrame < playerFrameCount)
		{
			return false;
		}
		else
		{
			// Cancel Invoke since video is no longer playing
			CancelInvoke("checkOver");
			player.Stop ();
			EndVideoFlag = true;
			MainMenu.SetActive(true);
			return true;
		}
	}
}
