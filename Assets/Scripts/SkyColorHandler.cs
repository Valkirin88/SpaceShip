using UnityEngine;
using UnityEngine.UI;

public class SkyColorHandler : MonoBehaviour
{
    [SerializeField]
    private Image _skyImage;

    [SerializeField]
    private Transform _groundTransform;
    [SerializeField]
    private Transform _rocketTransform;


    [SerializeField]
    private Color _blueSkyColor;

    [SerializeField]
    private Color _spaceColor;

    private float _distance;
    private float _maxDistance = 100;

    private void Update()
    {
        _distance = Vector2.Distance(_rocketTransform.position, _groundTransform.position);

        float distanceClamped = Mathf.Clamp01(_distance/_maxDistance);

        Color color = Color.Lerp(_blueSkyColor, _spaceColor, distanceClamped);

        _skyImage.color = color;
    }
}
