using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Parent class for Items
/// </summary>
public abstract class PItem : MonoBehaviour
{
    protected string itemName;
    protected StatType statType;
    protected ItemCategory itemCategory;
    protected float statChange;

    /// <summary>
    /// StatType helps us determine what to change on the player
    /// </summary>
    public enum StatType
    {
        Speed,
        Size,
        DashDistance,
        DashPower,
        Knockback,
        MoneyModifier
    };

    /// <summary>
    /// Based on category, we can determine how the item affects the player
    /// </summary>
    public enum ItemCategory
    {
        Buff,
        Challenge,
        Double,
        Sabotage,
        Universal
    }

    /// <summary>
    /// CONSTRUCTOR
    /// </summary>
    /// <param name="stat"></param>
    /// <param name="category"></param>
    /// <param name="name"></param>
    /// <param name="statVal"></param>
    public PItem(StatType stat, ItemCategory category, string name, float statVal)
    {
        itemName = name;
        itemCategory = category;
        statType = stat;
        statChange = statVal;
    }

    /// <summary>
    /// This method allows the item to affect the player
    /// </summary>
    /// <param name="player"></param>
    public virtual void ItemEffect(PlayerInfo player)
    {
        switch (statType)
        {
            case StatType.Speed:
                player.speed += statChange;
                break;
            case StatType.Size:
                player.size += statChange;
                break;
            case StatType.DashDistance:
                player.dashDistance += statChange;
                break;
            case StatType.DashPower:
                player.dashPower += statChange;
                break;
            case StatType.Knockback:
                player.knockback += statChange;
                break;
            case StatType.MoneyModifier:
                player.moneyModifier += statChange;
                break;
            default:
                print("Item StatType invalid!");
                break;
        }
    }
}
