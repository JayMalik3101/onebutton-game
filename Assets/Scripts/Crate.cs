using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{

    Rigidbody2D _RidBod;
    RigidbodyConstraints _Constrains;
    Coroutine _Coroutine;
    Animator _Anim;

    private void Start()
    {
        _RidBod = GetComponent<Rigidbody2D>();
        _Anim = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_Coroutine == null)
        {
            _Coroutine = StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall()
    {
        _Anim.SetBool("Fall", true);
        yield return new WaitForSeconds(1);
        _RidBod.constraints = RigidbodyConstraints2D.None;
        _RidBod.constraints = RigidbodyConstraints2D.FreezePositionX;
        _RidBod.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
