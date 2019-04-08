using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Support : Unit
{
    protected float _range;
    protected float _originOffset = 0.5f;

    protected override void Start()
    {
        base.Start();
        _range = 1;
    }
    protected override void Update()
    {
        base.Update();
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        #region Flip depending on player
        float flipPlayer = _direction;
        if (this.gameObject.tag == "Player1")
        {
            flipPlayer = _direction;
        }
        if (this.gameObject.tag == "Player2")
        {
            flipPlayer = -_direction;
        }
        #endregion
        //Shoot RayCast2D
        CheckRaycast(new Vector2(flipPlayer, 0));
    }
    private RaycastHit2D CheckRaycast(Vector2 direction)
    {
        float directionOffset = _originOffset * (direction.x > 0 ? 1 : -1);
        int layer = 0;

        if (this.tag == "Player1")
        {
            layer = 8;
        }
        else
        {
            layer = 9;
        }
        float rayHeight = 5f;
        Vector2 rayLength = new Vector2(0.5f, rayHeight);
        Vector2 startingPos = new Vector2(transform.position.x + directionOffset, transform.position.y);
        RaycastHit2D hitInfo = Physics2D.BoxCast(startingPos, rayLength, 0, direction, _range, 1 << layer);
        //DebugRay
        Debug.DrawRay(startingPos, direction * _range, Color.red);
        
        //Check if collider hits something
        if (hitInfo.collider != null)
        {
            if (this.tag == "Player1")
            {
                if (hitInfo.collider.CompareTag("Player1"))
                {
                    _state = UnitState.interact;
                }
                else
                {
                    _state = UnitState.normal;
                }
            }
            if (this.tag == "Player2")
            {
                if (hitInfo.collider.CompareTag("Player2"))
                {
                    _state = UnitState.interact;
                }
                else
                {
                    _state = UnitState.normal;
                }
            }
        }
        else
        {
            _state = UnitState.normal;
        }
        //Return Ray
        return hitInfo;
    }

    protected override void OnBecameVisible()
    {
        base.OnBecameVisible();
        _range = 1;
    }
}
