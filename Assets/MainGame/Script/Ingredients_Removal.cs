using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MainGame
{
    public class Ingredients_Removal : MonoBehaviour
    {
        Vector2 StartLocation;
        Collision2D BottomBar_collision = null;

        public bool isClick;
        public int Ingredient_num;
        public MainFood MainFood_cs;
        public Transform PlusObject;
        public int Price; //가격
        public bool essentialIngredient; //필수적인 재료
        // Start is called before the first frame update
        private void Awake()
        {
            StartLocation = transform.position;
        }
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (isClick && Input.GetMouseButtonUp(0))
            {
                if (BottomBar_collision != null)
                {
                    if (MainFood_cs.Ingredient_Count[Ingredient_num] > 1) //재료 추가 상태이면
                    {
                        PlusObject.gameObject.SetActive(false);
                        MainFood_cs.unSelect_Delete_Anim_Inst(Ingredient_num, transform.position); //재료 취소 애니메이션
                    }
                        Output_Ingredients(); //메인음식에 재료 1개 제거
                }
                unClick();
            }
            if (isClick) //클릭상태이면
            {
                    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    transform.position = mousePosition; //마우스 위치를 따라간다
            }
        }

        void unClick()
        {
            isClick = false; //클릭상태 해제
            BottomBar_collision = null;
            transform.position = StartLocation; //처음 좌표로 이동
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (isClick) //클릭상태일때
            {
                if (collision.gameObject.CompareTag("BottomBar")) //하단바 접촉시
                {
                    BottomBar_collision = collision;
                }
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (isClick) //클릭상태일때
            {
                if (collision.gameObject.CompareTag("BottomBar")) //하단바 분리시
                {
                    BottomBar_collision = null;
                }
            }
        }

        void OnApplicationFocus(bool hasFocus) //화면에서 나가면 (ALT + Tab)
        {
            if (!hasFocus)
            {
                unClick();
            }
        }
        void Output_Ingredients() //메인음식에 재료 투입
        {
            MainFood_cs.Food_translucent_Image(Ingredient_num, transform.position); //메인 음식 재료부분을 제거
        }
    }
}
