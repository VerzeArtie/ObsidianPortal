using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

namespace ObsidianPortal
{
    public class SinglePlayMenu : MotherForm
    {
        // Group
        public GameObject groupMessage;
        public GameObject groupCreateCharacter;
        public GameObject groupPlayer;
        public GameObject groupCharacter;
        public GameObject groupQuest;
        public GameObject groupMember;
        public GameObject groupShop;
        public GameObject groupBackpack;
        public GameObject groupInn;
        
        // Message
        public Text txtMessage;
        public Image panelHide;
        public Button btnOK;
        private List<string> m_list = new List<string>();
        private List<MessagePack.ActionEvent> e_list = new List<MessagePack.ActionEvent>();
        private int nowReading = 0;
        private bool nowHideing;
        public Text systemMessage;
        public GameObject systemMessagePanel;

        // Backpack
        public GameObject groupBackpackNormal;
        public GameObject groupBackpackValuables;
        public GameObject ItemNormalContent;
        public GameObject ItemValuablesContent;
        public GameObject ItemNode;
        public GameObject ItemDetailGroup;
        public Image ItemDetailImage;
        public Text ItemDetailTitle;
        public Text ItemDetailDesc;
        public Text ItemDetailSpecial;
        public Text ItemDetailStr;
        public Text ItemDetailAgl;
        public Text ItemDetailInt;
        public Text ItemDetailStm;
        public Text ItemDetailMnd;

        // Player View
        public Text txtPlayerName;
        public Text txtPlayerLevel;
        public Text txtCoin;
        public Text txtSoul;
        public Text txtExp;

        // Character View
        public List<Text> CharaName;
        public List<Image> CharaClassImage;
        public List<Text> CharaLevel;
        public List<Text> CharaLife;
        public List<Text> CharaStrength;
        public List<Text> CharaAgility;
        public List<Text> CharaIntelligence;
        public List<Text> CharaStamina;
        public List<Text> CharaMind;
        public List<Text> CharaMainWeapon;
        public List<Image> CharaImgMainWeapon;
        public List<GameObject> CharaBackMainWeapon;
        
        // Battle-Stage View
        public List<Text> txtEnemyName;
        public List<Text> txtEnemyStrength;
        public List<Text> txtEnemyAgility;
        public List<Text> txtEnemyIntelligence;
        public List<Text> txtEnemyStamina;
        public List<Text> txtEnemyMind;

        // Character Creation
        public GameObject groupFirst;
        public GameObject groupSecond;
        public GameObject groupThird;
        public GameObject groupFourth;
        public GameObject groupFinal;
        public GameObject groupComplete;

        protected int ChoiceSpell = 1;
        protected int ChoiceSkill = 2;
        protected int ChoiceClass = 3;
        public Text txtCurrentName;

        public Text txtCharacterName;
        public Text txtCharacterSpell;
        public Button imgCharacterSpell;
        public Text txtCharacterSkill;
        public Button imgCharacterSkill;
        public Text txtCharacterClass;
        public Button imgCharacterClass;

        public Text txtFirstDescription;
        public Text txtSecondDescription;
        public Text txtThirdDescription;

        // Header
        public GameObject groupAppearance;
        public GameObject groupAttributes;
        public GameObject groupAbilities;
        public GameObject groupSkills;

        // Appearance
        public Text txtName;
        public Text txtGender;
        public Text txtPersonality;
        public Text txtMainColor;
        public GameObject objMainColor;

        // Attributes
        public Text txtAvailableAttributes;
        public Text[] txtAttributeValue;

        // Abilities
        public Text txtAvailableAbility;
        public Text txtWeaponTotalValue;
        public Text txtSkillTotalValue;
        public Text[] txtWeaponValue;
        public Text[] txtSkillValue;

        private int CurrentAttribute = 0;
        private int[] CurrentAttributePoint = { 0, 0, 0, 0, 0 };
        private int MaxAttribute = 7;
        private int MaxAttributePoint = 999;

        private int CurrentAbility = 0;
        private int[] CurrentWeaponPoint = { 0, 0, 0, 0, 0 };
        private int[] CurrentSkillPoint = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private int MaxAbility = 9;
        private int MaxWeaponPoint = 99;
        private int MaxSkillPoint = 99;

        public GameObject CharacterContent;
        public GameObject CharacterNode;

        const int HEIGHT = 200;
        const int MARGIN = 10;

        public override void Start()
        {
            base.Start();

            Method.ReloadTruthWorldEnvironment();

            // クエストの設定
            SetupQuestList();

            // キャラクターリストの設定
            SetupCharacterList();

            // 貴重品の設定
            SetupValuablesList();

            // バックパックの設定
            SetupBackpackList();

            // ヘッダー情報（コインとソウルフラグメンツを設定）
            txtCoin.text = ONE.UnitList[0].Gold.ToString();
            txtSoul.text = ONE.UnitList[0].ObsidianStone.ToString();
            
            CurrentAbility = MaxAbility;
            txtAvailableAbility.text = "Available Ability Points: " + CurrentAbility.ToString();
            CurrentAttribute = MaxAttribute;
            txtAvailableAttributes.text = "Available Attribute Points: " + CurrentAttribute.ToString();

            groupAppearance.SetActive(true);
        }
        
        public void TapQuest()
        {
            Debug.Log("TapQuest");
            if (ONE.WE2.EventHomeTown_0001 == false)
            {
                TapBottomMenu(false, false, false, false, false);
                MessagePack.Message10001(ref m_list, ref e_list);
                TapOK();
            }
            else
            {
                TapBottomMenu(true, false, false, false, false);
            }
        }
        public void TapMember()
        {
            Debug.Log("TapMember");
            TapBottomMenu(false, true, false, false, false);
        }
        public void TapShop()
        {
            Debug.Log("TapShop");
            TapBottomMenu(false, false, true, false, false);
        }
        public void TapBackpack()
        {
            Debug.Log("TapBackpack");
            TapBottomMenu(false, false, false, true, false);
        }
        public void TapInn()
        {
            Debug.Log("TapInn");
            TapBottomMenu(false, false, false, false, true);
        }

        private void TapBottomMenu(bool g1, bool g2, bool g3, bool g4, bool g5)
        {
            groupQuest.SetActive(g1);
            groupMember.SetActive(g2);
            groupShop.SetActive(g3);
            groupBackpack.SetActive(g4);
            groupInn.SetActive(g5);
        }
            
        public void TapArea(int number)
        {
            Debug.Log("TapArea: " + number.ToString());
            //if (number == 1)
            //{
            //    SetupEnemy(Database.ENEMY_HIYOWA_BEATLE, Database.ENEMY_HENSYOKU_PLANT, string.Empty);
            //}
            //else if (number == 2)
            //{
            //    SetupEnemy(Database.ENEMY_HENSYOKU_PLANT, Database.ENEMY_GREEN_CHILD, string.Empty);
            //}
            //else if (number == 3)
            //{
            //    SetupEnemy(Database.ENEMY_HIYOWA_BEATLE, Database.ENEMY_GREEN_CHILD, string.Empty);
            //}
            //else if (number == 4)
            //{
            //    SetupEnemy(Database.ENEMY_TINY_MANTIS, Database.ENEMY_HENSYOKU_PLANT, Database.ENEMY_HIYOWA_BEATLE);
            //}
            //else if (number == 5)
            //{
            //}
            //else if (number == 6)
            //{
            //}
        }

        public void TapBattleStart()
        {
            Debug.Log("TapBattleStart");
            SceneManager.LoadScene("BattleField");
        }

        public void TapSelectSpell(int number)
        {
            //GroundOne.MC.AvailableSpellLight = false;
            //GroundOne.MC.AvailableSpellShadow = false;
            //GroundOne.MC.AvailableSpellFire = false;
            //GroundOne.MC.AvailableSpellIce = false;
            //GroundOne.MC.AvailableSpellForce = false;
            //GroundOne.MC.AvailableSpellWill = false;

            this.ChoiceSpell = number;
            if (number == 1)
            {
                txtFirstDescription.text = "正義、救済。ライフ回復がメイン。\r\n蘇生も行える。微力ながら魔法ダメージも可能。";
                //GroundOne.MC.AvailableSpellLight = true;
            }
            else if (number == 2)
            {
                txtFirstDescription.text = "邪悪、犠牲。ライフコントロール、パラメタ減衰がメイン。\r\n代償付き蘇生も行える。永続的ダメージも可能。";
                //GroundOne.MC.AvailableSpellShadow = true;
            }
            else if (number == 3)
            {
                txtFirstDescription.text = "勇猛、浄化。魔法純粋ダメージ（全属性の中で最大）。\r\n追加効果によるダメージも行える。防御無視の概念もたびたび入る。";
                //GroundOne.MC.AvailableSpellFire = true;
            }
            else if (number == 4)
            {
                txtFirstDescription.text = "厳正、調和。状態異常回復、魔法障壁がメイン。\r\n異常に強いデバフを与える効果が稀に存在する。";
                //GroundOne.MC.AvailableSpellIce = true;
            }
            else if (number == 5)
            {
                txtFirstDescription.text = "最強、最適。理論構築、ターン制効果がメイン。\r\n適用／性質／原則の部分修正も行える。魔法でありながら物理属性ダメージを有する。";
                //GroundOne.MC.AvailableSpellForce = true;
            }
            else if (number == 6)
            {
                txtFirstDescription.text = "遮断、無効。バフ除去がメイン。強い特性ダウンを示すものも存在する。\r\nまた、無視やゼロの効果を生み出す魔法もある。";
                //GroundOne.MC.AvailableSpellWill = true;
            }
        }
        public void TapChoiceSpell()
        {
            groupFirst.SetActive(false);
            groupSecond.SetActive(true);
        }

        public void TapSelectSkill(int number)
        {
            //GroundOne.MC.AvailableSkillActive = false;
            //GroundOne.MC.AvailableSkillPassive = false;
            //GroundOne.MC.AvailableSkillSoftness = false;
            //GroundOne.MC.AvailableSkillHardness = false;
            //GroundOne.MC.AvailableSkillTruth = false;
            //GroundOne.MC.AvailableSkillVoid = false;

            this.ChoiceSkill = number;
            if (number == 1)
            {
                txtSecondDescription.text = "積極的に物理ダメージを与える戦術がメイン。";
                //GroundOne.MC.AvailableSkillActive = true;
            }
            else if (number == 2)
            {
                txtSecondDescription.text = "カウンタータイプがメイン。耐性付与もある。";
                //GroundOne.MC.AvailableSkillPassive = true;
            }
            else if (number == 3)
            {
                txtSecondDescription.text = "特性・性質が変化してダメージを与える戦術がメイン。";
                //GroundOne.MC.AvailableSkillSoftness = true;
            }
            else if (number == 4)
            {
                txtSecondDescription.text = "防御および防衛スタイルを破壊するのがメイン。";
                //GroundOne.MC.AvailableSkillHardness = true;
            }
            else if (number == 5)
            {
                txtSecondDescription.text = "自分自身の能力を引き上げるのがメイン。";
                //GroundOne.MC.AvailableSkillTruth = true;
            }
            else if (number == 6)
            {
                txtSecondDescription.text = "相手からの能力変化（主にBUFFダウン）を止めるのがメイン。";
                //GroundOne.MC.AvailableSkillVoid = true;
            }
        }
        public void TapChoiceSkill()
        {
            groupSecond.SetActive(false);
            groupThird.SetActive(true);
        }

        public void TapSelectClassEquip(int number)
        {
            this.ChoiceClass = number;
            if (number == 1)
            {
                txtThirdDescription.text = "【　ファイター　】\r\n【STR】上昇";
            }
            else if (number == 2)
            {
                txtThirdDescription.text = "【　レンジャー　】\r\n【DEX】上昇";
                //GroundOne.MC.CharacterClass = MainCharacter.JobClass.Ranger;
            }
            else if (number == 3)
            {
                txtThirdDescription.text = "【　ウィザード　】\r\n【INT】上昇";
                //GroundOne.MC.CharacterClass = MainCharacter.JobClass.Wizard;
            }
        }
        public void TapChoiceClass()
        {
            groupThird.SetActive(false);
            groupFourth.SetActive(true);
        }

        public void TapChoiceName()
        {
            groupFourth.SetActive(false);

            txtCharacterName.text = txtCurrentName.text;

            if (ChoiceSpell == 1)
            {
                txtCharacterSpell.text = "Light (聖属性）";
                imgCharacterSpell.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("HolyShock");
            }
            else if (ChoiceSpell == 2)
            {
                txtCharacterSpell.text = "Shadow (闇属性）";
                imgCharacterSpell.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("DarkBlast");
            }
            else if (ChoiceSpell == 3)
            {
                txtCharacterSpell.text = "Fire (火属性）";
                imgCharacterSpell.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("FireBall");
            }
            else if (ChoiceSpell == 4)
            {
                txtCharacterSpell.text = "Ice (水属性）";
                imgCharacterSpell.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("FrozenLance");
            }
            else if (ChoiceSpell == 5)
            {
                txtCharacterSpell.text = "Force (理属性）";
                imgCharacterSpell.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("WordOfFortune");
            }
            else if (ChoiceSpell == 6)
            {
                txtCharacterSpell.text = "Will (空属性）";
                imgCharacterSpell.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("WhiteOut");
            }

            if (ChoiceSkill == 1)
            {
                txtCharacterSkill.text = "Active （動属性）";
                imgCharacterSkill.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("StraightSmash");
            }
            else if (ChoiceSkill == 2)
            {
                txtCharacterSkill.text = "Passive （静属性）";
                imgCharacterSkill.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("CounterAttack");
            }
            else if (ChoiceSkill == 3)
            {
                txtCharacterSkill.text = "Softness （柔属性）";
                imgCharacterSkill.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("StanceOfFlow");
            }
            else if (ChoiceSkill == 4)
            {
                txtCharacterSkill.text = "Hardness （剛属性）";
                imgCharacterSkill.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Catastrophe");
            }
            else if (ChoiceSkill == 5)
            {
                txtCharacterSkill.text = "Truth （心眼属性）";
                imgCharacterSkill.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("TruthVision");
            }
            else if (ChoiceSkill == 6)
            {
                txtCharacterSkill.text = "Void （無心属性）";
                imgCharacterSkill.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Negate");
            }

            //txtCharacterClass.text = Enum.Parse(typeof(MainCharacter.JobClass), ChoiceClass.ToString()).ToString();

            if (ChoiceClass == 1)
            {
                txtCharacterClass.text = "ファイター";
                imgCharacterClass.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Unit_Fighter");
            }
            else if (ChoiceClass == 2)
            {
                txtCharacterClass.text = "レンジャー";
                imgCharacterClass.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Unit_Archer");
            }
            else if (ChoiceClass == 3)
            {
                txtCharacterClass.text = "ウィザード";
                imgCharacterClass.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Unit_Sorcerer");
            }

            groupFinal.SetActive(true);
        }

        public void TapCreateCharacter()
        {
            //GroundOne.MC.FullName = txtCharacterName.text;
            //if (ChoiceSpell == 1)
            //{
            //    GroundOne.MC.AvailableSpellLight = true;
            //}
            //else if (ChoiceSpell == 2)
            //{
            //    GroundOne.MC.AvailableSpellShadow = true;
            //}
            //else if (ChoiceSpell == 3)
            //{
            //    GroundOne.MC.AvailableSpellFire = true;
            //}
            //else if (ChoiceSpell == 4)
            //{
            //    GroundOne.MC.AvailableSpellIce = true;
            //}
            //else if (ChoiceSpell == 5)
            //{
            //    GroundOne.MC.AvailableSpellForce = true;
            //}
            //else if (ChoiceSpell == 6)
            //{
            //    GroundOne.MC.AvailableSpellWill = true;
            //}

            //if (ChoiceSkill == 1)
            //{
            //    GroundOne.MC.AvailableSkillActive = true;
            //}
            //else if (ChoiceSkill == 2)
            //{
            //    GroundOne.MC.AvailableSkillPassive = true;
            //}
            //else if (ChoiceSkill == 3)
            //{
            //    GroundOne.MC.AvailableSkillSoftness = true;
            //}
            //else if (ChoiceSkill == 4)
            //{
            //    GroundOne.MC.AvailableSkillHardness = true;
            //}
            //else if (ChoiceSkill == 5)
            //{
            //    GroundOne.MC.AvailableSkillTruth = true;
            //}
            //else if (ChoiceSkill == 6)
            //{
            //    GroundOne.MC.AvailableSkillVoid = true;
            //}
            //GroundOne.MC.CharacterClass = (MainCharacter.JobClass)(Enum.Parse(typeof(MainCharacter.JobClass), ChoiceSpell.ToString()));

        }
        
        private void SetupEnemy(string enemy1, string enemy2, string enemy3)
        {
            // 初期化
            for (int ii = 0; ii < txtEnemyName.Count; ii++)
            {
                txtEnemyName[ii].text = string.Empty;
                txtEnemyStrength[ii].text = string.Empty;
                txtEnemyAgility[ii].text = string.Empty;
                txtEnemyIntelligence[ii].text = string.Empty;
                txtEnemyStamina[ii].text = string.Empty;
                txtEnemyMind[ii].text = string.Empty;
            }

            //GroundOne.enemyName1 = enemy1;
            //GroundOne.enemyName2 = enemy2;
            //GroundOne.enemyName3 = enemy3;

            //TruthEnemyCharacter ec1;
            //GameObject baseObj1 = new GameObject("enemyObj1");
            //ec1 = baseObj1.AddComponent<TruthEnemyCharacter>();
            //ec1.Initialize(GroundOne.enemyName1);
            //TruthEnemyCharacter ec2;
            //GameObject baseObj2 = new GameObject("enemyObj2");
            //ec2 = baseObj2.AddComponent<TruthEnemyCharacter>();
            //ec2.Initialize(GroundOne.enemyName2);
            //TruthEnemyCharacter ec3;
            //GameObject baseObj3 = new GameObject("enemyObj3");
            //ec3 = baseObj3.AddComponent<TruthEnemyCharacter>();
            //ec3.Initialize(GroundOne.enemyName3);

            //List<TruthEnemyCharacter> list = new List<TruthEnemyCharacter>();
            //list.Add(ec1);
            //list.Add(ec2);
            //list.Add(ec3);
            //for (int ii = 0; ii < list.Count; ii++)
            //{
            //    txtEnemyName[ii].text = "LV " + list[ii].Level.ToString() + "  " + list[ii].FirstName;
            //    txtEnemyStrength[ii].text = list[ii].Strength.ToString();
            //    txtEnemyAgility[ii].text = list[ii].Agility.ToString();
            //    txtEnemyIntelligence[ii].text = list[ii].Intelligence.ToString();
            //    txtEnemyStamina[ii].text = list[ii].Stamina.ToString();
            //    txtEnemyMind[ii].text = list[ii].Mind.ToString();
            //}

            //Destroy(baseObj1);
            //Destroy(baseObj2);
            //Destroy(baseObj3);

        }

        public void TapHeaderButton(int number)
        {
            if (number == 0)
            {
                UpdateGroupView(true, false, false);
            }
            else if (number == 1)
            {
                UpdateGroupView(false, true, false);
            }
            else if (number == 2)
            {
                UpdateGroupView(false, false, true);
            }
        }
        private void UpdateGroupView(bool g1, bool g2, bool g3)
        {
            groupAppearance.SetActive(g1);
            groupAttributes.SetActive(g2);
            groupAbilities.SetActive(g3);
        }

        public void TapMaleFamale()
        {
        }

        public void AtttributePlus(int number)
        {
            if (CurrentAttribute <= 0) { return; }
            if (CurrentAttributePoint[number] >= MaxAttributePoint) { return; }
            CurrentAttribute--;
            CurrentAttributePoint[number]++;

            UpdateTotalPoint(txtAttributeValue[number], txtAvailableAttributes, CurrentAttributePoint, number);
            UpdateAttributePoint();
        }
        public void AttributeMinus(int number)
        {
            if (CurrentAttribute >= MaxAttributePoint) { return; }
            if (CurrentAttributePoint[number] <= 0) { return; }
            CurrentAttribute++;
            CurrentAttributePoint[number]--;

            UpdateTotalPoint(txtAttributeValue[number], txtAvailableAttributes, CurrentAttributePoint, number);
            UpdateAttributePoint();
        }

        public void WeaponPlus(int number)
        {
            if (CurrentAbility <= 0) { return; }
            if (CurrentWeaponPoint[number] >= MaxWeaponPoint) { return; }
            CurrentAbility--;
            CurrentWeaponPoint[number]++;

            UpdateTotalPoint(txtWeaponValue[number], txtWeaponTotalValue, CurrentWeaponPoint, number);
            UpdateAbilityPoint();
        }
        public void WeaponMinus(int number)
        {
            if (CurrentAbility >= MaxAbility) { return; }
            if (CurrentWeaponPoint[number] <= 0) { return; }
            CurrentAbility++;
            CurrentWeaponPoint[number]--;

            UpdateTotalPoint(txtWeaponValue[number], txtWeaponTotalValue, CurrentWeaponPoint, number);
            UpdateAbilityPoint();
        }
        public void SkillPlus(int number)
        {
            if (CurrentAbility <= 0) { return; }
            if (CurrentSkillPoint[number] >= MaxSkillPoint) { return; }
            CurrentAbility--;
            CurrentSkillPoint[number]++;

            UpdateTotalPoint(txtSkillValue[number], txtSkillTotalValue, CurrentSkillPoint, number);
            UpdateAbilityPoint();
        }
        public void SkillMinus(int number)
        {
            if (CurrentAbility >= MaxAbility) { return; }
            if (CurrentSkillPoint[number] <= 0) { return; }
            CurrentAbility++;
            CurrentSkillPoint[number]--;

            UpdateTotalPoint(txtSkillValue[number], txtSkillTotalValue, CurrentSkillPoint, number);
            UpdateAbilityPoint();
        }

        public void TapAccept()
        {
            ONE.UnitList[0].FullName = txtName.text;
            ONE.UnitList[0].Personality = txtPersonality.text;
            ONE.UnitList[0].MainColor = txtMainColor.text;
            ONE.UnitList[0].BaseStrength = CurrentAttributePoint[0];
            ONE.UnitList[0].BaseAgility = CurrentAttributePoint[1];
            ONE.UnitList[0].BaseIntelligence = CurrentAttributePoint[2];
            ONE.UnitList[0].BaseStamina = CurrentAttributePoint[3];
            ONE.UnitList[0].BaseMind = CurrentAttributePoint[4];
            ONE.UnitList[0].Ability_01 = CurrentWeaponPoint[0];
            ONE.UnitList[0].Ability_02 = CurrentWeaponPoint[1];
            ONE.UnitList[0].Ability_03 = CurrentWeaponPoint[2];
            ONE.UnitList[0].Ability_04 = CurrentWeaponPoint[3];
            ONE.UnitList[0].Ability_05 = CurrentWeaponPoint[4];
            ONE.UnitList[0].Ability_06 = CurrentSkillPoint[0];
            ONE.UnitList[0].Ability_07 = CurrentSkillPoint[1];
            ONE.UnitList[0].Ability_09 = CurrentSkillPoint[3];
            ONE.UnitList[0].Ability_10 = CurrentSkillPoint[4];
            ONE.UnitList[0].Ability_11 = CurrentSkillPoint[5];
            ONE.UnitList[0].Ability_12 = CurrentSkillPoint[6];
            ONE.UnitList[0].Ability_13 = CurrentSkillPoint[7];
            ONE.UnitList[0].Ability_14 = CurrentSkillPoint[8];
            ONE.UnitList[0].Ability_15 = CurrentSkillPoint[9];
            ONE.UnitList[0].Ability_16 = CurrentSkillPoint[10];
            ONE.UnitList[0].Ability_17 = CurrentSkillPoint[11];
            groupCreateCharacter.SetActive(false);
            groupMember.SetActive(true);
        }

        public void TapCharacterDetail()
        {
        }

        private void UpdateTotalPoint(Text txtCurrent, Text txtTotal, int[] current, int number)
        {
            txtCurrent.text = current[number].ToString();
            int totalPoint = 0;
            for (int ii = 0; ii < current.Length; ii++)
            {
                totalPoint += current[ii];
            }
            txtTotal.text = totalPoint.ToString();
        }

        private void UpdateAbilityPoint()
        {
            txtAvailableAbility.text = "Available Ability Points: " + CurrentAbility.ToString();
        }
        private void UpdateAttributePoint()
        {
            txtAvailableAttributes.text = "Available Attribute Points: " + CurrentAttribute.ToString();
        }

        public void TapItemNormal()
        {
            Debug.Log("TapItemNormal");
            groupBackpackNormal.SetActive(true);
            groupBackpackValuables.SetActive(false);
        }
        public void TapItemValuables()
        {
            Debug.Log("TapItemValuables");
            groupBackpackNormal.SetActive(false);
            groupBackpackValuables.SetActive(true);
        }

        public void TapOK()
        {
            bool ForceSkipTapOK = false;

            if (this.nowReading < this.m_list.Count)
            {
                // 非表示のメッセージ枠を表示する。
                if (this.panelHide.isActiveAndEnabled == false && this.nowHideing)
                {
                    this.panelHide.gameObject.SetActive(true);
                }
                this.groupMessage.SetActive(true);
                this.btnOK.enabled = true;
                this.btnOK.gameObject.SetActive(true);

                // メッセージ処理
                MessagePack.ActionEvent current = this.e_list[this.nowReading];
                if (current == MessagePack.ActionEvent.HomeTownMessageDisplay)
                {
                    systemMessage.text = this.m_list[this.nowReading];
                    systemMessagePanel.SetActive(true);
                }
                else
                {
                    systemMessagePanel.SetActive(false);
                    systemMessage.text = "";
                    txtMessage.text = this.m_list[this.nowReading];
                    //GroundOne.playbackMessage.Add(this.m_list[this.nowReading]);
                }

                // イベント毎の処理
                if (current == MessagePack.ActionEvent.AutoSaveWorldEnvironment)
                {
                    Method.AutoSaveTruthWorldEnvironment();
                    ForceSkipTapOK = true;
                }

                this.nowReading++;
                if (this.m_list[this.nowReading - 1] == "" || ForceSkipTapOK)
                {
                    TapOK();
                }
            }

            if (this.nowReading >= this.m_list.Count)
            {
                this.nowReading = 0;
                this.m_list.Clear();
                this.e_list.Clear();

                this.systemMessage.text = "";
                this.systemMessagePanel.SetActive(false);
                this.txtMessage.text = "";
                this.groupMessage.SetActive(false);
                this.nowHideing = false;
                this.panelHide.gameObject.SetActive(false);
                this.btnOK.enabled = false;
                this.btnOK.gameObject.SetActive(false);
                this.groupMessage.SetActive(false);
            }
        }

        public void TapItemBackpack(Text txtItem)
        {
            Debug.Log("TapItemBackpack");
            Item item = new Item(txtItem.text);
            UpdateItemDetail(item);
            ItemDetailGroup.SetActive(true);
        }
        public void TapItemBackpackBack()
        {
            Debug.Log("TapItemBackpackBack");
            ItemDetailGroup.SetActive(false);
        }
        public void TapItemDelete(Text txtItem)
        {
            Debug.Log("TapItemDelete");
            Item deleteItem = new Item(txtItem.text);
            if (groupBackpackNormal.activeInHierarchy)
            {
                Debug.Log("TapItemDelete: group Normal");
                ONE.UnitList[0].DeleteBackPack(deleteItem, 10);
                foreach (Transform t in ItemNormalContent.transform)
                {
                    GameObject.Destroy(t.gameObject);
                }
                SetupBackpackList();
            }
            else
            {
                Debug.Log("TapItemDelete: group else");
                ONE.UnitList[0].DeleteValuables(deleteItem, 10);
                foreach (Transform t in ItemValuablesContent.transform)
                {
                    GameObject.Destroy(t.gameObject);
                }
                SetupValuablesList();
            }
            
            this.ItemDetailGroup.SetActive(false);
        }


        private void UpdateItemDetail(Item item)
        {
            Method.UpdateItemImage(item, ItemDetailImage);
            ItemDetailTitle.text = item.ItemName;
            ItemDetailDesc.text = item.Description;
            ItemDetailSpecial.text = item.UseSpecialAbility.ToString();

            if (item.BuffUpStrength <= 0) { ItemDetailStr.text = "----"; }
            else { ItemDetailStr.text = item.BuffUpStrength.ToString(); }

            if (item.BuffUpAgility <= 0) { ItemDetailAgl.text = "----"; }
            else { ItemDetailAgl.text = item.BuffUpAgility.ToString(); }

            if (item.BuffUpIntelligence <= 0) { ItemDetailInt.text = "----"; }
            else { ItemDetailInt.text = item.BuffUpIntelligence.ToString(); }

            if (item.BuffUpStamina <= 0) { ItemDetailStm.text = "----"; }
            else { ItemDetailStm.text = item.BuffUpStamina.ToString(); }

            if (item.BuffUpMind <= 0) { ItemDetailMnd.text = "----"; }
            else { ItemDetailMnd.text = item.BuffUpMind.ToString(); }
        }

        private void SetupQuestList()
        {
            //RectTransform rect = ItemNormalContent.GetComponent<RectTransform>();
            //for (int ii = 0; ii < ONE.Chara.Count; ii++)
            //{
            //    List<Item> backpack = ONE.Chara[ii].GetBackPackInfo();

            //    Debug.Log("backpack length: " + backpack.Count.ToString());
            //    for (int jj = 0; jj < backpack.Count; jj++)
            //    {
            //        if (backpack[jj] == null) { continue; }
            //        if (backpack[jj].Name == "" || backpack[jj].Name == String.Empty) { continue; }

            //        Debug.Log("backpack " + jj.ToString() + " " + backpack[jj].Name);

            //        // 個数に応じて、コンテンツ長さを延長する。
            //        rect.sizeDelta = new Vector2(rect.sizeDelta.x, rect.sizeDelta.y + HEIGHT);

            //        GameObject item = GameObject.Instantiate(ItemNode);
            //        item.transform.SetParent(ItemNormalContent.transform, false);
            //        item.transform.localPosition = new Vector3(item.transform.localPosition.x, item.transform.localPosition.y - HEIGHT * jj, item.transform.localPosition.z);
            //        item.SetActive(true);

            //        Text[] txtField = item.GetComponentsInChildren<Text>();
            //        Text txtColorField = null;
            //        Text txtColorFieldNum = null;
            //        for (int kk = 0; kk < txtField.Length; kk++)
            //        {
            //            if (txtField[kk].name == "txtItem") { txtField[kk].text = backpack[jj].Name; txtColorField = txtField[kk]; }
            //            if (txtField[kk].name == "txtItemNumber") { txtField[kk].text = "x " + backpack[jj].StackValue.ToString(); txtColorFieldNum = txtField[kk]; }
            //        }

            //        Image[] imgField = item.GetComponentsInChildren<Image>();
            //        Image img_item = null;
            //        Image[] objField = item.GetComponentsInChildren<Image>();
            //        Image obj_back = null; ;
            //        for (int kk = 0; kk < imgField.Length; kk++)
            //        {
            //            if (objField[kk].name == "back_item")
            //            {
            //                obj_back = objField[kk];
            //                break;
            //            }
            //        }

            //        for (int kk = 0; kk < imgField.Length; kk++)
            //        {
            //            if (imgField[kk].name == "imgItem")
            //            {
            //                img_item = imgField[kk];
            //                Method.UpdateItemImage(backpack[jj], imgField[kk]);
            //                Method.UpdateRareColor(backpack[jj], txtColorField, obj_back.gameObject, txtColorFieldNum);
            //            }
            //        }
            //    }

            //}
            //// 最後に余白を追加しておく。
            //rect.sizeDelta = new Vector2(rect.sizeDelta.x, rect.sizeDelta.y + MARGIN);
        }

        private void SetupCharacterList()
        {
            RectTransform rect = CharacterContent.GetComponent<RectTransform>();
            for (int ii = 0; ii < ONE.UnitList.Count; ii++)
            {
                GameObject item = GameObject.Instantiate(CharacterNode);
                item.transform.SetParent(CharacterContent.transform, false);
                item.transform.localPosition = new Vector3(item.transform.localPosition.x, item.transform.localPosition.y - HEIGHT * ii, item.transform.localPosition.z);
                item.SetActive(true);

                // 個数に応じて、コンテンツ長さを延長する。
                rect.sizeDelta = new Vector2(rect.sizeDelta.x, rect.sizeDelta.y + HEIGHT);
                item.GetComponentInChildren<Text>().text = ONE.UnitList[ii].FullName;
                Text[] txtField = item.GetComponentsInChildren<Text>();
                for (int jj = 0; jj < txtField.Length; jj++)
                {
                    Debug.Log("txtfield: " + txtField[jj].name);
                    if (txtField[jj].name == "CharaName") { txtField[jj].text = ONE.UnitList[ii].FullName; }
                    if (txtField[jj].name == "txtLevel") { txtField[jj].text = ONE.UnitList[ii].Level.ToString(); }
                    if (txtField[jj].name == "txtLife") { txtField[jj].text = ONE.UnitList[ii].MaxLife.ToString(); }
                    if (txtField[jj].name == "txtStrength") { txtField[jj].text = ONE.UnitList[ii].TotalStrength.ToString(); }
                    if (txtField[jj].name == "txtAgility") { txtField[jj].text = ONE.UnitList[ii].TotalAgility.ToString(); }
                    if (txtField[jj].name == "txtIntelligence") { txtField[jj].text = ONE.UnitList[ii].TotalIntelligence.ToString(); }
                    if (txtField[jj].name == "txtStamina") { txtField[jj].text = ONE.UnitList[ii].TotalStamina.ToString(); }
                    if (txtField[jj].name == "txtMind") { txtField[jj].text = ONE.UnitList[ii].TotalMind.ToString(); }
                    if (txtField[jj].name == "txtMainWeapon")
                    {
                        if (ONE.UnitList[ii].MainWeapon != null)
                        {
                            txtField[jj].text = ONE.UnitList[ii].MainWeapon.ItemName;
                            Image current = txtField[jj].GetComponentInParent<Image>();
                            if (current == null) { Debug.Log("current image is null?"); }
                            else
                            {

                                GameObject parent = current.gameObject;
                                Image[] imgIcon = parent.GetComponentsInChildren<Image>();
                                for (int kk = 0; kk < imgIcon.Length; kk++)
                                {
                                    if (imgIcon[kk].name == "imgMainWeapon")
                                    {
                                        Method.UpdateItemImage(ONE.UnitList[ii].MainWeapon, imgIcon[kk]);
                                        break;
                                    }
                                }
                                Method.UpdateRareColor(ONE.UnitList[ii].MainWeapon, txtField[jj], parent, null);
                            }
                        }
                    }
                }
                Image[] imgField = item.GetComponentsInChildren<Image>();
                for (int jj = 0; jj < imgField.Length; jj++)
                {
                    if (imgField[jj].name == "CharaClass")
                    {
                        Method.UpdateJobClassImage(ONE.UnitList[ii].Job, imgField[jj].gameObject);
                        break;
                    }
                }
            }
            // 最後に余白を追加しておく。
            rect.sizeDelta = new Vector2(rect.sizeDelta.x, rect.sizeDelta.y + MARGIN);
        }

        private void SetupBackpackList()
        {
            groupBackpack.SetActive(true);
            groupBackpackNormal.SetActive(true);
            groupBackpackValuables.SetActive(false);
            AbstractSetupItemList(ItemNormalContent, ONE.UnitList[0].GetBackPackInfo());
        }
        private void SetupValuablesList()
        {
            groupBackpack.SetActive(true);
            groupBackpackNormal.SetActive(false);
            groupBackpackValuables.SetActive(true);
            AbstractSetupItemList(ItemValuablesContent, ONE.UnitList[0].GetValuablesInfo());
        }
        private void AbstractSetupItemList(GameObject groupContent, List<Item> list)
        {
            RectTransform rect = groupContent.GetComponent<RectTransform>();
            rect.sizeDelta = new Vector2(rect.sizeDelta.x, 1);
            Debug.Log("list length: " + list.Count.ToString());
            for (int jj = 0; jj < list.Count; jj++)
            {
                if (list[jj] == null) { continue; }
                if (list[jj].ItemName == "" || list[jj].ItemName == String.Empty) { continue; }

                Debug.Log("list " + jj.ToString() + " " + list[jj].ItemName);

                // 個数に応じて、コンテンツ長さを延長する。
                rect.sizeDelta = new Vector2(rect.sizeDelta.x, rect.sizeDelta.y + HEIGHT);

                GameObject item = GameObject.Instantiate(ItemNode);
                item.transform.SetParent(groupContent.transform, false);
                item.transform.localPosition = new Vector3(item.transform.localPosition.x, item.transform.localPosition.y - HEIGHT * jj, item.transform.localPosition.z);
                item.SetActive(true);

                Text[] txtField = item.GetComponentsInChildren<Text>();
                Text txtColorField = null;
                Text txtColorFieldNum = null;
                for (int kk = 0; kk < txtField.Length; kk++)
                {
                    if (txtField[kk].name == "txtItem") { txtField[kk].text = list[jj].ItemName; txtColorField = txtField[kk]; }
                    if (txtField[kk].name == "txtItemNumber") { txtField[kk].text = "x " + list[jj].StackValue.ToString(); txtColorFieldNum = txtField[kk]; }
                }

                Image[] imgField = item.GetComponentsInChildren<Image>();
                Image img_item = null;
                Image[] objField = item.GetComponentsInChildren<Image>();
                Image obj_back = null; ;
                for (int kk = 0; kk < imgField.Length; kk++)
                {
                    if (objField[kk].name == "back_item")
                    {
                        obj_back = objField[kk];
                        break;
                    }
                }

                for (int kk = 0; kk < imgField.Length; kk++)
                {
                    if (imgField[kk].name == "imgItem")
                    {
                        img_item = imgField[kk];
                        Method.UpdateItemImage(list[jj], imgField[kk]);
                        Method.UpdateRareColor(list[jj], txtColorField, obj_back.gameObject, txtColorFieldNum);
                    }
                }
            }
            // 最後に余白を追加しておく。
            rect.sizeDelta = new Vector2(rect.sizeDelta.x, rect.sizeDelta.y + MARGIN);
        }
    }
}
