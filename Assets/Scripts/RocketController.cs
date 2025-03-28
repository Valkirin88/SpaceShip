using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rockerRigidbody;
    [SerializeField]
    private int _speed;
    private void FixedUpdate()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            _rockerRigidbody.AddForce(Vector2.up * _speed);
        }
    }
}
