using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MainGame
{
    public class Object_Following : MonoBehaviour
    {
        Vector2 StartLocation;
        public bool isClick;

        Collision2D Food_collision = null;

        public int Ingredient_num;


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
                if (Food_collision != null)
                {
                    Input_Ingredients(Food_collision); //메인음식에 재료 투입
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
            Food_collision = null;
            transform.position = StartLocation; //처음 좌표로 이동
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (isClick) //클릭상태일때
            {
                if (collision.gameObject.CompareTag("MainFood")) //메인음식과 재료가 접촉시
                {
                    Food_collision = collision;
                }
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (isClick) //클릭상태일때
            {
                if (collision.gameObject.CompareTag("MainFood")) //메인음식과 재료가 분리시
                {
                    Food_collision = null;
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
        void Input_Ingredients(Collision2D collision) //메인음식에 재료 투입
        {
            collision.transform.GetComponent<MainFood>().Food_Opaque_Image(Ingredient_num); //메인 음식 재료부분의 색을 추가
        }
    }
}
