using UnityEngine;
using UnityEngine.UI;

namespace UnityImageLoader
{
    public class DisplayOption
    {
        public bool isMemoryCache = true;
        public bool isDiscCache = true;
        public string loadingImagePath;
        public string loadErrorImagePath;

		public Sprite loadingSprite;
		public Sprite loadErrorSprite;

        DisplayOption(Builder builder)
        {
            isMemoryCache = builder.isMemoryCache;
            isDiscCache = builder.isDiscCache;
            loadingImagePath = builder.loadingImagePath;
            loadErrorImagePath = builder.loadErrorImagePath;

			loadingSprite = builder.loadingSprite;
			loadErrorSprite = builder.loadErrorSprite;
        }

        DisplayOption()
        {
        }

        public static DisplayOption GetDefaultDisplayOption()
        {
            return new DisplayOption();
        }

        public class Builder
        {
            public bool isMemoryCache = true;
            public bool isDiscCache = true;
            public string loadingImagePath;
            public string loadErrorImagePath;

			public Sprite loadingSprite;
			public Sprite loadErrorSprite;

            public Builder IsMemoryCache(bool isMemoryCache)
            {
                this.isMemoryCache = isMemoryCache;
                return this;
            }

            public Builder IsDiscCache(bool isDiscCache)
            {
                this.isDiscCache = isDiscCache;
                return this;
            }

            public Builder LoadingImagePath(string loadingImagePath)
            {
                this.loadingImagePath = loadingImagePath;
                return this;
            }

            public Builder LoadErrorImagePath(string loadErrorImagePath)
            {
                this.loadErrorImagePath = loadErrorImagePath;
                return this;
            }

            public DisplayOption Build()
            {
                return new DisplayOption(this);
            }

        }
    }
}
