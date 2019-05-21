using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace Weiqi
{
    public class BoardBackgroundUI : UIBehavior<BoardBackgroundUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<int> size;

            public VP<float> deltaX;

            public VP<float> deltaY;

            #region Constructor

            public enum Property
            {
                size,
                deltaX,
                deltaY
            }

            public UIData() : base()
            {
                this.size = new VP<int>(this, (byte)Property.size, 0);
                this.deltaX = new VP<float>(this, (byte)Property.deltaX, 0f);
                this.deltaY = new VP<float>(this, (byte)Property.deltaY, 0f);
            }

            #endregion
        }

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.Weiqi ? 1 : 0;
        }

        #region Refresh

        // public UILineRenderer tileRenderer;
        public Image bgTiles;
        public RectTransform bgColor;

        public GameObject[] stars;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    // tileRenderer
                    /*if (tileRenderer != null)
                    {
                        Vector2[] pointArray;
                        {
                            List<Vector2> points = new List<Vector2>();
                            {
                                for (int i = 0; i < this.data.size.v; i++)
                                {
                                    // vertical
                                    {
                                        float x = i - (this.data.size.v - 1) / 2.0f;
                                        // from
                                        {
                                            Vector2 from = new Vector2(x, -(this.data.size.v - 1) / 2.0f);
                                            points.Add(from);
                                        }
                                        // dest
                                        {
                                            Vector2 from = new Vector2(x, +(this.data.size.v - 1) / 2.0f);
                                            points.Add(from);
                                        }
                                    }
                                    // horizontal
                                    {
                                        float y = i - (this.data.size.v - 1) / 2.0f;
                                        // from
                                        {
                                            Vector2 from = new Vector2(-(this.data.size.v - 1) / 2.0f, y);
                                            points.Add(from);
                                        }
                                        // dest
                                        {
                                            Vector2 from = new Vector2(+(this.data.size.v - 1) / 2.0f, y);
                                            points.Add(from);
                                        }
                                    }
                                }
                            }
                            pointArray = points.ToArray();
                        }
                        tileRenderer.Points = pointArray;
                    }
                    else
                    {
                        Debug.LogError("tileRenderer null");
                    }*/
                    // bgTiles
                    if (bgTiles != null)
                    {
                        bgTiles.rectTransform.sizeDelta = new Vector2(this.data.size.v - 1, this.data.size.v - 1);
                    }
                    else
                    {
                        Debug.LogError("bgTiles null");
                    }
                    // bgColor
                    if (bgColor != null)
                    {
                        bgColor.sizeDelta = new Vector2(this.data.size.v, this.data.size.v);
                    }
                    else
                    {
                        Debug.LogError("bgColor null");
                    }
                    // stars
                    {
                        if (stars != null)
                        {
                            if (stars.Length == 9)
                            {
                                if (this.data.size.v == 19)
                                {
                                    foreach (GameObject star in stars)
                                    {
                                        star.SetActive(true);
                                    }
                                }
                                else
                                {
                                    for (int i = 0; i < 9; i++)
                                    {
                                        GameObject star = stars[i];
                                        if (i == 4)
                                        {
                                            star.SetActive(this.data.size.v % 2 == 1);
                                        }
                                        else
                                        {
                                            star.SetActive(false);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Debug.LogError("stars length not 9");
                            }
                        }
                        else
                        {
                            Debug.LogError("stars null");
                        }
                    }
                }
                else
                {
                    // Debug.LogError ("data null: " + this);
                }
            }
        }

        public override bool isShouldDisableUpdate()
        {
            return true;
        }

        #endregion

        #region implement callBacks

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                dirty = true;
                return;
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                this.setDataNull(uiData);
                return;
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
        {
            if (WrapProperty.checkError(wrapProperty))
            {
                return;
            }
            if (wrapProperty.p is UIData)
            {
                switch ((UIData.Property)wrapProperty.n)
                {
                    case UIData.Property.size:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}