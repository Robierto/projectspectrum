using UnityEngine;
using System.Collections;

public class WallDestruction : MonoBehaviour {

	public float despawnTime = 10.0f;
	public Color[] PuzzleSolution;
	public GameObject[] PaintableWall;
	public GameObject destroyedWall;
	private Rigidbody rb;
	private MeshRenderer mesh;
	private Collider col;
	public GameObject Bullet;
	public GameObject Bullet2;
	private Color[] colors;
	private int WallPuzzle;
	private bool alreadySolved;


	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody>();
		mesh = gameObject.GetComponent<MeshRenderer>();
		col = gameObject.GetComponent<Collider>();
		alreadySolved = false;

	}
	
	// Update is called once per frame
	void Update () {
//		despawnTime -= Time.deltaTime;
//		if (despawnTime <= 0)
//			Destroy(gameObject);

		CheckPuzzle ();

	}
	void CheckPuzzle ()
	{


		bool[] continuing = new bool[9];

		for (int i = 0; i < PuzzleSolution.Length; i++) 
		{
			if (PaintableWall [i].GetComponent<MeshRenderer> ().material.color
				== PuzzleSolution [i]) {
				continuing[i] = true;
			} else {
				continuing[i] = false;
			}
		}

		if (continuing[0] && continuing[1] && continuing[2] && continuing[3] && continuing[4] && 
			continuing[5] && continuing[6] && continuing[7] && continuing[8] && !alreadySolved)
			SolvePuzzle ();

	}

	void SolvePuzzle()
	{
		// Run Destruction mechanic here
		alreadySolved = true;
		foreach (GameObject wall in PaintableWall) 
		{
			//wall.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
			wall.GetComponent<MeshRenderer> ().enabled = false;
			Collider[] _cols = wall.GetComponents<BoxCollider> ();
			foreach (Collider col in _cols)
				col.enabled = false;

		}
			
		destroyedWall.SetActive (true);

		Debug.Log("Puzzle Solved!!");
	}

}

