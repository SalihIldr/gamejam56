using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Rotate : MonoBehaviour
{

   
  
    [SerializeField] private Force _force;
   
    [SerializeField] private GameObject GameObject;

    private Vector2 _directions;

    private bool _isRotate = false;
    private bool _isAddMove = false;

    private void OnMouseDown()
    {
        _isRotate = true;
        GameObject.SetActive(true);
       
    }

    private void OnMouseUp()
    {
        _isRotate = false;
        _isAddMove = true;

    }


    void Update()
    {
        //if (Input.GetMouseButtonDown(0)) //В момент нажатия ЛКМ
        //{
        //    startPoint = Input.mousePosition.x; //Мы задаем начальную точку
        //    startRot = player.rotation.eulerAngles.z; //И считываем начальный поворот игрока, чтобы вращать относительно него
        //}
        //if (Input.GetMouseButton(0)) //И пока мы удерживаем мышь
        //{
        //    currPoint = Input.mousePosition.x; //Мы задаем конечную точку
        //    float swipeLength = currPoint - startPoint; //Узнаем расстояние между начальной и конечной точкой
        //    currRot = startRot + swipeLength / 2; //И задаем новый поворот. 2 - это коэффициент чувствительности. Его подбирай сам
        //    player.rotation = Quaternion.Euler(player.rotation.eulerAngles.x, player.rotation.eulerAngles.y, currRot); //Применяем новый поворот на игрока
        //}


        //if(Input.GetMouseButtonDown(0))
        //{
        //    Vector3 screenMousePosition = Input.mousePosition;
        //    Vector3 worldMousePosition = _camera.ScreenToWorldPoint(screenMousePosition);
        //    startPoint = Input.mousePosition.x; //Мы задаем начальную точку
        //    startRot = player.rotation.eulerAngles.z; 
        //}
        //if (Input.GetMouseButton(0))
        //{
        //    float angle = Mathf.Atan2(Input.mousePosition.x - transform.position.x, Input.mousePosition.y - transform.position.y) * Mathf.Rad2Deg - 90;

        //    transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, angle);
        //}

        //float angle = Mathf.Atan2(Input.mousePosition.x - transform.position.x, Input.mousePosition.y - transform.position.y) * Mathf.Rad2Deg - 90;

        //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, angle);

       
            //Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            //float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);
        


        if (_isRotate)
        {

            Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg-90;
            //transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);
            transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);
            _directions = new Vector2 (diference.x, diference.y); 

            //Vector3 screenMousePosition = Input.mousePosition;
            //Vector3 worldMousePosition = _camera.ScreenToWorldPoint(screenMousePosition);
            //_directionMove = new Vector3(0, 0, worldMousePosition.z);
            //transform.Rotate(_directionMove);
        }
        if(_isAddMove)
        {
            GameObject.SetActive(false);
            
            _directions = _directions.normalized;
          
            _force.Move(_directions);
            _isAddMove=false;
        }


        //if (worldMousePosition.y <= 0)
        //{
        //    worldMousePosition.y = 0.5f;
        //}


    }
}
