using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemies;
    [SerializeField] private float _timerDefaultTime = 2;
    [SerializeField] private float _waveDefaultTime = 10;
    
    private int _waveCounter = 0;
    private float _currentWaveMaxEnemies = 3;
    private float _enemyCounter;
    private float _timer;
    private float _waveTimer;
    private bool _isWave = false;
    void Start()
    {
        _timer = _timerDefaultTime;
        _waveTimer = _waveDefaultTime;
    }

    void Update()
    {
        if (_enemyCounter != _currentWaveMaxEnemies)
        {
            SpawnEnemy();
        }
        else
        {
            _waveTimer -= Time.deltaTime;
            if (_waveTimer <= 0)
            {
                _enemyCounter = 0;
                _currentWaveMaxEnemies += 2;
                _waveCounter++;
                _waveTimer = _waveDefaultTime;
            }
        }

    }

    private void SpawnEnemy()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            Instantiate(_enemies[_waveCounter], transform.position, Quaternion.identity);
            ++_enemyCounter;
            _timer = _timerDefaultTime;
        }
    }
}
