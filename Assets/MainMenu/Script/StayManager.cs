using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StayManager : MonoBehaviour
{
    public TextMeshProUGUI DateText;
    public TextMeshProUGUI TimeText;
    private int Time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DateText.text = PlayerPrefs.GetString("Date");
        Time = PlayerPrefs.GetInt("Time");
        TimeText.text = Time.ToString() + "½Ã";
    }
}
