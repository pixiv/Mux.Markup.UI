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
    /// A class that represents <see cref="F:UnityEngine.UI.CanvasScaler.ScaleMode.ConstantPixelSize" />
    /// and its scaling properties.
    /// </summary>
    /// <summary>
    /// A class that represents <see cref="T:UnityEngine.UI.CanvasScaler.ScaleMode.ConstantPhysicalSize" />
    /// and its scaling properties.
    /// </summary>
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
    ///     <mu:CanvasScaler UiScale="{mu:ConstantPixelSize}" />
    ///     <mu:GraphicRaycaster />
    ///     <mu:Text Font="{Binding Path=Resources.Font}">
    ///         <mu:Text.Content>
    /// You have to give property name "Path" to Binding only when you compile
    /// the interpreter with IL2CPP. It is because ContentPropertyAttribute does
    /// not work with IL2CPP.
    ///
    /// > Using the Constant Pixel Size mode, positions and sizes of UI elements are specified in pixels on the screen.
    /// Unity - Scripting API: UI.CanvasScaler.ScaleMode.ConstantPixelSize
    /// https://docs.unity3d.com/ScriptReference/UI.CanvasScaler.ScaleMode.ConstantPixelSize.html
    ///         </mu:Text.Content>
    ///     </mu:Text>
    /// </m:RectTransform>
    /// ]]>
    /// </code>
    /// </example>
    public sealed class ConstantPixelSize : CanvasScaler.Modifier
    {
        /// <summary>Backing store for the <see cref="ScaleFactor" /> property.</summary>
        public static readonly BindableProperty ScaleFactorProperty = BindableProperty.Create(
            "ScaleFactor",
            typeof(float),
            typeof(ConstantPixelSize),
            1f,
            BindingMode.OneWay,
            null,
            OnScaleFactorChanged);

        private static void OnScaleFactorChanged(BindableObject sender, object oldValue, object newValue)
        {
            var body = ((ConstantPixelSize)sender).Body;

            if (body != null)
            {
                Forms.mainThread.Send(state => body.scaleFactor = (float)state, body);
            }
        }

        /// <summary>
        /// A property that represents <see cref="P:UnityEngine.UI.CanvasScaler.scaleFactor" />.
        /// </summary>
        public float ScaleFactor
        {
            get
            {
                return (float)GetValue(ScaleFactorProperty);
            }

            set
            {
                SetValue(ScaleFactorProperty, value);
            }
        }

        /// <inheritdoc />
        protected sealed override void InitializeBodyInMainThread()
        {
            Body.uiScaleMode = UnityEngine.UI.CanvasScaler.ScaleMode.ConstantPixelSize;
            Body.scaleFactor = ScaleFactor;
        }
    }
}
