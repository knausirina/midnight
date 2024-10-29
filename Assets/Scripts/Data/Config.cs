using Assets.Scripts;
using Assets.Scripts.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Config", menuName = "Configs/Config", order = 1)]
public class Config : ScriptableObject
{
    [SerializeField] List<ZoneData> _times;

    private Dictionary<ZoneType, int> _timesByZone;

    public int GetTimeByZone(ZoneType zone)
    {
        if (_timesByZone == null)
        {
            _timesByZone = new Dictionary<ZoneType, int>();
            foreach (ZoneData zoneData in _times)
            {
                _timesByZone[zoneData.ZoneType] = zoneData.Time;
            }
        }

        return _timesByZone[zone];
    }
}