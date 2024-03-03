using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

namespace DefaultOrder
{
    public class CreateIngredient : MonoBehaviour
    {
        public TMP_Text Ingredient_txt; //재료 Text
        public IngredientTXT IngredientTXT_cs;
        public int orderNum = 0;
        [SerializeField] MainGame.FoodInfoSO InfoSO;
        void Start()
        {
            foreach (Transform child in InfoSO.foodInfo[orderNum].mainFood.transform)
            {
                Ingredient_txt.text = child.name;
                if (child.GetComponent<MainGame.Ingredients_Removal>().essentialIngredient)
                    IngredientTXT_cs.essentialIngredient = true;
                else
                    IngredientTXT_cs.essentialIngredient = false;
                Instantiate(Ingredient_txt, transform.position, Quaternion.identity, transform); //메인음식 생성
            }
        }
        public void OrderComplete()
        {
            SceneManager.LoadScene("OrderEnd");
        }
    }
}
