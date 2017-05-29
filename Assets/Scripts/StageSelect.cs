using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ObsidianPortal
{
    public class StageSelect : MotherForm
    {
        public GameObject groupCommand;
        public GameObject CommandCursor;
        public int StageNumber = 0;
        // Use this for initialization
        public override void Start()
        {
            //base.Start();
            RenderSettings.skybox = (Material)Resources.Load("Skybox4");
        }

        // Update is called once per frame
        void Update()
        {
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
            StageNumber++;
            if (StageNumber > 1)
            {
                StageNumber = 0;
            }

            Camera.main.transform.localPosition = new Vector3(StageNumber * 10,
                                                              Camera.main.transform.localPosition.y,
                                                              Camera.main.transform.localPosition.z);
        }
    }
}