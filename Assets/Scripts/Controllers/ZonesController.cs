using UnityEngine;

public class ZonesController : MonoBehaviour
{
    [SerializeField] private EffectZone[] effectZones;
    [SerializeField] private Config _config;
    [SerializeField] private CandleView _candleView;

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
        _candleView.Blow(seconds);
    }

    private void TriggerEndAction()
    {
        _candleView.EndBlow();
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