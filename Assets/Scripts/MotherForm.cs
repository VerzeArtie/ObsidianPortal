using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace ObsidianPortal
{
    public class MotherForm : MonoBehaviour
    {
        public virtual void Start()
        {
            Debug.Log("MotherForm initialize");
            ONE.Initialize();
        }

        public virtual void Update()
        {
        }
    }
}
