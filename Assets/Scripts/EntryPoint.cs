using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField]
    private RocketController _rocketController;

    [SerializeField]
    private RocketFlame _rocketFlame;

    private void Awake()
    {
        _rocketFlame.Initialize(_rocketController);
    }
}
