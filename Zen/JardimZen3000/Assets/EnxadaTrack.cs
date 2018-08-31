using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
	public Shader _drawshader;
	public GameObject _terrain;
	public Transform[] _enxada;
	[Range(1,500)]
	public float _brushSize;
	[Range(0,1)]
	public float _brushStrength;	

	RaycastHit _groundHit;
	int _layerMask;

	private RenderTexture _splatmap;
	private Material _sandMaterial, _drawMaterial;

	// Use this for initialization
	void Start () {
		_layerMask = LayerMask.GetMask("Ground");
		_drawMaterial = new Material(_drawshader);
		_sandMaterial = _terrain.GetComponent<MeshRenderer>().material;
		_splatmap = new RenderTexture(1024, 1024, 0, RenderTextureFormat.ARGBFloat);
		_sandMaterial.SetTexture("_Splat", _splatmap);

	}

	// Update is called once per frame
	void Update () {

	}
}
