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
    /// A <see cref="Behaviour{T}" /> that represents <see cref="T:UnityEngine.CanvasGroup" />.
    /// </summary>
    /// <example>
    /// <code language="xaml">
    /// <![CDATA[
    /// <m:RectTransform
    ///     xmlns="http://xamarin.com/schemas/2014/forms"
    ///     xmlns:m="clr-namespace:Mux.Markup;assembly=Mux.Markup"
    ///     xmlns:mu="clr-namespace:Mux.Markup;assembly=Mux.Markup.UI"
    ///     xmlns:mue="clr-namespace:Mux.Markup.Extras;assembly=Mux.Markup.UI"
    ///     xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml">
    ///     <mu:StandaloneInputModule />
    ///     <mu:Canvas />
    ///     <mu:CanvasScaler UiScale="{mu:ConstantPhysicalSize}" />
    ///     <mu:GraphicRaycaster />
    ///     <mu:CanvasGroup Alpha="0.5" />
    ///     <m:RectTransform X="{m:Stretch AnchorMax=0.5}">
    ///         <mu:Image Color="{m:Color R=0, G=0, B=1}"  />
    ///     </m:RectTransform>
    ///     <m:RectTransform X="{m:Stretch AnchorMin=0.5}">
    ///         <mu:Image Color="{m:Color R=0, G=1, B=0}" />
    ///     </m:RectTransform>
    /// </m:RectTransform>
    /// ]]>
    /// </code>
    /// </example>
    public class CanvasGroup : Behaviour<UnityEngine.CanvasGroup>
    {
        /// <summary>Backing store for the <see cref="Alpha" /> property.</summary>
        public static readonly BindableProperty AlphaProperty = CreateBindableBodyProperty<float>(
            "Alpha",
            typeof(CanvasGroup),
            (body, value) => body.alpha = value,
            1f);

        /// <summary>Backing store for the <see cref="Interactable" /> property.</summary>
        public static readonly BindableProperty InteractableProperty = CreateBindableBodyProperty<bool>(
            "Interactable",
            typeof(CanvasGroup),
            (body, value) => body.interactable = value,
            true);

        /// <summary>Backing store for the <see cref="BlocksRaycasts" /> property.</summary>
        public static readonly BindableProperty BlocksRaycastsProperty = CreateBindableBodyProperty<bool>(
            "BlocksRaycasts",
            typeof(CanvasGroup),
            (body, value) => body.blocksRaycasts = value,
            true);

        /// <summary>Backing store for the <see cref="IgnoreParentGroups" /> property.</summary>
        public static readonly BindableProperty IgnoreParentGroupsProperty = CreateBindableBodyProperty<bool>(
            "IgnoreParentGroups",
            typeof(CanvasGroup),
            (body, value) => body.ignoreParentGroups = value,
            false);

        /// <summary>A property that represents <see cref="P:UnityEngine.CanvasGroup.alpha" />.</summary>
        public float Alpha
        {
            get
            {
                return (float)GetValue(AlphaProperty);
            }

            set
            {
                SetValue(AlphaProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.CanvasGroup.interactable" />.</summary>
        public bool Interactable
        {
            get
            {
                return (bool)GetValue(InteractableProperty);
            }

            set
            {
                SetValue(InteractableProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.CanvasGroup.blocksRaycasts" />.</summary>
        public bool BlocksRaycasts
        {
            get
            {
                return (bool)GetValue(BlocksRaycastsProperty);
            }

            set
            {
                SetValue(BlocksRaycastsProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.CanvasGroup.ignoreParentGroups" />.</summary>
        public bool IgnoreParentGroups
        {
            get
            {
                return (bool)GetValue(IgnoreParentGroupsProperty);
            }

            set
            {
                SetValue(IgnoreParentGroupsProperty, value);
            }
        }

        /// <inheritdoc />
        protected override void AwakeInMainThread()
        {
            Body.alpha = Alpha;
            Body.interactable = Interactable;
            Body.blocksRaycasts = BlocksRaycasts;
            Body.ignoreParentGroups = IgnoreParentGroups;

            base.AwakeInMainThread();
        }
    }
}
