using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace DefaultOrder
{
    public class IngredientTXT : MonoBehaviour
    {
        public int IngredientCount = 1;
        public TextMeshProUGUI InText;
        public Button LBtn;
        public Button RBtn;
        public bool essentialIngredient; //필수적인 재료

        string saveText;
                                         // Update is called once per frame

        private void Start()
        {
            saveText = InText.text;
        }

        void Update()
        {
            if (IngredientCount == 0 || (essentialIngredient && IngredientCount == 1))
            {
                LBtn.interactable = false;
                RBtn.interactable = true;
            } 
            else if (IngredientCount == 2)
            {
                LBtn.interactable = true;
                RBtn.interactable = false;
            }
            else
            {
                LBtn.interactable = true;
                RBtn.interactable = true;
            }
            
        }

        public void BtnLeft()
        {
            IngredientCount--;
            TextChange();
        }

        public void BtnRight()
        {
            IngredientCount++;
            TextChange();
        }

        void TextChange()
        {
            switch (IngredientCount)
            {
                case 0:
                    InText.text = saveText + "(-)";
                    InText.color = new Color(255, 140, 0); //주황색
                    break;
                case 1:
                    InText.text = saveText;
                    InText.color = new Color(0, 0, 0); //검정색
                    break;
                case 2:
                    InText.text = saveText + "(+)";
                    InText.color = new Color(0, 255, 0); //초록색
                    break;
                default:
                    break;
            }
        }
    }
}
