using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class UISpawnerManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField _speedInputField;
    [SerializeField] private TMP_InputField _spawnDelayInputField;
    [SerializeField] private TMP_InputField _distanceInputField;

    public void SetSpeed(float speed)
    {
        _speedInputField.text = speed.ToString();
    }
    public void SetDistance(float distance)
    {
        _distanceInputField.text = distance.ToString();
    }
    public void SetSpawnDelay(float spawnDelay)
    {
        _distanceInputField.text = spawnDelay.ToString();
    }
}
