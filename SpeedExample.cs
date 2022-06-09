// // Copyright (c) Microsoft. All rights reserved.
// // Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Windows.Controls;

namespace AnimationTiming
{
    public partial class SpeedExample : Page
    {

        enum SpeedType
        {
            Fast, Slow
        }


        abstract class SettingFast
        {
            protected string SpeedName;
            protected SpeedType speed_type;

            string start()
            {
                return "Speed Transaction was started.";
            }
            string finish()
            {
                return "Speed Transaction was stoped";
            }

            abstract public void name();
            abstract public void type();

            public void TemplateMethod()
            {
                start();
                finish();
                name();
                type();
            }

        }

        class TwoXSpeed : SettingFast
        {
            public override void type()
            {
                speed_type = SpeedType.Fast;
            }

            public override void name()
            {
                SpeedName = "2x speed";
            }
        }

        class _5xSpeed : SettingFast
        {
            public override void type()
            {
                speed_type = SpeedType.Slow;
            }

            public override void name()
            {
                SpeedName = "0.5x speed";
            }
        }

        public void function()
        {
            SettingFast twoXspeeder = new TwoXSpeed();
            twoXspeeder.TemplateMethod();

            SettingFast _5Xslower = new _5xSpeed();
            _5Xslower.TemplateMethod();
        }

    }
}

