using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stay : MonoBehaviour
{
    private bool _isStay = true;

    public bool IsStay()
    {
        return _isStay;
    }

    public void Stayd(bool stay)
    {
        _isStay = stay;
        Debug.Log("2");
      
    }
}
