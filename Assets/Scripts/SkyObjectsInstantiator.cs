using UnityEngine;

public class SkyObjectsInstantiator 
{

    private Transform _rocketTransform;
    private SkyObjectsSetConfig _skyObjectsSetConfig;
    private HeightMeasurer _heightMeasurer;

    private float _posX;
    private float _posY;
    private float _currentHeight;
    private float _lastInstantiationHeight;


    public SkyObjectsInstantiator(Transform rocketObject, SkyObjectsSetConfig skyObjectsSetConfig, HeightMeasurer heightMeasurer)
    {
        _rocketTransform = rocketObject;
        _skyObjectsSetConfig = skyObjectsSetConfig;
        _heightMeasurer = heightMeasurer;

        InstantiateSkyObject();
    }

    public void Update()
    {
        CalculateHeightForInstantiation();
    }

    private void InstantiateSkyObject()
    {
        _lastInstantiationHeight = _heightMeasurer.Height;
        GameObject skyObject = _skyObjectsSetConfig.SkyObjects[Random.Range(0, _skyObjectsSetConfig.SkyObjects.Count)];
        Vector3 position = GetInstantiatePosition();
        var obstacle = UnityEngine.Object.Instantiate(skyObject, position, Quaternion.Euler(0,0,90));
    }

    private void CalculateHeightForInstantiation()
    {
        _currentHeight = _heightMeasurer.Height;
        if (_currentHeight - _lastInstantiationHeight > Random.Range(10,15))
            InstantiateSkyObject();
    }

    private Vector3 GetInstantiatePosition()
    {
        //int rangeChoice = Random.Range(0, 2);
        //if (rangeChoice == 0)
        //    _posX = Random.Range(4.5f, 6);
        //else
        //    _posX = Random.Range(-6, -4.5f);

            _posX = Random.Range(-6, 2f);
        _posY = Random.Range(8, 13);

        Vector3 position = new Vector3(_rocketTransform.position.x + _posX, _rocketTransform.position.y + _posY, _rocketTransform.position.z);
        return position;
    }
}
