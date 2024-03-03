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
        public int Price; //����
        public bool essentialIngredient; //�ʼ����� ���
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
                    if (MainFood_cs.Ingredient_Count[Ingredient_num] > 1) //��� �߰� �����̸�
                    {
                        PlusObject.gameObject.SetActive(false);
                        MainFood_cs.unSelect_Delete_Anim_Inst(Ingredient_num, transform.position); //��� ��� �ִϸ��̼�
                    }
                        Output_Ingredients(); //�������Ŀ� ��� 1�� ����
                }
                unClick();
            }
            if (isClick) //Ŭ�������̸�
            {
                    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    transform.position = mousePosition; //���콺 ��ġ�� ���󰣴�
            }
        }

        void unClick()
        {
            isClick = false; //Ŭ������ ����
            BottomBar_collision = null;
            transform.position = StartLocation; //ó�� ��ǥ�� �̵�
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (isClick) //Ŭ�������϶�
            {
                if (collision.gameObject.CompareTag("BottomBar")) //�ϴܹ� ���˽�
                {
                    BottomBar_collision = collision;
                }
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (isClick) //Ŭ�������϶�
            {
                if (collision.gameObject.CompareTag("BottomBar")) //�ϴܹ� �и���
                {
                    BottomBar_collision = null;
                }
            }
        }

        void OnApplicationFocus(bool hasFocus) //ȭ�鿡�� ������ (ALT + Tab)
        {
            if (!hasFocus)
            {
                unClick();
            }
        }
        void Output_Ingredients() //�������Ŀ� ��� ����
        {
            MainFood_cs.Food_translucent_Image(Ingredient_num, transform.position); //���� ���� ���κ��� ����
        }
    }
}
