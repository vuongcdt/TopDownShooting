using UnityEngine;
using UnityEngine.UI;

namespace Scritps.GUI
{
    public class UpgradeGunDialogManage:Singleton<UpgradeGunDialogManage>
    {
        [SerializeField] private BulletStats bulletStats;
        [SerializeField] private Text titleText;
        [SerializeField] private GameObject dialog;
        
        [SerializeField] private Text currentReloadTimeValueText;
        [SerializeField] private Text reloadTimeUpText;
        [SerializeField] private Text currentDamageValueText;
        [SerializeField] private Text damageUpText;
        [SerializeField] private Text currentRangeValueText;
        [SerializeField] private Text rangeUpText; 
        
         private float _currentReloadTimeValue;
         private float _reloadTimeUp;
         private float _currentDamageValue;
         private float _damageUp;
         private float _currentRangeValue;
         private float _rangeUp;

         public void OnActive()
         {
             dialog.SetActive(true);
         }

    }
}