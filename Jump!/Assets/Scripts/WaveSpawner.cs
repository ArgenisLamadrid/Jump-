using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class Wave {

        public string name;
        public Transform enemy1;
        public Transform enemy2;
        public float enemyOneCount;
        public float enemyTwoCount;
        public float rate;

    }

    public int currentWave;                 // Current wave to be displayed
    public Text CurrentWaveText;             // Reference to current wave to be displayed

    public Wave[] waves;                    // Array of customizeable waves
    private int nextWave = 0;               // Wave Counter
    public Transform[] spawnPoints;         // Array of customizeable spawnpoints

    public float timeBetweenWaves = 5f;     // Wait time between waves
    public float waveCountDown;             

    private float searchCountDown = 1f;     // Time between EnemyIsAlive() searches

    private SpawnState state = SpawnState.COUNTING;

    void Start() {
        waveCountDown = timeBetweenWaves;
        currentWave = 0;
        if (spawnPoints.Length == 0)
        {
            Debug.Log("Error: No Spawn Points Set");
        }
    }

    void Update() {

        CurrentWaveText.text = "Wave: " + currentWave;
        if (state == SpawnState.WAITING) {
            // Check if enemies are still alive
            if (!EnemyIsAlive()) {
                // Begin next wave
                WaveCompleted();
            }
            else {
                return;
            }
        }

        if (waveCountDown <= 0) {

            if (state != SpawnState.SPAWNING){
                // Start spawning wave
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else {
            waveCountDown -= Time.deltaTime;
        }
    }

    void WaveCompleted(){
        Debug.Log("Wave completed");

        state = SpawnState.COUNTING;
        waveCountDown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1){
            nextWave = 0;
            // Enemy multiplier at the end of waves, makes them incrementally harder
            for (int i = 0; i < waves.Length; i++) {
                waves[i].enemyOneCount = Mathf.Floor(1.5f * waves[i].enemyOneCount);
                waves[i].enemyTwoCount = Mathf.Floor(1.5f * waves[i].enemyOneCount);
            }
            Debug.Log("All Waves Complete! Looping...");
        }
        else {
            nextWave++;
        }

    }

    bool EnemyIsAlive() {
        searchCountDown -= Time.deltaTime;

        if (searchCountDown <= 0) {
            searchCountDown = 1f;
            if (GameObject.FindGameObjectWithTag("head-guy") == null && GameObject.FindGameObjectWithTag("bullet-guy") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave) {
        Debug.Log("Spawning wave: " + _wave.name);
        state = SpawnState.SPAWNING;
        currentWave++;

        // Spawn enemy1
        for (int i = 0; i < _wave.enemyOneCount; i++) {
            SpawnEnemy(_wave.enemy1);
            yield return new WaitForSeconds(1f / (_wave.rate / 2f));

        }
        // Spawn enemy2
        for (int i = 0; i < _wave.enemyTwoCount; i++)
        {
            SpawnEnemy(_wave.enemy2);
            yield return new WaitForSeconds(1f / (_wave.rate / 2f));

        }

        state = SpawnState.WAITING;

        yield break;

    }

    void SpawnEnemy(Transform _enemy) {
        // Spawn enemy
        Debug.Log("Spawning Enemy" + _enemy.name);
        Transform _sp = spawnPoints[ Random.Range(0, spawnPoints.Length) ];
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }

}
