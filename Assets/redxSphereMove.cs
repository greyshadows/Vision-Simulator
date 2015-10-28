using UnityEngine;
using System.Collections;

public class redxSphereMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void move(Vector3 target)
	{
		transform.position = target;
		print("Move Called !");
	}
}
