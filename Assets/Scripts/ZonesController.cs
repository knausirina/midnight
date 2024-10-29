using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class ZonesController : MonoBehaviour
    {
        [SerializeField] private EffectZone[] effectZones;
        [SerializeField] private Config _config;
        [SerializeField] private Candle _candle;

        private void Awake()
        {
            foreach (var effectZone in effectZones)
            {
                effectZone.Consruct(_config);
                effectZone.TriggerBeginAction += TriggerBeginAction;
                effectZone.TriggerEndAction += TriggerEndAction;
            }
        }

        private void TriggerBeginAction(int seconds)
        {
            _candle.Blow(seconds);
        }

        private void TriggerEndAction()
        {
            _candle.EndBlow();
        }

        private void OnDestroy()
        {
            foreach (var effectZone in effectZones)
            {
                effectZone.TriggerBeginAction -= TriggerBeginAction;
                effectZone.TriggerEndAction -= TriggerEndAction;
            }
        }
    }
}