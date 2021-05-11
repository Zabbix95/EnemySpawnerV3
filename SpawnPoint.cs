using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Transform _position;

    public Transform Position => _position;

    private void Awake() 
    {
        _position = GetComponent<Transform>();
    }    
}
