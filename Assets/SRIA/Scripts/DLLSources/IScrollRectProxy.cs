using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace frame8.Logic.Misc.Visual.UI
{
	/// <summary> A delegate used to communicate with a ScrollRect</summary>
	public interface IScrollRectProxy
	{
		/// <summary>The float parameter has the same format as described in <see cref="SetNormalizedPosition(float)"/></summary>
		event Action<float> ScrollPositionChanged;

		/// <summary><paramref name="normalizedPosition"/> is exactly the same as the ScrollRect.horizontalNormalizedPosition, if the ScrollRect is horizontal (ScrollRect.verticalNormalizedPosition, else) </summary>
		void SetNormalizedPosition(float normalizedPosition);

		/// <summary>See <see cref="SetNormalizedPosition(float)"/></summary>
		float GetNormalizedPosition();

		/// <summary>The width of the content panel, if the ScrollRect is horizontal (the height, else)</summary>
		float GetContentSize();
	}
}
