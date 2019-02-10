using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace ObsidianPortal
{
    public class TruthImage : Image
    {
        public enum buffType
        {
            None,
            Small,
            Large,
        }
        public enum CumulativeTextAlign
        {
            TopRight,
            Center,
        }

        protected buffType buffMode = buffType.None;
        public buffType BuffMode
        {
            get { return buffMode; }
            set
            {
                buffMode = value;
                if (value == buffType.Large)
                {
                    //                this.fixedRect = new Rectangle(0, 0, 50, 50);
                    //                this.fixedPointCount = new PointF(4, 47);
                }
            }
        }

        protected string imageName = string.Empty;
        public string ImageName
        {
            get { return imageName; }
            set { imageName = value; }
        }

        protected int count = 0;
        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        protected int cumulative = 0;
        public int Cumulative
        {
            get { return cumulative; }
            set { if (value >= 0) { cumulative = value; } }
        }
        protected CumulativeTextAlign align = CumulativeTextAlign.TopRight;
        public CumulativeTextAlign CumulativeAlign
        {
            get { return align; }
            set { align = value; }
        }

        public void OnMouseEnterImage()
        {

        }

        private Text txtCounter;
        private Text txtCumulative;
        void Start()
        {
            //GameObject baseObj = new GameObject("object1");

            //txtCounter = baseObj.AddComponent<Text>();

            //txtCounter.name = "counter1";
            //txtCounter.rectTransform.anchorMin = new Vector2(0.0f, 0.0f);
            //txtCounter.rectTransform.anchorMax = new Vector2(1.0f, 1.0f);
            //txtCounter.rectTransform.pivot = new Vector2(0.5f, 0.5f);
            //txtCounter.rectTransform.sizeDelta = new Vector2(0, 0);
            //txtCounter.alignment = TextAnchor.UpperCenter;
            //txtCounter.font = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
            //txtCounter.color = Color.blue;
            //txtCounter.text = this.count.ToString();
            //txtCounter.gameObject.SetActive(true);
            //txtCounter.transform.SetParent(this.transform, false);
            //txtCounter.rectTransform.anchoredPosition = new Vector2(0, +15);

            //GameObject baseObj2 = new GameObject("object2");
            //txtCumulative = baseObj2.AddComponent<Text>();

            //txtCumulative.name = "counter2";
            //txtCumulative.rectTransform.anchorMin = new Vector2(0.0f, 0.0f);
            //txtCumulative.rectTransform.anchorMax = new Vector2(1.0f, 1.0f);
            //txtCumulative.rectTransform.pivot = new Vector2(0.5f, 0.5f);
            //txtCumulative.rectTransform.sizeDelta = new Vector2(0, 0);
            //txtCumulative.alignment = TextAnchor.LowerCenter;
            //txtCumulative.font = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
            //txtCumulative.color = Color.red;
            //txtCumulative.text = this.cumulative.ToString();
            //txtCumulative.gameObject.SetActive(true);
            //txtCumulative.transform.SetParent(this.transform, false);
            //txtCumulative.rectTransform.anchoredPosition = new Vector2(0, -15);
        }
        void Update()
        {
            //if (0 < this.count && this.count <= 99)
            //{
            //    txtCounter.text = this.count.ToString();
            //}
            //else
            //{
            //    txtCounter.text = "";
            //}

            //if (cumulative > 0)
            //{
            //    if (this.align == CumulativeTextAlign.TopRight)
            //    {

            //        if (cumulative >= 10)
            //        {
            //            txtCumulative.text = cumulative.ToString();
            //        }
            //        else
            //        {
            //            txtCumulative.text = cumulative.ToString();
            //        }
            //    }
            //    else
            //    {
            //        txtCumulative.text = cumulative.ToString();
            //    }
            //}
            //else
            //{
            //    txtCumulative.text = "";
            //}
        }

        public bool AbstractCountDownBuff()
        {
            if (this.Count > 0)
            {
                this.Count--;
                //this.Invalidate();
                if (this.Count <= 0)
                {
                    this.sprite = null;
                    this.Update();
                    return true; // BUFF効果が切れた事を通達する。
                }
            }
            return false;
        }
    }
}