using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class GoldUIController : MonoBehaviour
{
    #region Methods
    
    private void Awake()
    {
        this.GetComponent<TextMeshProUGUI>().text = 0.ToString();
    }

    public void SetGold(int p_Gold)
    {
        this.transform.GetComponent<TextMeshProUGUI>().text = p_Gold.ToString();
    }
    
    #endregion // Methods
}
