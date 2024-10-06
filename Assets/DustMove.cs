using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustMove : MonoBehaviour


{
   
    private float _timer;
    private float _currentTime = 0;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] float _timeBetweenSpawns;



    private void Update()
    {
        _timer += Time.deltaTime;
        _currentTime += Time.deltaTime;
        if (_timer >= _timeBetweenSpawns)
        {
            _timer = 0;
            _rigidbody2D.AddForce(50 * Vector2.up);

        }
    }
}
