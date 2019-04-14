using UnityEngine;
using System;
using System.Collections;

public interface HaveTransformInterface
{

    Transform getTransform();

    Data getData();

    Type getDataType();

    void setDirty(bool dirty);

}