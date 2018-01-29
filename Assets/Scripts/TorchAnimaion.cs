using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchAnimaion : MonoBehaviour {


    public Material[] _Material = new Material[3];
    Renderer _Rend;
    Coroutine _Coroutine;

    float _Timer;
    int _TextureNumber;

    void Start()
    {
        _Rend = GetComponent<Renderer>();
        _Rend.enabled = true;
        _Rend.sharedMaterial = _Material[0];
    }

    // Update is called once per frame
    void Update ()
    {
		if (_Coroutine == null)
        {
            _Coroutine = StartCoroutine(Torch());
        }
	}

    private IEnumerator Torch()
    {
        _Timer = Random.Range(0.05f, 0.2f);
        yield return new WaitForSeconds(_Timer);
        _TextureNumber = Random.Range(0, _Material.Length);
        _Rend.sharedMaterial = _Material[_TextureNumber];
        _Coroutine = null;
    }
}
