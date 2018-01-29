using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Death : MonoBehaviour {

    Collider2D _DeathTrigger;
    Canvas _Canvas;
    [SerializeField] Image _Panel;
    Coroutine _Corouting;

    private void Start()
    {
        _DeathTrigger = GetComponent<Collider2D>();
        _Canvas = GetComponent<Canvas>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            if (_Corouting == null)
            {
                _Corouting = StartCoroutine(Kill());
            }

            
        }
    }

    IEnumerator Kill()
    {
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            _Panel.color = new Color(0, 0, 0, i);
            yield return null;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
