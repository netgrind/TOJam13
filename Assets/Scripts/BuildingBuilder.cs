﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBuilder : MonoBehaviour {

    public Transform player;
    public List<GameObject> prefabs;
    public float spawnAheadDistance = 300;
    public float spawnRange = 100;
    public float spawnEverySeconds = .5f;
    float t = 0;
    List<GameObject> buildings;

	// Use this for initialization
	void Start () {
        buildings = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
        t -= Time.deltaTime;
        if (t < 0)
        {
            t = spawnEverySeconds;
            Spawn();
        }
        if (buildings[0].transform.position.z < player.position.z-100)
        {
            Destroy(buildings[0]);
            buildings.RemoveAt(0);
        }
	}

    void Spawn()
    {
        GameObject g = Instantiate<GameObject>(prefabs[Random.Range(0, prefabs.Count)]);
        buildings.Add(g);
        g.transform.position = player.position;
        g.transform.position.Scale( new Vector3(1, 0, 1));
        g.transform.position += new Vector3(Random.Range(-spawnRange, spawnRange), 0, spawnAheadDistance);
    }
}