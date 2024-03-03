using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MainGame 
{
    public class Object_Click_Manager : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            ScreenClick();
        }

        void ScreenClick()
        {
            if (Input.GetMouseButtonDown(0)) //���콺 Ŭ����
            {
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //���콺 Ŭ�� ��ǥ��
                RaycastHit2D[] hit = Physics2D.RaycastAll(pos, Vector2.zero, 0f);

                if (!EventSystem.current.IsPointerOverGameObject()) //UI�� ��������������   
                {
                    if (hit.Length != 0) //�ݶ��̴� ����
                    {
                        for (int i = 0; i < hit.Length; i++)
                        {
                            if (hit[i].transform.CompareTag("Food Ingredient")) //��� �±װ� ���� ������Ʈ���
                            {
                                Food_Ingredient_Click(hit[i]);
                                break;
                            }
                            else if (hit[i].transform.CompareTag("Food Contents")) //�������� ��ᰡ ���� ������Ʈ���
                            {
                                Food_Contents_Click(hit[i]);
                                break;
                            }
                        }
                    }
                }
            }
        }

        void Food_Ingredient_Click(RaycastHit2D hit)
        {
            hit.transform.gameObject.GetComponent<Object_Following>().isClick = true; //������Ʈ ���콺 ���󰡱� true
        }
        void Food_Contents_Click(RaycastHit2D hit)
        {
            Color tmp = hit.transform.gameObject.GetComponent<SpriteRenderer>().color;
            if (tmp.a == 1f)
            {
                hit.transform.gameObject.GetComponent<Ingredients_Removal>().isClick = true; //������Ʈ ���콺 ���󰡱� true
            }
        }
    }
}
