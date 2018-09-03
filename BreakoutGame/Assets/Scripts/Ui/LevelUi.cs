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
            _textField.text = LevelController.LevelNumber.ToString();
        }
    }
}