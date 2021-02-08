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
using Xamarin.Forms;

namespace Mux.Markup
{
    /// <summary>A <see cref="Selectable{T}" /> that represents <see cref="T:UnityEngine.UI.Toggle" />.</summary>
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
    ///     <!--
    ///         You have to give property name "Path" to Binding and "Name" to x:Reference
    ///         only when you compile the interpreter with IL2CPP.
    ///         It is because ContentPropertyAttribute does not work with IL2CPP.
    ///     -->
    ///     <m:RectTransform>
    ///         <mu:Toggle Graphic="{Binding Path=Body, Source={x:Reference Name=graphic}}" />
    ///         <m:RectTransform X="{m:Stretch}" Y="{m:Stretch}">
    ///             <mu:Image x:Name="graphic" Color="{m:Color R=0, G=0, B=1}" />
    ///         </m:RectTransform>
    ///     </m:RectTransform>
    /// </m:RectTransform>
    /// ]]>
    /// </code>
    /// </example>
    public class Toggle : Selectable<UnityEngine.UI.Toggle>
    {
        /// <summary>Backing store for the <see cref="ToggleTransition" /> property.</summary>
        public static readonly BindableProperty ToggleTransitionProperty = CreateBindableBodyProperty<UnityEngine.UI.Toggle.ToggleTransition>(
            "ToggleTransition",
            typeof(Toggle),
            (body, value) => body.toggleTransition = value,
            UnityEngine.UI.Toggle.ToggleTransition.Fade);

        /// <summary>Backing store for the <see cref="Graphic" /> property.</summary>
        public static readonly BindableProperty GraphicProperty = BindableProperty.Create(
            "Graphic",
            typeof(UnityEngine.UI.Graphic),
            typeof(Toggle),
            null,
            BindingMode.OneWay,
            null,
            OnGraphicChanged);

        /// <summary>Backing store for the <see cref="Group" /> property.</summary>
        public static readonly BindableProperty GroupProperty = CreateBindableBodyProperty<UnityEngine.UI.ToggleGroup>(
            "Group",
            typeof(Toggle),
            (body, value) => body.group = value);

        /// <summary>Backing store for the <see cref="IsOn" /> property.</summary>
        public static readonly BindableProperty IsOnProperty = CreateBindableBodyProperty<bool>(
            "IsOn",
            typeof(Toggle),
            (body, value) =>
            {
                var old = body.onValueChanged;
                body.onValueChanged = new UnityEngine.UI.Toggle.ToggleEvent();

                try
                {
                    body.isOn = value;
                }
                finally
                {
                    body.onValueChanged = old;
                }
            },
            true,
            BindingMode.TwoWay);

        private static void OnGraphicChanged(BindableObject boxedToggle, object boxedOldValue, object boxedNewValue)
        {
            var toggle = (Toggle)boxedToggle;

            if (toggle.Body == null)
            {
                return;
            }

            Forms.mainThread.Send(state =>
            {
                toggle.Body.graphic = toggle.Graphic;

                // This triggers an effect such as hiding graphic if off to be played.
                toggle.Body.group = toggle.Group;
            }, null);
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Toggle.toggleTransition" />.</summary>
        public UnityEngine.UI.Toggle.ToggleTransition ToggleTransition
        {
            get
            {
                return (UnityEngine.UI.Toggle.ToggleTransition)GetValue(ToggleTransitionProperty);
            }

            set
            {
                SetValue(ToggleTransitionProperty, value);
            }
        }

        /// <summary>A property that represents <see href="P:UnityEngine.UI.Toggle.graphic" />.</summary>
        /// <seealso cref="Graphic" />
        public UnityEngine.UI.Graphic Graphic
        {
            get
            {
                return (UnityEngine.UI.Graphic)GetValue(GraphicProperty);
            }

            set
            {
                SetValue(GraphicProperty, value);
            }
        }

        /// <summary>A property that represents <see href="P:UnityEngine.UI.Toggle.group" />.</summary>
        /// <seealso cref="ToggleGroup" />
        public UnityEngine.UI.ToggleGroup Group
        {
            get
            {
                return (UnityEngine.UI.ToggleGroup)GetValue(GroupProperty);
            }

            set
            {
                SetValue(GroupProperty, value);
            }
        }

        /// <summary>A property that represents <see href="P:UnityEngine.UI.Toggle.isOn" />.</summary>
        public bool IsOn
        {
            get
            {
                return (bool)GetValue(IsOnProperty);
            }

            set
            {
                SetValue(IsOnProperty, value);
            }
        }

        /// <inheritdoc />
        protected override void AwakeInMainThread()
        {
            Body.toggleTransition = ToggleTransition;
            Body.graphic = Graphic;
            Body.group = Group;
            Body.isOn = IsOn;
            Body.onValueChanged.AddListener(value => SetValueCore(IsOnProperty, value));

            base.AwakeInMainThread();
        }
    }
}
