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
    /// <summary>A <see cref="Behaviour{T}" /> that represents <see cref="T:UnityEngine.UI.GraphicRaycaster" />.</summary>
    /// <example>
    /// <code language="xaml">
    /// <![CDATA[
    /// <m:RectTransform
    ///     xmlns="http://xamarin.com/schemas/2014/forms"
    ///     xmlns:m="clr-namespace:Mux.Markup;assembly=Mux.Markup"
    ///     xmlns:mu="clr-namespace:Mux.Markup;assembly=Mux.Markup.UI"
    ///     xmlns:mue="clr-namespace:Mux.Markup.Extras;assembly=Mux.Markup.UI"
    ///     xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    ///     xmlns:playground="clr-namespace:Mux.Playground;assembly=Assembly-CSharp"
    ///     xmlns:playgroundMarkup="clr-namespace:Mux.Playground.Markup;assembly=Assembly-CSharp"
    //      x:DataType="playground:PlaygroundViewModel">
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
    ///     <mu:Text Font="{Binding Path=Resources.Font}">
    ///         <mu:Text.Content>
    /// You have to give property name "Path" to Binding only when you compile
    /// the interpreter with IL2CPP. It is because ContentPropertyAttribute does
    /// not work with IL2CPP.
    ///
    /// mu:GraphicRaycaster is required for the interactive components.
    /// Remove mu:GraphicRaycaster and try to click the toggle!
    ///         </mu:Text.Content>
    ///     </mu:Text>
    ///     <playgroundMarkup:ToggleTransform />
    /// </m:RectTransform>
    /// ]]>
    /// </code>
    /// </example>
    public class GraphicRaycaster : Behaviour<UnityEngine.UI.GraphicRaycaster>
    {
        /// <summary>Backing store for the <see cref="IgnoreReversedGraphics" /> property.</summary>
        public static readonly BindableProperty IgnoreReversedGraphicsProperty = CreateBindableBodyProperty<bool>(
            "IgnoreReversedGraphics",
            typeof(GraphicRaycaster),
            (body, value) => body.ignoreReversedGraphics = value,
            true);

        /// <summary>Backing store for the <see cref="BlockingObjects" /> property.</summary>
        public static readonly BindableProperty BlockingObjectsProperty = CreateBindableBodyProperty<UnityEngine.UI.GraphicRaycaster.BlockingObjects>(
            "BlockingObjects",
            typeof(GraphicRaycaster),
            (body, value) => body.blockingObjects = value,
            UnityEngine.UI.GraphicRaycaster.BlockingObjects.None);

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.GraphicRaycaster.ignoreReversedGraphics" />.</summary>
        public bool IgnoreReversedGraphics
        {
            get
            {
                return (bool)GetValue(IgnoreReversedGraphicsProperty);
            }

            set
            {
                SetValue(IgnoreReversedGraphicsProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.GraphicRaycaster.blockingObjects" />.</summary>
        public UnityEngine.UI.GraphicRaycaster.BlockingObjects BlockingObjects
        {
            get
            {
                return (UnityEngine.UI.GraphicRaycaster.BlockingObjects)GetValue(BlockingObjectsProperty);
            }

            set
            {
                SetValue(BlockingObjectsProperty, value);
            }
        }

        /// <inheritdoc />
        protected override void AwakeInMainThread()
        {
            Body.ignoreReversedGraphics = IgnoreReversedGraphics;
            Body.blockingObjects = BlockingObjects;

            base.AwakeInMainThread();
        }
    }
}
