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
    /// A <see cref="Behaviour{T}" /> that represents <see cref="T:UnityEngine.UI.RectMask2D" />.
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
    ///     <m:RectTransform>
    ///         <mu:RectMask2D />
    ///         <playgroundMarkup:TextTransform X="{m:Sized Anchor=0, Pivot=0, SizeDelta=999}" Y="{m:Sized Anchor=1, Pivot=1, SizeDelta=999}">
    ///             <playgroundMarkup:TextTransform.Text>
    /// This text is masked by mu:RectMask2D.
    ///
    /// Comparison between mu:RectMask2D and mu:Mask:
    /// - mu:RectMask2D performs better than mu:Mask.
    ///   Concretely, mu:RectMask2D does not require the stencil buffer while mu:Mask does.
    /// - mu:Mask can mask with a complex graphic while mu:RectMask2D always masks with a rectangle.
    ///             </playgroundMarkup:TextTransform.Text>
    ///         </playgroundMarkup:TextTransform>
    ///     </m:RectTransform>
    /// </m:RectTransform>
    /// ]]>
    /// </code>
    /// </example>
    public sealed class RectMask2D : Behaviour<UnityEngine.UI.RectMask2D>
    {
    }
}
