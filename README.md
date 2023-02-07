This fork simply adds an AudioLink node, so that AudioLink compatible shaders can be made in Shader Forge. 

The AudioLink node takes the X and Y coordinates of the AudioLink texture and outputs a float. There are a handful of presets built-in. Otherwise, you can put in custom coordinates, which can be found in this unofficial reference for the AudioLink texture: https://docs.google.com/spreadsheets/d/1PkA98uI_zslpTr6ARBVGOBSq5Yna0rKPe_RWbdtbERM/

You can preview the AudioLink effects if you put the AudioLinkAvatar prefab in your scene, add a sound file to the input, and press play. The effects should appear in the Shader Forge preview in real-time.

Please note that the implementation is currently very simple and largely untested.

For more info on AudioLink, see https://github.com/llealloo/vrc-udon-audio-link

For a video tutorial on how to use this, see: https://youtu.be/q0I4rVN3D9w

-------------------------------

ORIGINAL SHADER FORGE README:

hey everyone~

I will occasionally update this repository with fixes and features!
I'll mostly do compatibility updates for future versions of Unity whenever I need it. if you want older versions, consider pulling one of the older branches! I'll try to name branches helpfully. the oldest version of SF you can get is for Unity 5.x

also, please don't pressure me into doing or fixing things because holy heck I was burnt out at the end of Shader Forge's first lifetime 👀 I'm mostly working on this casually, either when I need a fix or a new feature, or when I have time to fix something other people really want to see fixed!

also, if you enjoy or are currently enjoying or finding Shader Forge useful, please consider supporting me, if you're able to!

you can either do a one-time donation on PayPal at https://www.paypal.me/acegikmo ✨

or a monthly donation on Patreon at https://www.patreon.com/acegikmo 💖

support is entirely optional though, I intend to keep this project open and free, but if you do donate, thank you so hecking much!! if you want to reach me, Twitter is the best place https://twitter.com/FreyaHolmer 🐦

~ Freya

-------------------------------


https://tldrlegal.com/license/mit-license

Copyright 2019 Freya Holmér

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
