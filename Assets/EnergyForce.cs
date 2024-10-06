using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnergyForce : MonoBehaviour
{
    private float _forceEnergy=250;
    private float _timer;
    private float _timerExp;
   
    [SerializeField] float _timeBetweenSpawns;
    [SerializeField] private GameObject _gameObject;
    [SerializeField] float _timeExpBetwin;
    [SerializeField] private GameObject _textObject;
    [SerializeField] private Image  _image;
    [SerializeField] private Slider _slider;

    private Color _color;

    private bool _isExplosing = false;

    private void Start()
    {
        _slider.value = _forceEnergy;
        _color = _image.color;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
       
        if (_timer >= _timeBetweenSpawns)
        {
            if(_isExplosing == false ) 
            {
                _timer = 0;
                _forceEnergy = _forceEnergy + Random.Range(200, 250);
                _slider.value = _forceEnergy;
                Debug.Log("Энергия " + _forceEnergy);
                if (_forceEnergy > 800)
                {
                    _isExplosing = true;
                    Debug.Log("Проигрыш");
                }
            } 
        }
        if(_isExplosing)
        {
          
            _textObject.SetActive(true);
            _image.color = Color.Lerp(Color.white, Color.red, Mathf.PingPong(Time.time, 0.5f));
         
            if (_timer >= _timeExpBetwin)
            {
                _textObject.SetActive(false);
                _gameObject.SetActive(true);
                StartCoroutine(Delay());
            }
          
        }
    }

    public float AddEnergy()
    {
        float currentAddEnergy = _forceEnergy;
        if (_forceEnergy > 0) 
        {
            _forceEnergy = 0;
            _slider.value = _forceEnergy;
            return currentAddEnergy;
           
        }
        else
        {
            return 1;
        }
       
    }

    public void Moved()
    {
        if (_isExplosing)
        {
            _isExplosing = false;
            _textObject.SetActive(false);
            _image.color = _color;
        }
        
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("SampleScene");
        // Color color = _sprite.color;
        // color.a = 1;
        //_sprite.color = color;
    }
}
