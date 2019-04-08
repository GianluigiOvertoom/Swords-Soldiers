using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : Controller
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.A))
        {
            _spawnCollector = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _spawnMelee = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _spawnRanged = true;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            _spawnSupport = true;
        }

    }
}
