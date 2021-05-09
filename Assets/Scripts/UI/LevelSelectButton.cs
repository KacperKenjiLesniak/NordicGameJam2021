using System;
using System.Linq;
using DefaultNamespace.LevelSelect;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LevelSelectButton : MonoBehaviour
    {
        public int levelNumber;
        
        private MatchManager matchManager;
        
        private void Awake()
        {
            matchManager = FindObjectOfType<MatchManager>();
        }

        private void Update()
        {
            if (matchManager.levelList.Contains(levelNumber))
            {
                var currentColor = GetComponent<Image>().color;
                GetComponent<Image>().color = new Color(currentColor.r, currentColor.g, currentColor.b, 1f);
            }
            else
            {
                var currentColor = GetComponent<Image>().color;
                GetComponent<Image>().color = new Color(currentColor.r, currentColor.g, currentColor.b, 0.3f);

            }
        }
    }
}