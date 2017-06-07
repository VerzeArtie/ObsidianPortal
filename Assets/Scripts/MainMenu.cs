using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ObsidianPortal
{
    public class MainMenu : MotherForm
    {
        public Camera camera;
        public GameObject background;
        public GameObject txtHeroName;
        public GameObject txtLevel;
        public GameObject txtTotalPlayed;
        public GameObject txtMostDamageDone;
        public GameObject txtMostHealingDone;
        public GameObject txtMostTacticsPoints;
        public GameObject txtMostEliminations;
        public GameObject groupCanvasObject;

        private bool MoveCamera1 = false;
        private bool MoveCamera2 = false;

        // Use this for initialization
        new void Start()
        {
            base.Start();
        }

        float currentCameraX = 0.0f;
        // Update is called once per frame
        new void Update()
        {
            base.Update();
            if (this.MoveCamera2)
            {
                groupCanvasObject.SetActive(false);
                Color current = this.background.GetComponent<Image>().color;
                if (current.a > 0.0f)
                {
                    this.background.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, current.a - 0.1f);
                }
                if (currentCameraX < 10.0f)
                {
                    currentCameraX += 1.0f;
                    if (currentCameraX >= 10.0f) { currentCameraX = 10.0f; }
                    camera.transform.localPosition = new Vector3(currentCameraX,
                                                 camera.transform.localPosition.y,
                                                 camera.transform.localPosition.z);
                }
            }

            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                if (this.MoveCamera2)
                {
                    this.MoveCamera2 = false;
                    this.MoveCamera1 = true;
                }
            }

            if (this.MoveCamera1)
            {
                Color current = this.background.GetComponent<Image>().color;
                if (current.a < 1.0f)
                {
                    this.background.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, current.a + 0.1f);
                }
                if (currentCameraX > 0.0f)
                {
                    currentCameraX -= 1.0f;
                    if (currentCameraX <= 0.0f) { currentCameraX = 0.0f; }
                    camera.transform.localPosition = new Vector3(currentCameraX,
                                                 camera.transform.localPosition.y,
                                                 camera.transform.localPosition.z);
                }
                if (currentCameraX <= 0.0f)
                {
                    groupCanvasObject.SetActive(true);
                    this.MoveCamera1 = false;
                }
            }
        }

        public void TapPlay()
        {
            SceneManager.LoadScene(FIX.SCENE_STAGESELECT);
        }

        public void TapTraining()
        {
            SceneManager.LoadScene("BattleTraining");
        }

        public void TapCarrierProfile()
        {
            this.MoveCamera2 = true;
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