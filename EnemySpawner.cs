using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private List<SpawnPoint> _dotsSpawn;    
    [SerializeField] private float _cooldown = 2f;       
    
    private void Start()
    {
        PutEnemiesToList(gameObject.GetComponentsInChildren<SpawnPoint>());        
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (_dotsSpawn.Any()) 
        {
            var dotSpawn = _dotsSpawn[Random.Range(0, _dotsSpawn.Count)];
            Instantiate(_enemy, dotSpawn.transform);
            _dotsSpawn.Remove(dotSpawn);
            yield return new WaitForSecondsRealtime(_cooldown);
        }
    }

    private void PutEnemiesToList(SpawnPoint[] dots)
    {        
        _dotsSpawn.AddRange(dots);         
    }
}
