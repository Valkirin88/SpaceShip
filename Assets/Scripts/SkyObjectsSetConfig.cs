using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkyObjectsSetConfig", menuName = "ScriptableObject/SkyObjectSet")]
public class SkyObjectsSetConfig : ScriptableObject
{
    [SerializeField]
    private List<GameObject> _skyObjects;

    public List<GameObject> SkyObjects  => _skyObjects;
}
