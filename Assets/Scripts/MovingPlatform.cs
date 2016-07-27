using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	public Transform movingPlatform;
	public Transform position1;
	public Transform position2;
	public Vector3 newPosition;
	public string currentState;
	public float smooth;
	public float resetTime;
	public Color PlatformSolution;
	public GameObject Bullet;
	public GameObject Bullet2;
	public GameObject Currentwall;



	// Use this for initialization
	void Start () 
	{
		
		ChangeTarget ();
		newPosition = movingPlatform.position;

	}
		
	// Update is called once per frame
	void FixedUpdate () 
	{
		
		movingPlatform.position = Vector3.Lerp (movingPlatform.position, newPosition, smooth * Time.deltaTime);	

	}
    void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Bullet1" || col.tag == "Bullet2")
			InvokeRepeating ("ChangeTarget", 0.1f, resetTime);
	}
	//Currentwall.GetComponent<MeshRenderer>() .material.color == PlatformSolution && 
	void ChangeTarget()
	{
		
		if (currentState == "Moving To Position 1") 
		{
			currentState = "Moving To Position 2";
			newPosition = position1.position;
		} 
		else if (currentState == "Moving To Position 2") 
		{
			currentState = "Moving To Position 1";
			newPosition = position2.position;
		}
		else if (Currentwall.GetComponent<MeshRenderer>() .material.color == PlatformSolution && currentState == "")
		{
			Debug.Log ("Change Target");
			currentState = "Moving To Position 2";
			newPosition = position2.position;
		} 
		Invoke ("ChangeTarget", resetTime);

//		if (currentPosition == position1.position && isMoving == false) 
//		{
//			newPosition = position2.position;
//		}
//		else if (currentPosition == position2.position && isMoving == false)
//		{
//			newPosition = position1.position;
//		}

	}
//	void Startmovement()
//	{
//		
//	}
}
