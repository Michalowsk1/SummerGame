using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class upgradePurchase : MonoBehaviour
{

    int DamageUpgradeCost = 10;
    int ArmourUpgradeCost = 10;
    int HealingUpgradeCost = 10;

    int hpupgradeCount = 0;

    [SerializeField] TextMeshProUGUI damageCost;
    [SerializeField] TextMeshProUGUI armourCost;
    [SerializeField] TextMeshProUGUI HealingCost;
    public void DamageUpgrade()
    {
        if(PointSystem.pointCount >= DamageUpgradeCost)
        {
            PointSystem.pointCount -= DamageUpgradeCost;
            playerAttack.dmg = playerAttack.dmg * 2;
            DamageUpgradeCost = DamageUpgradeCost + 15;
            damageCost.text = "x " + DamageUpgradeCost;
        }
    }

    public void ArmourUpgrade()
    {

        if (PointSystem.pointCount >= ArmourUpgradeCost)
        {
            PointSystem.pointCount -= ArmourUpgradeCost;
            playerAttack.armour = playerAttack.armour * 2;
            ArmourUpgradeCost = ArmourUpgradeCost + 20;
            armourCost.text = "x " + ArmourUpgradeCost;
        } 
    }

    public void HealingUpgrade()
    {
        if (PointSystem.pointCount >= HealingUpgradeCost)
        {

            if(hpupgradeCount >= 0 && hpupgradeCount <= 3)
            {
                playerAttack.hpRecover = playerAttack.hpRecover - 5;
                PointSystem.pointCount -= HealingUpgradeCost;
                HealingUpgradeCost = HealingUpgradeCost + 50;
                HealingCost.text = "x " + HealingUpgradeCost;
                hpupgradeCount++;
            }

            if(hpupgradeCount >= 3 && hpupgradeCount <= 6)
            {
                playerAttack.hpRecover = playerAttack.hpRecover - 3;
                PointSystem.pointCount -= HealingUpgradeCost;
                HealingUpgradeCost = HealingUpgradeCost + 50;
                HealingCost.text = "x " + HealingUpgradeCost;
                hpupgradeCount++;
            }

            else if (hpupgradeCount >= 6 && hpupgradeCount < 8)
            {
                playerAttack.hpRecover = playerAttack.hpRecover - 2;
                PointSystem.pointCount -= HealingUpgradeCost;
                HealingUpgradeCost = HealingUpgradeCost + 50;
                HealingCost.text = "x " + HealingUpgradeCost;
                hpupgradeCount++;
            }

            else if (hpupgradeCount >= 8)
            {

            }

            
        }
    }
}
