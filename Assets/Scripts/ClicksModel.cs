using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClicksModel : MonoBehaviour
{
    [SerializeField]
    private UIManager _viewManager;
    private int _clicksCount = 0;

    public void IncrementClicksCount()
    {
        ++_clicksCount;
        _viewManager.SetCounterViewPoints(_clicksCount);
    }
}
