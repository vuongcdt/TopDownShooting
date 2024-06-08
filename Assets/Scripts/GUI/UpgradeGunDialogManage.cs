using UnityEngine;
using UnityEngine.UI;

namespace Scritps.GUI
{
    public class UpgradeGunDialogManage : Singleton<UpgradeGunDialogManage>
    {
        [SerializeField] private BulletStats bulletStats;
        [SerializeField] private Text titleText;
        [SerializeField] private GameObject dialog;

        [SerializeField] private Text currentReloadTimeText;
        [SerializeField] private Text reloadTimeUpText;
        [SerializeField] private Text currentDamageText;
        [SerializeField] private Text damageUpText;
        [SerializeField] private Text currentRangeText;
        [SerializeField] private Text rangeUpText;

        private int _level = 5;
        private float _currentReloadTimeValue = 5;
        private float _reloadTimeUp = 10;
        private float _currentDamageValue = 6;
        private float _damageUp = 12;
        private float _currentRangeValue = 7;
        private float _rangeUp = 11;

        private const string VALUE_UP_FORMAT = "( {0} )";

        public void OnTriggerActive()
        {
            Time.timeScale = dialog.activeSelf ? 1 : 0;
            dialog.SetActive(!dialog.activeSelf);
            SetValueUpgrade();
        }

        private void SetValueUpgrade()
        {
            titleText.text = _level.ToString();
            
            currentReloadTimeText.text = _currentReloadTimeValue.ToString("F");
            reloadTimeUpText.text = string.Format(VALUE_UP_FORMAT,_reloadTimeUp.ToString("F"));
            currentDamageText.text = _currentDamageValue.ToString("F");
            damageUpText.text = string.Format(VALUE_UP_FORMAT,_currentDamageValue.ToString("F"));
            currentRangeText.text = _currentRangeValue.ToString("F");
            rangeUpText.text = string.Format(VALUE_UP_FORMAT,_rangeUp.ToString("F"));
            
        }
    }
}