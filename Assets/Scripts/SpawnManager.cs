using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    [SerializeField] float xMin;
    [SerializeField] float xMax;
    [SerializeField] float timeInterval;
    [SerializeField] List<GameObject> Objects;
    bool gameOver = false;
    void Start() {
        InvokeRepeating("SpawnObject", 0, timeInterval);
        EventHub.PlayerGameOver += OnGameOver;
    }
    
    void Update() {
        
    }

    void SpawnObject() {
        if (gameOver) return;
        var randomPos = Random.Range(xMin, xMax);
        Instantiate(Objects[Random.Range(0, Objects.Count)], new Vector3(randomPos, 0, 0), Quaternion.identity);
    }

    void OnGameOver() {
        gameOver = true;
    }
}
