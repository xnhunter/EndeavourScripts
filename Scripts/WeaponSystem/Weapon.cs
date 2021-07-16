using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityStandardAssets._2D;
using UnityStandardAssets.CrossPlatformInput;

public class Weapon : MonoBehaviour {
	public string Name;
	public int Damage;
	public int fireRate;

	//private Image image;
	private PlayerBullet bulletTemplate;

	public GameObject initialBullet;
	private GameObject fire;

	bool boughtOrFound = false;

	void Start () 
	{
		Name = transform.name;

		// Make pistol is always available.
		if (Name == "Pistol")
			boughtOrFound = true;

		bulletTemplate = GetComponentInChildren<PlayerBullet>();

		Name = "Pistol";
		// Damage = Damage;// bulletTemplate.damage;
		bulletTemplate.gameObject.SetActive(false);
	}

	void Fire()
    {
		PlayerBullet bullet = Instantiate(bulletTemplate, initialBullet.transform.position, Quaternion.identity);
		bullet.gameObject.SetActive(true);
		fire = bullet.transform.Find("Fire").gameObject;

		bullet.damage = Damage;

		if (PlatformerCharacter2D.m_FacingRight)
		{
			bullet.GetComponentInChildren<SpriteRenderer>().flipY = true;
			bullet.GetComponent<Rigidbody2D>().velocity += new Vector2(8f, 0f);
			bullet.initialPosition = initialBullet.transform.position;
		}
		else
		{
			bullet.GetComponentInChildren<SpriteRenderer>().flipY = false;
			bullet.GetComponent<Rigidbody2D>().velocity += new Vector2(-8f, 0f);
			bullet.initialPosition = -initialBullet.transform.position;
		}

		bullet.GetComponent<Rigidbody2D>().simulated = true;
		StartCoroutine(ShowFire());
		Debug.Log("Player Fire");
	}

	public IEnumerator ShowFire()
	{
		fire.SetActive(true);
		yield return new WaitForSeconds(0.03f);
		fire.SetActive(false);
	}

	void Update () {
		if (CrossPlatformInputManager.GetButtonDown("Shoot"))
			Fire();
	}
}
