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
        [SerializeField] private GameObject gunUpgradeText;

        [SerializeField] private GameObject startGameDialog;
        [SerializeField] private GameObject gunUpgradeDialog;

        private const string LEVEL_TEXT_FORMAT = "LEVEL {0}";
        private const string PROGRESS_TEXT_FORMAT = "{0}/{1}";
        private const int LIFES = 4;

        private int _level = 5;
        private float _currentXp = 5;
        private float _xpUp = 10;
        private float _currentHp = 10;
        private float _maxHp = 10;
        private float _coinTotal = 0;

        protected override void Awake()
        {
            levelText.text = string.Format(LEVEL_TEXT_FORMAT, _level);
            progressLevelText.text = string.Format(PROGRESS_TEXT_FORMAT, _currentXp, _xpUp);
            progressHealthText.text = string.Format(PROGRESS_TEXT_FORMAT, _currentHp, _maxHp);
            levelImage.fillAmount = _currentXp / _xpUp;
            hpImage.fillAmount = _currentHp / _maxHp;

            for (var i = 0; i < lifeImages.Length; i++)
            {
                lifeImages[i].color = i >= LIFES ? new Color(0.43f, 0.66f, 0.61f, 1) : Color.white;
            }

            coinTotal.text = _coinTotal.ToString("0");
            gunUpgradeText.SetActive(true);

            Time.timeScale = 0;
            startGameDialog.SetActive(true);
        }

        public void OnTriggerGameObjectClick(GameObject gameObj)
        {
            Time.timeScale = gameObj.activeSelf ? 1 : 0;
            gameObj.SetActive(!gameObj.activeSelf);
        }
    }
}