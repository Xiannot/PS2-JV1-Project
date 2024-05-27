using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;    

public class Height : MonoBehaviour
{
    

    public TextMeshProUGUI height;
  

    private void Update()
    {
        height.text = (int)transform.position.y + "";
    }


}
