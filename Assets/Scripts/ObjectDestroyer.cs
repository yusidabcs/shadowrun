using UnityEngine;
using System.Collections;

public class ObjectDestroyer : MonoBehaviour {

	public GameObject objectDestructionPoint;
	private Rigidbody2D myRigidbody;
	// Use this for initialization
	void Start () {
		objectDestructionPoint = GameObject.Find ("ObjectDestructionPoint");
		myRigidbody = GetComponent<Rigidbody2D> ();
		Debug.Log(gameObject.tag);
	}
	
	// Update is called once per frame
	void Update () {

		 
		if (transform.position.x < objectDestructionPoint.transform.position.x) {

			if (myRigidbody != null && gameObject.tag != "scenery") {
				myRigidbody.isKinematic = false;
				if (transform.position.y < -5) {
					gameObject.SetActive (false);
				}
			} else {
				gameObject.SetActive (false);
			}


		}

	}
}
