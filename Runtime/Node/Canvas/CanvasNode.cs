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
    /// <summary>An <see cref="Behaviour{T}" /> that represents <see cref="T:UnityEngine.Canvas" />.</summary>
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
    ///     <mu:CanvasScaler UiScale="{mu:ConstantPhysicalSize}" />
    ///     <mu:GraphicRaycaster />
    ///     <mu:Text Font="{Binding Path=Resources.Font}">
    ///         <mu:Text.Content>
    /// You have to give property name "Path" to Binding only when you compile
    /// the interpreter with IL2CPP. It is because ContentPropertyAttribute does
    /// not work with IL2CPP.
    ///
    /// mu:Canvas is required anything based on uGUI.
    /// See what happens to this text if you remove the mu:Canvas!
    ///         </mu:Text.Content>
    ///     </mu:Text>
    /// </m:RectTransform>
    /// ]]>
    /// </code>
    /// </example>
    public class Canvas : Behaviour<UnityEngine.Canvas>
    {
        /// <summary>Backing store for the <see cref="Render" /> property.</summary>
        public static readonly BindableProperty RenderProperty = BindableProperty.Create(
            "Render",
            typeof(Render),
            typeof(Canvas),
            null,
            BindingMode.OneWay,
            null,
            OnRenderChanged,
            null,
            null,
            sender => new ScreenSpaceOverlay());

        /// <summary>Backing store for the <see cref="AdditionalShaderChannels" /> property.</summary>
        public static readonly BindableProperty AdditionalShaderChannelsProperty = CreateBindableBodyProperty<UnityEngine.AdditionalCanvasShaderChannels>(
            "AdditionalShaderChannels",
            typeof(Canvas),
            (body, value) => body.additionalShaderChannels = value,
            UnityEngine.AdditionalCanvasShaderChannels.None);

        private static void OnRenderChanged(BindableObject sender, object oldValue, object newValue)
        {
            ((Render)oldValue)?.DestroyMux();

            if (newValue != null)
            {
                var body = ((Canvas)sender).Body;
                var render = (Render)newValue;

                if (body != null)
                {
                    body.renderMode = render.Mode;
                    render.Body = body;
                }

                SetInheritedBindingContext(render, sender.BindingContext);
            }
        }

        /// <summary>A property that represents <see cref="T:UnityEngine.RenderMode.ScreenSpaceCamera" /> and its rendering properties.</summary>
        /// <remarks>Setting <see cref="Render" /> to this property binds its lifetime to the lifetime of this object.</remarks>
        public Render Render
        {
            get
            {
                return (Render)GetValue(RenderProperty);
            }

            set
            {
                SetValue(RenderProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.Canvas.additionalShaderChannels" />.</summary>
        public UnityEngine.AdditionalCanvasShaderChannels AdditionalShaderChannels
        {
            get
            {
                return (UnityEngine.AdditionalCanvasShaderChannels)GetValue(AdditionalShaderChannelsProperty);
            }

            set
            {
                SetValue(AdditionalShaderChannelsProperty, value);
            }
        }

        /// <inheritdoc />
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            SetInheritedBindingContext(Render, BindingContext);
        }

        /// <inhertidoc />
        protected override void AddToInMainThread(UnityEngine.GameObject gameObject)
        {
            base.AddToInMainThread(gameObject);

            if (Render != null)
            {
                // Setting renderMode of an enabled component causes properties of
                // RectTransform modified. Therefore, it must be set in AddToInMainThread.
                Body.renderMode = Render.Mode;
            }
        }

        /// <inheritdoc />
        protected override void AwakeInMainThread()
        {
            Body.additionalShaderChannels = AdditionalShaderChannels;
            Render.Body = Body;

            base.AwakeInMainThread();
        }

        /// <inheritdoc />
        protected override void DestroyMuxInMainThread()
        {
            base.DestroyMuxInMainThread();
            Render.DestroyMux();
        }
    }
}
