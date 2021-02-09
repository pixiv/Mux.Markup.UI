﻿// Copyright 2019 pixiv Inc.
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
using Xamarin.Forms.Xaml;

namespace Mux.Markup
{
    /// <summary>
    /// A <xref href="Xamarin.Forms.Xaml.IMarkupExtension`1?text=markup extension" />
    /// that represents <see cref="T:UnityEngine.UI.SpriteState" />.
    /// </summary>
    [AcceptEmptyServiceProvider]
    public class SpriteState : IMarkupExtension<UnityEngine.UI.SpriteState>
    {
        /// <summary>
        /// A property that represents <see cref="P:UnityEngine.UI.SpriteState.highlightedSprite" />.
        /// </summary>
        public UnityEngine.Sprite HighlightedSprite { get; set; }

        /// <summary>
        /// A property that represents <see cref="P:UnityEngine.UI.SpriteState.pressedSprite" />.
        /// </summary>
        public UnityEngine.Sprite PressedSprite { get; set; }

        /// <summary>
        /// A property that represents <see cref="P:UnityEngine.UI.SpriteState.disabledSprite" />.
        /// </summary>
        public UnityEngine.Sprite DisabledSprite { get; set; }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return ProvideValue(serviceProvider);
        }

        public UnityEngine.UI.SpriteState ProvideValue(IServiceProvider serviceProvider)
        {
            return new UnityEngine.UI.SpriteState
            {
                highlightedSprite = HighlightedSprite,
                pressedSprite = PressedSprite,
                disabledSprite = DisabledSprite
            };
        }
    }
}
