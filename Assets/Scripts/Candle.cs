using UnityEngine;

public class Candle : MonoBehaviour
{
    private ParticleSystem _particleSystem;

    private Color Color = new Color(247/255, 250/255, 221/255, 1);

    private bool _isStartTimer = false;
    private float _remainTime = 0;
    private float _maxTime;
    private bool _isHasFire = true;

    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }
    public void Blow(int seconds)
    {
        if (!_isHasFire)
        {
            return;
        }

        if (seconds == 0)
        {
            SetAlpha(0);
             _isHasFire = false;
        }
        else
        {
            _maxTime = seconds;
            _remainTime = seconds;
            _isStartTimer = true;
        }
    }

    public void EndBlow()
    {
        _isStartTimer = false;
        if (_isHasFire)
        {
            SetAlpha(1);
        }
    }

    private void Update()
    {
        if (_isStartTimer)
        {
            _remainTime -= Time.deltaTime;
            if (_remainTime <= Mathf.Epsilon)
            {
                _isStartTimer = false;
                Blow(0);
            }
            else
            {
                var alpha =  _remainTime / _maxTime;
                SetAlpha(alpha);
            }
        }
    }

    private void SetAlpha(float alpha)
    {
        var main = _particleSystem.main;
        var color = main.startColor.color;
        color.a = alpha;
        main.startColor = color;

        if (alpha == 0)
        {
            _isHasFire = false;
        }
    }
}
