using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainGame
{
    public class MainFood : MonoBehaviour
    {
        Color tmp;
        public Transform[] Food_Contents; //�������� �������
        public int[] Ingredient_Count; //���� �� ��� ����

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
            for (int i = 0; i < Food_Contents.Length; i++) //���� ���� ����� ��
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

        public void Food_Opaque_Image(int i) //�������� ��� ������ -> ������
        {
            tmp = Food_Contents[i].GetComponent<SpriteRenderer>().color;
            if (Ingredient_Count[i] > 0) //���� ��ᰡ �̹� ���õ� ���¶��
            {
                Plus_Add_ingredients(i);
            }
            tmp.a = 1f;
            Food_Contents[i].GetComponent<SpriteRenderer>().color = tmp; //�ش��ϴ� ��� ������

            foreach (Transform child in Food_Contents[i])
            {
                tmp = child.GetComponent<SpriteRenderer>().color;
                tmp.a = 1f;
                child.GetComponent<SpriteRenderer>().color = tmp; //�ش��ϴ� ����� ��� �ڽĵ鵵 ������
            }
            if (Ingredient_Count[i] < 2)
                Ingredient_Count[i] += 1; //�ش��ϴ� ��� ���õ�
            Select_Delete_Anim_Inst(i); //��� ���� �ִϸ��̼�
        }

        public void Food_translucent_Image(int i, Vector2 position)//�������� ��� ������ -> ������
        {
            if (Ingredient_Count[i] > 0)
                Ingredient_Count[i] -= 1; //�ش��ϴ� ��� ���õ�
            if (Ingredient_Count[i] == 0)
            {
                tmp = Food_Contents[i].GetComponent<SpriteRenderer>().color;
                tmp.a = 0.2f;
                Food_Contents[i].GetComponent<SpriteRenderer>().color = tmp; //�ش��ϴ� ��� ������

                foreach (Transform child in Food_Contents[i])
                {
                    tmp = child.GetComponent<SpriteRenderer>().color;
                    tmp.a = 0.2f;
                    child.GetComponent<SpriteRenderer>().color = tmp; //�ش��ϴ� ����� ��� �ڽĵ鵵 ������
                }
            }
            unSelect_Delete_Anim_Inst(i, position); //��� ��� �ִϸ��̼�
        }

        void Plus_Add_ingredients(int i) //����߰�
        {
            Food_Contents[i].GetComponent<Ingredients_Removal>().PlusObject.gameObject.SetActive(true); //��� �߰� ������Ʈ Ȱ��ȭ
        }

        public void Select_Delete_Anim_Inst(int i) //��� ���� �ִϸ��̼�
        {
            Instant_Delete_Anim = Delete_Anim;
            Instant_Delete_Anim.GetComponent<Anim_Ingredients>().followIngred = Food_Contents[i]; //��� ������Ʈ�� ����
            Instant_Delete_Anim.GetComponent<Anim_Ingredients>().ingredSprite = Food_Contents[i]; //��� ������Ʈ�� �̹��� ����
            Instantiate(Instant_Delete_Anim, transform.position, Quaternion.identity);
        }
        public void unSelect_Delete_Anim_Inst(int i, Vector2 position) //��� ��� �ִϸ��̼�
        {
            Instant_Delete_Anim = Delete_Anim;
            Instant_Delete_Anim.GetComponent<Anim_Ingredients>().followIngred = null;
            Instant_Delete_Anim.GetComponent<Anim_Ingredients>().ingredSprite = Food_Contents[i]; //��� ������Ʈ�� �̹��� ����
            Instantiate(Instant_Delete_Anim, position, Quaternion.identity);
        }
    }
}