using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BreakoutGame
{
    public class LevelUi : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _textField;
        [SerializeField]
        private bool _withLevelPrefix = false;

        public LevelController LevelController
        {
            get;
            set;
        }

        private void Start()
        {
            UpdateDisplay();
        }

        private void Update()
        {
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            if (LevelController == null)
            {
                return;
            }

            if (!_withLevelPrefix)
            {
                _textField.text = LevelController.LevelNumber.ToString();
            }
            else
            {
                _textField.text = "Level: " + LevelController.LevelNumber;
            }
        }
    }
}