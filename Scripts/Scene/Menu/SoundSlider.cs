using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
	public Toggle toggle;

	// Use this for initialization
	void Start()
	{

	}
	public void DisableSound()
	{
		AudioListener.volume = toggle.isOn ? 1f : 0f;
	}

	void Update()
	{
		if (toggle.isOn)
		{
			AudioListener.volume = this.GetComponent<Slider>().normalizedValue;
		}
	}
}