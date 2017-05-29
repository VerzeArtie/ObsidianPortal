using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ObsidianPortal
{
    public class MainCharacter : MonoBehaviour
    {
        // basic parameter
        public int Level = 1;
        public int Exp = 0;
        public int BaseLife = 10;
        public int Gold = 0;

        // core parameter
        public string FullName = string.Empty;
        public int BaseStrength = 1;
        public int BaseAgility = 1;
        public int BaseIntelligence = 1;
        public int BaseStamina = 1;
        public int BaseMind = 1;
        
        // equipment
        public Item mainWeapon = null;
        public Item subWeapon = null;
        public Item mainArmor = null;
        public Item accessory = null;
        public Item accessory2 = null;

        // Obsidian parameter
        public int ObsidianStone = 1;
        public FIX.Race Race = FIX.Race.Human;

        public int MaxLife
        {
            get
            {
                int result = this.BaseLife;
                result += TotalStamina;
                return result;
            }
        }

        protected int currentLife = 0;
        public int CurrentLife
        {
            get { return currentLife; }
            set
            {
                if (value >= MaxLife)
                {
                    value = MaxLife;
                }
                if (value <= 0)
                {
                    value = 0;
                }
                currentLife = value;
            }
        }

        protected int buffStrength_MainWeapon = 0;
        protected int buffAgility_MainWeapon = 0;
        protected int buffIntelligence_MainWeapon = 0;
        protected int buffStamina_MainWeapon = 0;
        protected int buffMind_MainWeapon = 0;

        protected int buffStrength_SubWeapon = 0;
        protected int buffAgility_SubWeapon = 0;
        protected int buffIntelligence_SubWeapon = 0;
        protected int buffStamina_SubWeapon = 0;
        protected int buffMind_SubWeapon = 0;

        protected int buffStrength_Armor = 0;
        protected int buffAgility_Armor = 0;
        protected int buffIntelligence_Armor = 0;
        protected int buffStamina_Armor = 0;
        protected int buffMind_Armor = 0;

        protected int buffStrength_Accessory = 0;
        protected int buffAgility_Accessory = 0;
        protected int buffIntelligence_Accessory = 0;
        protected int buffStamina_Accessory = 0;
        protected int buffMind_Accessory = 0;

        protected int buffStrength_Accessory2 = 0;
        protected int buffAgility_Accessory2 = 0;
        protected int buffIntelligence_Accessory2 = 0;
        protected int buffStamina_Accessory2 = 0;
        protected int buffMind_Accessory2 = 0;

        protected bool dead = false;
        public bool Dead
        {
            get { return dead; }
            set { dead = value; }
        }

        public Item MainWeapon
        {
            get { return mainWeapon; }
            set
            {
                mainWeapon = value;
                if (mainWeapon != null)
                {
                    this.buffStrength_MainWeapon = mainWeapon.BuffUpStrength;
                    this.buffAgility_MainWeapon = mainWeapon.BuffUpAgility;
                    this.buffIntelligence_MainWeapon = mainWeapon.BuffUpIntelligence;
                    this.buffStamina_MainWeapon = mainWeapon.BuffUpStamina;
                    this.buffMind_MainWeapon = mainWeapon.BuffUpMind;
                }
                else
                {
                    this.buffStrength_MainWeapon = 0;
                    this.buffAgility_MainWeapon = 0;
                    this.buffIntelligence_MainWeapon = 0;
                    this.buffStamina_MainWeapon = 0;
                    this.buffMind_MainWeapon = 0;
                }
                if (this.CurrentLife > this.MaxLife) this.CurrentLife = this.MaxLife;
            }
        }
        public Item SubWeapon
        {
            get { return subWeapon; }
            set
            {
                subWeapon = value;
                if (subWeapon != null)
                {
                    this.buffStrength_SubWeapon = subWeapon.BuffUpStrength;
                    this.buffAgility_SubWeapon = subWeapon.BuffUpAgility;
                    this.buffIntelligence_SubWeapon = subWeapon.BuffUpIntelligence;
                    this.buffStamina_SubWeapon = subWeapon.BuffUpStamina;
                    this.buffMind_SubWeapon = subWeapon.BuffUpMind;
                }
                else
                {
                    this.buffStrength_SubWeapon = 0;
                    this.buffAgility_SubWeapon = 0;
                    this.buffIntelligence_SubWeapon = 0;
                    this.buffStamina_SubWeapon = 0;
                    this.buffMind_SubWeapon = 0;
                }
                if (this.CurrentLife > this.MaxLife) this.CurrentLife = this.MaxLife;
            }
        }
        public Item MainArmor
        {
            get { return mainArmor; }
            set
            {
                mainArmor = value;
                if (mainArmor != null)
                {
                    this.buffStrength_Armor = mainArmor.BuffUpStrength;
                    this.buffAgility_Armor = mainArmor.BuffUpAgility;
                    this.buffIntelligence_Armor = mainArmor.BuffUpIntelligence;
                    this.buffStamina_Armor = mainArmor.BuffUpStamina;
                    this.buffMind_Armor = mainArmor.BuffUpMind;
                }
                else
                {
                    this.buffStrength_Armor = 0;
                    this.buffAgility_Armor = 0;
                    this.buffIntelligence_Armor = 0;
                    this.buffStamina_Armor = 0;
                    this.buffMind_Armor = 0;
                }
                if (this.CurrentLife > this.MaxLife) this.CurrentLife = this.MaxLife;
            }
        }
        public Item Accessory
        {
            get { return accessory; }
            set
            {
                accessory = value;
                if (accessory != null)
                {
                    this.buffStrength_Accessory = accessory.BuffUpStrength;
                    this.buffAgility_Accessory = accessory.BuffUpAgility;
                    this.buffIntelligence_Accessory = accessory.BuffUpIntelligence;
                    this.buffStamina_Accessory = accessory.BuffUpStamina;
                    this.buffMind_Accessory = accessory.BuffUpMind;
                }
                else
                {
                    this.buffStrength_Accessory = 0;
                    this.buffAgility_Accessory = 0;
                    this.buffIntelligence_Accessory = 0;
                    this.buffStamina_Accessory = 0;
                    this.buffMind_Accessory = 0;
                }
                if (this.CurrentLife > this.MaxLife) this.CurrentLife = this.MaxLife;
            }
        }
        public Item Accessory2
        {
            get { return accessory2; }
            set
            {
                accessory2 = value;
                if (accessory2 != null)
                {
                    this.buffStrength_Accessory2 = accessory2.BuffUpStrength;
                    this.buffAgility_Accessory2 = accessory2.BuffUpAgility;
                    this.buffIntelligence_Accessory2 = accessory2.BuffUpIntelligence;
                    this.buffStamina_Accessory2 = accessory2.BuffUpStamina;
                    this.buffMind_Accessory2 = accessory2.BuffUpMind;
                }
                else
                {
                    this.buffStrength_Accessory2 = 0;
                    this.buffAgility_Accessory2 = 0;
                    this.buffIntelligence_Accessory2 = 0;
                    this.buffStamina_Accessory2 = 0;
                    this.buffMind_Accessory2 = 0;
                }
                if (this.CurrentLife > this.MaxLife) this.CurrentLife = this.MaxLife;
            }
        }

        // GUI
        public Text labelFullName = null;
        public Text labelRace = null;
        public Image ImageRace = null;
        public Image MeterExp = null;
        
        public int TotalStrength
        {
            get
            {
                return this.BaseStrength +
                    this.buffStrength_MainWeapon +
                    this.buffStrength_SubWeapon +
                    this.buffStrength_Armor + 
                    this.buffStrength_Accessory +
                    this.buffStrength_Accessory2;
            }
        }
        public int TotalAgility
        {
            get
            {
                return this.BaseAgility +
                    this.buffAgility_MainWeapon +
                    this.buffAgility_SubWeapon +
                    this.buffAgility_Armor +
                    this.buffAgility_Accessory +
                    this.buffAgility_Accessory2;
            }
        }
        public int TotalIntelligence
        {
            get
            {
                return this.BaseIntelligence +
                  this.buffIntelligence_MainWeapon +
                  this.buffIntelligence_SubWeapon +
                  this.buffIntelligence_Armor +
                  this.buffIntelligence_Accessory +
                  this.buffIntelligence_Accessory2;
            }
        }
        public int TotalStamina
        {
            get
            {
                return this.BaseStamina +
                   this.buffStamina_MainWeapon +
                   this.buffStamina_SubWeapon +
                   this.buffStamina_Armor +
                   this.buffStamina_Accessory +
                   this.buffStamina_Accessory2;
            }
        }
        public int TotalMind
        {
            get
            {
                return this.BaseMind +
                    this.buffMind_MainWeapon +
                    this.buffMind_SubWeapon +
                    this.buffMind_Armor +
                    this.buffMind_Accessory +
                    this.buffMind_Accessory2;
            }
        }

        public void MaxGain()
        {
            this.currentLife = this.MaxLife;
        }

        public void UpdateExp()
        {
            float dx = (float)Exp / (float)NextLevelBorder;
            if (MeterExp != null)
            {
                MeterExp.rectTransform.localScale = new Vector2(dx, 1.0f);
            }
        }
        #region "バックパック制御関連"
        protected Item[] backpack;
        public MainCharacter()
        {
            backpack = new Item[FIX.MAX_BACKPACK_SIZE];
        }

        /// <summary>
        /// バックパックにアイテムを追加します。
        /// </summary>
        /// <param name="item"></param>
        /// <returns>TRUE:追加完了、FALSE:満杯のため追加できない</returns>
        public bool AddBackPack(Item item)
        {
            return AddBackPack(item, 1);
        }
        public bool AddBackPack(Item item, int addValue)
        {
            int dummyValue = 0;
            return AddBackPack(item, addValue, ref dummyValue);
        }
        public bool AddBackPack(Item item, int addValue, ref int addedNumber)
        {
            for (int ii = 0; ii < FIX.MAX_BACKPACK_SIZE; ii++)
            {
                // まだ持っていない場合、１つ目として生成する。
                if (this.backpack[ii] == null)
                {
                    // いや、次を探索すると同名アイテムを持っているかもしれないので、まず検索する。
                    for (int jj = ii + 1; jj < FIX.MAX_BACKPACK_SIZE; jj++)
                    {
                        if (CheckBackPackExist(item, jj) > 0)
                        {
                            // スタック上限以上の場合、別のアイテムとして追加する。
                            if (this.backpack[jj].StackValue >= item.LimitValue)
                            {
                                // 次のアイテムリストへスルー
                                break;
                            }
                            else
                            {
                                // スタック上限を超えていなくても、多数追加で上限を超えてしまう場合
                                if (this.backpack[jj].StackValue + addValue > item.LimitValue)
                                {
                                    // 次のアイテムリストへスルー
                                    break;
                                }
                                else
                                {
                                    this.backpack[jj].StackValue += addValue;
                                    addedNumber = jj;
                                    return true;
                                }
                            }
                        }
                    }

                    // やはり探索しても無かったので、そのまま追加する。
                    this.backpack[ii] = item;
                    this.backpack[ii].StackValue = addValue;
                    addedNumber = ii;
                    return true;
                }
                else
                {
                    // 既に持っている場合、スタック量を増やす。
                    if (this.backpack[ii].Name == item.Name)
                    {
                        // スタック上限以上の場合、別のアイテムとして追加する。
                        if (this.backpack[ii].StackValue >= item.LimitValue)
                        {
                            // 次のアイテムリストへスルー
                        }
                        else
                        {
                            // スタック上限を超えていなくても、多数追加で上限を超えてしまう場合
                            if (this.backpack[ii].StackValue + addValue > item.LimitValue)
                            {
                                // 次のアイテムリストへスルー
                            }
                            else
                            {
                                this.backpack[ii].StackValue += addValue;
                                addedNumber = ii;
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// バックパックのアイテムを削除します。
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool DeleteBackPack(Item item)
        {
            return DeleteBackPack(item, 0);
        }
        /// <summary>
        /// バックパックのアイテムを指定した数だけ削除します。
        /// </summary>
        /// <param name="item"></param>
        /// <param name="deleteValue">削除する数 ０：全て削除、正値：指定数だけ削除</param>
        /// <returns></returns>
        public bool DeleteBackPack(Item item, int deleteValue)
        {
            for (int ii = 0; ii < FIX.MAX_BACKPACK_SIZE; ii++)
            {
                if (this.backpack[ii] != null)
                {
                    if (this.backpack[ii].Name == item.Name)
                    {
                        if (deleteValue <= 0)
                        {
                            this.backpack[ii] = null;
                            break;
                        }
                        else
                        {
                            // スタック量が正値の場合、指定されたスタック量を減らす。
                            this.backpack[ii].StackValue -= deleteValue;
                            if (this.backpack[ii].StackValue <= 0) // 結果的にスタック量が０になった場合はオブジェクトを消す。
                            {
                                this.backpack[ii] = null;
                            }
                            break;
                        }
                    }
                }
            }
            return true;
        }
        public bool DeleteBackPack(Item item, int deleteValue, int ii)
        {
            if (this.backpack[ii] != null)
            {
                if (this.backpack[ii].Name == item.Name)
                {
                    // スタック量が１以下の場合、生成されているオブジェクトを消す。
                    if (this.backpack[ii].StackValue <= 1)
                    {
                        this.backpack[ii] = null;
                    }
                    else
                    {
                        // スタック量が１より大きい場合、指定されたスタック量を減らす。
                        this.backpack[ii].StackValue -= deleteValue;
                        if (this.backpack[ii].StackValue <= 0) // 結果的にスタック量が０になった場合はオブジェクトを消す。
                        {
                            this.backpack[ii] = null;
                        }
                    }
                }
            }
            return true;
        }

        public void DeleteBackPackAll()
        {
            this.backpack = null;
            this.backpack = new Item[FIX.MAX_BACKPACK_SIZE];
        }
        /// <summary>
        /// バックパックに対象のアイテムが含まれている数を示します。
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int CheckBackPackExist(Item item, int ii)
        {
            if (this.backpack[ii] != null)
            {
                if (this.backpack[ii].Name == item.Name)
                {
                    return this.backpack[ii].StackValue;
                }
            }
            return 0;
        }

        /// <summary>
        /// バックパックに対象のアイテムが含まれているかどうかをチェックします。
        /// </summary>
        /// <param name="itemName">検索対象となるアイテム名</param>
        /// <returns>true: 存在する,  false: 存在しない</returns>
        public bool FindBackPackItem(string itemName)
        {
            Item[] list = this.GetBackPackInfo();
            for (int ii = 0; ii < list.Length; ii++)
            {
                if (list[ii] != null && list[ii].Name == itemName)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// アイテム内容を全面的に入れ替えます。
        /// </summary>
        /// <param name="item"></param>
        public void ReplaceBackPack(Item[] item)
        {
            this.backpack = null;
            this.backpack = new Item[FIX.MAX_BACKPACK_SIZE];
            for (int ii = 0; ii < item.Length; ii++)
            {
                if (item[ii] != null)
                {
                    this.backpack[ii] = new Item(item[ii].Name);
                    this.backpack[ii].StackValue = item[ii].StackValue;
                }
            }
        }

        /// <summary>
        /// バックパックの内容を一括で全て取得します。
        /// </summary>
        /// <returns></returns>
        public Item[] GetBackPackInfo()
        {
            return backpack;
        }

        #endregion

        public int NextLevelBorder
        {
            get
            {
                int nextValue = 0;
                switch (this.Level)
                {
                    case 1:
                        nextValue = 150;
                        break;
                    case 2:
                        nextValue = 300;
                        break;
                    case 3:
                        nextValue = 490;
                        break;
                    case 4:
                        nextValue = 680;
                        break;
                    case 5:
                        nextValue = 870;
                        break;
                    case 6:
                        nextValue = 1060;
                        break;
                    case 7:
                        nextValue = 1300;
                        break;
                    case 8:
                        nextValue = 1540;
                        break;
                    case 9:
                        nextValue = 1780;
                        break;
                    case 10:
                        nextValue = 2020;
                        break;
                    case 11:
                        nextValue = 2320;
                        break;
                    case 12:
                        nextValue = 2620;
                        break;
                    case 13:
                        nextValue = 2920;
                        break;
                    case 14:
                        nextValue = 3220;
                        break;
                    case 15:
                        nextValue = 3590;
                        break;
                    case 16:
                        nextValue = 3960;
                        break;
                    case 17:
                        nextValue = 4330;
                        break;
                    case 18:
                        nextValue = 4700;
                        break;
                    case 19:
                        nextValue = 5370;
                        break;
                    case 20:
                        nextValue = 6640;
                        break;
                    case 21:
                        nextValue = 7910;
                        break;
                    case 22:
                        nextValue = 9180;
                        break;
                    case 23:
                        nextValue = 10450;
                        break;
                    case 24:
                        nextValue = 12370;
                        break;
                    case 25:
                        nextValue = 14290;
                        break;
                    case 26:
                        nextValue = 16210;
                        break;
                    case 27:
                        nextValue = 18130;
                        break;
                    case 28:
                        nextValue = 20750;
                        break;
                    case 29:
                        nextValue = 23370;
                        break;
                    case 30:
                        nextValue = 25990;
                        break;
                    case 31:
                        nextValue = 28610;
                        break;
                    case 32:
                        nextValue = 31980;
                        break;
                    case 33:
                        nextValue = 35350;
                        break;
                    case 34:
                        nextValue = 39720;
                        break;
                    case 35:
                        nextValue = 44090;
                        break;
                    case 36:
                        nextValue = 48460;
                        break;
                    case 37:
                        nextValue = 52830;
                        break;
                    case 38:
                        nextValue = 58300;
                        break;
                    case 39:
                        nextValue = 63770;
                        break;
                    case 40:
                        nextValue = 69240;
                        break;
                    case 41:
                        nextValue = 74710;
                        break;
                    case 42:
                        nextValue = 81380;
                        break;
                    case 43:
                        nextValue = 88050;
                        break;
                    case 44:
                        nextValue = 94720;
                        break;
                    case 45:
                        nextValue = 101390;
                        break;
                    case 46:
                        nextValue = 109360;
                        break;
                    case 47:
                        nextValue = 117330;
                        break;
                    case 48:
                        nextValue = 125300;
                        break;
                    case 49:
                        nextValue = 134770;
                        break;
                    case 50:
                        nextValue = 146240;
                        break;
                    case 51:
                        nextValue = 157710;
                        break;
                    case 52:
                        nextValue = 169180;
                        break;
                    case 53:
                        nextValue = 182850;
                        break;
                    case 54:
                        nextValue = 196520;
                        break;
                    case 55:
                        nextValue = 210190;
                        break;
                    case 56:
                        nextValue = 226260;
                        break;
                    case 57:
                        nextValue = 242330;
                        break;
                    case 58:
                        nextValue = 258400;
                        break;
                    case 59:
                        nextValue = 277070;
                        break;
                    case 60:
                        nextValue = 295740;
                        break;
                    case 61:
                        nextValue = 314410;
                        break;
                    case 62:
                        nextValue = 333080;
                        break;
                    case 63:
                        nextValue = 351750;
                        break;
                    case 64:
                        nextValue = 378420;
                        break;
                    case 65:
                        nextValue = 405090;
                        break;
                    case 66:
                        nextValue = 431760;
                        break;
                    case 67:
                        nextValue = 458430;
                        break;
                    case 68:
                        nextValue = 485100;
                        break;
                    case 69:
                        nextValue = 511770;
                        break;
                    case 70:
                        nextValue = 1023540;
                        break;
                }
                return nextValue;
            }
        }
    }
}