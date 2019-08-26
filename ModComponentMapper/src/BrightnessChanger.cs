using System;
using System.Reflection;
using Harmony;

namespace ModComponentMapper
{
    public class BrightnessChanger
    {
        private static readonly Assembly UnityAssembly = typeof(UnityEngine.Rendering.PostProcessing.ColorGrading).Assembly;
        private static readonly Type ColorGradingRenderer = UnityAssembly.GetType("UnityEngine.Rendering.PostProcessing.ColorGradingRenderer");
        private static readonly FieldInfo BrightnessField = AccessTools.Field(ColorGradingRenderer, "s_Brightness");

        public static float Brightness
        {
            get => (float) BrightnessField.GetValue(null);
            set => BrightnessField.SetValue(null, value);
        }

        public static float GetDefault()
        {
            return InterfaceManager.m_Panel_OptionsMenu.m_State.m_Brightness;
        }

        public static void Reset()
        {
            Brightness = InterfaceManager.m_Panel_OptionsMenu.m_State.m_Brightness;
        }
    }
}