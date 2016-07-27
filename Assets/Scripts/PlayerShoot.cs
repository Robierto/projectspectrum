using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	public GameObject[] bulletPrefabs;

	public Transform primaryFirePoint;
	public Transform secondaryFirePoint;

	public float primaryFireForce = 10.0f;
	public float secondaryFireForce = 10.0f;

	public int maxAmmo;
	public int ammo = 10;

	public Material tankMaterial;

	// Use this for initialization
	void Start() {
		//Color redTank = Color.red;
		//tankMaterial.SetColor ("_EmissionColor", redTank);
		maxAmmo = ammo;
	}
	
	// Update is called once per frame
	void Update() {
		if (Input.GetButtonDown ("Fire1") && ammo >= 1) 
		{
			ammo -= 1;
			GameObject _clone = Instantiate (bulletPrefabs [0], primaryFirePoint.position, primaryFirePoint.rotation) as GameObject;
			_clone.GetComponent<SmearEffect>().enabled = true;
			_clone.GetComponent<Rigidbody>().AddForce(primaryFirePoint.transform.forward * primaryFireForce, ForceMode.Impulse);
		}

		if (Input.GetButtonDown ("Fire2") && ammo >= 1) 
		{
			ammo -= 1;
			GameObject _clone = Instantiate (bulletPrefabs [1], secondaryFirePoint.position, secondaryFirePoint.rotation) as GameObject;
			_clone.GetComponent<SmearEffect>().enabled = true;
			_clone.GetComponent<Rigidbody>().AddForce(secondaryFirePoint.transform.forward * secondaryFireForce, ForceMode.Impulse);
		}

		// Cheat because im lazy
		if (Input.GetKeyDown (KeyCode.P))
			ammo = 500;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Ammo") 
		{
			ammo += other.GetComponent<Ammo> ().ammoValue;
		}
	}
}