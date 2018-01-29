using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour {

    [SerializeField] private Collider2D m_NextLevel;
    [SerializeField] private string m_NextScene;
    Player _Player;

    Canvas _Canvas;
    [SerializeField] Image _Panel;
    Coroutine _Corouting;

    private void Start()
    {
        _Player = FindObjectOfType<Player>();   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            _Player._State = State.Victory;

            if (_Corouting == null)
            {
                _Corouting = StartCoroutine(FadeOut());
            }
        }
    }

    IEnumerator FadeOut()
    {
        for (float i = 0; i <= 1f; i += Time.deltaTime)
        {
            _Panel.color = new Color(0, 0, 0, i);
            yield return null;
        }

        SceneManager.LoadScene(m_NextScene);
    }
}
