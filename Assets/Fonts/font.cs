using Fonts;
using UnityEngine;

namespace Fonts
{
    [CreateAssetMenu(fileName = "Font", menuName = "Fonts/Font")]
    public sealed class Font : ScriptableObject
    {
        [SerializeField] private string fontName;
        [SerializeField] private int fontSize;
        [SerializeField] private FontStyle fontStyle;
        public string FontName => fontName;
        public int FontSize => fontSize;
        public FontStyle FontStyle => fontStyle;
    }

    public sealed class FontManager : MonoBehaviour
    {
        [SerializeField] private Font[] fonts;
        public Font GetFont(string fontName)
        {
            foreach (var font in fonts)
            {
                if (font.FontName == fontName)
                {
                    return font;
                }
            }
            Debug.LogWarning($"Font '{fontName}' not found.");
            return null;
        }
    }
}