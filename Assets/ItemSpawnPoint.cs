﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemSpawnPoint : MonoBehaviour {

	public static List<GameObject> spawnPoints = new List<GameObject>();

	// Use this for initialization
	void Start () {
		spawnPoints.Add (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
