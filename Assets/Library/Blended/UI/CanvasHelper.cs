using UnityEngine;
using TMPro;

namespace Blended.UI
{
    public class CanvasHelper : MonoSingleton<CanvasHelper>
    {
        [Header("Game Panels")]
        [SerializeField] private GameObject startPanel;
        [SerializeField] private GameObject mainPanel;
        [SerializeField] private GameObject successPanel;
        [SerializeField] private GameObject failPanel;
        [SerializeField] private GameObject tutorialPanel;
        [SerializeField] private GameObject cursor;

        [Header("Texts")]
        [SerializeField] private TMP_Text levelText;

        private bool isCursor = false;

        /// <summary>
        /// Set the desired panel as given state.
        /// </summary>
        public void SetPanel(CanvasPanel panel, bool state)
        {
            switch (panel)
            {
                case CanvasPanel.Start:
                    startPanel.SetActive(state);
                    return;
                case CanvasPanel.Tutorial:
                    tutorialPanel.SetActive(state);
                    return;
                case CanvasPanel.Main:
                    mainPanel.SetActive(state);
                    return;
                case CanvasPanel.Success:
                    successPanel.SetActive(state);
                    return;
                case CanvasPanel.Fail:
                    failPanel.SetActive(state);
                    return;
                default:
                    return;
            }
        }

        /// <summary>
        /// Set level number text.
        /// </summary>
        public void SetLevelText(int levelNo)
        {
            levelText.text = "Level " + levelNo;
        }

        public void SetCursor()
        {
            isCursor = !isCursor;
            cursor.SetActive(isCursor);
        }
    }

    public enum CanvasPanel
    {
        Start,
        Tutorial,
        Main,
        Success,
        Fail
    }
}