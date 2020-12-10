using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlashText : MonoBehaviour
{
    public bool fadingOut = false;
    public float speed = .05f;

    void Update()
    {
        //Color 1 to Color 2
        
    }

    IEnumerator fadeOut()
    {
        for(float i = 0f; i <= 1f; i+= 0.05f)
        {
            this.gameObject.GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, i);
            yield return new WaitForSeconds(speed);
    }
      
    }
}
