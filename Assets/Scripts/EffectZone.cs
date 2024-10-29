using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class EffectZone : MonoBehaviour
    {
        [SerializeField] private ZoneType _zoneType;

        private int _time;
        public int Time => _time;

        public Action<int> TriggerBeginAction;
        public Action TriggerEndAction;

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
}