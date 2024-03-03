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
            if (Input.GetMouseButtonDown(0)) //마우스 클릭시
            {
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //마우스 클릭 좌표값
                RaycastHit2D[] hit = Physics2D.RaycastAll(pos, Vector2.zero, 0f);

                if (!EventSystem.current.IsPointerOverGameObject()) //UI가 존재하지않으면   
                {
                    if (hit.Length != 0) //콜라이더 존재
                    {
                        for (int i = 0; i < hit.Length; i++)
                        {
                            if (hit[i].transform.CompareTag("Food Ingredient")) //재료 태그가 붙은 오브젝트라면
                            {
                                Food_Ingredient_Click(hit[i]);
                                break;
                            }
                            else if (hit[i].transform.CompareTag("Food Contents")) //메인음식 재료가 붙은 오브젝트라면
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
            hit.transform.gameObject.GetComponent<Object_Following>().isClick = true; //오브젝트 마우스 따라가기 true
        }
        void Food_Contents_Click(RaycastHit2D hit)
        {
            Color tmp = hit.transform.gameObject.GetComponent<SpriteRenderer>().color;
            if (tmp.a == 1f)
            {
                hit.transform.gameObject.GetComponent<Ingredients_Removal>().isClick = true; //오브젝트 마우스 따라가기 true
            }
        }
    }
}
