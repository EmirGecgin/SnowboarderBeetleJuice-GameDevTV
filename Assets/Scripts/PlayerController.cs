using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int torqueAmount;
    private Rigidbody2D _rb2D;
    private SurfaceEffector2D _surfaceEffector;
    private bool _canMove=true;
    private float _rotationAngle;

    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _surfaceEffector = FindObjectOfType<SurfaceEffector2D>();
    }
    private void Update()
    {
        AddTorque();
        RespondToBooost();
        _rotationAngle = Mathf.Abs(_rb2D.rotation);
        if (_rotationAngle >= 360.0f)
        {
            Debug.Log("Full Lock!");
            // Puan ekledikten sonra karakterin dönüşünü sıfırlayabilirsiniz
            //_rb2D.angularVelocity = 0.0f;
            _rb2D.SetRotation(0.0f);
        }
    }
    public void DisableController()
    {
        _canMove = false;
    }
    private void RespondToBooost()
    {
        if (_canMove)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                _surfaceEffector.speed = 25;
            }
            else
            {
                _surfaceEffector.speed = 18;
            }    
        }
    }

    private void AddTorque()
    {
        if (_canMove)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                _rb2D.AddTorque(torqueAmount*Time.deltaTime);
            }
            else if(Input.GetKey(KeyCode.RightArrow))
            {
                _rb2D.AddTorque(-torqueAmount*Time.deltaTime);
            }    
        }
    }
}
