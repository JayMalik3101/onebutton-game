using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    [SerializeField] private Image m_PlayImage;
    [SerializeField] private Image m_QuitImage;
    private float m_MenuTimer = 6;
    // 1 is play 2 is quit
    private int m_MenuOption;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        m_MenuTimer -= Time.deltaTime;
        m_PlayImage.color = Color.black;
        m_QuitImage.color = Color.red;
        if (m_MenuTimer > 3 && m_MenuTimer <= 6)
        {
            m_PlayImage.color = Color.green;
            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene("Level1");
            }
        }
        else if( m_MenuTimer >= 0 && m_MenuTimer <= 3)
        {
            m_QuitImage.color = Color.green;
            if (Input.GetKey(KeyCode.Space))
            {
                Application.Quit();
            }
        }
        else
        {
            m_MenuTimer = 6;
        }
    }
}
