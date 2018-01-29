using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Idle, Run, Jump, Victory
}

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public State _State;

    [SerializeField] int _Speed = 10;
    [SerializeField] float _JumpSpeed = 1700, _Grav = 10, _KeyPressTimer;
    Rigidbody2D _RidBod;
    BoxCollider2D _BoxCollider;
    bool _JumpActive;

    AudioSource _AudioSource;
    [SerializeField] AudioClip[] _AudioClip = new AudioClip[13];
    Animator _Anim;

    void Start()
    {
        _RidBod = GetComponent<Rigidbody2D>();
        _RidBod.gravityScale = _Grav;
        _BoxCollider = GetComponent<BoxCollider2D>();
        _Anim = GetComponent<Animator>();
        _AudioSource = GetComponentInChildren<AudioSource>();
    }

    void FixedUpdate()
    {
        switch (_State)
        {
            case State.Idle:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _State = State.Jump;
                    _RidBod.AddForce(transform.up * _JumpSpeed);
                    _Anim.SetBool("Running", true);
                    _Anim.SetBool("IsJumping", true);
                    _AudioSource.pitch = Random.Range(0.9f, 1.1f);
                    _AudioSource.PlayOneShot(_AudioClip[Random.Range(1, _AudioClip.Length)]);
                }
            break;

            case State.Run:
                if (Input.GetKey(KeyCode.Space) && _RidBod.velocity.y == 0)
                {
                    _State = State.Jump;
                    _RidBod.AddForce(transform.up * _JumpSpeed);
                    _Anim.SetBool("IsJumping", true);
                    _AudioSource.pitch = Random.Range(0.9f, 1.1f);
                    _AudioSource.PlayOneShot(_AudioClip[Random.Range(1, _AudioClip.Length)]);
                }

               transform.position = new Vector3(transform.position.x + _Speed * Time.deltaTime, transform.position.y, transform.position.z);

                for (int i = 0; i < 5; i++)
                {
                    RaycastHit2D rayHitDwn = Physics2D.Raycast(new Vector2(((transform.position.x - (transform.localScale.x / 2)) + (transform.localScale.x / 5) * i) + 0.1f, transform.position.y - 0.51f), Vector2.down, 0.5f);
                    RaycastHit2D rayHitRght = Physics2D.Raycast(new Vector2(transform.position.x + 0.51f, ((transform.position.y + (transform.localScale.y / 2)) - (transform.localScale.y / 7) * i) - 0.1f), Vector2.right, 0.1f);
                    RaycastHit2D rayHitLft = Physics2D.Raycast(new Vector2(transform.position.x - 0.51f, ((transform.position.y + (transform.localScale.y / 2)) - (transform.localScale.y / 7) * i) - 0.1f), Vector2.left, 0.1f);


                    if ((rayHitRght && _Speed > 0) || (rayHitLft && _Speed < 0))
                    {
                        _Speed *= -1;
                        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                    }
                }
                break;
            case State.Jump:
                transform.position = new Vector3(transform.position.x + _Speed * Time.deltaTime, transform.position.y, transform.position.z);

                for (int i = 0; i < 5; i++)
                {
                    RaycastHit2D rayHitDwn = Physics2D.Raycast(new Vector2(((transform.position.x - (transform.localScale.x / 2)) + (transform.localScale.x / 5) * i) + 0.1f, transform.position.y - 0.51f), Vector2.down, 0.5f);
                    RaycastHit2D rayHitRght = Physics2D.Raycast(new Vector2(transform.position.x + 0.51f, ((transform.position.y + (transform.localScale.y / 2)) - (transform.localScale.y / 7) * i) - 0.1f), Vector2.right, 0.1f);
                    RaycastHit2D rayHitLft = Physics2D.Raycast(new Vector2(transform.position.x - 0.51f, ((transform.position.y + (transform.localScale.y / 2)) - (transform.localScale.y / 7) * i) - 0.1f), Vector2.left, 0.1f);


                    if (rayHitDwn && _RidBod.velocity.y < 0)
                    {
                        _State = State.Run;
                        _Anim.SetBool("IsJumping", false);
                        transform.position = (new Vector3(transform.position.x, (transform.position.y - rayHitDwn.distance)));
                    }


                    if ((rayHitRght && _Speed > 0) || (rayHitLft && _Speed < 0))
                    {
                        _Speed *= -1;
                        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                    }
                }
                break;
            case State.Victory:
                _Anim.SetBool("Victory", true);
                break;
        }
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < 5; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(new Vector3(((transform.position.x - (transform.localScale.x / 2)) + (transform.localScale.x / 5) * i) + 0.1f, transform.position.y - 0.51f, transform.position.z), Vector3.down * 0.1f);
            Gizmos.DrawRay(new Vector3(transform.position.x + 0.51f, ((transform.position.y + (transform.localScale.y / 2)) - (transform.localScale.y / 7) * i) - 0.1f, transform.position.z), Vector2.right * 0.1f);
            Gizmos.DrawRay(new Vector3(transform.position.x - 0.51f, ((transform.position.y + (transform.localScale.y / 2)) - (transform.localScale.y / 7) * i) - 0.1f, transform.position.z), Vector2.left * 0.1f);
        }   
    }
}
