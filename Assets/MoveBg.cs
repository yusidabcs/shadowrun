using UnityEngine;
using System.Collections;

public class MoveBg : MonoBehaviour {

	public float scrollSpeed = 0.5f;

	void Start ()
	{
	}

	void Update ()
	{

		Vector2 offset = new Vector2 (Time.time * scrollSpeed,0);
		GetComponent<Renderer>().material.mainTextureOffset = offset;﻿
	}
}
