using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

    [SerializeField] Image _Panel;
    Coroutine _Corouting;

    private void Start()
    {
        _Corouting = StartCoroutine(FadingIn());
    }

    IEnumerator FadingIn()
    {
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            _Panel.color = new Color(0, 0, 0, i);
            yield return null;
        }
    }
}
