using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperCoolCamera : MonoBehaviour {
    [SerializeField]
    private Transform m_FollowObject;                               // The object that needs to be followed

    [SerializeField]
    private float m_Speed;                                          // How fast the camera follows the object
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 Position = transform.position;
        Position.x = Mathf.Lerp(transform.position.x, m_FollowObject.position.x, m_Speed * Time.deltaTime);
        Position.y = Mathf.Lerp(transform.position.y, m_FollowObject.position.y, m_Speed * Time.deltaTime) + 0.8f;
        Position.z = transform.position.z;
        transform.position = Position;
    }
}
