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
    /// A class that represents <see cref="F:UnityEngine.UI.CanvasScaler.ScaleMode.ScaleWithScreenSize" />
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
    ///     <mu:CanvasScaler UiScale="{mu:ScaleWithScreenSize}" />
    ///     <mu:GraphicRaycaster />
    ///     <mu:Text Font="{Binding Path=Resources.Font}">
    ///         <mu:Text.Content>
    /// You have to give property name "Path" to Binding only when you compile
    /// the interpreter with IL2CPP. It is because ContentPropertyAttribute does
    /// not work with IL2CPP.
    ///
    /// > Using the Scale With Screen Size mode, positions and sizes can be specified according to the pixels of a specified reference resolution.
    /// > If the current screen resolution is larger than the reference resolution, the Canvas will keep having only the resolution of the reference resolution,
    /// > but will scale up in order to fit the screen. If the current screen resolution is smaller than the reference resolution,
    /// > the Canvas will similarly be scaled down to fit.
    /// Unity - Scripting API: UI.CanvasScaler.ScaleMode.ScaleWithScreenSize
    /// https://docs.unity3d.com/ScriptReference/UI.CanvasScaler.ScaleMode.ScaleWithScreenSize.html
    ///         </mu:Text.Content>
    ///     </mu:Text>
    /// </m:RectTransform>
    /// ]]>
    /// </code>
    /// </example>
    public sealed class ScaleWithScreenSize : CanvasScaler.Modifier
    {
        /// <summary>Backing store for the <see cref="ReferenceResolution" /> property.</summary>
        public static readonly BindableProperty ReferenceResolutionProperty = BindableProperty.Create(
            "ReferenceResolution",
            typeof(UnityEngine.Vector2),
            typeof(ScaleWithScreenSize),
            new UnityEngine.Vector2(800, 600),
            BindingMode.OneWay,
            null,
            OnReferenceResolutionChanged);

        /// <summary>Backing store for the <see cref="ScreenMatchMode" /> property.</summary>
        public static readonly BindableProperty ScreenMatchModeProperty = BindableProperty.Create(
            "ScreenMatchMode",
            typeof(UnityEngine.UI.CanvasScaler.ScreenMatchMode),
            typeof(ScaleWithScreenSize),
            UnityEngine.UI.CanvasScaler.ScreenMatchMode.MatchWidthOrHeight,
            BindingMode.OneWay,
            null,
            OnScreenMatchModeChanged);

        /// <summary>Backing store for the <see cref="MatchWidthOrHeight" /> property.</summary>
        public static readonly BindableProperty MatchWidthOrHeightProperty = BindableProperty.Create(
            "MatchWidthOrHeight",
            typeof(float),
            typeof(ScaleWithScreenSize),
            0f,
            BindingMode.OneWay,
            null,
            OnMatchWidthOrHeightChanged);

        private static void OnReferenceResolutionChanged(BindableObject sender, object oldValue, object newValue)
        {
            var body = ((ScaleWithScreenSize)sender).Body;

            if (body != null)
            {
                Forms.mainThread.Send(
                    state => body.referenceResolution = (UnityEngine.Vector2)state,
                    newValue);
            }
        }

        private static void OnScreenMatchModeChanged(BindableObject sender, object oldValue, object newValue)
        {
            var body = ((ScaleWithScreenSize)sender).Body;

            if (body != null)
            {
                Forms.mainThread.Send(
                    state => body.screenMatchMode = (UnityEngine.UI.CanvasScaler.ScreenMatchMode)state,
                    newValue);
            }
        }

        private static void OnMatchWidthOrHeightChanged(BindableObject sender, object oldValue, object newValue)
        {
            var body = ((ScaleWithScreenSize)sender).Body;

            if (body != null)
            {
                Forms.mainThread.Send(state => body.matchWidthOrHeight = (float)state, newValue);
            }
        }

        /// <summary>
        /// A property that represents <see cref="P:UnityEngine.UI.CanvasScaler.referenceResolution" />.
        /// </summary>
        public UnityEngine.Vector2 ReferenceResolution
        {
            get
            {
                return (UnityEngine.Vector2)GetValue(ReferenceResolutionProperty);
            }

            set
            {
                SetValue(ReferenceResolutionProperty, value);
            }
        }

        /// <summary>
        /// A property that represents <see cref="P:UnityEngine.UI.CanvasScaler.screenMatchMode" />.
        /// </summary>
        public UnityEngine.UI.CanvasScaler.ScreenMatchMode ScreenMatchMode
        {
            get
            {
                return (UnityEngine.UI.CanvasScaler.ScreenMatchMode)GetValue(ScreenMatchModeProperty);
            }

            set
            {
                SetValue(ScreenMatchModeProperty, value);
            }
        }

        /// <summary>
        /// A property that represents <see cref="P:UnityEngine.UI.CanvasScaler.matchWidthOrHeight" />.
        /// </summary>
        public float MatchWidthOrHeight
        {
            get
            {
                return (float)GetValue(MatchWidthOrHeightProperty);
            }

            set
            {
                SetValue(MatchWidthOrHeightProperty, value);
            }
        }

        /// <inheritdoc />
        protected sealed override void InitializeBodyInMainThread()
        {
            Body.uiScaleMode = UnityEngine.UI.CanvasScaler.ScaleMode.ScaleWithScreenSize;
            Body.referenceResolution = ReferenceResolution;
            Body.screenMatchMode = ScreenMatchMode;
            Body.matchWidthOrHeight = MatchWidthOrHeight;
        }
    }
}
