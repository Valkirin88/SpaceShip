using System;
using UnityEngine;

public class InputHandler 
{
    public event Action OnAccelerate;
    public event Action OnAccelerateFinished;

    private bool _isPushed;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isPushed = true;
        }
    }
    public void FixedUpdate()
    {
        if (_isPushed)
        {
            OnAccelerate?.Invoke();
            _isPushed = false;
        }
        else
            OnAccelerateFinished?.Invoke();
    }
}
