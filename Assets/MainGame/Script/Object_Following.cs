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
                    Input_Ingredients(Food_collision); //�������Ŀ� ��� ����
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
            Food_collision = null;
            transform.position = StartLocation; //ó�� ��ǥ�� �̵�
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (isClick) //Ŭ�������϶�
            {
                if (collision.gameObject.CompareTag("MainFood")) //�������İ� ��ᰡ ���˽�
                {
                    Food_collision = collision;
                }
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (isClick) //Ŭ�������϶�
            {
                if (collision.gameObject.CompareTag("MainFood")) //�������İ� ��ᰡ �и���
                {
                    Food_collision = null;
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
        void Input_Ingredients(Collision2D collision) //�������Ŀ� ��� ����
        {
            collision.transform.GetComponent<MainFood>().Food_Opaque_Image(Ingredient_num); //���� ���� ���κ��� ���� �߰�
        }
    }
}
