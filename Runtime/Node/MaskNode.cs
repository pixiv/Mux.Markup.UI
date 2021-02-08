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
    /// <summary>A <see cref="Behaviour{T}" /> that represents <see cref="T:UnityEngine.UI.Mask" />.</summary>
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
    ///     <mu:Mask />
    ///     <mu:Text Font="{Binding Path=Resources.Font}">
    ///         <mu:Text.Content>
    /// You have to give property name "Path" to Binding only when you compile
    /// the interpreter with IL2CPP. It is because ContentPropertyAttribute does
    /// not work with IL2CPP.
    ///
    /// This text is masked by mu:Image.
    ///         </mu:Text.Content>
    ///     </mu:Text>
    ///     <m:RectTransform X="{m:Stretch}" Y="{m:Stretch}">
    ///         <mu:Image Color="{m:Color R=0, G=0, B=1}" />
    ///     </m:RectTransform>
    /// </m:RectTransform>
    /// ]]>
    /// </code>
    /// </example>
    public class Mask : Behaviour<UnityEngine.UI.Mask>
    {
        /// <summary>Backing store for the <see cref="ShowMaskGraphic" /> property.</summary>
        public static readonly BindableProperty ShowMaskGraphicProperty = CreateBindableBodyProperty<bool>(
            "ShowMaskGraphic",
            typeof(Mask),
            (body, value) => body.showMaskGraphic = value,
            true);

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Mask.showMaskGraphic" />.</summary>
        public bool ShowMaskGraphic
        {
            get
            {
                return (bool)GetValue(ShowMaskGraphicProperty);
            }

            set
            {
                SetValue(ShowMaskGraphicProperty, value);
            }
        }

        /// <inheritdoc />
        protected override void AwakeInMainThread()
        {
            Body.showMaskGraphic = ShowMaskGraphic;
            base.AwakeInMainThread();
        }
    }
}
