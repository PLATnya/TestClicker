using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
   public TextMeshProUGUI CounterText;
   
   public void SetCounterViewPoints(int points)
   {
      CounterText.text = points.ToString();
   }
}

