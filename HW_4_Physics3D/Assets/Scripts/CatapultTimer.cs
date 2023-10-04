using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CatapultTimer : MonoBehaviour
{

    [SerializeField] private float _catapultTimer = 5f;
    [SerializeField] private float _currentTime = 0f;

    public GameObject Catapult;

    public TextMeshProUGUI Text;

    private int _decimalPlacesToShow = 0;

    public bool isCountingDown = false;

    public void Update()
    {
        if (isCountingDown)
        {
            _currentTime -= Time.deltaTime;
            Text.text = _currentTime.ToString("" + _decimalPlacesToShow);

            if (_currentTime <= 0)
            {
                _currentTime = 0;
                LaunchCatapult();
                isCountingDown = false;
            }
        }

    }
    public void StartTimer()
    {
        _currentTime = _catapultTimer;
        Text.text = _currentTime.ToString();
        isCountingDown = true;

        Debug.Log("Start Timer");
    }

    public void LaunchCatapult()
    {
        Catapult.GetComponent<HingeJoint>().useMotor = true;
    }
}
