using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private Transform _rocketTransform;

    private Vector2 _newCameraPosition;
    private float _smoothSpeed = 5f;

    private void Update()
    {
        CheckRocketPosition();
    }

    private void CheckRocketPosition()
    {
        if (_rocketTransform.position.y > _camera.transform.position.y)
        {
            float targetY = _rocketTransform.position.y;
            _camera.transform.position = new Vector3(_camera.transform.position.x, targetY, _camera.transform.position.z);
        } 

        if (_camera.transform.position.y - _rocketTransform.position.y > 2)
        {
            float targetY = _rocketTransform.position.y + 2;
            _camera.transform.position = new Vector3(_camera.transform.position.x, targetY, _camera.transform.position.z);
        }

        if (_camera.transform.position.x - _rocketTransform.position.x > 1)
        {
            float targetX = _rocketTransform.position.x + 1;
            _camera.transform.position = new Vector3(targetX, _camera.transform.position.y, _camera.transform.position.z);
        }
        if (_camera.transform.position.x - _rocketTransform.position.x < -1)
        {
            float targetX = _rocketTransform.position.x -1;
            _camera.transform.position = new Vector3(targetX, _camera.transform.position.y, _camera.transform.position.z);
        }
    }

    private void CameraFollowUp()
    {
        float targetY = _rocketTransform.position.y;
        float currentY = _camera.transform.position.y;
        float newY = Mathf.Lerp(currentY, targetY, _smoothSpeed * Time.deltaTime);
        _camera.transform.position = new Vector3(_camera.transform.position.x, newY, _camera.transform.position.z);
    }
}
