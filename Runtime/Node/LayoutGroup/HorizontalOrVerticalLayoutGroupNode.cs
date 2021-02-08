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
    /// <summary>An abstract class that represents <see cref="T:UnityEngine.UI.HorizontalOrVerticalLayoutGroup" />.</summary>
    public abstract class HorizontalOrVerticalLayoutGroup<T> : LayoutGroup<T> where T : UnityEngine.UI.HorizontalOrVerticalLayoutGroup
    {
        /// <summary>Backing store for the <see cref="Spacing" /> property.</summary>
        public static readonly BindableProperty SpacingProperty = CreateBindableBodyProperty<float>(
            "Spacing",
            typeof(HorizontalOrVerticalLayoutGroup<T>),
            (body, value) => body.spacing = value,
            0f);

        /// <summary>Backing store for the <see cref="ChildForceExpandWidth" /> property.</summary>
        public static readonly BindableProperty ChildForceExpandWidthProperty = CreateBindableBodyProperty<bool>(
            "ChildForceExpandWidth",
            typeof(HorizontalOrVerticalLayoutGroup<T>),
            (body, value) => body.childForceExpandWidth = value,
            true);

        /// <summary>Backing store for the <see cref="ChildForceExpandHeight" /> property.</summary>
        public static readonly BindableProperty ChildForceExpandHeightProperty = CreateBindableBodyProperty<bool>(
            "ChildForceExpandHeight",
            typeof(HorizontalOrVerticalLayoutGroup<T>),
            (body, value) => body.childForceExpandHeight = value,
            true);

        /// <summary>Backing store for the <see cref="ChildControlWidth" /> property.</summary>
        public static readonly BindableProperty ChildControlWidthProperty = CreateBindableBodyProperty<bool>(
            "ChildControlWidth",
            typeof(HorizontalOrVerticalLayoutGroup<T>),
            (body, value) => body.childControlWidth = value,
            true);

        /// <summary>Backing store for the <see cref="ChildControlHeight" /> property.</summary>
        public static readonly BindableProperty ChildControlHeightProperty = CreateBindableBodyProperty<bool>(
            "ChildControlHeight",
            typeof(HorizontalOrVerticalLayoutGroup<T>),
            (body, value) => body.childControlHeight = value,
            true);

        /// <summary>
        /// A property that represents <see cref="P:UnityEngine.UI.HorizontalOrVerticalLayoutGroup.spacing" />.
        /// </summary>
        public float Spacing
        {
            get
            {
                return (float)GetValue(SpacingProperty);
            }

            set
            {
                SetValue(SpacingProperty, value);
            }
        }

        /// <summary>
        /// A property that represents <see cref="P:UnityEngine.UI.HorizontalOrVerticalLayoutGroup.childForceExpandWidth" />.
        /// </summary>
        public bool ChildForceExpandWidth
        {
            get
            {
                return (bool)GetValue(ChildForceExpandWidthProperty);
            }

            set
            {
                SetValue(ChildForceExpandWidthProperty, value);
            }
        }

        /// <summary>
        /// A property that represents <see cref="P:UnityEngine.UI.HorizontalOrVerticalLayoutGroup.childForceExpandHeight" />.
        /// </summary>
        public bool ChildForceExpandHeight
        {
            get
            {
                return (bool)GetValue(ChildForceExpandHeightProperty);
            }

            set
            {
                SetValue(ChildForceExpandHeightProperty, value);
            }
        }

        /// <summary>
        /// A property that represents <see cref="P:UnityEngine.UI.HorizontalOrVerticalLayoutGroup.childControlWidth" />.
        /// </summary>
        public bool ChildControlWidth
        {
            get
            {
                return (bool)GetValue(ChildControlWidthProperty);
            }

            set
            {
                SetValue(ChildControlWidthProperty, value);
            }
        }

        /// <summary>
        /// A property that represents <see cref="P:UnityEngine.UI.HorizontalOrVerticalLayoutGroup.childControlHeight" />.
        /// </summary>
        public bool ChildControlHeight
        {
            get
            {
                return (bool)GetValue(ChildControlHeightProperty);
            }

            set
            {
                SetValue(ChildControlHeightProperty, value);
            }
        }

        /// <inheritdoc />
        protected override void AwakeInMainThread()
        {
            Body.spacing = Spacing;
            Body.childForceExpandWidth = ChildForceExpandWidth;
            Body.childForceExpandHeight = ChildForceExpandHeight;
            Body.childControlWidth = ChildControlWidth;
            Body.childControlHeight = ChildControlHeight;

            base.AwakeInMainThread();
        }
    }

    /// <summary>
    /// A <see cref="HorizontalOrVerticalLayoutGroup{T}" /> that represents <see cref="T:UnityEngine.UI.HorizontalLayoutGroup" />.
    /// </summary>
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
    ///     <mu:HorizontalLayoutGroup />
    ///     <m:RectTransform><mu:Image Color="{m:Color R=0, G=0, B=1}" /></m:RectTransform>
    ///     <m:RectTransform><mu:Image Color="{m:Color R=0, G=1, B=0}" /></m:RectTransform>
    /// </m:RectTransform>
    /// ]]>
    /// </code>
    /// </example>
    public class HorizontalLayoutGroup : HorizontalOrVerticalLayoutGroup<UnityEngine.UI.HorizontalLayoutGroup>
    {
    }

    /// <summary>
    /// A <see cref="HorizontalOrVerticalLayoutGroup{T}" /> that represents <see cref="T:UnityEngine.UI.VerticalLayoutGroup" />.
    /// </summary>
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
    ///     <mu:VerticalLayoutGroup />
    ///     <m:RectTransform><mu:Image Color="{m:Color R=0, G=0, B=1}" /></m:RectTransform>
    ///     <m:RectTransform><mu:Image Color="{m:Color R=0, G=1, B=0}" /></m:RectTransform>
    /// </m:RectTransform>
    /// ]]>
    /// </code>
    /// </example>
    public class VerticalLayoutGroup : HorizontalOrVerticalLayoutGroup<UnityEngine.UI.VerticalLayoutGroup>
    {
    }
}
