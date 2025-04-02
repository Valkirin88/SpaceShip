using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField]
    private GameObject _rocketObject;

    [SerializeField]
    private SkyObjectsSetConfig _skyObjectsConfigs;

    [SerializeField]
    private RocketView _rocketView;
    

    [SerializeField]
    private GameObject _groundObject;

    private InputHandler _inputHandler;
    private RocketController _rocketController;
    private SkyObjectsInstantiator _skyObjectsInstantiator;
    private SpecialEffectsHandler _specialEffectsHandler;
    private HeightMeasurer _heightMeasurer;

    private void Awake()
    {
        _inputHandler = new InputHandler();
        _rocketController = new RocketController(_inputHandler, _rocketView);
        _specialEffectsHandler = new SpecialEffectsHandler(_rocketView);
        _heightMeasurer = new HeightMeasurer(_groundObject, _rocketObject);
        _skyObjectsInstantiator = new SkyObjectsInstantiator(_rocketObject.transform, _skyObjectsConfigs, _heightMeasurer);
    }


    private void Update()
    {
        _inputHandler.Update();
        _heightMeasurer.Update();
        _skyObjectsInstantiator.Update();
    }

    private void FixedUpdate()
    {
        _inputHandler.FixedUpdate();
    }

    private void OnDisable()
    {
        _rocketController.Dispose();
        _specialEffectsHandler.Dispose();
    }
}
