using UnityEngine;
using System.Collections;

public interface HaveTransformData
{

    TransformData getTransformData();

    void setDirtyForTransformData();

    Data getDataHaveTransformData();

    Transform getUITransform();

    /*
    #region TransformData

        public TransformData transformData = new TransformData();

        private void updateTransformData()
        {
            this.transformData.update(this.transform);
    }

    public TransformData getTransformData()
    {
        return this.transformData;
    }

        #endregion
    */

}