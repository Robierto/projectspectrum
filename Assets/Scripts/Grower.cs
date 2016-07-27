using UnityEngine;
using System.Collections;

public class Grower : MonoBehaviour {

	public float growthScaleX = 1.1f;
	public float growthScaleY = 1.0f;
	public float growthScaleZ = 1.1f;
	public int maxGrows = 5;

	[SerializeField]
	private int grows;
	private Color initialColor;

	// Use this for initialization
	void Start () {
		grows = 0;
		initialColor = GetComponent<MeshRenderer> ().material.color;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{

		if (other.tag == "Bullet1" && grows < maxGrows) {
			grows++;
			CheckGrows (other.gameObject);
			float _scaleX = transform.localScale.x; 
			float _scaleY = transform.localScale.y; 
			float _scaleZ = transform.localScale.z; 
			transform.localScale = new Vector3(_scaleX * growthScaleX, _scaleY * growthScaleY, _scaleZ * growthScaleZ);
			Destroy (other.gameObject);
		}
		if (other.tag == "Bullet2" && grows > 0) {
			grows--;
			CheckGrows (other.gameObject);
			float _scaleX = transform.localScale.x; 
			float _scaleY = transform.localScale.y; 
			float _scaleZ = transform.localScale.z; 
			transform.localScale = new Vector3(_scaleX * (1.0f / growthScaleX), _scaleY * (1.0f / growthScaleY), _scaleZ * (1.0f / growthScaleZ));
			Destroy (other.gameObject);
		}
	}

	void CheckGrows(GameObject other)
	{
		if (grows == maxGrows)
			GetComponent<MeshRenderer> ().material.color = other.GetComponent<MeshRenderer> ().material.color;
		else if (grows < maxGrows)
			GetComponent<MeshRenderer> ().material.color = initialColor;
	}
}
