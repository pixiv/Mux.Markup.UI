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

using System;
using Xamarin.Forms.Xaml;

namespace Mux.Markup
{
    /// <summary>
    /// A <xref href="Xamarin.Forms.Xaml.IMarkupExtension`1?text=markup extension" />
    /// that represents <see cref="T:UnityEngine.UI.ColorBlock" />.
    /// </summary>
    /// <example>
    /// <code language="xaml">
    /// <![CDATA[
    /// <m:RectTransform
    ///     xmlns="http://xamarin.com/schemas/2014/forms"
    ///     xmlns:m="clr-namespace:Mux.Markup;assembly=Mux.Markup"
    ///     xmlns:mu="clr-namespace:Mux.Markup;assembly=Mux.Markup.UI"
    ///     xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    ///     xmlns:playgroundMarkup="clr-namespace:Mux.Playground.Markup;assembly=Assembly-CSharp">
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
    ///     <mu:VerticalLayoutGroup />
    ///     <!--
    ///         You have to give property name "Path" to Binding and "Name" to
    ///         x:Reference only when you compile the interpreter with IL2CPP.
    ///         It is because ContentPropertyAttribute does not work with IL2CPP.
    ///     -->
    ///     <mu:Selectable TargetGraphic="{Binding Path=Body, Source={x:Reference Name=targetGraphic}}">
    ///         <mu:Selectable.Colors>
    ///             <mu:ColorBlock
    ///                 ColorMultiplier="0.5"
    ///                 NormalColor="{m:Color R=0, G=0, B=0}"
    ///                 PressedColor="{m:Color R=0, G=0, B=1}"
    ///                 HighlightedColor="{m:Color R=0, G=1, B=0}"
    ///                 DisabledColor="{m:Color R=1, G=0, B=0}" />
    ///         </mu:Selectable.Colors>
    ///     </mu:Selectable>
    ///     <mu:Image x:Name="targetGraphic" />
    ///     <playgroundMarkup:TextTransform Text="See what happens if you click or change Interactive property of mu:Selectable!" />
    /// </m:RectTransform>
    /// ]]>
    /// </code>
    /// </example>
    [AcceptEmptyServiceProvider]
    public class ColorBlock : IMarkupExtension<UnityEngine.UI.ColorBlock>
    {
        /// <summary>
        /// A property that represents <see cref="P:UnityEngine.UI.ColorBlock.colorMultiplier" />.
        /// </summary>
        public float ColorMultiplier { get; set; } = 1;

        /// <summary>
        /// A property that represents <see cref="P:UnityEngine.UI.ColorBlock.disabledColor" />.
        /// </summary>
        public UnityEngine.Color DisabledColor { get; set; } = new UnityEngine.Color32(200, 200, 200, 128);

        /// <summary>
        /// A property that represents <see cref="P:UnityEngine.UI.ColorBlock.fadeDuration" />.
        /// </summary>
        public float FadeDuration { get; set; } = 0.1f;

        /// <summary>
        /// A property that represents <see cref="P:UnityEngine.UI.ColorBlock.highlightedColor" />.
        /// </summary>
        public UnityEngine.Color HighlightedColor { get; set; } = new UnityEngine.Color32(255, 255, 255, 255);

        /// <summary>
        /// A property that represents <see cref="P:UnityEngine.UI.ColorBlock.normalColor" />.
        /// </summary>
        public UnityEngine.Color NormalColor { get; set; } = new UnityEngine.Color32(255, 255, 255, 255);

        /// <summary>
        /// A property that represents <see cref="P:UnityEngine.UI.ColorBlock.pressedColor" />.
        /// </summary>
        public UnityEngine.Color PressedColor { get; set; } = new UnityEngine.Color32(200, 200, 200, 255);

        /// <summary>
        /// A property that represents <see cref="P:UnityEngine.UI.ColorBlock.selectedColor" />.
        /// </summary>
        public UnityEngine.Color SelectedColor { get; set; } = new UnityEngine.Color32(245, 245, 245, 255);

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return ProvideValue(serviceProvider);
        }

        public UnityEngine.UI.ColorBlock ProvideValue(IServiceProvider serviceProvider)
        {
            return new UnityEngine.UI.ColorBlock
            {
                colorMultiplier = ColorMultiplier,
                disabledColor = DisabledColor,
                fadeDuration = FadeDuration,
                highlightedColor = HighlightedColor,
                normalColor = NormalColor,
                pressedColor = PressedColor,
                selectedColor = SelectedColor
            };
        }
    }
}
