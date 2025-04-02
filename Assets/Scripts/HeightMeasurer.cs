using UnityEngine;

public class HeightMeasurer 
{
    private GameObject _groundObject;
    private GameObject _rocketObject;
    private float _height;

    public float Height => _height;
    public HeightMeasurer(GameObject groundObject, GameObject rocketObject)
    {
        _groundObject = groundObject;
        _rocketObject = rocketObject;
    }

    public void Update()
    {
        MeasureCurrentHeight();
    }

    private void MeasureCurrentHeight()
    {
        _height = _rocketObject.transform.position.y - _groundObject.transform.position.y;
    }
}
