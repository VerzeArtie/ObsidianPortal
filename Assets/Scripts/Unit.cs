using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace ObsidianPortal
{
    public partial class Unit : MonoBehaviour
    {
        public enum Ally
        {
            Ally = 0,
            Enemy = 1,
            TimerKeeper = 2,
        }

        public enum GenderType
        {
            None,
            Male,
            Female,
            TransGender,
            Agender,
        }

        // basic parameter
        public int Level = 1;
        public int Exp = 0;
        public int BaseLife = 10;
        public int Gold = 0;

        // core parameter
        public int BaseStrength = 1;
        public int BaseAgility  = 1;
        public int BaseIntelligence = 1;
        public int BaseStamina = 1;
        public int BaseMind = 1;

        // appearance
        public string FullName = string.Empty;
        public string Personality = String.Empty;
        public string MainColor = String.Empty;

        // ability
        public int Ability_01 = 0; // weapon-1
        public int Ability_02 = 0; // weapon-2
        public int Ability_03 = 0; // weapon-3
        public int Ability_04 = 0; // weapon-4
        public int Ability_05 = 0; // weapon-5
        public int Ability_06 = 0; // skill-1
        public int Ability_07 = 0; // skill-2
        public int Ability_08 = 0; // skill-3
        public int Ability_09 = 0; // skill-4
        public int Ability_10 = 0; // skill-5
        public int Ability_11 = 0; // skill-6
        public int Ability_12 = 0; // skill-7
        public int Ability_13 = 0; // skill-8
        public int Ability_14 = 0; // skill-9
        public int Ability_15 = 0; // skill-10
        public int Ability_16 = 0; // skill-11
        public int Ability_17 = 0; // skill-12

        // current-status
        public int ActivePoint = 100;

        // Available List
        public List<string> AvailableCommandName = new List<string>();
        public List<int> AvailableCommandLv = new List<int>();
        public List<string> AvailableCommandValue = new List<string>();

        // equipment
        public Item mainWeapon = null;
        public Item subWeapon = null;
        public Item mainArmor = null;
        public Item accessory = null;
        public Item accessory2 = null;
        public Item accessory3 = null;
        public Item stone1 = null;

        // Obsidian parameter
        protected int soulFragment = 0;
        public int SoulFragment
        {
            get { return soulFragment; }
            set { soulFragment = value; }
        }

        protected int obsidianStone = 0;
        public int ObsidianStone
        {
            get { return obsidianStone; }
            set { obsidianStone = value; }
        }
        public FIX.RaceType Race = FIX.RaceType.None;
        protected FIX.JobClass job = FIX.JobClass.None;
        public FIX.JobClass Job
        {
            set { job = value; }
            get { return job; }
        }

        public int MaxLife
        {
            get
            {
                int result = this.BaseLife;
                result += TotalStamina * 10;
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

        protected int buffStrength_Accessory3 = 0;
        protected int buffAgility_Accessory3 = 0;
        protected int buffIntelligence_Accessory3 = 0;
        protected int buffStamina_Accessory3 = 0;
        protected int buffMind_Accessory3 = 0;

        protected int buffStrength_Stone1 = 0;
        protected int buffAgility_Stone1 = 0;
        protected int buffIntelligence_Stone1 = 0;
        protected int buffStamina_Stone1 = 0;
        protected int buffMind_Stone1 = 0;

        // ユニット属性値
        public int MovePoint = 1; // 移動力
        public int AttackRange = 1; // 攻撃範囲
        public int HealRange = 1; // 回復範囲
        public int EffectRange = 1; // 味方効果範囲
        public string SkillName = "";
        public int Cost = 999; // コスト
        public bool ActionComplete = false; // 行動完了フラグ
        public Ally ally = Ally.Ally; // 陣営タイプ
        public int MaxAP = 10;
        private int currentAP = 3; // 現在のアクションポイント
        public int CurrentAP
        {
            get { return currentAP; }
            set
            {
                if (value > this.MaxAP) { value = this.MaxAP; }
                if (value <= 0) { value = 0; }
                currentAP = value;
            }
        }
        protected int currentTime = FIX.MAX_TIME; // 現在待機時間
        public int CurrentTime
        {
            get { return this.currentTime; }
            set
            {
                if (value <= 0) { value = 0; }
                this.currentTime = value;
            }
        }
        protected int shadowCurrentTime = FIX.MAX_TIME; // ユニットの未来順序用
        public int ShadowCurrentTime
        {
            get { return this.shadowCurrentTime; }
            set
            {
                if (value <= 0) { value = 0; }
                this.shadowCurrentTime = value;
            }
        }

        public int CurrentMovePoint = 1; // 現在移動可能ポイント（敵専用）

        // Buff-up Effect
        public int CurrentPowerWord = 0; // STR UP
        public int CurrentPowerWordValue = 0;
        public int CurrentSilverArrow = 0; // SILENCE
        public int CurrentSilverArrowValue = 0;
        public int CurrentProtection = 0; // DEF UP
        public int CurrentProtectionValue = 0;
        public int CurrentFireBlade = 0; // STR UP
        public int CurrentFireBladeValue = 0;
        public int CurrentEarthBind = 0; // Cannot Move
        public int CurrentEarthBindValue = 0;
        public int CurrentHealingWord = 0; // After life gain
        public int CurrentHealingWordValue = 0;
        public int CurrentReachableTarget = 0; // DEF DOWN
        public int CurrentReachabletargetValue = 0;
        public int CurrentAuraOfPower = 0;
        public int CurrentAuraOfPowerValue = 0;
        public TruthImage imgAuraOfPower = null;
        public int CurrentHeartOfLife = 0;
        public int CurrentHeartOfLifeValue = 0;
        public TruthImage imgHeartOfLife = null;
        public int CurrentSkyShield = 0;
        public int CurrentSkyShieldValue = 0;
        public TruthImage imgSkyShield = null;
        public int CurrentStanceOfBlade = 0;
        public int CurrentStanceOfBladeValue = 0;
        public TruthImage imgStanceOfBlade = null;
        public int CurrentStanceOfGuard = 0;
        public int CurrentStanceOfGuardValue = 0;
        public TruthImage imgStanceOfGuard = null;
        public int CurrentFortuneSpirit = 0;
        public int CurrentFortuneSpiritValue = 0;
        public TruthImage imgFortuneSpirit = null;
        public int CurrentZeroImmunity = 0;
        public int CurrentZeroImmunityValue = 0;
        public TruthImage imgZeroImmunity = null;
        public int CurrentDivineCircle = 0;
        public int CurrentDivineCircleValue = 0;
        public TruthImage imgDivineCircle = null;
        //public int CurrentBloodSign = 0;
        //public int CurrentBloodSignValue = 0;
        //public TruthImage imgBloodSign = null;
        public int CurrentFlameBlade = 0;
        public int CurrentFlameBladeValue = 0;
        public TruthImage imgFlameBlade = null;
        public int CurrentStormArmor = 0;
        public int CurrentStormArmorValue = 0;
        public TruthImage imgStormArmor = null;

        public int CurrentWordOfFortune = 0;

        // Injured Effect
        public int CurrentPoison = 0; // 猛毒
        public int CurrentPoisonValue = 0;
        public TruthImage imgPoison = null;
        public int CurrentBlind = 0; // 暗闇
        public int CurrentBlindValue = 0;
        public TruthImage imgBlind = null;
        public int CurrentBind = 0; // 足止
        public int CurrentBindValue = 0;
        public TruthImage imgBind = null;
        public int CurrentSilence = 0; // 沈黙
        public int CurrentSilenceValue = 0;
        public TruthImage imgSilence = null;
        public int CurrentSeal = 0; // 技封
        public int CurrentSealValue = 0;
        public TruthImage imgSeal = null;
        public int CurrentSlow = 0; // 鈍足
        public int CurrentSlowValue = 0;
        public TruthImage imgSlow = null;
        public int CurrentSlip = 0; // 出血
        public int CurrentSlipValue = 0;

        // Battle Value
        public int CurrentPhysicalChargeCount = 0;
        public int CurrentChargeCount = 0;
        public int AmplifyPhysicalAttack = 0;
        public int AmplifyPhysicalDefense = 0;
        public int AmplifyMagicAttack = 0;
        public int AmplifyMagicDefense = 0;
        public int AmplifyBattleSpeed = 0;
        public int AmplifyBattleResponse = 0;
        public int AmplifyPotential = 0;

        public int CurrentSyutyu_Danzetsu = 0;
        public int CurrentSeventhMagic = 0;
        public int CurrentOnslaughtHit = 0;
        public int CurrentOnslaughtHitValue = 0;
        public int CurrentBlindJustice = 0;
        public int CurrentImmolate = 0;
        public int CurrentDarkenField = 0;
        public int CurrentConcussiveHit = 0;
        public int CurrentConcussiveHitValue = 0;
        public int CurrentBlackFire = 0;
        public int CurrentPsychicTrance = 0;
        public int CurrentImpulseHit = 0;
        public int CurrentImpulseHitValue = 0;
        public int CurrentSwiftStep = 0;
        public int CurrentColorlessMove = 0;
        public int CurrentPhantasmalWind = 0;
        public int CurrentVigorSense = 0;
        public int CurrentWordOfMalice = 0;
        public int CurrentParadoxImage = 0;

        public int CurrentPhysicalAttackUpValue = 0;
        public int CurrentPhysicalAttackDownValue = 0;
        public int CurrentPhysicalDefenseUpValue = 0;
        public int CurrentPhysicalDefenseDownValue = 0;
        public int CurrentMagicAttackUpValue = 0;
        public int CurrentMagicAttackDownValue = 0;
        public int CurrentMagicDefenseUpValue = 0;
        public int CurrentMagicDefenseDownValue = 0;
        public int CurrentSpeedUpValue = 0;
        public int CurrentSpeedDownValue = 0;
        public int CurrentReactionUpValue = 0;
        public int CurrentReactionDownValue = 0;
        public int CurrentPotentialUpValue = 0;
        public int CurrentPotentialDownValue = 0;

        // Upkeep Check Flag
        public bool UpkeepCheck = false;

        public string CurrentCommand = FIX.NORMAL_ATTACK;
        public Unit CurrentTarget = null;

        // Gauge
        public List<GameObject> objAP = new List<GameObject>(10);

        // Buff
        public List<GameObject> objBuff = new List<GameObject>();
        public GameObject BuffPanel = null;
        public int BuffNumber = 0;
        public TruthImage[] BuffElement = null; // 「警告」：後編ではこれでBUFF並びを整列する。最終的には個別BUFFのTruthImageは全て不要になる。

        // Enemy-Only
        public bool NowBattle = false;

        public Sprite UnitImage = null;
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
        public Item Accessory3
        {
            get { return accessory3; }
            set
            {
                accessory3 = value;
                if (accessory3 != null)
                {
                    this.buffStrength_Accessory3 = accessory3.BuffUpStrength;
                    this.buffAgility_Accessory3 = accessory3.BuffUpAgility;
                    this.buffIntelligence_Accessory3 = accessory3.BuffUpIntelligence;
                    this.buffStamina_Accessory3 = accessory3.BuffUpStamina;
                    this.buffMind_Accessory3 = accessory3.BuffUpMind;
                }
                else
                {
                    this.buffStrength_Accessory3 = 0;
                    this.buffAgility_Accessory3 = 0;
                    this.buffIntelligence_Accessory3 = 0;
                    this.buffStamina_Accessory3 = 0;
                    this.buffMind_Accessory3 = 0;
                }
                if (this.CurrentLife > this.MaxLife) this.CurrentLife = this.MaxLife;
            }
        }
        public Item Stone
        {
            get { return stone1; }
            set
            {
                stone1 = value;
                if (stone1 != null)
                {
                    this.buffStrength_Stone1 = stone1.BuffUpStrength;
                    this.buffAgility_Stone1 = stone1.BuffUpAgility;
                    this.buffIntelligence_Stone1 = stone1.BuffUpIntelligence;
                    this.buffStamina_Stone1 = stone1.BuffUpStamina;
                    this.buffMind_Stone1 = stone1.BuffUpMind;
                }
                else
                {
                    this.buffStrength_Stone1 = 0;
                    this.buffAgility_Stone1 = 0;
                    this.buffIntelligence_Stone1 = 0;
                    this.buffStamina_Stone1 = 0;
                    this.buffMind_Stone1 = 0;
                }
            }
        }

        // GUI
        public Text labelFullName = null;
        public Text labelRace = null;
        public Image ImageRace = null;
        public Image MeterExp = null;
        public List<string> ActionButtonCommand = new List<string>(5);

        public int TotalStrength
        {
            get
            {
                return this.BaseStrength +
                    this.buffStrength_MainWeapon +
                    this.buffStrength_SubWeapon +
                    this.buffStrength_Armor +
                    this.buffStrength_Accessory +
                    this.buffStrength_Accessory2 +
                    this.buffStrength_Accessory3 +
                    this.buffStrength_Stone1;
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
                    this.buffAgility_Accessory2 +
                    this.buffAgility_Accessory3 +
                    this.buffAgility_Stone1;
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
                  this.buffIntelligence_Accessory2 +
                  this.buffIntelligence_Accessory3 +
                  this.buffIntelligence_Stone1;
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
                   this.buffStamina_Accessory2 +
                   this.buffStamina_Accessory3 +
                   this.buffStamina_Stone1;
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
                    this.buffMind_Accessory2 +
                    this.buffMind_Accessory3 +
                    this.buffMind_Stone1;
            }
        }

        /// <summary>
        /// 初期設定を行う。
        /// </summary>
        public void ConstructUnit(List<GameObject> objButton)
        {
            for (int ii = 0; ii < objButton.Count; ii++)
            {
                Debug.Log("SetupActionButton: " + ii.ToString());
                SetupActionButton(objButton[ii], ActionButtonCommand[ii]);
            }
        }

        /// <summary>
        /// アクションボタンを設定する
        /// </summary>
        /// <param name="actionButton"></param>
        /// <param name="sorceryMark"></param>
        /// <param name="actionCommand"></param>
        private void SetupActionButton(GameObject actionButton, string actionCommand)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S) " + actionCommand);

            if (actionCommand != null && actionCommand != "" && actionCommand != string.Empty)
            {
                actionButton.GetComponent<TruthImage>().sprite = Resources.Load<Sprite>(actionCommand);
                actionButton.name = actionCommand;
            }
            else
            {
                actionButton.GetComponent<TruthImage>().sprite = Resources.Load<Sprite>(FIX.NORMAL_ATTACK);
                actionButton.name = FIX.NORMAL_ATTACK;
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
        protected List<Item> backpack = new List<Item>(FIX.MAX_BACKPACK_SIZE);
        protected List<Item> valuables = new List<Item>(FIX.MAX_BACKPACK_SIZE);
        /// <summary>
        /// バックパックにアイテムを追加します。
        /// </summary>
        /// <param name="item"></param>
        /// <returns>TRUE:追加完了、FALSE:満杯のため追加できない</returns>
        public bool AddBackPack(Item item, int addValue)
        {
            return AbstractAddItem(backpack, item, addValue);
        }
        public bool AddValuables(Item item, int addValue)
        {
            return AbstractAddItem(valuables, item, addValue);
        }
        protected bool AbstractAddItem(List<Item> list, Item item, int addValue)
        {
            // バックパックを検索し、新しいアイテムとして追加するかどうか確認する。
            for (int ii = 0; ii < list.Count; ii++)
            {
                if (list[ii].ItemName == item.ItemName)
                {
                    // スタック上限に指定した数のぶんだけ追加で間に合う場合は、スタック数を追加して終わり。
                    if (list[ii].StackValue + addValue <= item.LimitValue)
                    {
                        list[ii].StackValue += addValue;
                        return true;
                    }
                }
            }

            // バックパックの上限を超えている場合は、満杯とみなして追加しない。
            if (list.Count >= FIX.MAX_BACKPACK_SIZE)
            {
                return false;
            }

            // 新しいアイテムを追加する。
            list.Add(item);
            list[list.Count - 1].StackValue = addValue;
            return true;
        }


        /// <summary>
        /// バックパックのアイテムを指定した数だけ削除します。
        /// </summary>
        /// <param name="item"></param>
        /// <param name="deleteValue">指定数だけ削除</param>
        /// <returns></returns>
        public void DeleteBackPack(Item item, int deleteValue)
        {
            AbstractDeleteItem(backpack, item, deleteValue);
        }
        public void DeleteValuables(Item item, int deteteValue)
        {
            AbstractDeleteItem(valuables, item, deteteValue);
        }
        protected void AbstractDeleteItem(List<Item> list, Item item, int deleteValue)
        {
            for (int ii = 0; ii < list.Count; ii++)
            {
                if (list[ii] != null)
                {
                    if (list[ii].ItemName == item.ItemName)
                    {
                        // スタック量が正値の場合、指定されたスタック量を減らす。
                        list[ii].StackValue -= deleteValue;
                        if (list[ii].StackValue <= 0) // 結果的にスタック量が０になった場合はオブジェクトを消す。
                        {
                            list.RemoveAt(ii);
                        }
                        break;
                    }
                }
            }
        }

        public void DeleteBackPackAll()
        {
            AbstractDeleteItemAll(backpack);
        }
        public void DeleteValuablesAll()
        {
            AbstractDeleteItemAll(valuables);
        }
        protected void AbstractDeleteItemAll(List<Item> list)
        {
            list.Clear();
        }

        /// <summary>
        /// バックパックに対象のアイテムが含まれている数を示します。
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int CheckBackPackExist(Item item, int ii)
        {
            return AbstractItemExist(backpack, item, ii);
        }
        public int CheckValuablesExist(Item item, int ii)
        {
            return AbstractItemExist(valuables, item, ii);
        }
        protected int AbstractItemExist(List<Item> list, Item item, int ii)
        {
            if (list[ii] != null)
            {
                if (list[ii].ItemName == item.ItemName)
                {
                    return list[ii].StackValue;
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
            return AbstractFindItem(backpack, itemName);
        }
        public bool FindValuablesItem(string itemName)
        {
            return AbstractFindItem(valuables, itemName);
        }
        protected bool AbstractFindItem(List<Item> list, string itemName)
        {
            for (int ii = 0; ii < list.Count; ii++)
            {
                if (list[ii] != null && list[ii].ItemName == itemName)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// バックパックの内容を一括で全て取得します。
        /// </summary>
        /// <returns></returns>
        public List<Item> GetBackPackInfo()
        {
            return backpack;
        }
        public List<Item> GetValuablesInfo()
        {
            return valuables;
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

        public void Levelup(string playerName)
        {
            this.Level++;
            this.SoulFragment++;
            switch (playerName)
            {
                case FIX.DUEL_BILLY_RAKI:
                    this.BaseStrength += 3;
                    this.BaseAgility += 2;
                    this.BaseIntelligence += 1;
                    this.BaseStamina += 4;
                    this.BaseMind = 1;
                    break;

                case FIX.DUEL_ANNA_HAMILTON:
                    this.BaseStrength += 2;
                    this.BaseAgility += 3;
                    this.BaseIntelligence += 1;
                    this.BaseStamina += 2;
                    this.BaseMind = 1;
                    break;

                case FIX.DUEL_EONE_FULNEA:
                    this.BaseStrength += 1;
                    this.BaseAgility += 1;
                    this.BaseIntelligence += 3;
                    this.BaseStamina += 2;
                    this.BaseMind = 1;
                    break;
            }
        }
        
        /// <summary>
        /// 倒された時の経験値取得
        /// </summary>
        public int GetExp
        {
            get { return 100; }
        }

        public void Completed()
        {
            this.CurrentTime = FIX.MAX_TIME;
            Debug.Log("Completed: " + this.CurrentTime.ToString());
        }


        public void ActivateBuff(TruthImage imageData, string imageName, int count)
        {
            if (imageData.sprite != null)
            {
                DeBuff(imageData);
            }

            imageData.sprite = Resources.Load<Sprite>(imageName);
            imageData.rectTransform.anchoredPosition = new Vector3(-1 * (FIX.BUFFPANEL_OFFSET_X + FIX.BUFFPANEL_BUFF_WIDTH) * (this.BuffNumber), 0);
            imageData.Count = count;
            imageData.gameObject.SetActive(true);
            this.BuffNumber++;
        }

        public void ChangeBuffImage(TruthImage imageData, string imageName)
        {
            if (imageData.sprite != null)
            {
                imageData.sprite = Resources.Load<Sprite>(imageName);
            }
        }
        public void DeBuff(TruthImage imageData)
        {
            if (imageData != null && imageData.sprite != null)
            {
                RemoveOneBuff(imageData);
                this.BuffNumber--;
            }
        }

        private void RemoveOneBuff(TruthImage imageBox)
        {
            Vector2 tempPoint = imageBox.rectTransform.anchoredPosition; //new Vector3(imageBox.transform.position.x - Database.BUFFPANEL_BUFF_WIDTH, 0);
            MoveNextBuff(tempPoint);

            imageBox.Count = 0;
            imageBox.Cumulative = 0;
            imageBox.sprite = null;
            imageBox.transform.position = new Vector3(FIX.BUFFPANEL_BUFF_WIDTH, 0);
            imageBox.gameObject.SetActive(false);
        }

        private void MoveNextBuff(Vector2 tempPoint)
        {
            Debug.Log("MoveNextBuff(S) " + tempPoint.x);
            for (int ii = 0; ii < FIX.BUFF_NUM; ii++)
            {
                if (tempPoint.x >= this.BuffElement[ii].rectTransform.anchoredPosition.x)
                {
                    this.BuffElement[ii].rectTransform.anchoredPosition = new Vector3(this.BuffElement[ii].rectTransform.anchoredPosition.x + (FIX.BUFFPANEL_OFFSET_X + FIX.BUFFPANEL_BUFF_WIDTH), 0);
                }
            }
        }

        /// <summary>
        /// クリーンナップ
        /// </summary>
        public void CleanUp()
        {
            this.CurrentMovePoint = this.MovePoint;
            BuffCountDown(ref this.CurrentPowerWord);
            BuffCountDown(ref this.CurrentSilverArrow);
            BuffCountDown(ref this.CurrentProtection);
            BuffCountDown(ref this.CurrentFireBlade);
            BuffCountDown(ref this.CurrentEarthBind);
            BuffCountDown(ref this.CurrentHealingWord);
            BuffCountDown(ref this.CurrentPoison, ref this.CurrentPoisonValue);
            BuffCountDown(ref this.CurrentBlind, ref this.CurrentBlindValue);
            BuffCountDown(ref this.CurrentBind, ref this.CurrentBindValue);
            BuffCountDown(ref this.CurrentSilence, ref this.CurrentSilenceValue);
            BuffCountDown(ref this.CurrentSeal, ref this.CurrentSealValue);
            BuffCountDown(ref this.CurrentSlow, ref this.CurrentSlowValue);
            BuffCountDown(ref this.CurrentSlip, ref this.CurrentSlipValue);
            BuffCountDown(ref this.CurrentHeartOfLife, ref this.CurrentHeartOfLifeValue);
            BuffCountDown(ref this.CurrentSkyShield, ref this.CurrentSkyShieldValue);
            BuffCountDown(ref this.CurrentFortuneSpirit, ref this.CurrentFortuneSpiritValue);
            BuffCountDown(ref this.CurrentZeroImmunity, ref this.CurrentZeroImmunityValue);
            BuffCountDown(ref this.CurrentDivineCircle, ref this.CurrentDivineCircleValue);
            //CountDown(ref this.CurrentBloodSign, ref this.CurrentBloodSignValue);
            BuffCountDown(ref this.CurrentStanceOfBlade, ref this.CurrentStanceOfBladeValue);
            BuffCountDown(ref this.CurrentStanceOfGuard, ref this.CurrentStanceOfGuardValue);
            BuffCountDown(ref this.CurrentFlameBlade, ref this.CurrentFlameBladeValue);
            BuffCountDown(ref this.CurrentStormArmor, ref this.CurrentStormArmorValue);

            //this.GetComponent<MeshRenderer>().material = Resources.Load(Type.ToString()) as Material;

            if (this.CurrentHealingWord > 0)
            {
                this.currentLife += ActionCommand.EffectValue(FIX.HEALINGWORD);
                if (this.IsAlly)
                {
                    ONE.BattleHealingDone += ActionCommand.EffectValue(FIX.HEALINGWORD);
                }
            }
            // todo healingWord
        }

        private void BuffCountDown(ref int value1)
        {
            int dummy2 = 0;
            BuffCountDown(ref value1, ref dummy2);
        }
        private void BuffCountDown(ref int value1, ref int value2)
        {
            if (value1 > 0)
            {
                value1--;
                if (value1 <= 0)
                {
                    value1 = 0;
                    value2 = 0;
                }
            }
        }

        public void DeadUnit()
        {
            Debug.Log("DeadUnit: " + this.FullName);
            this.CurrentLife = 0;
            this.Dead = true;
            this.Completed();
            this.GetComponent<MeshRenderer>().material = Resources.Load("Dead") as Material;
        }

        public void TimerProgress()
        {
            AbstractTimerProgress(ref this.currentTime);
        }
        public void ShadowTimerProgress()
        {
            AbstractTimerProgress(ref this.shadowCurrentTime);
        }
        private void AbstractTimerProgress(ref int time)
        {
            int current = (int)(PrimaryLogic.BattleSpeedValue(this));
            if (this.CurrentSlow > 0)
            {
                current = current / CurrentSlowValue;
            }
            if (current <= 1) { current = 1; }

            time -= current;
            if (time <= 0) { time = 0; }
        }

        public bool IsAlly
        {
            get
            {
                if (this.ally == Ally.Ally)
                {
                    return true;
                }
                return false;
            }
        }
        public bool IsEnemy
        {
            get
            {
                if (this.ally == Ally.Enemy)
                {
                    return true;
                }
                return false;
            }
        }

       
        /// <summary>
        /// 飛行可能なユニットかどうか判別します。(trueなら飛行可能)
        /// </summary>
        /// <returns></returns>
        public bool IsFlying()
        {
            // 初版はすべて地上ユニットとする。
            return false;
        }

        /// <summary>
        /// 方向を指定して、隣接する位置情報を取得します。
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public Vector3 GetNeighborhood(FIX.Direction direction)
        {
            if (direction == FIX.Direction.Top)
            {
                return new Vector3(this.transform.localPosition.x, this.transform.localPosition.y + FIX.HEX_MOVE_X, this.transform.localPosition.z);
            }
            else if (direction == FIX.Direction.Left)
            {
                return new Vector3(this.transform.localPosition.x - FIX.HEX_MOVE_X, this.transform.localPosition.y, this.transform.localPosition.z);
            }
            else if (direction == FIX.Direction.Right)
            {
                return new Vector3(this.transform.localPosition.x + FIX.HEX_MOVE_X, this.transform.localPosition.y, this.transform.localPosition.z);
            }
            else if (direction == FIX.Direction.Bottom)
            {
                return new Vector3(this.transform.localPosition.x, this.transform.localPosition.y - FIX.HEX_MOVE_X, this.transform.localPosition.z);
            }

            // same as Top
            return new Vector3(this.transform.localPosition.x + FIX.HEX_MOVE_X, this.transform.localPosition.y, this.transform.localPosition.z);
        }

        /// <summary>
        /// 方向を指定して、ユニットを移動します。
        /// </summary>
        /// <param name="direction"></param>
        public void Move(FIX.Direction direction)
        {
            if (direction == (int)(FIX.Direction.Top))
            {
                this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y + FIX.HEX_MOVE_X, this.transform.localPosition.z);
            }
            else if (direction == FIX.Direction.Left)
            {
                this.transform.localPosition = new Vector3(this.transform.localPosition.x - FIX.HEX_MOVE_X, this.transform.localPosition.y, this.transform.localPosition.z);
            }
            else if (direction == FIX.Direction.Right)
            {
                this.transform.localPosition = new Vector3(this.transform.localPosition.x + FIX.HEX_MOVE_X, this.transform.localPosition.y, this.transform.localPosition.z);
            }
            else if (direction == FIX.Direction.Bottom)
            {
                this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y - FIX.HEX_MOVE_X, this.transform.localPosition.z);
            }
        }

        public static int Compare(Unit a, Unit b)
        {
            if (a.CurrentTime > b.CurrentTime) { return 1; }
            else if (a.CurrentTime == b.CurrentTime) { return 0; }
            else { return -1; }
        }

        public Vector3 Top
        {
            get { return new Vector3(this.transform.localPosition.x, this.transform.localPosition.y + 1, this.transform.localPosition.z); }
        }
        public Vector3 Left
        {
            get { return new Vector3(this.transform.localPosition.x - 1, this.transform.localPosition.y, this.transform.localPosition.z); }
        }
        public Vector3 Right
        {
            get { return new Vector3(this.transform.localPosition.x + 1, this.transform.localPosition.y, this.transform.localPosition.z); }
        }
        public Vector3 Bottom
        {
            get { return new Vector3(this.transform.localPosition.x, this.transform.localPosition.y - 1, this.transform.localPosition.z); }
        }

   }
}