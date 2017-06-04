using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ObsidianPortal
{
    public class GameResult : MotherForm
    {
        public GameObject txtHeroName;
        public GameObject back_WinLose;
        public GameObject txtWinLose;
        public GameObject MedalElimination;
        public GameObject txtElimination;
        public GameObject MedalTactics;
        public GameObject txtTactics;
        public GameObject MedalTotalTurn;
        public GameObject txtTotalTurn;
        public GameObject txtDamageDone;
        public GameObject txtHealingDone;
        public GameObject txtBonusValue;
        public GameObject txtExp;
        public GameObject txtCurrentLevel;
        public GameObject txtNextLevel;
        public GameObject txtTotalExp;
        public GameObject[] ExpGauge;
        public GameObject back_LevelUpMessage;
        public GameObject txtLevelUpMessage;

        private int BonusValue = 0;

        private int GettingExp = 0;
        private float GettingExpPercent = 0;
        private float GettingGauge = 0;
        int counter = 0;

        int waitCounter = 100;

        // Use this for initialization
        new void Start()
        {
            base.Start();
            for (int ii = 0; ii < ExpGauge.Length; ii++)
            {
                ExpGauge[ii].transform.localScale = new Vector3(0.0f,
                    ExpGauge[ii].transform.localScale.y,
                    ExpGauge[ii].transform.localScale.z);
            }

            string WIN = "WIN";
            string LOSE = "LOSE";
            string Result = WIN;

            // debug
            //Result = LOSE;
            //ONE.Player.Level = 21;
            //ONE.Player.Exp = 6500;
            //ONE.BattleElimination = 7;
            //ONE.BattleTacticsPoint = 2;
            //ONE.BattleTotalTurn = 5;
            //ONE.BattleDamageDone = 32;
            //ONE.BattleHealingDone = 21;
            //ONE.BattleGettingExp = 2500;
            //BonusValue = 400;

            if (Result == LOSE)
            {
                BonusValue = 0;
            }
            GettingExp = ONE.BattleGettingExp + BonusValue;

            txtWinLose.GetComponent<TextMesh>().text = Result;
            if (Result == LOSE)
            {
                back_WinLose.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            }
            txtHeroName.GetComponent<TextMesh>().text = ONE.Player.FullName;
            txtCurrentLevel.GetComponent<TextMesh>().text = ONE.Player.Level.ToString();
            txtNextLevel.GetComponent<TextMesh>().text = (ONE.Player.Level + 1).ToString();
            txtElimination.GetComponent<TextMesh>().text = ONE.BattleElimination.ToString();
            txtTactics.GetComponent<TextMesh>().text = ONE.BattleTacticsPoint.ToString();
            txtTotalTurn.GetComponent<TextMesh>().text = ONE.BattleTotalTurn.ToString();
            txtDamageDone.GetComponent<TextMesh>().text = ONE.BattleDamageDone.ToString();
            txtHealingDone.GetComponent<TextMesh>().text = ONE.BattleHealingDone.ToString();
            txtBonusValue.GetComponent<TextMesh>().text = "+" + BonusValue.ToString();
            txtExp.GetComponent<TextMesh>().text = GettingExp.ToString() + " Exp";
            txtTotalExp.GetComponent<TextMesh>().text = ONE.Player.Exp.ToString() + "/" + ONE.Player.NextLevelBorder.ToString();

            string GOLD = "MedalGold";
            string SILVER = "MedalSilver";
            string COPPER = "MedalCopper";
            string medal = SILVER;
            MedalElimination.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(medal);
            medal = COPPER;
            MedalTactics.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(medal);
            medal = GOLD;
            MedalTotalTurn.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(medal);

            float percent = (float)(((float)ONE.Player.Exp * 100) / (float)ONE.Player.NextLevelBorder);
            GettingGauge = (float)((float)(GettingExp * 100) / (float)ONE.Player.NextLevelBorder);
            GettingExpPercent = (float)((float)GettingExp / (float)GettingGauge);
            for (int ii = 0; ii < percent; ii++)
            {
                IncreaseExpGauge();
            }
        }

        private int AutoClose = 300;
        new void Update()
        {
            base.Update();

            if (waitCounter > 0)
            {
                waitCounter--;
                return;
            }

            if (GettingGauge > 0)
            {
                System.Threading.Thread.Sleep(10);
                GettingGauge--;
                txtExp.GetComponent<TextMesh>().text = (GettingExp - counter * GettingExpPercent).ToString("N0") + " Exp";
                txtTotalExp.GetComponent<TextMesh>().text = (ONE.Player.Exp + counter * GettingExpPercent).ToString("N0") + "/" + ONE.Player.NextLevelBorder.ToString();
                counter++;
                IncreaseExpGauge();

                if (GettingGauge <= 0)
                {
                    ONE.Player.Exp += GettingExp;
                    txtExp.GetComponent<TextMesh>().text = "0";
                    txtTotalExp.GetComponent<TextMesh>().text = (ONE.Player.Exp).ToString("N0") + "/" + ONE.Player.NextLevelBorder.ToString();

                    if (ONE.Player.Exp >= ONE.Player.NextLevelBorder)
                    {
                        ONE.Player.Exp -= ONE.Player.NextLevelBorder;
                        ONE.Player.Level++;
                        for (int ii = 0; ii < ExpGauge.Length; ii++)
                        {
                            ExpGauge[ii].SetActive(false);
                        }
                        txtTotalExp.SetActive(false);
                        txtExp.SetActive(false);

                        txtLevelUpMessage.GetComponent<TextMesh>().text = "REACHED LEVEL " + ONE.Player.Level.ToString() + "!";
                        back_LevelUpMessage.SetActive(true);
                        txtLevelUpMessage.SetActive(true);

                        ONE.ResetBattleData();
                    }                    
                }
            }

            if (GettingGauge <= 0)
            {
                this.AutoClose--;
                if (this.AutoClose <= 0)
                {
                    SceneManager.LoadSceneAsync(FIX.SCENE_MAINMENU);
                }
                else if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
                {
                    SceneManager.LoadSceneAsync(FIX.SCENE_MAINMENU);
                }
            }

            //for (int ii = 0; ii < ExpGauge.Length; ii++)
            //{
            //    if (ExpGauge[ii].transform.localScale.x < 1.0f)
            //    {
            //        float x = ExpGauge[ii].transform.localScale.x + 0.1f;
            //        if (x > 1.0f) { x = 1.0f; }
            //        ExpGauge[ii].transform.localScale = new Vector3(x,
            //            ExpGauge[ii].transform.localScale.y,
            //            ExpGauge[ii].transform.localScale.z);
            //        break;
            //    }
            //}
        }

        private void IncreaseExpGauge()
        {
            for (int ii = 0; ii < ExpGauge.Length; ii++)
            {
                if (ExpGauge[ii].transform.localScale.x < 1.0f)
                {
                    float x = ExpGauge[ii].transform.localScale.x + 0.1f;
                    if (x > 1.0f) { x = 1.0f; }
                    ExpGauge[ii].transform.localScale = new Vector3(x,
                        ExpGauge[ii].transform.localScale.y,
                        ExpGauge[ii].transform.localScale.z);
                    break;
                }
            }
        }
    }
}
