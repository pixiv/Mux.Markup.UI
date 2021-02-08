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
    /// <summary>
    /// A <see cref="Behaviour{T}" /> that represents <see cref="T:UnityEngine.UI.ToggleGroup" />.
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
    ///     <mu:StandaloneInputModule />
    ///     <mu:Canvas />
    ///     <mu:CanvasScaler UiScale="{mu:ConstantPhysicalSize}" />
    ///     <mu:GraphicRaycaster />
    ///     <mu:ToggleGroup x:Name="group" />
    ///     <!--
    ///         You have to give property name "Path" to Binding and "Name" to x:Reference
    ///         only when you compile the interpreter with IL2CPP.
    ///         It is because ContentPropertyAttribute does not work with IL2CPP.
    ///     -->
    ///     <playgroundMarkup:ToggleTransform
    ///         Group="{Binding Path=Body, Source={x:Reference Name=group}}"
    ///         X="{m:Stretch AnchorMax=0.5}" />
    ///     <playgroundMarkup:ToggleTransform
    ///         Group="{Binding Path=Body, Source={x:Reference Name=group}}"
    ///         X="{m:Stretch AnchorMin=0.5}" />
    /// </m:RectTransform>
    /// ]]>
    /// </code>
    /// </example>
    public class ToggleGroup : Behaviour<UnityEngine.UI.ToggleGroup>
    {
        /// <summary>Backing store for the <see cref="AllowSwitchOff" /> property.</summary>
        public static readonly BindableProperty AllowSwitchOffProperty = CreateBindableBodyProperty<bool>(
            "AllowSwitchOff",
            typeof(ToggleGroup),
            (body, value) => body.allowSwitchOff = value,
            false);

        /// <summary>
        /// A property that represents <see cref="P:UnityEngine.UI.ToggleGroup.allowSwitchOff" />.
        /// </summary>
        public bool AllowSwitchOff
        {
            get
            {
                return (bool)GetValue(AllowSwitchOffProperty);
            }

            set
            {
                SetValue(AllowSwitchOffProperty, value);
            }
        }

        /// <inheritdoc />
        protected override void AwakeInMainThread()
        {
            Body.allowSwitchOff = AllowSwitchOff;
            base.AwakeInMainThread();
        }
    }
}
