using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    public class DontDestroy : MonoBehaviour
    {
        public OrderInformation OrdInf_cs;
        public static DontDestroy instance = null;
        [SerializeField] MainGame.FoodInfoSO InfoSO;

        void Awake()
        {
            // SoundManager �ν��Ͻ��� �̹� �ִ��� Ȯ��, �� ���·� ����
            if (instance == null)
                instance = this;

            // �ν��Ͻ��� �̹� �ִ� ��� ������Ʈ ����
            else if (instance != this)
            {
                Destroy(instance.gameObject);
                instance = this;
            }
            DontDestroyOnLoad(gameObject);
        }

        void OnEnable()
        {
            // �� �Ŵ����� sceneLoaded�� ü���� �Ǵ�.
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        // ü���� �ɾ �� �Լ��� �� ������ ȣ��ȴ�.
        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (SceneManager.GetActiveScene().name == "MainGame") //���ΰ��� ���� ����
            {
                GameObject.Find("SignObject").GetComponent<MainGame.Information>().num = OrdInf_cs.order_num;  //���� ������ ã�� ��ȣ�ο�
                Transform MainFood = GameObject.Find("MainFood_List").transform; //�������� ����Ʈ ã��
                Instantiate(InfoSO.foodInfo[OrdInf_cs.order_num].mainFood, MainFood.position, Quaternion.identity, MainFood); //�������� ����
                Instantiate(InfoSO.foodInfo[OrdInf_cs.order_num].ingredientList, MainFood.position, Quaternion.identity);//������� ����
            }
            else if (SceneManager.GetActiveScene().name == "DefaultOrder") //�Ϲ��ֹ� ���� ����
            {
                GameObject.Find("SignObject").GetComponent<MainGame.Information>().num = OrdInf_cs.order_num; //���� ������ ã�� ��ȣ�ο�
                GameObject.Find("FoodPanel_List").GetComponent<DefaultOrder.CreateIngredient>().orderNum = OrdInf_cs.order_num; //���� �ǳ� ����Ʈ�� ���� ��ȣ �ο�
            }
            else if (SceneManager.GetActiveScene().name == "OrderEnd")
            {
                instance = null;
                Destroy(gameObject);
            }
        }

        void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}
