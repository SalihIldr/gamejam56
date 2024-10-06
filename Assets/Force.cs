using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Force : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Stay _stay;
    [SerializeField] private Energy _energy;
    [SerializeField] private EnergyForce _energyForce;
   
    
    
    //[SerializeField] private Rotate _rotate;
    private bool _isAddMove = false;
    private Vector2 _direction;


    //private void OnMouseDown()
    //{
    //    _isMove = true;
    //    Debug.Log("Нажал");
    //}

  

    public void Move(Vector2 direction)
    {
        if(_stay.IsStay()==true)
        {
            _isAddMove = true;
            _direction = direction;
            _stay.Stayd(false);
            _energyForce.Moved();
            Debug.Log("1");
        }
      
    }

    private void FixedUpdate()
    {
        if (_rigidbody2D.velocity.magnitude <= 2&&_stay.IsStay() == false)
        {
            _rigidbody2D.velocity = Vector2.zero;
            _stay.Stayd(true);
        }
        if (_rigidbody2D.velocity.magnitude > 2&& _stay.IsStay() == true)
        {
           
            _stay.Stayd(false);
        }

        if (_isAddMove)
        {
          
            _rigidbody2D.AddForce(_energyForce.AddEnergy() * _direction);
            _isAddMove = false;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      

            if (collision.collider.TryGetComponent(out Stay stay))
            {

                //_rigidbody2D.velocity = Vector2.zero;
                if (stay.IsStay() ==false&&_stay.IsStay()==false)
                {
                Debug.Log(stay.IsStay() + "Состояние" );
                Debug.Log(" Получение энергии");
                _energy.AddEnergy(_rigidbody2D.velocity.magnitude);
                StartCoroutine(Delay());
                //_stay.Stayd(true);
                }
            //    else
            //{
            //    stay.Stayd(false);
            //    Debug.Log(" Активировался ещё шарик");
            //}


                //_transform = transform;
                //_rigidbody2D.velocity = Vector2.MoveTowards(_rigidbody2D.velocity, Vector2.zero, 150f * Time.deltaTime);

            }

        //}
        //else
        //{
        //    if (collision.collider.TryGetComponent(out Force force))
        //    {
        //        enabled = true;
        //    }
        //}

       


        //_rigidbody2D.AddForce(250 * Vector2.left);
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.4f);
        _rigidbody2D.velocity = Vector2.zero;
      
    }

}
