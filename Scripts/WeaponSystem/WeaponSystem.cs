using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSystem : MonoBehaviour {
	public Weapon CurrentWeapon;
	public List<Weapon> Weapons;
	public List<Collider2D> EnemyColliders;

	void Start () {
		if (!CurrentWeapon)
			CurrentWeapon = Weapons[0];

		CurrentWeapon.gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
