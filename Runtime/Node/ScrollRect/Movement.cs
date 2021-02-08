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
    /// A class that represents the unrestricted movement of <see cref="T:UnityEngine.UI.ScrollRect" />.
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
    ///     <playgroundMarkup:ScrollViewTransform Movement="{mu:Unrestricted}" />
    /// </m:RectTransform>
    /// ]]>
    /// </code>
    /// </example>
    public class Unrestricted : ScrollRect.Modifier
    {
        /// <inheritdoc />
        protected sealed override void InitializeBodyInMainThread()
        {
            Body.movementType = UnityEngine.UI.ScrollRect.MovementType.Unrestricted;
        }
    }

    /// <summary>
    /// A class that represents the elastic movement of <see cref="T:UnityEngine.UI.ScrollRect" />.
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
    ///     <playgroundMarkup:ScrollViewTransform Movement="{mu:Elastic}" />
    /// </m:RectTransform>
    /// ]]>
    /// </code>
    /// </example>
    [ContentProperty("Elasticity")]
    public class Elastic : ScrollRect.Modifier
    {
        /// <summary>Backing store for the <see cref="Elasticity" /> property.</summary>
        public static readonly BindableProperty ElasticityProperty = BindableProperty.Create(
            "Elasticity",
            typeof(float),
            typeof(Elastic),
            0.1f,
            BindingMode.OneWay,
            null,
            OnElasticityChanged);

        private static void OnElasticityChanged(BindableObject sender, object oldValue, object newValue)
        {
            var body = ((Elastic)sender).Body;

            if (body != null)
            {
                Forms.mainThread.Send(state => body.elasticity = (float)state, newValue);
            }
        }

        /// <summary>
        /// A property that represents <see cref="P:UnityEngine.UI.ScrollRect.elasticity" />.
        /// </summary>
        /// <remarks>
        /// This is the content property; you do not have to specify the property name in XAML.
        /// </remarks>
        public float Elasticity
        {
            get
            {
                return (float)GetValue(ElasticityProperty);
            }

            set
            {
                SetValue(ElasticityProperty, value);
            }
        }

        /// <inheritdoc />
        protected sealed override void InitializeBodyInMainThread()
        {
            Body.movementType = UnityEngine.UI.ScrollRect.MovementType.Elastic;
            Body.elasticity = Elasticity;
        }
    }

    /// <summary>
    /// A class that represents the clamped movement of <see cref="T:UnityEngine.UI.ScrollRect" />.
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
    ///     <playgroundMarkup:ScrollViewTransform Movement="{mu:Clamped}" />
    /// </m:RectTransform>
    /// ]]>
    /// </code>
    /// </example>
    public class Clamped : ScrollRect.Modifier
    {
        /// <inheritdoc />
        protected sealed override void InitializeBodyInMainThread()
        {
            Body.movementType = UnityEngine.UI.ScrollRect.MovementType.Clamped;
        }
    }
}
