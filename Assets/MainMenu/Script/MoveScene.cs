using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    public class MoveScene : MonoBehaviour
    {
        public void ScenesCtrlChoice()
        {
            SceneManager.LoadScene("ChoiceMenu");
        }
        public void ScenesCtrlMain()
        {
            SceneManager.LoadScene("Main");
        }
        public void ScenesCtrlChoiceOrder()
        {
            SceneManager.LoadScene("ChoiceStart");
        }
        public void ScenesCtrlEndOrder()
        {
            SceneManager.LoadScene("OrderEnd");
        }
        public void ScenesCtrlMini()
        {
            SceneManager.LoadScene("SyntheticWatermelon");
        }
        public void ScenesCtrlMaingame()
        {
            SceneManager.LoadScene("MainGame");
        }
        public void ScenesCtrlStayroom()
        {
            SceneManager.LoadScene("StayGame");
        }
        public void ScenesCtrlCalender()
        {
            SceneManager.LoadScene("Calender");
        }
        public void ScenesCtrlDefaultOrder()
        {
            SceneManager.LoadScene("DefaultOrder");
        }
        public void ScenesCtrlPointShop()
        {
            SceneManager.LoadScene("PointShop");
        }
        public void ScenesCtrlSide()
        {
            SceneManager.LoadScene("SideChoice");
        }
        public void ScenesCtrlDrink()
        {
            SceneManager.LoadScene("DrinkChoice");
        }
        public void ScenesCtrlPointOrder()
        {
            SceneManager.LoadScene("PointOrder");
        }
    }
}
