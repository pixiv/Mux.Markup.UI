// Copyright 2019 pixiv Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Xamarin.Forms;

namespace Mux.Markup
{
    /// <summary>An abstract class that represents <see cref="T:UnityEngine.UI.Shadow" /> or its subclass.</summary>
    public class Shadow<T> : Behaviour<T> where T : UnityEngine.UI.Shadow
    {
        /// <summary>Backing store for the <see cref="EffectColor" /> property.</summary>
        public static readonly BindableProperty EffectColorProperty = CreateBindableBodyProperty<UnityEngine.Color>(
            "EffectColor",
            typeof(Shadow<T>),
            (body, value) => body.effectColor = value,
            new UnityEngine.Color(0f, 0f, 0f, 0.5f));

        /// <summary>Backing store for the <see cref="EffectDistance" /> property.</summary>
        public static readonly BindableProperty EffectDistanceProperty = CreateBindableBodyProperty<UnityEngine.Vector2>(
            "EffectDistance",
            typeof(Shadow<T>),
            (body, value) => body.effectDistance = value,
            new UnityEngine.Vector2(1, -1));

        /// <summary>Backing store for the <see cref="UseGraphicAlpha" /> property.</summary>
        public static readonly BindableProperty UseGraphicAlphaProperty = CreateBindableBodyProperty<bool>(
            "UseGraphicAlpha",
            typeof(Shadow<T>),
            (body, value) => body.useGraphicAlpha = value,
            true);

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Shadow.effectColor" />.</summary>
        /// <seealso cref="Color" />
        /// <seealso cref="Color32" />
        public UnityEngine.Color EffectColor
        {
            get
            {
                return (UnityEngine.Color)GetValue(EffectColorProperty);
            }

            set
            {
                SetValue(EffectColorProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Shadow.effectDistance" />.</summary>
        /// <seealso cref="Vector2" />
        public UnityEngine.Vector2 EffectDistance
        {
            get
            {
                return (UnityEngine.Vector2)GetValue(EffectDistanceProperty);
            }

            set
            {
                SetValue(EffectDistanceProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Shadow.useGraphicAlpha" />.</summary>
        public bool UseGraphicAlpha
        {
            get
            {
                return (bool)GetValue(UseGraphicAlphaProperty);
            }

            set
            {
                SetValue(UseGraphicAlphaProperty, value);
            }
        }

        /// <inheritdoc />
        protected override void AwakeInMainThread()
        {
            Body.effectColor = EffectColor;
            Body.effectDistance = EffectDistance;
            Body.useGraphicAlpha = UseGraphicAlpha;

            base.AwakeInMainThread();
        }
    }

    /// <summary>A class that represents <see cref="T:UnityEngine.UI.Shadow" />.</summary>
    /// <example>
    /// <code language="xaml">
    /// <![CDATA[
    /// <m:RectTransform
    ///     xmlns="http://xamarin.com/schemas/2014/forms"
    ///     xmlns:m="clr-namespace:Mux.Markup;assembly=Mux.Markup"
    ///     xmlns:mu="clr-namespace:Mux.Markup;assembly=Mux.Markup.UI"
    ///     xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    ///     xmlns:playground="clr-namespace:Mux.Playground;assembly=Assembly-CSharp"
    ///     x:DataType="playground:PlaygroundViewModel">
    ///     <!--
    ///       Note that you can use "using" scheme instead of "clr-namespace" to omit assembly
    ///       specification if:
    ///       - the referenced type is in an assembly already loaded. (interpreter)
    ///       - the referenced type is in the assembly containing the compiled XAML. (compiler)
    ///     -->
    ///     <mu:StandaloneInputModule />
    ///     <mu:Canvas />
    ///     <mu:CanvasScaler UiScale="{mu:ConstantPhysicalSize}" />
    ///     <mu:GraphicRaycaster />
    ///     <mu:Shadow />
    ///     <mu:Text Font="{Binding Path=Resources.Font}">
    ///         <mu:Text.Content>
    /// You have to give property name "Path" to Binding only when you compile
    /// the interpreter with IL2CPP. It is because ContentPropertyAttribute does
    /// not work with IL2CPP.
    ///
    /// This text is shadowed.
    ///         </mu:Text.Content>
    ///     </mu:Text>
    /// </m:RectTransform>
    /// ]]>
    /// </code>
    /// </example>
    public sealed class Shadow : Shadow<UnityEngine.UI.Shadow>
    {
    }

    /// <summary>A class that represents <see cref="T:UnityEngine.UI.Outline" />.</summary>
    /// <example>
    /// <code language="xaml">
    /// <![CDATA[
    /// <m:RectTransform
    ///     xmlns="http://xamarin.com/schemas/2014/forms"
    ///     xmlns:m="clr-namespace:Mux.Markup;assembly=Mux.Markup"
    ///     xmlns:mu="clr-namespace:Mux.Markup;assembly=Mux.Markup.UI"
    ///     xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    ///     xmlns:playground="clr-namespace:Mux.Playground;assembly=Assembly-CSharp"
    ///     x:DataType="playground:PlaygroundViewModel">
    ///     <!--
    ///       Note that you can use "using" scheme instead of "clr-namespace" to omit assembly
    ///       specification if:
    ///       - the referenced type is in an assembly already loaded. (interpreter)
    ///       - the referenced type is in the assembly containing the compiled XAML. (compiler)
    ///     -->
    ///     <mu:StandaloneInputModule />
    ///     <mu:Canvas />
    ///     <mu:CanvasScaler UiScale="{mu:ConstantPhysicalSize}" />
    ///     <mu:GraphicRaycaster />
    ///     <mu:Outline />
    ///     <mu:Text Font="{Binding Path=Resources.Font}">
    ///         <mu:Text.Content>
    /// You have to give property name "Path" to Binding only when you compile
    /// the interpreter with IL2CPP. It is because ContentPropertyAttribute does
    /// not work with IL2CPP.
    ///
    /// This text is outlined.
    ///         </mu:Text.Content>
    ///     </mu:Text>
    /// </m:RectTransform>
    /// ]]>
    /// </code>
    /// </example>
    public sealed class Outline : Shadow<UnityEngine.UI.Outline>
    {
    }
}
