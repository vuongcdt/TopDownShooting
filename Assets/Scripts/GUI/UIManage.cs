using Common;
using UnityEngine;
using UnityEngine.UI;

namespace Scritps.GUI
{
    public class UIManage : Singleton<UIManage>
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

        public void SetValueTextUI(PlayerStats playerStatsCurrent)
        {
            SetLevelBar(playerStatsCurrent);

            SetHpBar(playerStatsCurrent);

            SetLifeBar(playerStatsCurrent.lifeCount);

            SetCoinCount(playerStatsCurrent.coinCount);
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

        public void SetHpBar(PlayerStats playerStatsCurrent)
        {
            var maxHp = GameStats.Ins.PlayerStats.GetMaxHp(playerStatsCurrent.level);

            progressHealthText.text = string.Format(PROGRESS_TEXT_FORMAT, playerStatsCurrent.hp, maxHp.ToString("0"));
            hpImage.fillAmount = playerStatsCurrent.hp / maxHp;
        }

        public void SetLevelBar(PlayerStats playerStatsCurrent)
        {
            var xpMax = playerStatsCurrent.GetXpUp(playerStatsCurrent.level);

            while (playerStatsCurrent.xp >= xpMax)
            {
                playerStatsCurrent.level++;
                xpMax = playerStatsCurrent.GetXpUp(playerStatsCurrent.level);
            }

            var xpMin = playerStatsCurrent.GetXpUp(playerStatsCurrent.level - 1);

            levelText.text = string.Format(LEVEL_TEXT_FORMAT, playerStatsCurrent.level);
            progressLevelText.text = string.Format(PROGRESS_TEXT_FORMAT, playerStatsCurrent.xp, xpMax.ToString("0"));
            levelImage.fillAmount = (playerStatsCurrent.xp - xpMin) / ( xpMax - xpMin);
        }
    }
}