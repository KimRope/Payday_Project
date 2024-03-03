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

            foreach (Transform child in Food) //��� �ϳ��ϳ� ã��
            {
                if (child.GetComponent<Ingredients_Removal>().essentialIngredient) //���� �ش� ��ᰡ �ʼ�����̸�
                {
                    GameObject Instant_Ingredient = null; //����� ��� �ν���Ʈ
                    Instant_Ingredient = Ingredient_UI; //�гο� ����� UI������Ʈ ������ (�׸𳭰�)
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
