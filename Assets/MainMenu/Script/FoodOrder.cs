using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    public class FoodOrder : MonoBehaviour
    {
        public Transform OrderInfo;
        int i;
        public void Order_Btn()
        {
           OrderInfo.GetComponent<OrderInformation>().order_num = EventSystem.current.currentSelectedGameObject.GetComponent<OrderInformation>().order_num;
           ScenesCtrlChoice();
        }
        public void ScenesCtrlChoice()
        {
            Instantiate(OrderInfo);
            SceneManager.LoadScene("ChoiceStart");
        }
    }
}
