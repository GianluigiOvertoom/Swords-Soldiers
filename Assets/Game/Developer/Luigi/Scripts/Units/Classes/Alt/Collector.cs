using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : Unit
{
    public bool _objectiveComplete;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        if (!_objectiveComplete)
        {
            _direction = 1;
        }
        else
        {
            _direction = -1;
        }
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    private void OnBecameVisible()
    {
        _objectiveComplete = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collect"))
        {
            _objectiveComplete = true;
        }
        if (collision.tag == this.gameObject.tag && _objectiveComplete)
        {
            this.gameObject.SetActive(false);
        }
    }
}
