using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawnController : MonoBehaviour {

	public bool gameStart = false;
	public float difficultyLevel = 1;
	public List<EnemySpawner> enemySpawnerList;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GameStart(){
		gameStart = true;
		for(int i = 0; i < enemySpawnerList.Count; i++){
			enemySpawnerList[i].enabled = true;
		}
	}

	public void IncreaseDifficulty(){
		difficultyLevel++;

	}
}
