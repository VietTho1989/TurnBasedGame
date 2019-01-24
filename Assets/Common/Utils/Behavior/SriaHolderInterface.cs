using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;

public interface SriaHolderInterface
{

	void setHolder(BaseItemViewsHolder holder);

	TransformChange getTransformChange();

}