using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private bool _ifEnabled;
    private int _currentValue;
    private float _timeStep;
    private int _valueStep;

    
    void Start()
    {
        _ifEnabled = false;
        _currentValue = 0;
        _timeStep = 0.5f;
        _valueStep = 1;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!_ifEnabled)
            {
                _ifEnabled = true;
                
                StartCoroutine(RunCounter());
            }
            else
            {
                _ifEnabled = false;

                StopCoroutine(nameof(RunCounter));
            }
        }
    }

    private IEnumerator RunCounter()
    {
        while (_ifEnabled)
        {
            _currentValue += _valueStep;

            Debug.Log(_currentValue);

            yield return new WaitForSeconds(_timeStep);
        } 
    }
}