using System.Collections.Generic;
using UnityEngine;

public class CapsulList : MonoBehaviour
{
    private List<Capsul> _capsuls;

    private void Awake()
    {
        _capsuls = new();
    }

    public void Add(Capsul capsul)
    {
        _capsuls.Add(capsul);
    }

    public Capsul GetRandomCapsul()
    {
        Capsul capsul;

        capsul = _capsuls[Random.Range(0, _capsuls.Count)];

        return capsul;
    }
}