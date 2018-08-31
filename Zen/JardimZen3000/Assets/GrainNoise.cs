using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrainNoise : MonoBehaviour {
	public Shader _ReplaceSandShader;
	[Range(0.001f, 0.1f)]
	public float _GrainAmount;
	[Range(0,1)]
	public float _GrainOpacity;

	private Material _ReplaceSandMat;
	private MeshRenderer _meshRenderer;

	// Use this for initialization
	void Start () {
		_meshRenderer = GetComponent<MeshRenderer>();
		_ReplaceSandMat = new Material(_ReplaceSandShader);

	}

	// Update is called once per frame
	void Update () {
		_ReplaceSandMat.SetFloat("_GrainAmount", _GrainAmount);
		_ReplaceSandMat.SetFloat("_GrainOpacity", _GrainOpacity);
		RenderTexture grain = (RenderTexture)_meshRenderer.material.GetTexture("_Splat");
		RenderTexture temp = RenderTexture.GetTemporary(grain.width, grain.height, 0, RenderTextureFormat.ARGBFloat);
		Graphics.Blit(grain, temp, _ReplaceSandMat);
		Graphics.Blit(temp, grain);
		_meshRenderer.material.SetTexture("_Splat", grain);
		RenderTexture.ReleaseTemporary(temp);

	}
}
