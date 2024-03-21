using System.Collections;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _valueInfo;
    [SerializeField] private float _timeStep;
    [SerializeField] private int _valueStep;

    private bool _isCounterRunning;
    private int _currentValue;
    private WaitForSeconds _waitForSeconds;
    
    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_timeStep);   
        _isCounterRunning = false;
        _currentValue = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!_isCounterRunning)
            {
                _isCounterRunning = true;
                
                StartCoroutine(RunCounter());
            }
            else
            {
                _isCounterRunning = false;

                StopCoroutine(nameof(RunCounter));
            }
        }
    }

    private IEnumerator RunCounter()
    {
        while (_isCounterRunning)
        {
            _currentValue += _valueStep;

            _valueInfo.text = _currentValue.ToString();

            yield return _waitForSeconds;
        } 
    }
}
