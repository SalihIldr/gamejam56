using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    private float _energy = 0;
    [SerializeField] private SpriteRenderer _sprite;
    //[SerializeField] private SpriteRenderer _spriteBack;
    //[SerializeField] private TextMeshProUGUI _textMeshProUGUI;
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private GameObject _gameObject1;
    [SerializeField] private SpriteRenderer _circle1;
    [SerializeField] private SpriteRenderer _circle2;
    [SerializeField] private SpriteRenderer _circle3;

    private float _ee;


    [SerializeField] private Animator _anim;


    private void Update()
    {
        
    }

    public void AddEnergy(float energy)
    {
        _energy += energy;
        float ee =  (255-_energy)/255;
        Debug.Log("Цвет "+ee);
        _ee= ee;
        Debug.Log(_sprite.color);
        Debug.Log(_energy);
        _anim.enabled = true;
        _gameObject.SetActive(true);
        _anim.SetTrigger("VK");
        StartCoroutine(Delay());
        if (_energy >255)
        {
            _anim.enabled = false;
            Debug.Log("Победа");
            //Color color = _sprite.color;
            //color.a = 0;
            //_sprite.color = color;
            _gameObject1.SetActive(true);
            _sprite.color = new Color(0, 0, 0, 0);
            _circle1.enabled = false;
            _circle2.enabled = false;
            _circle3.enabled = false;
        }
    }

   



    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.3f);
       
        _gameObject.SetActive(false);
        _anim.enabled=false;
        _sprite.color = new Color(1, 1, _ee, 1);

        // Color color = _sprite.color;
        // color.a = 1;
        //_sprite.color = color;
    }

}
