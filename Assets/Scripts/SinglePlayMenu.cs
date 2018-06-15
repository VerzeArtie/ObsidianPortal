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
        public GameObject groupCreateCharacter;
        public GameObject groupPlayer;
        public GameObject groupCharacter;
        public GameObject groupStage;
        public GameObject groupMainMenu;

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

        public GameObject node;
        public GameObject content;

        public override void Start()
        {
            base.Start();

            const int HEIGHT = 200;
            const int MARGIN = 10;
            RectTransform rect = content.GetComponent<RectTransform>();
            for (int ii = 0; ii < ONE.Chara.Count; ii++)
            {
                GameObject item = GameObject.Instantiate(node);
                item.transform.SetParent(content.transform, false);
                item.transform.localPosition = new Vector3(item.transform.localPosition.x, item.transform.localPosition.y - HEIGHT * ii, item.transform.localPosition.z);
                item.SetActive(true);

                // 個数に応じて、コンテンツ長さを延長する。
                rect.sizeDelta = new Vector2(rect.sizeDelta.x, rect.sizeDelta.y + HEIGHT);
                item.GetComponentInChildren<Text>().text = ONE.Chara[ii].FullName;
                Text[] txtField = item.GetComponentsInChildren<Text>();
                for (int jj = 0; jj < txtField.Length; jj++)
                {
                    Debug.Log("txtfield: " + txtField[jj].name);
                    if (txtField[jj].name == "CharaName") { txtField[jj].text = ONE.Chara[ii].FullName; }
                    if (txtField[jj].name == "txtLevel") { txtField[jj].text = ONE.Chara[ii].Level.ToString(); }
                    if (txtField[jj].name == "txtLife") { txtField[jj].text = ONE.Chara[ii].MaxLife.ToString(); }
                    if (txtField[jj].name == "txtStrength") { txtField[jj].text = ONE.Chara[ii].TotalStrength.ToString(); }
                    if (txtField[jj].name == "txtAgility") { txtField[jj].text = ONE.Chara[ii].TotalAgility.ToString(); }
                    if (txtField[jj].name == "txtIntelligence") { txtField[jj].text = ONE.Chara[ii].TotalIntelligence.ToString(); }
                    if (txtField[jj].name == "txtStamina") { txtField[jj].text = ONE.Chara[ii].TotalStamina.ToString(); }
                    if (txtField[jj].name == "txtMind") { txtField[jj].text = ONE.Chara[ii].TotalMind.ToString(); }
                    if (txtField[jj].name == "txtMainWeapon")
                    {
                        if (ONE.Chara[ii].MainWeapon != null)
                        {
                            txtField[jj].text = ONE.Chara[ii].MainWeapon.Name;
                            GameObject parent = txtField[jj].GetComponentInParent<Image>().gameObject;
                            Image[] imgIcon = parent.GetComponentsInChildren<Image>();
                            for (int kk = 0; kk < imgIcon.Length; kk++)
                            {
                                if (imgIcon[kk].name == "imgMainWeapon")
                                {
                                    Method.UpdateItemImage(ONE.Chara[ii].MainWeapon, imgIcon[kk]);
                                    break;
                                }
                            }
                            Method.UpdateRareColor(ONE.Chara[ii].MainWeapon, txtField[jj], parent, null);
                        }
                    }
                }
                Image[] imgField = item.GetComponentsInChildren<Image>();
                for (int jj = 0; jj < imgField.Length; jj++)
                {
                    if (imgField[jj].name == "CharaClass")
                    {
                        Method.UpdateJobClassImage(ONE.Chara[ii].Job, imgField[jj].gameObject);
                        break;
                    }
                }
            }
            // 最後に余白を追加しておく。
            rect.sizeDelta = new Vector2(rect.sizeDelta.x, rect.sizeDelta.y + MARGIN);


            txtCoin.text = ONE.Chara[0].Gold.ToString();
            txtSoul.text = ONE.Chara[0].ObsidianStone.ToString();

            //CurrentAttributePoint[0] = ONE.P1.BaseStrength;
            //CurrentAttributePoint[1] = ONE.P1.BaseAgility;
            //CurrentAttributePoint[2] = ONE.P1.BaseIntelligence;
            //CurrentAttributePoint[3] = ONE.P1.BaseStamina;
            //CurrentAttributePoint[4] = ONE.P1.BaseMind;
            //for (int ii = 0; ii < CurrentAttributePoint.Length; ii++)
            //{
            //    txtAttributeValue[ii].text = CurrentAttributePoint[ii].ToString();
            //}

            CurrentAbility = MaxAbility;
            txtAvailableAbility.text = "Available Ability Points: " + CurrentAbility.ToString();
            CurrentAttribute = MaxAttribute;
            txtAvailableAttributes.text = "Available Attribute Points: " + CurrentAttribute.ToString();

            groupAppearance.SetActive(true);

            TapArea(1);
        }
        
        public void TapStage()
        {
            Debug.Log("TapStage");
            groupMainMenu.SetActive(false);
            groupCreateCharacter.SetActive(false);
            groupStage.SetActive(true);
        }
        public void TapTavern()
        {
            groupMainMenu.SetActive(true);
            groupCreateCharacter.SetActive(false);
            groupStage.SetActive(false);

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
            ONE.Chara[0].FullName = txtName.text;
            ONE.Chara[0].Gender = txtGender.text;
            ONE.Chara[0].Personality = txtPersonality.text;
            ONE.Chara[0].MainColor = txtMainColor.text;
            ONE.Chara[0].BaseStrength = CurrentAttributePoint[0];
            ONE.Chara[0].BaseAgility = CurrentAttributePoint[1];
            ONE.Chara[0].BaseIntelligence = CurrentAttributePoint[2];
            ONE.Chara[0].BaseStamina = CurrentAttributePoint[3];
            ONE.Chara[0].BaseMind = CurrentAttributePoint[4];
            ONE.Chara[0].Ability_01 = CurrentWeaponPoint[0];
            ONE.Chara[0].Ability_02 = CurrentWeaponPoint[1];
            ONE.Chara[0].Ability_03 = CurrentWeaponPoint[2];
            ONE.Chara[0].Ability_04 = CurrentWeaponPoint[3];
            ONE.Chara[0].Ability_05 = CurrentWeaponPoint[4];
            ONE.Chara[0].Ability_06 = CurrentSkillPoint[0];
            ONE.Chara[0].Ability_07 = CurrentSkillPoint[1];
            ONE.Chara[0].Ability_08 = CurrentSkillPoint[2];
            ONE.Chara[0].Ability_09 = CurrentSkillPoint[3];
            ONE.Chara[0].Ability_10 = CurrentSkillPoint[4];
            ONE.Chara[0].Ability_11 = CurrentSkillPoint[5];
            ONE.Chara[0].Ability_12 = CurrentSkillPoint[6];
            ONE.Chara[0].Ability_13 = CurrentSkillPoint[7];
            ONE.Chara[0].Ability_14 = CurrentSkillPoint[8];
            ONE.Chara[0].Ability_15 = CurrentSkillPoint[9];
            ONE.Chara[0].Ability_16 = CurrentSkillPoint[10];
            ONE.Chara[0].Ability_17 = CurrentSkillPoint[11];
            groupCreateCharacter.SetActive(false);
            groupMainMenu.SetActive(true);
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
    }
}
