// // Copyright (c) Microsoft. All rights reserved.
// // Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace AnimationTiming
{
    public partial class AccelDecelExample : Page
    {
        public abstract class ControlState
        {
            public abstract string content();
            public abstract string Null_Content();
        }
        //context
        public class StateControl
        {
            ControlState state;
            ControlState content_;
            ControlState Null_content;

            public StateControl()
            {
                content_ = new Content(this);
                Null_content = new null_Content(this);
            }

            public void SetContent()
                => state = content_;
            public void SetNull_Content()
                => state = Null_content;

            public string Content()
            {
                state.content();
                return state.content();
            }


            public string null_Content()
            {
                state.Null_Content();
                return state.Null_Content();
            }

        }

        //Concrete State <--- if there is a Content

        public class Content : ControlState
        {

            string value { get; set; }

            StateControl _context;

            public Content(StateControl context)
            {
                _context = context;
            }

            public override string content()
            {
                value = "Warning! There is a content.";
                return value;
            }

            public override string Null_Content()
            {
                _context.SetNull_Content();
                value = null;
                return value; ;
            }
        }

        public class null_Content : ControlState
        {
            string value { get; set; }

            public null_Content()
            {

            }


            StateControl _context;

            public null_Content(StateControl context)
            {
                _context = context;
            }

            public override string content()
            {
                value = "Warning! There is a content.";
                _context.SetContent();
                return value;

            }
            public override string Null_Content()
            {
                value = null;
                return value;
            }

        }





        private void StateInvalidated(object sender, EventArgs args)
        {

            StateControl stte = new StateControl();
            string null_value = stte.null_Content();


            if (sender != null_value)
            {
                elapsedTime.Clock = (Clock)sender;
            }
        }

    }
}

/*
        private void StateInvalidated(object sender, EventArgs args)
        {
            if (sender != null)
            {
                elapsedTime.Clock = (Clock) sender;
            }
        }
    */

