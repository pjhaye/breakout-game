using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BreakoutGame
{
    public class ScoreUi: MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _textField;

        public ScoreController ScoreController
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
            if (ScoreController == null)
            {
                return;
            }
            _textField.text = ScoreController.Score.ToString();
        }
    }
}