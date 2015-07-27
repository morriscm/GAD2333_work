using UnityEngine;
using System.Collections;

public class AppleTree : MonoBehaviour 
{

	public GameObject applePrefab;
	public float speed = 1f;
	public float leftAndRightEdge = 10f;
	public float chanceToChangeDirections = 0.1f;
	public float secondsBetweenAppleDrops = 1f;
	void Start () {
		// Dropping apples every second
		InvokeRepeating( "DropApple", 2f, secondsBetweenAppleDrops );
	}
	void DropApple() {
		GameObject apple = Instantiate( applePrefab ) as GameObject;
		apple.transform.position = transform.position;
	}

	void Update () 
	{
		// Basic Movement
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;
		// Changing Direction
		if ( pos.x < -leftAndRightEdge ) {
			speed = Mathf.Abs(speed); 
		} else if ( pos.x > leftAndRightEdge ) {
			speed = -Mathf.Abs(speed);
		}
	}
	void FixedUpdate() {
		// Changing Direction Randomly
		if ( Random.value < chanceToChangeDirections ) {
			speed *= -1; 
		}
	}
}
