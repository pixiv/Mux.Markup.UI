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
    /// <summary>A <see cref="Behaviour{T}" /> that represents <see cref="T:UnityEngine.UI.ContentSizeFitter" />.</summary>
    /// <example>
    /// <code language="xaml">
    /// <![CDATA[
    /// <m:RectTransform
    ///     xmlns="http://xamarin.com/schemas/2014/forms"
    ///     xmlns:m="clr-namespace:Mux.Markup;assembly=Mux.Markup"
    ///     xmlns:mu="clr-namespace:Mux.Markup;assembly=Mux.Markup.UI"
    ///     xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml">
    ///     <mu:StandaloneInputModule />
    ///     <mu:Canvas />
    ///     <mu:CanvasScaler UiScale="{mu:ConstantPhysicalSize}" />
    ///     <mu:GraphicRaycaster />
    ///     <mu:ContentSizeFitter
    ///         VerticalFit="PreferredSize"
    ///         HorizontalFit="PreferredSize" />
    ///     <mu:LayoutElement
    ///         PreferredWidth="99"
    ///         PreferredHeight="50" />
    ///     <mu:Image />
    /// </m:RectTransform>
    /// ]]>
    /// </code>
    /// </example>
    public class ContentSizeFitter : Behaviour<UnityEngine.UI.ContentSizeFitter>
    {
        /// <summary>Backing store for the <see cref="HorizontalFit" /> property.</summary>
        public static readonly BindableProperty HorizontalFitProperty = CreateBindableBodyProperty<UnityEngine.UI.ContentSizeFitter.FitMode>(
            "HorizontalFit",
            typeof(ContentSizeFitter),
            (body, value) => body.horizontalFit = value,
            UnityEngine.UI.ContentSizeFitter.FitMode.Unconstrained);

        /// <summary>Backing store for the <see cref="VerticalFit" /> property.</summary>
        public static readonly BindableProperty VerticalFitProperty = CreateBindableBodyProperty<UnityEngine.UI.ContentSizeFitter.FitMode>(
            "VerticalFit",
            typeof(ContentSizeFitter),
            (body, value) => body.verticalFit = value,
            UnityEngine.UI.ContentSizeFitter.FitMode.Unconstrained);

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.ContentSizeFitter.horizontalFit" />.</summary>
        public UnityEngine.UI.ContentSizeFitter.FitMode HorizontalFit
        {
            get
            {
                return (UnityEngine.UI.ContentSizeFitter.FitMode)GetValue(HorizontalFitProperty);
            }

            set
            {
                SetValue(HorizontalFitProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.ContentSizeFitter.verticalFit" />.</summary>
        public UnityEngine.UI.ContentSizeFitter.FitMode VerticalFit
        {
            get
            {
                return (UnityEngine.UI.ContentSizeFitter.FitMode)GetValue(VerticalFitProperty);
            }

            set
            {
                SetValue(VerticalFitProperty, value);
            }
        }

        /// <inheritdoc />
        protected override void AwakeInMainThread()
        {
            Body.horizontalFit = HorizontalFit;
            Body.verticalFit = VerticalFit;

            base.AwakeInMainThread();
        }
    }
}
