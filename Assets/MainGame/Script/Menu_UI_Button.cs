using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainGame
{
    public class Menu_UI_Button : MonoBehaviour
    {
        public Animator animator;

        public void Menu_Show() //�޴� �г� ����Ʈ On / Off
        {
            if (!animator.GetBool("isShow"))
            {
                animator.SetBool("isShow", true);
            }
            else
            {
                animator.SetBool("isShow", false);;
            }
    }
    }
}
