using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.Patterns
{
    /* The command pattern gives us a way of managing callbacks
     * This is a way of binding an action to a command that allows us to use virtualisation to make everything configurable
     * It also gives us a command stream that can be used to undo and redo actions
     */

    //Implementation of the most basic command pattern, a simple action to command transformer
    public class CommandBasic
    {
        public enum Buttons
        {
            BUTTON_X,
            BUTTON_Y,
            BUTTON_A,
            BUTTON_B
        }

        private Buttons _buttons;
        public Buttons ButtonPressed
        {
            get
            {
                return _buttons;
            }
            set
            {
                _buttons = value;
            }
        }

        /* The most basic command pattern simply acts as an action to command transformer
         */
        public string HandleInput()
        {
            if (ButtonPressed == Buttons.BUTTON_A)
                return "Button A";
            else if (ButtonPressed == Buttons.BUTTON_B)
                return "Button B";
            else if (ButtonPressed == Buttons.BUTTON_X)
                return "Button X";
            else if (ButtonPressed == Buttons.BUTTON_Y)
                return "Button Y";

            return string.Empty;
        }        
    }

    //A proper command pattern makes use of virtualisation to give us more flexibility
    public abstract class Command
    {
        /// <summary>
        /// Button currently pressed for this frame
        /// </summary>
        public enum Buttons
        {
            Button_A,
            Button_B,
            Button_X,
            Button_Y
        }

        public Buttons ButtonPressed;

        #region Constructors and Destructors
        /// <summary>
        /// Simple Constructor
        /// </summary>
        public Command()
        {

        }

        /// <summary>
        /// Simple Destructor if needed
        /// </summary>
        ~Command()
        {

        }
        #endregion

        /// <summary>
        /// The basic execute action that should be performed
        /// </summary>
        /// <returns></returns>
        public abstract string Execute();

        public class Button_A_Pressed : Command
        {
            public override string Execute()
            {
                return "Button A";
            }
        }

        public class Button_B_Pressed : Command
        {
            public override string Execute()
            {
                return "Button B";
            }
        }

        public class Button_X_Pressed : Command
        {
            public override string Execute()
            {
                return "Button X";
            }
        }

        public class Button_Y_Pressed : Command
        {
            public override string Execute()
            {
                return "Button Y";
            }
        }
    }
}
