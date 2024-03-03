using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainGame
{
    public class MainFood : MonoBehaviour
    {
        Color tmp;
        public Transform[] Food_Contents; //메인음식 기존재료
        public int[] Ingredient_Count; //선택 된 재료 수량

        public GameObject Delete_Anim;
        GameObject Instant_Delete_Anim;

        // Start is called before the first frame update
        private void Awake()
        {
            Ingredient_Count = new int[Food_Contents.Length];
            for(int i = 0; i < Food_Contents.Length; i++)
            {
                Ingredient_Count[i] = 0;
            }

        }
        void Start()
        {
            for (int i = 0; i < Food_Contents.Length; i++) //메인 음식 재료의 수
            {
                tmp = Food_Contents[i].GetComponent<SpriteRenderer>().color;
                tmp.a = 0.2f;
                Food_Contents[i].GetComponent<SpriteRenderer>().color = tmp;
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Food_Opaque_Image(int i) //메인음식 재료 반투명 -> 불투명
        {
            tmp = Food_Contents[i].GetComponent<SpriteRenderer>().color;
            if (Ingredient_Count[i] > 0) //만약 재료가 이미 선택된 상태라면
            {
                Plus_Add_ingredients(i);
            }
            tmp.a = 1f;
            Food_Contents[i].GetComponent<SpriteRenderer>().color = tmp; //해당하는 재료 불투명

            foreach (Transform child in Food_Contents[i])
            {
                tmp = child.GetComponent<SpriteRenderer>().color;
                tmp.a = 1f;
                child.GetComponent<SpriteRenderer>().color = tmp; //해당하는 재료의 모든 자식들도 불투명
            }
            if (Ingredient_Count[i] < 2)
                Ingredient_Count[i] += 1; //해당하는 재료 선택됨
            Select_Delete_Anim_Inst(i); //재료 선택 애니메이션
        }

        public void Food_translucent_Image(int i, Vector2 position)//메인음식 재료 불투명 -> 반투명
        {
            if (Ingredient_Count[i] > 0)
                Ingredient_Count[i] -= 1; //해당하는 재료 선택됨
            if (Ingredient_Count[i] == 0)
            {
                tmp = Food_Contents[i].GetComponent<SpriteRenderer>().color;
                tmp.a = 0.2f;
                Food_Contents[i].GetComponent<SpriteRenderer>().color = tmp; //해당하는 재료 반투명

                foreach (Transform child in Food_Contents[i])
                {
                    tmp = child.GetComponent<SpriteRenderer>().color;
                    tmp.a = 0.2f;
                    child.GetComponent<SpriteRenderer>().color = tmp; //해당하는 재료의 모든 자식들도 불투명
                }
            }
            unSelect_Delete_Anim_Inst(i, position); //재료 취소 애니메이션
        }

        void Plus_Add_ingredients(int i) //재료추가
        {
            Food_Contents[i].GetComponent<Ingredients_Removal>().PlusObject.gameObject.SetActive(true); //재료 추가 오브젝트 활성화
        }

        public void Select_Delete_Anim_Inst(int i) //재료 선택 애니메이션
        {
            Instant_Delete_Anim = Delete_Anim;
            Instant_Delete_Anim.GetComponent<Anim_Ingredients>().followIngred = Food_Contents[i]; //재료 오브젝트로 따라감
            Instant_Delete_Anim.GetComponent<Anim_Ingredients>().ingredSprite = Food_Contents[i]; //재료 오브젝트로 이미지 변경
            Instantiate(Instant_Delete_Anim, transform.position, Quaternion.identity);
        }
        public void unSelect_Delete_Anim_Inst(int i, Vector2 position) //재료 취소 애니메이션
        {
            Instant_Delete_Anim = Delete_Anim;
            Instant_Delete_Anim.GetComponent<Anim_Ingredients>().followIngred = null;
            Instant_Delete_Anim.GetComponent<Anim_Ingredients>().ingredSprite = Food_Contents[i]; //재료 오브젝트로 이미지 변경
            Instantiate(Instant_Delete_Anim, position, Quaternion.identity);
        }
    }
}