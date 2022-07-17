using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemies;
    [SerializeField] private float _timerDefaultTime = 2;
    [SerializeField] private float _waveDefaultTime = 10;

    private int _maxWaves;
    private int _waveCounter = 0;
    private float _currentWaveMaxEnemies = 3;
    private float _enemyCounter;
    private float _timer;
    private float _waveTimer;
    private bool _isWave = false;
    private Vector3 _spawnPos;
    void Start()
    {
        _spawnPos = SetSpawnPosition();
        _maxWaves = _enemies.Count;
        _timer = _timerDefaultTime;
        _waveTimer = _waveDefaultTime;
    }

    void Update()
    {
        if (_enemyCounter != _currentWaveMaxEnemies)
        {
            SpawnEnemy(_spawnPos);
        }
        else
        {
            _waveTimer -= Time.deltaTime;
            if (_waveTimer <= 0)
            {
                _enemyCounter = 0;
                _currentWaveMaxEnemies += 2;
                _waveCounter++;
                _spawnPos = SetSpawnPosition();
                _waveTimer = _waveDefaultTime;
            }
        }

    }

    private void SpawnEnemy(Vector3 positionToSpawn)
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            if (_waveCounter < _maxWaves)
            {
                Instantiate(_enemies[_waveCounter], positionToSpawn, Quaternion.identity);
                ++_enemyCounter;
                _timer = _timerDefaultTime;
            }
            else
            {
                Instantiate(_enemies[Random.Range(0,_enemies.Count)], positionToSpawn, Quaternion.identity);
                ++_enemyCounter;
                _timer = _timerDefaultTime;
            }
        }
    }

    private Vector3 SetSpawnPosition() => new Vector3(Random.Range(-30, 30), 1.8f, Random.Range(-30, 30));
}
