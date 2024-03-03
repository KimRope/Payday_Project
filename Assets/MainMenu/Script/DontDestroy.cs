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
            // SoundManager 인스턴스가 이미 있는지 확인, 이 상태로 설정
            if (instance == null)
                instance = this;

            // 인스턴스가 이미 있는 경우 오브젝트 제거
            else if (instance != this)
            {
                Destroy(instance.gameObject);
                instance = this;
            }
            DontDestroyOnLoad(gameObject);
        }

        void OnEnable()
        {
            // 씬 매니저의 sceneLoaded에 체인을 건다.
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        // 체인을 걸어서 이 함수는 매 씬마다 호출된다.
        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (SceneManager.GetActiveScene().name == "MainGame") //메인게임 씬에 들어가면
            {
                GameObject.Find("SignObject").GetComponent<MainGame.Information>().num = OrdInf_cs.order_num;  //음식 설명판 찾아 번호부여
                Transform MainFood = GameObject.Find("MainFood_List").transform; //메인음식 리스트 찾음
                Instantiate(InfoSO.foodInfo[OrdInf_cs.order_num].mainFood, MainFood.position, Quaternion.identity, MainFood); //메인음식 생성
                Instantiate(InfoSO.foodInfo[OrdInf_cs.order_num].ingredientList, MainFood.position, Quaternion.identity);//음식재료 생성
            }
            else if (SceneManager.GetActiveScene().name == "DefaultOrder") //일반주문 씬에 들어가면
            {
                GameObject.Find("SignObject").GetComponent<MainGame.Information>().num = OrdInf_cs.order_num; //음식 설명판 찾아 번호부여
                GameObject.Find("FoodPanel_List").GetComponent<DefaultOrder.CreateIngredient>().orderNum = OrdInf_cs.order_num; //음식 판넬 리스트에 음식 번호 부여
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
