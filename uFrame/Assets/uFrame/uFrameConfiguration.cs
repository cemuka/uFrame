using UnityEngine;

namespace com.uFrame
{
    [CreateAssetMenu]
    public class uFrameConfiguration : ScriptableObject
    {
        public Configuration configuration;
    }

    [System.Serializable]
    public class Configuration
    {
        public Sprite body;
        public Sprite headerButton;
        public Font defaultFont;
        public int windowContentPadding;
        public int headerHeight;
    }
}