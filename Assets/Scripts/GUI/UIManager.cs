using Stats;
using UnityEngine;
using UnityEngine.UI;

namespace GUI
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private Image[] lifeImages;
        [SerializeField] private Text levelText;
        [SerializeField] private Image levelImage;
        [SerializeField] private Text progressLevelText;
        [SerializeField] private Image hpImage;
        [SerializeField] private Text progressHealthText;
        [SerializeField] private Text coinTotal;

        [SerializeField] private GameObject startGameDialog;

        private PlayerStats _playerStats;
        private const string LEVEL_TEXT_FORMAT = "LEVEL {0}";
        private const string PROGRESS_TEXT_FORMAT = "{0}/{1}";
        private readonly Color _colorLifeHide = new(0.43f, 0.66f, 0.61f, 1);

        protected override void Awake()
        {
            Time.timeScale = 0;
            startGameDialog.SetActive(true);
        }

        public void OnTriggerGameObjectClick(GameObject gameObj)
        {
            Time.timeScale = gameObj.activeSelf ? 1 : 0;
            gameObj.SetActive(!gameObj.activeSelf);
        }

        public void SetCoinCount(int value)
        {
            coinTotal.text = value.ToString("0");
        }

        public void SetLifeBar(int value)
        {
            for (var i = 0; i < lifeImages.Length; i++)
            {
                lifeImages[i].color = i >= value ? _colorLifeHide : Color.white;
            }
        }

        public void SetHpBar(float hpCurrent,float hpMax)
        {
            progressHealthText.text = string.Format(PROGRESS_TEXT_FORMAT, hpCurrent, hpMax);
            hpImage.fillAmount =  hpCurrent/hpMax;
        }

        public void SetLevelBar(PlayerStats playerStats)
        {
            var xpMax = playerStats.GetXpUp(playerStats.level);
            var xpMin = playerStats.GetXpUp(playerStats.level - 1);

            levelText.text = string.Format(LEVEL_TEXT_FORMAT, playerStats.level);
            progressLevelText.text = string.Format(PROGRESS_TEXT_FORMAT, playerStats.xp, xpMax.ToString("0"));
            levelImage.fillAmount = (playerStats.xp - xpMin) / ( xpMax - xpMin);
        }
    }
}