using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

namespace MainGame
{
    public class Food_Complete_Button : MonoBehaviour
    {
        public Transform Complete_View;
        public Transform MainFood;
        public Transform Content;
        public Transform unComplete_Scrol_View;
        public Transform unableComplete_Scrol_View;

        public GameObject Ingredient_Text;

        public Button unableYesButton;

        GameObject Instant_txt;


        bool changeComplete; //완성되지 않은 음식
        bool unableComplete; //완성할 수 없는 음식(필수 재료 안넣음)
        public void Btn_Complete_View_On() //완료 버튼을 누르면
        {

            Transform Food = MainFood.GetChild(0);
            int Ingredient_Select_num = Food.GetComponent<MainFood>().Ingredient_Count.Length;
            changeComplete = false;
            unableComplete = false;
            //선택되지 않은 재료를 감지
            for (int j = 0; j < 3; j++) //필수재료, 제외재료, 추가재료
            {
                for (int i = 0; i < Ingredient_Select_num; i++) //선택된 재료 번호
                {

                    switch (j)
                    {
                        case 0:
                            if (MainFood.GetChild(0).GetComponent<MainFood>().Ingredient_Count[i] == 0) //만약 선택되지 않은 재료이며
                            {
                                if (Food.GetChild(i).GetComponent<Ingredients_Removal>().essentialIngredient) //만약 선택되지 않은 재료가 필수재료이면
                                {
                                    unableComplete = true;
                                    Instant_txt = Ingredient_Text;
                                    Instant_txt.GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0);
                                    Instant_txt.GetComponent<TextMeshProUGUI>().text = Food.GetChild(i).name + "(필수)";
                                    Instantiate(Instant_txt, Content.position, Quaternion.identity, Content);
                                    changeComplete = true;
                                }
                            }
                            break;
                        case 1:
                            if (MainFood.GetChild(0).GetComponent<MainFood>().Ingredient_Count[i] == 0)//만약 선택되지 않은 재료이며
                            {
                                if (!Food.GetChild(i).GetComponent<Ingredients_Removal>().essentialIngredient) //만약 선택되지 않은 재료가 일반재료 이면
                                {
                                    Instant_txt = Ingredient_Text;
                                    Instant_txt.GetComponent<TextMeshProUGUI>().color = new Color(255, 140, 0);
                                    Instant_txt.GetComponent<TextMeshProUGUI>().text = Food.GetChild(i).name + "(-)";
                                    Instantiate(Instant_txt, Content.position, Quaternion.identity, Content);
                                    changeComplete = true;
                                }
                            }
                            break;

                        case 2:
                            if (MainFood.GetChild(0).GetComponent<MainFood>().Ingredient_Count[i] > 1) //해당 음식 재료가 추가된 상태라면
                            {
                                Instant_txt = Ingredient_Text;
                                Instant_txt.GetComponent<TextMeshProUGUI>().color = new Color(0, 255, 0);
                                Instant_txt.GetComponent<TextMeshProUGUI>().text = Food.GetChild(i).name + "(+)";
                                Instantiate(Instant_txt, Content.position, Quaternion.identity, Content);
                                changeComplete = true;
                            }
                            break;
                    }
                }
            }

            if (changeComplete) //재료 전부 선택 안하면
            {
                unComplete_Scrol_View.gameObject.SetActive(true);
            }
            else
            {
                unComplete_Scrol_View.gameObject.SetActive(false);
            }

            if (unableComplete)//필수재료 선택 안하면
            {
                unableComplete_Scrol_View.gameObject.SetActive(true);
                unableYesButton.interactable = false; //버튼 비활성화
            }
            else
            {
                unableComplete_Scrol_View.gameObject.SetActive(false);
                unableYesButton.interactable = true;//버튼 활성화
            }
            Complete_View.gameObject.SetActive(true); //완료 뷰를 활성화
        }

        public void Btn_Complete_View_Off()
        {
            Complete_View.gameObject.SetActive(false);
            foreach(Transform child in Content)
            {
                Destroy(child.gameObject);
            }
        }

        public void Btn_Complete()
        {
            SceneManager.LoadScene("OrderEnd");
        }
    }
}