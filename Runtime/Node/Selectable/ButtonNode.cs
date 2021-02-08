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

namespace Mux.Markup
{
    /// <summary>A <see cref="Selectable{T}" /> that represents <see cref="T:UnityEngine.UI.Button" />.</summary>
    public class Button : Selectable<UnityEngine.UI.Button>
    {
        private readonly UnityEngine.UI.Button.ButtonClickedEvent _onClick = new UnityEngine.UI.Button.ButtonClickedEvent();

        /// <summary>An event that represents <see cref="P:UnityEngine.UI.Button.onClick" />.</summary>
        public event UnityEngine.Events.UnityAction OnClick
        {
            add
            {
                Forms.mainThread.Send(state => _onClick.AddListener(value), null);
            }

            remove
            {
                Forms.mainThread.Send(state => _onClick.RemoveListener(value), null);
            }
        }

        /// <inheritdoc />
        protected override void AwakeInMainThread()
        {
            Body.onClick = _onClick;
            base.AwakeInMainThread();
        }
    }
}
