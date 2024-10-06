using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private GameObject _gameObject1;
    [SerializeField] private GameObject _gameObject2;


    public void StartGames()
    {
        _gameObject.SetActive(false);
        _gameObject1.SetActive(false);
        _gameObject2.SetActive(false);
    }
}
