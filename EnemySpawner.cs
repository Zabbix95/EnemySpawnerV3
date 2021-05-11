using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private SpawnPoint[] _dotsSpawn;
    [SerializeField] private int _enemyCount = 0;
    [SerializeField] private float _cooldown = 2f;       
    
    void Start()
    {
        _dotsSpawn = gameObject.GetComponentsInChildren<SpawnPoint>();        
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (_enemyCount < _dotsSpawn.Length)
        {
            Transform spawnPosition = _dotsSpawn[Random.Range(0, _dotsSpawn.Length)].Position;            
            Collider[] intersecting = Physics.OverlapSphere(spawnPosition.transform.position, 1f, 1 << 6);            
            if (intersecting.Length == 0)
            {                
                Instantiate(_enemy, new Vector3(spawnPosition.position.x, 0f, spawnPosition.position.z), Quaternion.identity);
                _enemyCount++;
                yield return new WaitForSeconds(_cooldown);                
            }            
        }
    }
}
