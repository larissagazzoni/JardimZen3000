using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawwithmouse : MonoBehaviour
{
    public Camera _Camera;
    public Shader _drawShader;

    private RenderTexture _splatmap;
    private Material _sandMaterial, _drawMaterial;

    // Use this for initialization
    void Start()
    {
        _drawMaterial = new Material(_drawShader);
        _drawMaterial.SetVector("_Color", Color.red);

        _sandMaterial = GetComponent<MeshRenderer>().material;
        _splatmap = new RenderTexture(1024, 1024, 0, RenderTextureFormat.ARGBFloat);
        _sandMaterial.SetTexture("_Splat", _splatmap);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
