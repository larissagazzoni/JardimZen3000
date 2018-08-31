﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawWithMouse : MonoBehaviour {
    public Camera _camera;
    public Shader _drawshader;
    [Range(1,500)]
    public float _brushSize;
    [Range(0,1)]
    public float _brushStrength;

    private RenderTexture _splatmap;
    private Material _sandMaterial, _drawMaterial;
    private RaycastHit _hit;

    // Use this for initialization
	void Start () {
        _drawMaterial = new Material(_drawshader);
        _drawMaterial.SetVector("_Color", Color.red);

        _sandMaterial = GetComponent<MeshRenderer>().material;
        _splatmap = new RenderTexture(1024, 1024, 0, RenderTextureFormat.ARGBFloat);
        _sandMaterial.SetTexture("_Splat", _splatmap);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Mouse0))
        {
            if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out _hit))
            {
                _drawMaterial.SetVector("_Coordinate", new Vector4(_hit.textureCoord.x, _hit.textureCoord.y, 0, 0));
                _drawMaterial.SetFloat("_Strength", _brushStrength);
                _drawMaterial.SetFloat("_Size", _brushSize);
                RenderTexture temp = RenderTexture.GetTemporary(_splatmap.width, _splatmap.height, 0, RenderTextureFormat.ARGBFloat);
                Graphics.Blit(_splatmap, temp);
                Graphics.Blit(temp, _splatmap, _drawMaterial);
                RenderTexture.ReleaseTemporary(temp);
            }
        }

	}
    private void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, 256, 256), _splatmap, ScaleMode.ScaleToFit, false, 1);
    }
}
