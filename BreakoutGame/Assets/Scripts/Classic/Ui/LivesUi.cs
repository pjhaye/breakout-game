using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BreakoutGame
{
    public class LivesUi : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _textField;

        public LivesController LivesController
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
            if (LivesController == null)
            {
                return;
            }
            _textField.text = LivesController.NumLives.ToString();
        }
    }
}