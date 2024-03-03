using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace MainGame
{
    public class Panel_Ingredients : MonoBehaviour
    {
        public Transform MainFood;

        public GameObject Ingredient_UI;

        Color tmp;
        // Start is called before the first frame update
        void Start()
        {
            Transform Food = MainFood.GetChild(0).transform;

            foreach (Transform child in Food) //재료 하나하나 찾기
            {
                if (child.GetComponent<Ingredients_Removal>().essentialIngredient) //만약 해당 재료가 필수재료이면
                {
                    GameObject Instant_Ingredient = null; //출력한 재료 인스턴트
                    Instant_Ingredient = Ingredient_UI; //패널에 출력할 UI오브젝트 프리팹 (네모난거)
                    Instant_Ingredient.GetComponent<Image>().sprite = child.GetComponent<SpriteRenderer>().sprite;

                    Instant_Ingredient.GetComponent<Image>().color = child.GetComponent<SpriteRenderer>().color;
                    tmp = Instant_Ingredient.GetComponent<Image>().color;
                    tmp.a = 1f;
                    Instant_Ingredient.GetComponent<Image>().color = tmp;

                    Instantiate(Instant_Ingredient, transform.position, Quaternion.identity, transform);
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
