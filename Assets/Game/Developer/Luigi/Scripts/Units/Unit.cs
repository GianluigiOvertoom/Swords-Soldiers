
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitState
{
    normal,
    interact,
    die
}

public class Unit : MonoBehaviour
{
    //Assign Essentials
    protected Rigidbody2D _rb;
    protected Animator _anim;
    protected ObjectPooler _objectPool;
    //Assign Variables
    protected float _mSpeed;
    protected float _direction;
    //Assign Sate
    protected UnitState _state;

    protected virtual void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        //_anim = GetComponent<Animator>();
        _objectPool = ObjectPooler.Instance;
        _mSpeed = 5;
        _state = UnitState.normal;
    }
    protected virtual void Update()
    {
        //Flip units depending on player
        if (this.gameObject.tag == "Player1")
        {
            if (_direction == 1)
            {
                _rb.transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            else if (_direction == -1)
            {
                _rb.transform.rotation = new Quaternion(0, 180, 0, 0);
            }
        }
        if (this.gameObject.tag == "Player2")
        {
            if (_direction == 1)
            {
                _rb.transform.rotation = new Quaternion(0, 180, 0, 0);
            }
            else if (_direction == -1)
            {
                _rb.transform.rotation = new Quaternion(0, 0, 0, 0);
            }
        }
    }
    protected virtual void FixedUpdate()
    {
        //Handle movement
        if (_state == UnitState.normal)
        {
            if (this.gameObject.tag == "Player1")
            {
                _rb.velocity = new Vector2(_direction * _mSpeed, _rb.velocity.y);
            }
            if (this.gameObject.tag == "Player2")
            {
                _rb.velocity = new Vector2(-_direction * _mSpeed, _rb.velocity.y);
            }
        }
        else
        {
            _rb.velocity = Vector2.zero;
        }
    }
    protected virtual void OnBecameVisible()
    {
        _direction = 1;
    }
}
