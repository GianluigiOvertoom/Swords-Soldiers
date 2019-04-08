using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : Controller
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _spawnCollector = true;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            _spawnMelee = true;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            _spawnRanged = true;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            _spawnSupport = true;
        }
    }
}
