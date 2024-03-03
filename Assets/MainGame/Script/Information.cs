using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MainGame
{
    public class Information : MonoBehaviour
    {
        public int num;
        public TextMeshProUGUI foodName_;
        public TextMeshProUGUI foodInfo_;
        [SerializeField] FoodInfoSO InfoSO;
        // Start is called before the first frame update
        void Start()
        {
            foodName_.text = InfoSO.foodInfo[num]._name;
            foodInfo_.text = InfoSO.foodInfo[num]._tooltip;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
