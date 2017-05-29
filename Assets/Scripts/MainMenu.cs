using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ObsidianPortal
{
    public class MainMenu : MotherForm
    {

        // Use this for initialization
        void Start()
        {
            base.Start();
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void TapPlay()
        {
            SceneManager.LoadScene(FIX.SCENE_STAGESELECT);
        }

        public void TapTraining()
        {
            SceneManager.LoadScene("BattleTraining");
        }

        public void TapOption()
        {
            SceneManager.LoadScene("Option");
        }

        public void TapExit()
        {
            Application.Quit();
        }
    }
}