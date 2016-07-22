using UnityEngine;
using System.Collections;

public class Splatter : MonoBehaviour {

	public Color colorToUse;

	public float despawnTime = 10.0f;

	public GameObject splatterPrefab;

	public float splatterForce = 20.0f;

	public float splatterRadius = 5.0f;

	private Rigidbody rb;
	private MeshRenderer mesh;
	private Collider col;

	void Start () {
		rb = gameObject.GetComponent<Rigidbody>();
		mesh = gameObject.GetComponent<MeshRenderer>();
		col = gameObject.GetComponent<Collider>();
	}

	void Update () {
		despawnTime -= Time.deltaTime;
		if (despawnTime <= 0)
			Destroy(gameObject);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Paintable")
		{
			other.GetComponent<MeshRenderer>().material.color = colorToUse;
			DoSplatter();
			Debug.Log("Hit Paintable");
		}
	}

	void DoSplatter()
	{
		rb.constraints = RigidbodyConstraints.FreezeAll;
		mesh.enabled = false;
		col.enabled = false;

		GameObject _clone = Instantiate(splatterPrefab, transform.position, transform.rotation) as GameObject;
		MeshRenderer[] renderers = _clone.GetComponentsInChildren<MeshRenderer>();
		foreach (MeshRenderer mr in renderers)
		{
			mr.material.color = colorToUse;
		}
		_clone.GetComponent<Rigidbody>().AddExplosionForce(splatterForce, _clone.transform.position, splatterRadius);
		Destroy(_clone, 8.0f);
	}
}