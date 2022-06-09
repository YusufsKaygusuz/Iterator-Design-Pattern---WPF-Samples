// // Copyright (c) Microsoft. All rights reserved.
// // Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace AnimationTiming
{
    public class ElapsedTimeControl : Control
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


        public static readonly DependencyProperty CurrentTimeProperty =
            DependencyProperty.Register(
                "CurrentTime",
                typeof(TimeSpan?),
                typeof(ElapsedTimeControl),
                new FrameworkPropertyMetadata(
                    null,
                    currentTime_Changed));
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


        public static readonly DependencyProperty CurrentTimeAsStringProperty =
            DependencyProperty.Register("CurrentTimeAsString", typeof(string),
                typeof(ElapsedTimeControl));

        private TimeSpan? _previousTime;
        private Clock _theClock;

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
        public ElapsedTimeControl(TimeSpan? previousTime)
        {
            _previousTime = previousTime;
        }

        public ElapsedTimeControl()
        {
        }

        public class Fnct
        {
            public void function()
            {
                SettingFast twoXspeeder = new TwoXSpeed();
                twoXspeeder.TemplateMethod();

                SettingFast _5Xslower = new _5xSpeed();
                _5Xslower.TemplateMethod();
            }
        }

        public Clock Clock
        {
            get { return _theClock; }
            set
            {
                Fnct a = new Fnct();
                a.function();
                if (_theClock != null)
                {
                    _theClock.CurrentTimeInvalidated -= OnClockTimeInvalidated;
                }

                _theClock = value;

                if (_theClock != null)
                {
                    _theClock.CurrentTimeInvalidated += OnClockTimeInvalidated;
                }
            }
        }


        public string CurrentTimeAsString
        {
            get { return GetValue(CurrentTimeAsStringProperty) as string; }
            set { SetValue(CurrentTimeAsStringProperty, value); }
        }

        private void OnClockTimeInvalidated(object sender, EventArgs args)
        {
            SetValue(CurrentTimeProperty, _theClock.CurrentTime);
        }

        private static void currentTime_Changed(DependencyObject d,
            DependencyPropertyChangedEventArgs args)
        {
            ((ElapsedTimeControl)d).SetValue(CurrentTimeAsStringProperty, args.NewValue.ToString());
        }
    }
}