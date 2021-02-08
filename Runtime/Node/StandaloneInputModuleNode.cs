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
    /// An <see cref="Behaviour{T}" /> that represents <see cref="T:UnityEngine.EventSystems.StandaloneInputModule" />
    /// or its subclass.
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
    ///     <playgroundMarkup:TextTransform X="{m:Stretch}" Y="{m:Stretch}">
    ///         <playgroundMarkup:TextTransform.Text>
    /// You need StandaloneInputModule to get an interactive component such as a toggle work.
    /// Try to click the toggle with/without StandaloneInputModule!
    ///         </playgroundMarkup:TextTransform.Text>
    ///     </playgroundMarkup:TextTransform>
    ///     <playgroundMarkup:ToggleTransform />
    /// </m:RectTransform>
    /// ]]>
    /// </code>
    /// </example>
    public sealed class StandaloneInputModule : Behaviour<UnityEngine.EventSystems.StandaloneInputModule>
    {
        /// <summary>Backing store for the <see cref="HorizontalAxis" /> property.</summary>
        public BindableProperty HorizontalAxisProperty = CreateBindableBodyProperty<string>(
            "HorizontalAxis",
            typeof(StandaloneInputModule),
            (body, value) => body.horizontalAxis = value,
            "Horizontal");

        /// <summary>Backing store for the <see cref="VerticalAxis" /> property.</summary>
        public BindableProperty VerticalAxisProperty = CreateBindableBodyProperty<string>(
            "VerticalAxis",
            typeof(StandaloneInputModule),
            (body, value) => body.verticalAxis = value,
            "Vertical");

        /// <summary>Backing store for the <see cref="SubmitButton" /> property.</summary>
        public BindableProperty SubmitButtonProperty = CreateBindableBodyProperty<string>(
            "SubmitButton",
            typeof(StandaloneInputModule),
            (body, value) => body.submitButton = value,
            "Submit");

        /// <summary>Backing store for the <see cref="CancelButton" /> property.</summary>
        public BindableProperty CancelButtonProperty = CreateBindableBodyProperty<string>(
            "CancelButton",
            typeof(StandaloneInputModule),
            (body, value) => body.cancelButton = value,
            "Cancel");

        /// <summary>Backing store for the <see cref="InputActionsPerSecond" /> property.</summary>
        public BindableProperty InputActionsPerSecondProperty = CreateBindableBodyProperty<float>(
            "InputActionsPerSecond",
            typeof(StandaloneInputModule),
            (body, value) => body.inputActionsPerSecond = value,
            10);

        /// <summary>Backing store for the <see cref="RepeatDelay" /> property.</summary>
        public BindableProperty RepeatDelayProperty = CreateBindableBodyProperty<float>(
            "RepeatDelay",
            typeof(StandaloneInputModule),
            (body, value) => body.repeatDelay = value,
            0.5f);

        /// <summary>Backing store for the <see cref="ForceModuleActive" /> property.</summary>
        public BindableProperty ForceModuleActiveProperty = CreateBindableBodyProperty<bool>(
            "ForceModuleActive",
            typeof(StandaloneInputModule),
            (body, value) => body.forceModuleActive = value,
            false);

        /// <summary>
        /// A property that represents <see cref="P:UnityEngine.EventSystems.StandaloneInputModule.horizontalAxis" />.
        /// </summary>
        public string HorizontalAxis
        {
            get
            {
                return (string)GetValue(HorizontalAxisProperty);
            }

            set
            {
                SetValue(HorizontalAxisProperty, value);
            }
        }

        /// <summary>
        /// A property that represents <see cref="P:UnityEngine.EventSystems.StandaloneInputModule.verticalAxis" />.
        /// </summary>
        public string VerticalAxis
        {
            get
            {
                return (string)GetValue(VerticalAxisProperty);
            }

            set
            {
                SetValue(VerticalAxisProperty, value);
            }
        }

        /// <summary>
        /// A property that represents <see cref="P:UnityEngine.EventSystems.StandaloneInputModule.submitButton" />.
        /// </summary>
        public string SubmitButton
        {
            get
            {
                return (string)GetValue(SubmitButtonProperty);
            }

            set
            {
                SetValue(SubmitButtonProperty, value);
            }
        }

        /// <summary>
        /// A property that represents <see cref="P:UnityEngine.EventSystems.StandaloneInputModule.cancelButton" />.
        /// </summary>
        public string CancelButton
        {
            get
            {
                return (string)GetValue(CancelButtonProperty);
            }

            set
            {
                SetValue(CancelButtonProperty, value);
            }
        }

        /// <summary>
        /// A property that represents <see cref="P:UnityEngine.EventSystems.StandaloneInputModule.inputActionsPerSecond" />.
        /// </summary>
        public float InputActionsPerSecond
        {
            get
            {
                return (float)GetValue(InputActionsPerSecondProperty);
            }

            set
            {
                SetValue(InputActionsPerSecondProperty, value);
            }
        }

        /// <summary>
        /// A property that represents <see cref="P:UnityEngine.EventSystems.StandaloneInputModule.repeatDelay" />.
        /// </summary>
        public float RepeatDelay
        {
            get
            {
                return (float)GetValue(RepeatDelayProperty);
            }

            set
            {
                SetValue(RepeatDelayProperty, value);
            }
        }

        /// <summary>
        /// A property that represents <see cref="P:UnityEngine.EventSystems.StandaloneInputModule.forceModuleActive" />.
        /// </summary>
        public bool ForceModuleActive
        {
            get
            {
                return (bool)GetValue(ForceModuleActiveProperty);
            }

            set
            {
                SetValue(ForceModuleActiveProperty, value);
            }
        }

        /// <inheritdoc />
        protected override void AwakeInMainThread()
        {
            Body.horizontalAxis = HorizontalAxis;
            Body.verticalAxis = VerticalAxis;
            Body.submitButton = SubmitButton;
            Body.cancelButton = CancelButton;
            Body.inputActionsPerSecond = InputActionsPerSecond;
            Body.repeatDelay = RepeatDelay;
            Body.forceModuleActive = ForceModuleActive;

            base.AwakeInMainThread();
        }
    }
}
