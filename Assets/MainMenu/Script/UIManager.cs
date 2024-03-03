using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class UIManager : MonoBehaviour
    {
        public Button buttonToShow; // 나타날 버튼을 가리키는 변수
        public Button buttonToHide; // 사라질 버튼

        void Start()
        {
            buttonToShow.gameObject.SetActive(false); // 초기에는 두 번째 버튼을 비활성화합니다.
        }

        public void OnMouseEnter()
        {
            buttonToShow.gameObject.SetActive(true); // 첫 번째 버튼에 마우스를 올렸을 때 두 번째 버튼을 활성화합니다.
            buttonToHide.gameObject.SetActive(false); // 두번째 버튼이 나오면 첫번째 버튼이 사라진다
        }

        public void OnMouseExit()
        {
            buttonToShow.gameObject.SetActive(false); // 첫 번째 버튼을 벗어났을 때 두 번째 버튼을 다시 비활성화합니다.
            buttonToHide.gameObject.SetActive(true);  // 두번째 버튼을 벗어났을때 첫번째 버튼을 활성화
        }
    }
}
