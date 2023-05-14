using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UVScroller : MonoBehaviour
{
    [SerializeField] float _speed = 1f;
    [SerializeField] Graphic _renderer;
    const string parameterName = "_Offset";



    private void Update()
    {
        var current = _renderer.material.GetTextureOffset(parameterName);
        _renderer.material.SetTextureOffset(parameterName, new Vector2(current.x + _speed * Time.unscaledDeltaTime, current.y));
    }
}
