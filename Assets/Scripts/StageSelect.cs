using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ObsidianPortal
{
    public class StageSelect : MotherForm
    {
        private int MoveCamera = 0;
        float currentCameraX = 0.0f;
        public Camera camera;

        public GameObject groupCommand;
        public GameObject CommandCursor;
        public int StageNumber = 0;
        public GameObject[] Complete1;
        public GameObject[] Complete2;
        public GameObject[] Complete3;
        public GameObject[] Complete4;
        public GameObject[] Complete5;

        // Use this for initialization
        public override void Start()
        {
            //base.Start();
            RenderSettings.skybox = (Material)Resources.Load("Skybox4");
            for (int ii = 0; ii < Complete1.Length; ii++)
            {
                Complete1[ii].SetActive(false);
            }
            for (int ii = 0; ii < Complete2.Length; ii++)
            {
                Complete2[ii].SetActive(false);
            }
            for (int ii = 0; ii < Complete3.Length; ii++)
            {
                Complete3[ii].SetActive(false);
            }
            for (int ii = 0; ii < Complete4.Length; ii++)
            {
                Complete4[ii].SetActive(false);
            }
            for (int ii = 0; ii < Complete5.Length; ii++)
            {
                Complete5[ii].SetActive(false);
            }
            if (ONE.WE2.CompleteStage11) { Complete1[0].SetActive(true); }
            if (ONE.WE2.CompleteStage12) { Complete1[1].SetActive(true); }
            if (ONE.WE2.CompleteStage13) { Complete1[2].SetActive(true); }
            if (ONE.WE2.CompleteStage14) { Complete1[3].SetActive(true); }
            if (ONE.WE2.CompleteStage15) { Complete1[4].SetActive(true); }
            if (ONE.WE2.CompleteStage21) { Complete2[0].SetActive(true); }
            if (ONE.WE2.CompleteStage22) { Complete2[1].SetActive(true); }
            if (ONE.WE2.CompleteStage23) { Complete2[2].SetActive(true); }
            if (ONE.WE2.CompleteStage24) { Complete2[3].SetActive(true); }
            if (ONE.WE2.CompleteStage25) { Complete2[4].SetActive(true); }
            if (ONE.WE2.CompleteStage31) { Complete3[0].SetActive(true); }
            if (ONE.WE2.CompleteStage32) { Complete3[1].SetActive(true); }
            if (ONE.WE2.CompleteStage33) { Complete3[2].SetActive(true); }
            if (ONE.WE2.CompleteStage34) { Complete3[3].SetActive(true); }
            if (ONE.WE2.CompleteStage35) { Complete3[4].SetActive(true); }
            if (ONE.WE2.CompleteStage41) { Complete4[0].SetActive(true); }
            if (ONE.WE2.CompleteStage42) { Complete4[1].SetActive(true); }
            if (ONE.WE2.CompleteStage43) { Complete4[2].SetActive(true); }
            if (ONE.WE2.CompleteStage44) { Complete4[3].SetActive(true); }
            if (ONE.WE2.CompleteStage45) { Complete4[4].SetActive(true); }
            if (ONE.WE2.CompleteStage51) { Complete5[0].SetActive(true); }
            if (ONE.WE2.CompleteStage52) { Complete5[1].SetActive(true); }
            if (ONE.WE2.CompleteStage53) { Complete5[2].SetActive(true); }
            if (ONE.WE2.CompleteStage54) { Complete5[3].SetActive(true); }
            if (ONE.WE2.CompleteStage55) { Complete5[4].SetActive(true); }
        }

        // Update is called once per frame
        new void Update()
        {
            base.Update();

            // CarrierProfile : ON
            if (this.MoveCamera > 0)
            {
                if (currentCameraX < 10.0f * this.MoveCamera)
                {
                    currentCameraX += 1.0f;
                    if (currentCameraX >= 10.0f * this.MoveCamera) { currentCameraX = 10.0f * this.MoveCamera; }
                    camera.transform.localPosition = new Vector3(currentCameraX,
                                                 camera.transform.localPosition.y,
                                                 camera.transform.localPosition.z);
                }
            }
            else
            {
                if (currentCameraX > 0)
                {
                    currentCameraX -= 5.0f;
                    if (currentCameraX <= 0.0f) { currentCameraX = 0.0f; }
                    camera.transform.localPosition = new Vector3(currentCameraX,
                                                 camera.transform.localPosition.y,
                                                 camera.transform.localPosition.z);

                }
            }


            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // カーソル移動
            int LayerNo = LayerMask.NameToLayer(FIX.LAYER_STAGEPANEL);
            int layerMask = 1 << LayerNo;
            if (Physics.Raycast(ray, out hit, 100, layerMask))
            {
                GameObject obj = hit.collider.gameObject;
                CommandCursor.transform.localPosition = new Vector3(obj.transform.localPosition.x,
                                                                        obj.transform.localPosition.y - 0.01f,
                                                                        obj.transform.localPosition.z);
                if (Input.GetMouseButtonDown(0))
                {
                    ONE.CurrentStage = (FIX.Stage)(Enum.Parse(typeof(FIX.Stage), obj.name));
                    SceneManager.LoadSceneAsync(FIX.SCENE_BATTLEFIELD);
                }
            }
        }

        public void TapChange()
        {
            this.MoveCamera++;
            if (MoveCamera > 4)
            {
                MoveCamera = 0;
            }
        }
    }
}