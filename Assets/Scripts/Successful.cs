using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Successful : MonoBehaviour
{
    int score;
    TMP_Text successful;
    void Update()
    {
        successful = GetComponent<TMP_Text>();
        successful.text = "SUCCESSFUL";

        if (score > 500)
        {
            successful.enabled = true;
        }
    }
}
