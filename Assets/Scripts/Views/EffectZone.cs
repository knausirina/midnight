using System;
using System.Collections;
using UnityEngine;

public class EffectZone : MonoBehaviour
{
    public Action<int> TriggerBeginAction;
    public Action TriggerEndAction;

    [SerializeField] private ZoneType _zoneType;

    private int _time;
    public int Time => _time;

    public ZoneType TypeZone => _zoneType;

    public void Consruct(Config config)
    {
        _time = config.GetTimeByZone(TypeZone);
    }

    private void OnTriggerEnter(Collider other)
    {
        TriggerBeginAction?.Invoke(Time);
    }

    private void OnTriggerExit(Collider other)
    {
        TriggerEndAction?.Invoke();
    }
}