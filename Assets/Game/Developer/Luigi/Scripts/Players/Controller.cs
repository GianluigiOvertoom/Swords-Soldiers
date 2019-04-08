using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    protected ObjectPooler _objectPool;
    [SerializeField]
    protected GameObject _tower;

    protected bool _spawnCollector;
    protected bool _spawnMelee;
    protected bool _spawnRanged;
    protected bool _spawnSupport;

    protected virtual void Start()
    {
        _objectPool = ObjectPooler.Instance;
        _spawnCollector = false;
        _spawnMelee = false;
        _spawnRanged = false;
        _spawnSupport = false;
    }

    protected virtual void Update()
    {
        _tower.layer = this.gameObject.layer;
        //Spawn collector unit
        if (_spawnCollector)
        {
            SpawnCollector();
            _spawnCollector = false;
        }
        //spawn melee unit
        if (_spawnMelee)
        {
            SpawnMelee();
            _spawnMelee = false;
        }
        //spawn ranged unit
        if (_spawnRanged)
        {
            SpawnRanged();
            _spawnRanged = false;
        }
        //spawn support unit
        if (_spawnSupport)
        {
            SpawnSupport();
            _spawnSupport = false;
        }
    }
    public void SpawnCollector()
    {
        GameObject unit;
        unit = _objectPool.SpawnFromPool("Collector", _tower.transform.position, Quaternion.identity);
        unit.tag = this.gameObject.tag;
        unit.layer = this.gameObject.layer;
    }
    public void SpawnMelee()
    {
        GameObject unit;
        unit = _objectPool.SpawnFromPool("Melee", _tower.transform.position, Quaternion.identity);
        unit.tag = this.gameObject.tag;
        unit.layer = this.gameObject.layer;
    }
    public void SpawnRanged()
    {
        GameObject unit;
        unit = _objectPool.SpawnFromPool("Ranged", _tower.transform.position, Quaternion.identity);
        unit.tag = this.gameObject.tag;
        unit.layer = this.gameObject.layer;
    }
    public void SpawnSupport()
    {
        GameObject unit;
        unit = _objectPool.SpawnFromPool("Support", _tower.transform.position, Quaternion.identity);
        unit.tag = this.gameObject.tag;
        unit.layer = this.gameObject.layer;
    }
}
