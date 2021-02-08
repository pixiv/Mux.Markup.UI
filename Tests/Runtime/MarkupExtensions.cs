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

using NUnit.Framework;

namespace Mux.Tests.Markup
{
    [TestFixture]
    public static class AnimationTriggers
    {
        [Test]
        public static void ProvideValue()
        {
            var instance = new Mux.Markup.AnimationTriggers();
            var value = instance.ProvideValue(null);

            Assert.AreEqual("Disabled", value.disabledTrigger);
            Assert.AreEqual("Highlighted", value.highlightedTrigger);
            Assert.AreEqual("Normal", value.normalTrigger);
            Assert.AreEqual("Pressed", value.pressedTrigger);
        }
    }

    [TestFixture]
    public static class ColorBlock
    {
        [Test]
        public static void ProvideValue()
        {
            var instance = new Mux.Markup.ColorBlock();
            var value = instance.ProvideValue(null);

            Assert.AreEqual(1, value.colorMultiplier);
            Assert.AreEqual((UnityEngine.Color)new UnityEngine.Color32(200, 200, 200, 128), value.disabledColor);
            Assert.AreEqual(0.1f, value.fadeDuration);
            Assert.AreEqual((UnityEngine.Color)new UnityEngine.Color32(255, 255, 255, 255), value.highlightedColor);
            Assert.AreEqual((UnityEngine.Color)new UnityEngine.Color32(255, 255, 255, 255), value.normalColor);
            Assert.AreEqual((UnityEngine.Color)new UnityEngine.Color32(200, 200, 200, 255), value.pressedColor);
        }
    }
}
