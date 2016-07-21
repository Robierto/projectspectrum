using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	public GameObject[] bulletPrefabs;

	public Transform primaryFirePoint;
	public Transform secondaryFirePoint;

	public float primaryFireForce = 10.0f;
	public float secondaryFireForce = 10.0f;

	public Material tankMaterial;

	// Use this for initialization
	void Start () {
		//Color redTank = Color.red;
		//tankMaterial.SetColor ("_EmissionColor", redTank);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) 
		{
			GameObject _clone = Instantiate (bulletPrefabs [0], primaryFirePoint.position, primaryFirePoint.rotation) as GameObject;
			_clone.GetComponent<Rigidbody> ().AddForce (primaryFirePoint.transform.forward * primaryFireForce, ForceMode.Impulse);
			Destroy (_clone, 10.0f);
		}

		if (Input.GetButtonDown ("Fire2")) 
		{
			GameObject _clone = Instantiate (bulletPrefabs [1], secondaryFirePoint.position, secondaryFirePoint.rotation) as GameObject;
			_clone.GetComponent<Rigidbody> ().AddForce ( secondaryFirePoint.transform.forward * secondaryFireForce, ForceMode.Impulse);
			Destroy(_clone, 10.0f);
		}
	}
}