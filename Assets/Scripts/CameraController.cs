using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private Transform _rocketTransform;

    private float _downLimit = 2;
    private float _lefttLimit = 1;
    private float _rightLimit = -1;


    private void Update()
    {
        CorrectCameraPosition();
    }

    private void CorrectCameraPosition()
    {
        if (_rocketTransform.position.y > _camera.transform.position.y)
        {
            float targetY = _rocketTransform.position.y;
            _camera.transform.position = new Vector3(_camera.transform.position.x, targetY, _camera.transform.position.z);
        } 

        if (_camera.transform.position.y - _rocketTransform.position.y > _downLimit)
        {
            float targetY = _rocketTransform.position.y + _downLimit;

            _camera.transform.position = new Vector3(_camera.transform.position.x, targetY, _camera.transform.position.z);
        }

        if (_camera.transform.position.x - _rocketTransform.position.x > _lefttLimit)
        {
            float targetX = _rocketTransform.position.x + _lefttLimit;
            _camera.transform.position = new Vector3(targetX, _camera.transform.position.y, _camera.transform.position.z);
        }
        if (_camera.transform.position.x - _rocketTransform.position.x <_rightLimit)
        {
            float targetX = _rocketTransform.position.x + _rightLimit;
            _camera.transform.position = new Vector3(targetX, _camera.transform.position.y, _camera.transform.position.z);
        }
    }
}
