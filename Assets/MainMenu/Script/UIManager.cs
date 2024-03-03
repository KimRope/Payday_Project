using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class UIManager : MonoBehaviour
    {
        public Button buttonToShow; // ��Ÿ�� ��ư�� ����Ű�� ����
        public Button buttonToHide; // ����� ��ư

        void Start()
        {
            buttonToShow.gameObject.SetActive(false); // �ʱ⿡�� �� ��° ��ư�� ��Ȱ��ȭ�մϴ�.
        }

        public void OnMouseEnter()
        {
            buttonToShow.gameObject.SetActive(true); // ù ��° ��ư�� ���콺�� �÷��� �� �� ��° ��ư�� Ȱ��ȭ�մϴ�.
            buttonToHide.gameObject.SetActive(false); // �ι�° ��ư�� ������ ù��° ��ư�� �������
        }

        public void OnMouseExit()
        {
            buttonToShow.gameObject.SetActive(false); // ù ��° ��ư�� ����� �� �� ��° ��ư�� �ٽ� ��Ȱ��ȭ�մϴ�.
            buttonToHide.gameObject.SetActive(true);  // �ι�° ��ư�� ������� ù��° ��ư�� Ȱ��ȭ
        }
    }
}
