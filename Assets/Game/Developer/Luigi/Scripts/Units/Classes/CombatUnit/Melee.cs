using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : CombatUnit
{
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
    }
    protected override void OnBecameVisible()
    {
        base.OnBecameVisible();
        _range = 1;
    }
}
