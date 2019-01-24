

namespace frame8.ScrollRectItemsAdapter
{
    /// <summary> Constants static class </summary>
    public static class C
    {
        public static readonly string[] SMALL_IMAGES_URLS = new string[]
        {
            "https://68.media.tumblr.com/avatar_a6abe54fa29b_128.png",
            "https://a.wattpad.com/useravatar/YasYeas.128.870434.jpg",
            "https://www.lebanoninapicture.com/Prv/Images/Pages/Page_92120/meditation-nature-peace-lebanesemountains-livel-2-22-2017-12-19-17-am-t.jpg",
            "https://www.lebanoninapicture.com/Prv/Images/Pages/Page_96905/purple-flower-green-plants-nature-naturecolors--2-28-2017-4-06-40-pm-t.jpg",
            "https://68.media.tumblr.com/avatar_4b20b991f1fa_128.png",
            "https://s-media-cache-ak0.pinimg.com/236x/cd/de/a2/cddea289ff95c409ce414983f02847b6.jpg",
            "https://images-na.ssl-images-amazon.com/images/I/71L8cVOFuAL._CR204,0,1224,1224_UX128.jpg",
            "https://d2ujflorbtfzji.cloudfront.net/key-image/691c98df-8e89-491f-b7ac-c7ff5a0c441e.png",
            "https://images-na.ssl-images-amazon.com/images/I/71QdMdCSz5L._CR204,0,1224,1224_UX128.jpg",
            "https://a.wattpad.com/useravatar/CorpseDragneel0.128.192903.jpg",
            "http://wiki.teamliquid.net/commons/images/1/18/Crystal_maiden_freezing_field.png",
            "http://icons.iconarchive.com/icons/emoopo/darktheme-folder/128/Folder-Nature-Leave-icon.png",
            "http://icons.iconarchive.com/icons/majid-ksa/nature-folder/128/flower-folder-icon.png"
        };


        public static string GetRandomSmallImageURL() { return SMALL_IMAGES_URLS[UnityEngine.Random.Range(0, SMALL_IMAGES_URLS.Length)]; }
    }
}
