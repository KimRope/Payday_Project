using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainMenu
{
    public class TabPanel : MonoBehaviour
    {
        public List<TabButton> tabbuttons;
        public List<GameObject> contentsPanels;

        public void ClickTab(int id)
        {
            for (int i = 0; i < contentsPanels.Count; i++)
            {
                if (i == id)
                {
                    contentsPanels[i].SetActive(true);
                    //                tabButtons[i].Selected();
                }
                else
                {
                    contentsPanels[i].SetActive(false);
                    //                tabButtons[i].DeSelected();
                }
            }
        }
    }
}
