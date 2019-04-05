using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPlayerPain : MonoBehaviour {

    private Renderer _renderer;
    private float _painOpacity;
    public float _painDecayRate;
    private Color _transparentRed = new Color();

	void Start ()
    {
        _painOpacity = 0f;
        _transparentRed.r = 1;
        _transparentRed.g = 0;
        _transparentRed.b = 0;
        _transparentRed.a = 0;
        _renderer = GetComponent<Renderer>();
        _renderer.material.SetColor("_Color", _transparentRed);
	}


    void Update ()
    {
		if (_painOpacity > 0f)
        {
            _painOpacity -= _painDecayRate;
            Color painNow = _transparentRed;
            painNow.a = _painOpacity;
            _renderer.material.SetColor("_Color", painNow);
        }
	}

    public void AddPain ()
    {
        _painOpacity += 0.2f;
        if (_painOpacity > 1f)
            _painOpacity = 1f;
    }
}
