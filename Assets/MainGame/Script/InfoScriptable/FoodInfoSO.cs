using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainGame
{

    [System.Serializable]
    public class FoodInfo
    {
        [SerializeField] public string _name;
        [Multiline]
        [SerializeField] public string _tooltip;
        [SerializeField] public int price;
        [SerializeField] public GameObject mainFood;
        [SerializeField] public GameObject ingredientList;
    }

    [CreateAssetMenu(fileName = "FoodInfoSO", menuName = "Scriptable Object/FoodInfoSO")]
    public class FoodInfoSO : ScriptableObject
    {
        public FoodInfo[] foodInfo;
    }
}
