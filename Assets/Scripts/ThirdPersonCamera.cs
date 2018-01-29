// 3rd person camera script 1.0.1 for unity by: Kaj Rumpff

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{

    [SerializeField]
    private Transform m_FollowObject;                               // The object that needs to be followed

    [SerializeField]
    private bool m_lerpToStart;                                     // If the camera should lerp to the start point

    [SerializeField]
    private float m_distance;                                       // The distance of the camera to the object

   /* [SerializeField]
    [Range(0.0f, 89.99f)]
    private float m_heightAngle;    */                                // The angle of the camera on the Y axis

    [SerializeField]
    [Range(0.0f, 20.0f)]
    private float m_lerpInterpolation;                              // The interpolation for all the lerps

    private float m_xDest, m_yDest, m_zDest;                        // The position where the camera has to go to

    private float m_x, m_y, m_z;                                    // The positions of the camera (these are lerped with the dest positions)

    private float m_objectX, m_objectY, m_objectZ, m_objectRotY;    // These are the positions and rotation of the object that needs to be followed

    private void Start()
    {
        if (!m_lerpToStart)
        {
            m_xDest = m_objectX + Mathf.Sin((m_objectRotY - 180) * Mathf.Deg2Rad) * (Mathf.Cos( Mathf.Deg2Rad) * m_distance);
            m_yDest = m_objectY + Mathf.Sin( Mathf.Deg2Rad) * m_distance;
            m_zDest = m_objectZ + Mathf.Cos((m_objectRotY - 180) * Mathf.Deg2Rad) * (Mathf.Cos(Mathf.Deg2Rad) * m_distance);

            m_x = m_xDest;
            m_y = m_yDest;
            m_z = m_zDest;
        }
    }

    void FixedUpdate()
    {
        UpdateVariables();

        // Calculate the final position
        m_xDest = m_objectX + Mathf.Sin((m_objectRotY - 180) * Mathf.Deg2Rad) * (Mathf.Cos( Mathf.Deg2Rad) * m_distance);
        m_yDest = m_objectY + Mathf.Sin(Mathf.Deg2Rad) * m_distance;
        m_zDest = m_objectZ + Mathf.Cos((m_objectRotY - 180) * Mathf.Deg2Rad) * (Mathf.Cos(Mathf.Deg2Rad) * m_distance);

        // Lerp the position and rotation
        m_x = Mathf.Lerp(m_x, m_xDest, LerpInterpolation());
        m_y = Mathf.Lerp(m_y, m_yDest, LerpInterpolation());
        m_z = Mathf.Lerp(m_z, m_zDest, LerpInterpolation());

        // Apply the new values
        transform.position = new Vector3(m_x, m_y, m_z);
        transform.LookAt(m_FollowObject);
    }

    private void UpdateVariables()
    {
        m_x = transform.position.x;
        m_y = transform.position.y;
        m_z = transform.position.z;

        m_objectX = m_FollowObject.position.x;
        m_objectY = m_FollowObject.position.y;
        m_objectZ = m_FollowObject.position.z;

        m_objectRotY = m_FollowObject.eulerAngles.y;
    }

    private float LerpInterpolation()
    {
        return m_lerpInterpolation * Time.deltaTime;
    }
}
