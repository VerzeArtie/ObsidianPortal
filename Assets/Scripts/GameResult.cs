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
            string Result = string.Empty;

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

            ONE.WE2.TotalPlayed++;
            if (ONE.BattleWin)              
            {
                Result = WIN;
                ONE.WE2.TotalWin++;
                //BonusValue = 0;
            }
            else
            {
                Result = LOSE;
                ONE.WE2.TotalLose++;
                BonusValue = 0;
            }
            GettingExp = ONE.BattleGettingExp + BonusValue;

            txtWinLose.GetComponent<TextMesh>().text = Result;
            if (Result == LOSE)
            {
                back_WinLose.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            }
            txtHeroName.GetComponent<TextMesh>().text = ONE.P1.FullName;
            txtCurrentLevel.GetComponent<TextMesh>().text = ONE.P1.Level.ToString();
            txtNextLevel.GetComponent<TextMesh>().text = (ONE.P1.Level + 1).ToString();
            txtElimination.GetComponent<TextMesh>().text = ONE.BattleElimination.ToString();
            txtTactics.GetComponent<TextMesh>().text = ONE.BattleTacticsPoint.ToString();
            txtTotalTurn.GetComponent<TextMesh>().text = ONE.BattleTotalTurn.ToString();
            txtDamageDone.GetComponent<TextMesh>().text = ONE.BattleDamageDone.ToString();
            txtHealingDone.GetComponent<TextMesh>().text = ONE.BattleHealingDone.ToString();
            txtBonusValue.GetComponent<TextMesh>().text = "+" + BonusValue.ToString();
            txtExp.GetComponent<TextMesh>().text = GettingExp.ToString() + " Exp";
            txtTotalExp.GetComponent<TextMesh>().text = ONE.P1.Exp.ToString() + "/" + ONE.P1.NextLevelBorder.ToString();

            string GOLD = "MedalGold";
            string SILVER = "MedalSilver";
            string COPPER = "MedalCopper";
            string medal = SILVER;
            MedalElimination.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(medal);
            medal = COPPER;
            MedalTactics.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(medal);
            medal = GOLD;
            MedalTotalTurn.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(medal);

            if (ONE.CurrentStage == FIX.Stage.Stage1_1) { ONE.WE2.CompleteStage11 = true; }
            if (ONE.CurrentStage == FIX.Stage.Stage1_2) { ONE.WE2.CompleteStage12 = true; }
            if (ONE.CurrentStage == FIX.Stage.Stage1_3) { ONE.WE2.CompleteStage13 = true; }
            if (ONE.CurrentStage == FIX.Stage.Stage1_4) { ONE.WE2.CompleteStage14 = true; }
            if (ONE.CurrentStage == FIX.Stage.Stage1_5) { ONE.WE2.CompleteStage15 = true; }
            if (ONE.CurrentStage == FIX.Stage.Stage2_1) { ONE.WE2.CompleteStage21 = true; }
            if (ONE.CurrentStage == FIX.Stage.Stage2_2) { ONE.WE2.CompleteStage22 = true; }
            if (ONE.CurrentStage == FIX.Stage.Stage2_3) { ONE.WE2.CompleteStage23 = true; }
            if (ONE.CurrentStage == FIX.Stage.Stage2_4) { ONE.WE2.CompleteStage24 = true; }
            if (ONE.CurrentStage == FIX.Stage.Stage2_5) { ONE.WE2.CompleteStage25 = true; }
            if (ONE.CurrentStage == FIX.Stage.Stage3_1) { ONE.WE2.CompleteStage31 = true; }
            if (ONE.CurrentStage == FIX.Stage.Stage3_2) { ONE.WE2.CompleteStage32 = true; }
            if (ONE.CurrentStage == FIX.Stage.Stage3_3) { ONE.WE2.CompleteStage33 = true; }
            if (ONE.CurrentStage == FIX.Stage.Stage3_4) { ONE.WE2.CompleteStage34 = true; }
            if (ONE.CurrentStage == FIX.Stage.Stage3_5) { ONE.WE2.CompleteStage35 = true; }
            if (ONE.CurrentStage == FIX.Stage.Stage4_1) { ONE.WE2.CompleteStage41 = true; }
            if (ONE.CurrentStage == FIX.Stage.Stage4_2) { ONE.WE2.CompleteStage42 = true; }
            if (ONE.CurrentStage == FIX.Stage.Stage4_3) { ONE.WE2.CompleteStage43 = true; }
            if (ONE.CurrentStage == FIX.Stage.Stage4_4) { ONE.WE2.CompleteStage44 = true; }
            if (ONE.CurrentStage == FIX.Stage.Stage4_5) { ONE.WE2.CompleteStage45 = true; }
            if (ONE.CurrentStage == FIX.Stage.Stage5_1) { ONE.WE2.CompleteStage51 = true; }
            if (ONE.CurrentStage == FIX.Stage.Stage5_2) { ONE.WE2.CompleteStage52 = true; }
            if (ONE.CurrentStage == FIX.Stage.Stage5_3) { ONE.WE2.CompleteStage53 = true; }
            if (ONE.CurrentStage == FIX.Stage.Stage5_4) { ONE.WE2.CompleteStage54 = true; }
            if (ONE.CurrentStage == FIX.Stage.Stage5_5) { ONE.WE2.CompleteStage55 = true; }

            Method.AutoSaveTruthWorldEnvironment();

            float percent = (float)(((float)ONE.P1.Exp * 100) / (float)ONE.P1.NextLevelBorder);
            GettingGauge = (float)((float)(GettingExp * 100) / (float)ONE.P1.NextLevelBorder);
            GettingExpPercent = (float)((float)GettingExp / (float)GettingGauge);
            for (int ii = 0; ii < percent; ii++)
            {
                IncreaseExpGauge();
            }
        }

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
                txtTotalExp.GetComponent<TextMesh>().text = (ONE.P1.Exp + counter * GettingExpPercent).ToString("N0") + "/" + ONE.P1.NextLevelBorder.ToString();
                counter++;
                IncreaseExpGauge();

                if (GettingGauge <= 0)
                {
                    ONE.P1.Exp += GettingExp;
                    txtExp.GetComponent<TextMesh>().text = "0";
                    txtTotalExp.GetComponent<TextMesh>().text = (ONE.P1.Exp).ToString("N0") + "/" + ONE.P1.NextLevelBorder.ToString();

                    if (ONE.P1.Exp >= ONE.P1.NextLevelBorder)
                    {
                        ONE.P1.Exp -= ONE.P1.NextLevelBorder;
                        ONE.P1.Level++;
                        for (int ii = 0; ii < ExpGauge.Length; ii++)
                        {
                            ExpGauge[ii].SetActive(false);
                        }
                        txtTotalExp.SetActive(false);
                        txtExp.SetActive(false);

                        txtLevelUpMessage.GetComponent<TextMesh>().text = "REACHED LEVEL " + ONE.P1.Level.ToString() + "!";
                        back_LevelUpMessage.SetActive(true);
                        txtLevelUpMessage.SetActive(true);
                    }
                    ONE.ResetBattleData();
                    Method.AutoSaveTruthWorldEnvironment();
                }
            }

            if (GettingGauge <= 0)
            {
                if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
                {
                    SceneManager.LoadSceneAsync(FIX.SCENE_MAINMENU);
                }
            }
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
