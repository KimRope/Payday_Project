using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ChoiceTime : MonoBehaviour
{
    public GameObject EndPanel;
    public TextMeshProUGUI DateText;
    public TextMeshProUGUI TimeText;
    private int Time;

    public void ScenesCtrlMain()
    {
        SceneManager.LoadScene("Main");
        EndPanel.SetActive(false);
    }

    public void TwoChoice()
    {
        PlayerPrefs.SetInt("Time", 2);
        EndPanel.SetActive(true);
    }
    public void ThreeChoice()
    {
        PlayerPrefs.SetInt("Time", 3);
        EndPanel.SetActive(true);
    }
    public void FourChoice()
    {
        PlayerPrefs.SetInt("Time", 4);
        EndPanel.SetActive(true);
    }
    public void FiveChoice()
    {
        PlayerPrefs.SetInt("Time", 5);
        EndPanel.SetActive(true);
    }
    public void SixChoice()
    {
        PlayerPrefs.SetInt("Time", 6);
        EndPanel.SetActive(true);
    }
    public void Update()
    {
        DateText.text = PlayerPrefs.GetString("Date");
        Time = PlayerPrefs.GetInt("Time");
        TimeText.text = Time.ToString() + "½Ã";
    }
}
