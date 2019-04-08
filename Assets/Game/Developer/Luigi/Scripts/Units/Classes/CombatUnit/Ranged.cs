using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged : CombatUnit
{
    private float _shotTimer;
    private float _startShotTimer;
    private float _bulletDirection;
    private bool _shooting;

    protected override void Start()
    {
        base.Start();
        _range = 4;
        //Assign shooting variables
        _shotTimer -= _shotTimer;
        _bulletDirection = 0f;
        _startShotTimer = 2.5f;
    }
    protected override void Update()
    {
        base.Update();
        #region shooting
        if (_state == UnitState.interact)
        {
            _shooting = true;
            //shoot shot
            if (_shotTimer <= 0f && _shooting)
            {
                //Rotate shot
                float rotation = 0;
                if (tag == "Player2")
                {
                    rotation = 180;
                }
                else
                {
                    rotation = 0;
                }
                //Spawn Projectile and reset shot timer
                _objectPool.SpawnFromPool("Arrow", new Vector2(transform.position.x  * _direction, transform.position.y), Quaternion.Euler(0f, rotation, 0f));
                _shotTimer = _startShotTimer;
            }
            else
            {
                _shotTimer -= Time.deltaTime;
            }
        }
        else
        {
            _shooting = false;
            _state = UnitState.normal;
        }
        #endregion
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();       
    }
    protected override void OnBecameVisible()
    {
        base.OnBecameVisible();
        _range = 4;
    }
}
