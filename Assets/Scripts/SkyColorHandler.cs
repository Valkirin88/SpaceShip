using UnityEngine;
using UnityEngine.UI;

public class SkyColorHandler : MonoBehaviour
{
    [SerializeField]
    private Image _skyImage;
    [SerializeField]
    private SpriteRenderer _spriteRenderer;


    [SerializeField]
    private Transform _groundTransform;
    [SerializeField]
    private Transform _rocketTransform;


    [SerializeField]
    private Color _blueSkyColor;

    [SerializeField]
    private Color _spaceColor;

    private float _distance;
    private float _maxDistance = 180;

    private void Update()
    {

        _distance = Vector2.Distance(_rocketTransform.position, _groundTransform.position);
        float distanceClamped = Mathf.Clamp01(_distance/_maxDistance);

        

        Color color = Color.Lerp(_blueSkyColor, _spaceColor, distanceClamped);
        Color colora = _spriteRenderer.color;
        colora.a = distanceClamped ;
        Debug.Log(colora.a);
        _spriteRenderer.color = colora;
        _skyImage.color = color;
    }
}
