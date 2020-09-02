using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class forceShadows : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        GetComponent<Renderer>().receiveShadows = true;
    }
}