using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MainGame
{
    public class Anim_Ingredients : MonoBehaviour
    {
        public Animator ingredAnim;
        public Transform followIngred; //���󰡾� �� ������Ʈ
        public Transform ingredSprite; //�̹��� �������� ������Ʈ
        public SpriteRenderer mySpr;
        public float speed;
        // Start is called before the first frame update

        void Start()
        {
            mySpr.sprite = ingredSprite.GetComponent<SpriteRenderer>().sprite;
            ingredAnim.SetTrigger("Delete_Trig");
        }

        // Update is called once per frame
        void Update()
        {
            if (followIngred != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, followIngred.position, speed * Time.deltaTime);
            }
        }
    }
}