using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField]
    private GameObject _rocketObject;

    [SerializeField]
    private SkyObjectsSetConfig _skyObjectsConfigs;

    [SerializeField]
    private RocketController _rocketController;

    [SerializeField]
    private RocketFlame _rocketFlame;

    [SerializeField]
    private GameObject _groundObject;

    private SkyObjectsInstantiator _skyObjectsInstantiator;
    private HeightMeasurer _heightMeasurer;

    private void Awake()
    {
        _rocketFlame.Initialize(_rocketController);
        _heightMeasurer = new HeightMeasurer(_groundObject, _rocketObject);
        _skyObjectsInstantiator = new SkyObjectsInstantiator(_rocketObject.transform, _skyObjectsConfigs, _heightMeasurer);
    }


    private void Update()
    {
        _heightMeasurer.Update();
        _skyObjectsInstantiator.Update();
    }
}
