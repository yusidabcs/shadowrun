using UnityEngine;
using System.Collections;

public class CoinGenerator : MonoBehaviour {

	public ObjectPooler coinPool;

	public float distanceBetweenCoin;

	public void SpawnCoin(Vector3 position){

		GameObject coin1 = coinPool.GetPooledObject ();
		coin1.transform.position = position;
		coin1.SetActive (true);

	}
}
