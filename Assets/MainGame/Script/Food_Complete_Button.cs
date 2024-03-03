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


        bool changeComplete; //�ϼ����� ���� ����
        bool unableComplete; //�ϼ��� �� ���� ����(�ʼ� ��� �ȳ���)
        public void Btn_Complete_View_On() //�Ϸ� ��ư�� ������
        {

            Transform Food = MainFood.GetChild(0);
            int Ingredient_Select_num = Food.GetComponent<MainFood>().Ingredient_Count.Length;
            changeComplete = false;
            unableComplete = false;
            //���õ��� ���� ��Ḧ ����
            for (int j = 0; j < 3; j++) //�ʼ����, �������, �߰����
            {
                for (int i = 0; i < Ingredient_Select_num; i++) //���õ� ��� ��ȣ
                {

                    switch (j)
                    {
                        case 0:
                            if (MainFood.GetChild(0).GetComponent<MainFood>().Ingredient_Count[i] == 0) //���� ���õ��� ���� ����̸�
                            {
                                if (Food.GetChild(i).GetComponent<Ingredients_Removal>().essentialIngredient) //���� ���õ��� ���� ��ᰡ �ʼ�����̸�
                                {
                                    unableComplete = true;
                                    Instant_txt = Ingredient_Text;
                                    Instant_txt.GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0);
                                    Instant_txt.GetComponent<TextMeshProUGUI>().text = Food.GetChild(i).name + "(�ʼ�)";
                                    Instantiate(Instant_txt, Content.position, Quaternion.identity, Content);
                                    changeComplete = true;
                                }
                            }
                            break;
                        case 1:
                            if (MainFood.GetChild(0).GetComponent<MainFood>().Ingredient_Count[i] == 0)//���� ���õ��� ���� ����̸�
                            {
                                if (!Food.GetChild(i).GetComponent<Ingredients_Removal>().essentialIngredient) //���� ���õ��� ���� ��ᰡ �Ϲ���� �̸�
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
                            if (MainFood.GetChild(0).GetComponent<MainFood>().Ingredient_Count[i] > 1) //�ش� ���� ��ᰡ �߰��� ���¶��
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

            if (changeComplete) //��� ���� ���� ���ϸ�
            {
                unComplete_Scrol_View.gameObject.SetActive(true);
            }
            else
            {
                unComplete_Scrol_View.gameObject.SetActive(false);
            }

            if (unableComplete)//�ʼ���� ���� ���ϸ�
            {
                unableComplete_Scrol_View.gameObject.SetActive(true);
                unableYesButton.interactable = false; //��ư ��Ȱ��ȭ
            }
            else
            {
                unableComplete_Scrol_View.gameObject.SetActive(false);
                unableYesButton.interactable = true;//��ư Ȱ��ȭ
            }
            Complete_View.gameObject.SetActive(true); //�Ϸ� �並 Ȱ��ȭ
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