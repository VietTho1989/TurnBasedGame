using UnityEngine;
using System.Collections;

public interface HaveTransformInterface
{

    Transform getTransform();

    Data getData();

    void setDirty(bool dirty);

}