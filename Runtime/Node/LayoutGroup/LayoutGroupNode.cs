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
    /// <summary>A <see cref="Behaviour{T}" /> that represents <see cref="T:UnityEngine.UI.LayoutGroup" />.</summary>
    public abstract class LayoutGroup<T> : Behaviour<T> where T : UnityEngine.UI.LayoutGroup
    {
        /// <summary>Backing store for the <see cref="PaddingLeft" /> property.</summary>
        public static readonly BindableProperty PaddingLeftProperty = CreateBindableBodyProperty<int>(
            "PaddingLeft",
            typeof(LayoutGroup<T>),
            (body, value) => body.padding.left = value,
            0);

        /// <summary>Backing store for the <see cref="PaddingRight" /> property.</summary>
        public static readonly BindableProperty PaddingRightProperty = CreateBindableBodyProperty<int>(
            "PaddingRight",
            typeof(LayoutGroup<T>),
            (body, value) => body.padding.right = value,
            0);

        /// <summary>Backing store for the <see cref="PaddingTop" /> property.</summary>
        public static readonly BindableProperty PaddingTopProperty = CreateBindableBodyProperty<int>(
            "PaddingTop",
            typeof(LayoutGroup<T>),
            (body, value) => body.padding.top = value,
            0);

        /// <summary>Backing store for the <see cref="PaddingBottom" /> property.</summary>
        public static readonly BindableProperty PaddingBottomProperty = CreateBindableBodyProperty<int>(
            "PaddingBottom",
            typeof(LayoutGroup<T>),
            (body, value) => body.padding.bottom = value,
            0);

        /// <summary>Backing store for the <see cref="ChildAlignment" /> property.</summary>
        public static readonly BindableProperty ChildAlignmentProperty = CreateBindableBodyProperty<UnityEngine.TextAnchor>(
            "ChildAlignment",
            typeof(LayoutGroup<T>),
            (body, value) => body.childAlignment = value,
            UnityEngine.TextAnchor.UpperLeft);

        /// <summary>
        /// A property that represents <see cref="P:UnityEngine.RectOffset.left" /> of
        /// <see cref="P:UnityEngine.UI.LayoutGroup.padding" />.
        /// </summary>
        public int PaddingLeft
        {
            get
            {
                return (int)GetValue(PaddingLeftProperty);
            }

            set
            {
                SetValue(PaddingLeftProperty, value);
            }
        }

        /// <summary>
        /// A property that represents <see cref="P:UnityEngine.RectOffset.right" /> of
        /// <see cref="P:UnityEngine.UI.LayoutGroup.padding" />.
        /// </summary>
        public int PaddingRight
        {
            get
            {
                return (int)GetValue(PaddingRightProperty);
            }

            set
            {
                SetValue(PaddingRightProperty, value);
            }
        }

        /// <summary>
        /// A property that represents <see cref="P:UnityEngine.RectOffset.top" /> of
        /// <see cref="P:UnityEngine.UI.LayoutGroup.padding" />.
        /// </summary>
        public int PaddingTop
        {
            get
            {
                return (int)GetValue(PaddingTopProperty);
            }

            set
            {
                SetValue(PaddingTopProperty, value);
            }
        }

        /// <summary>
        /// A property that represents <see cref="P:UnityEngine.RectOffset.bottom" /> of
        /// <see cref="P:UnityEngine.UI.LayoutGroup.padding" />.
        /// </summary>
        public int PaddingBottom
        {
            get
            {
                return (int)GetValue(PaddingBottomProperty);
            }

            set
            {
                SetValue(PaddingBottomProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.LayoutGroup.childAlignment" />.</summary>
        public UnityEngine.TextAnchor ChildAlignment
        {
            get
            {
                return (UnityEngine.TextAnchor)GetValue(ChildAlignmentProperty);
            }

            set
            {
                SetValue(ChildAlignmentProperty, value);
            }
        }

        /// <inheritdoc />
        protected override void AwakeInMainThread()
        {
            Body.padding.left = PaddingLeft;
            Body.padding.right = PaddingRight;
            Body.padding.top = PaddingTop;
            Body.padding.bottom = PaddingBottom;
            Body.childAlignment = ChildAlignment;

            base.AwakeInMainThread();
        }
    }
}
