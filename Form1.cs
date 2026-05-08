using Nefarius.ViGEm.Client;
using Nefarius.ViGEm.Client.Targets.Xbox360;
using System.Diagnostics;
using System.Media;
using System.Runtime.InteropServices;
namespace GordoControllerFakeInput;

public partial class GordoControllerFakeInput : Form
{

    // word = ushort
    // Uint32 = dword

    [Flags]
    public enum GamepadButtons
    {
        XINPUT_GAMEPAD_DPAD_UP = 0x0001,
        XINPUT_GAMEPAD_DPAD_DOWN = 0x0002,
        XINPUT_GAMEPAD_DPAD_LEFT = 0x0004,
        XINPUT_GAMEPAD_DPAD_RIGHT = 0x0008,
        XINPUT_GAMEPAD_START = 0x0010,
        XINPUT_GAMEPAD_BACK = 0x0020,
        XINPUT_GAMEPAD_LEFT_THUMB = 0x0040,
        XINPUT_GAMEPAD_RIGHT_THUMB = 0x0080,
        XINPUT_GAMEPAD_LEFT_SHOULDER = 0x0100,
        XINPUT_GAMEPAD_RIGHT_SHOULDER = 0x0200,
        XINPUT_GAMEPAD_A = 0x1000,
        XINPUT_GAMEPAD_B = 0x2000,
        XINPUT_GAMEPAD_X = 0x4000,
        XINPUT_GAMEPAD_Y = 0x8000
    }

    public struct XINPUT_GAMEPAD
    {
        public ushort wButtons;
        public byte bLeftTrigger;
        public byte bRightTrigger;
        public short sThumbLX;
        public short sThumbLY;
        public short sThumbRX;
        public short sThumbRY;
    }

    public struct XINPUT_STATE
    {
        public uint dwPacketNumber;
        public XINPUT_GAMEPAD Gamepad;
    }

    [DllImport("xinput1_4.dll")]
    public static extern int XInputGetState(int dwUserIndex, out XINPUT_STATE pState);

    [DllImport("user32.dll")]
    static extern short GetAsyncKeyState(int vKey);

#if TRIGGERANTICHEAT || DEBUG
    private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll")]
    private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool UnhookWindowsHookEx(IntPtr hhk);

    [DllImport("kernel32.dll")]
    private static extern IntPtr GetModuleHandle(string lpModuleName);
    [DllImport("user32.dll")]
    private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

    public struct tagBDLLHOOKSTRUCT
    {
        public uint vkCode;
        public uint scanCode;
        public uint flags;
        public uint time;
        public IntPtr dwExtraInfo;
    }
#endif

    Dictionary<String, int> VirtualKeys = new Dictionary<string, int>()
    {
        { "NONE",0x0 },
        { "LBUTTON", 0x01 },
        { "RBUTTON", 0x02 },
        { "MBUTTON", 0x04 },
        { "XBUTTON1", 0x05 },
        { "XBUTTON2", 0x06 },
        { "BACKSPACE", 0x08 },
        { "TAB", 0x09 },
        { "ENTER", 0x0D },
        { "SHIFT", 0x10 },
        { "CTRL", 0x11 },
        { "ALT", 0x12 },
        { "PAUSE", 0x13 },
        { "CAPS LOCK", 0x14 },
        { "ESC", 0x1B },
        { "SPACE", 0x20 },
        { "PAGE UP", 0x21 },
        { "PAGE DOWN", 0x22 },
        { "END", 0x23 },
        { "HOME", 0x24 },
        { "LEFT", 0x25 },
        { "UP", 0x26 },
        { "RIGHT", 0x27 },
        { "DOWN", 0x28 },
        { "PRINT SCREEN", 0x2C },
        { "INSERT", 0x2D },
        { "DELETE", 0x2E },
        { "0", 0x30 },
        { "1", 0x31 },
        { "2", 0x32 },
        { "3", 0x33 },
        { "4", 0x34 },
        { "5", 0x35 },
        { "6", 0x36 },
        { "7", 0x37 },
        { "8", 0x38 },
        { "9", 0x39 },
        { "A", 0x41 },
        { "B", 0x42 },
        { "C", 0x43 },
        { "D", 0x44 },
        { "E", 0x45 },
        { "F", 0x46 },
        { "G", 0x47 },
        { "H", 0x48 },
        { "I", 0x49 },
        { "J", 0x4A },
        { "K", 0x4B },
        { "L", 0x4C },
        { "M", 0x4D },
        { "N", 0x4E },
        { "O", 0x4F },
        { "P", 0x50 },
        { "Q", 0x51 },
        { "R", 0x52 },
        { "S", 0x53 },
        { "T", 0x54 },
        { "U", 0x55 },
        { "V", 0x56 },
        { "W", 0x57 },
        { "X", 0x58 },
        { "Y", 0x59 },
        { "Z", 0x5A },
        { "LEFT WINDOWS", 0x5B },
        { "RIGHT WINDOWS", 0x5C },
        { "APPLICATION", 0x5D },
        { "NUMPAD0", 0x60 },
        { "NUMPAD1", 0x61 },
        { "NUMPAD2", 0x62 },
        { "NUMPAD3", 0x63 },
        { "NUMPAD4", 0x64 },
        { "NUMPAD5", 0x65 },
        { "NUMPAD6", 0x66 },
        { "NUMPAD7", 0x67 },
        { "NUMPAD8", 0x68 },
        { "NUMPAD9", 0x69 },
        { "MULTIPLY", 0x6A },
        { "ADD", 0x6B },
        { "SUBTRACT", 0x6D },
        { "DECIMAL", 0x6E },
        { "DIVIDE", 0x6F },
        { "F1", 0x70 },
        { "F2", 0x71 },
        { "F3", 0x72 },
        { "F4", 0x73 },
        { "F5", 0x74 },
        { "F6", 0x75 },
        { "F7", 0x76 },
        { "F8", 0x77 },
        { "F9", 0x78 },
        { "F10", 0x79 },
        { "F11", 0x7A },
        { "F12", 0x7B },
        { "F13", 0x7C },
        { "F14", 0x7D },
        { "F15", 0x7E },
        { "F16", 0x7F },
        { "F17", 0x80 },
        { "F18", 0x81 },
        { "F19", 0x82 },
        { "F20", 0x83 },
        { "F21", 0x84 },
        { "F22", 0x85 },
        { "F23", 0x86 },
        { "F24", 0x87 },
        { "NUM LOCK", 0x90 },
        { "SCROLL LOCK", 0x91 },
        { "LEFT SHIFT", 0xA0 },
        { "RIGHT SHIFT", 0xA1 },
        { "LEFT CTRL", 0xA2 },
        { "RIGHT CTRL", 0xA3 },
        { "LEFT ALT", 0xA4 },
        { "RIGHT ALT", 0xA5 },
        { "VOLUME MUTE", 0xAD },
        { "VOLUME DOWN", 0xAE },
        { "VOLUME UP", 0xAF },
        { "MEDIA NEXT", 0xB0 },
        { "MEDIA PREV", 0xB1 },
        { "MEDIA STOP", 0xB2 },
        { "MEDIA PLAY", 0xB3 }
    };


    System.Windows.Forms.Timer looptimer = new();
    Nefarius.ViGEm.Client.Targets.IXbox360Controller controller;
    private int FakeControllerID = -1;
    private bool[] ControllersConected = new bool[4];
    private byte oldvalue_lefttrigger = 0;
    private byte oldvalue_righttrigger = 0;
    // Keyboard 99% shortcut
    private int selectedKey = -1;
    // Controller Toggle
    private int toggleSelectedKey = -1;
    private bool isControllerToggleEnabled = false;
    // Keyboard Toggle
    private int toggleKeyboardSelectedKey = -1;
    private bool isKeyboardToggleEnabled = false;
    private bool isPressingSelectedKey = false;
    //Controller Toggle sounds
    private const string pathSoundActivate = @"audio\ON.wav";
    private const string pathSoundDeactivate = @"audio\OFF.wav";
    SoundPlayer soundToggleActivate = new SoundPlayer(pathSoundActivate);
    SoundPlayer soundToggleDeactivate = new SoundPlayer(pathSoundDeactivate);
    GamepadButtons oldflags;

#if TRIGGERANTICHEAT || DEBUG
    //might trigger anti cheat if the game has it.
    private IntPtr hookID = IntPtr.Zero;
    private readonly LowLevelKeyboardProc keyproc;

    private IntPtr KeyboardEventProc(int nCode, IntPtr wParam, IntPtr lParam)
    {
        if (nCode >= 0 && isKeyboardToggleEnabled && selectedKey > 0)
        {
            if (wParam == 0x0100 || wParam == 0x0104)
            {
                tagBDLLHOOKSTRUCT inpt = Marshal.PtrToStructure<tagBDLLHOOKSTRUCT>(lParam);
                if (inpt.vkCode == selectedKey && isPressingSelectedKey)
                {
                    return 1;
                }
            }
        }
        return CallNextHookEx(hookID, nCode, wParam, lParam);
    }
#endif

    // Main Entry point
    public GordoControllerFakeInput()
    {
        InitializeComponent();
#if TRIGGERANTICHEAT || DEBUG
        //Hook with keyboard events.
        keyproc = KeyboardEventProc;
        hookID = SetWindowsHookEx(0xD, keyproc, GetModuleHandle(Process.GetCurrentProcess().MainModule!.ModuleName), 0);

        //if the person is using the trigger anticheat version, the toggle is going to be enabled by default.
        //because the person will have access to changing it.
        isKeyboardToggleEnabled = true;
#else
        // if the person is not using the trigger anticheat version, just disable the toggle and hide the options.
        comboBox_ToggleKeyboard.Enabled = false;
        checkBox_PlaySoundsKeyboard.Enabled = false;
        label_IsKeyboardKeyDisabled.Visible = false;
#endif

        //Loading the sound files.
        if (File.Exists(pathSoundActivate))
            soundToggleActivate.Load();
        if (File.Exists(pathSoundDeactivate))
            soundToggleDeactivate.Load();

        //Default stuff because forms is stupid.
        comboBox1.SelectedIndex = 0;
        comboBox_ToggleKey.SelectedIndex = 0;
        comboBox_ToggleKeyboard.SelectedIndex = 0;

        // Api setup for ViGEm
        var client = new ViGEmClient();
        controller = client.CreateXbox360Controller();
        controller.Connect();

        // Instead of using while(), i am going to use the timer function.
        // makes sure the main window is not going to be locked and other issues.
        looptimer.Interval = 4;
        looptimer.Tick += TimerLoop;
        looptimer.Start();
    }

    // Get any input from any controller windows is detecting and copy it to the fake controller.
    // since gta5 can only detect one controller at the time.
    private void PassWindowsInputsToFakeController()
    {
        if (controller == null)
        {
            return;
        }

        XINPUT_STATE c;
        for (int i = 0; i < 4; i++)
        {
            if (i == FakeControllerID)
            {// don't test fake controller just to make sure stuff is not going to break
                continue;
            }
            //ERROR_SUCCESS = 0, anything else is >= 1
            if (XInputGetState(i, out c) == 0)
            {
                GamepadButtons b = (GamepadButtons)c.Gamepad.wButtons;
                FlagExistsSetButtonState(b, GamepadButtons.XINPUT_GAMEPAD_DPAD_UP);
                FlagExistsSetButtonState(b, GamepadButtons.XINPUT_GAMEPAD_DPAD_DOWN);
                FlagExistsSetButtonState(b, GamepadButtons.XINPUT_GAMEPAD_DPAD_LEFT);
                FlagExistsSetButtonState(b, GamepadButtons.XINPUT_GAMEPAD_DPAD_RIGHT);
                FlagExistsSetButtonState(b, GamepadButtons.XINPUT_GAMEPAD_START);
                FlagExistsSetButtonState(b, GamepadButtons.XINPUT_GAMEPAD_BACK);
                FlagExistsSetButtonState(b, GamepadButtons.XINPUT_GAMEPAD_LEFT_THUMB);
                FlagExistsSetButtonState(b, GamepadButtons.XINPUT_GAMEPAD_RIGHT_THUMB);
                FlagExistsSetButtonState(b, GamepadButtons.XINPUT_GAMEPAD_LEFT_SHOULDER);
                FlagExistsSetButtonState(b, GamepadButtons.XINPUT_GAMEPAD_RIGHT_SHOULDER);
                FlagExistsSetButtonState(b, GamepadButtons.XINPUT_GAMEPAD_A);
                FlagExistsSetButtonState(b, GamepadButtons.XINPUT_GAMEPAD_B);
                FlagExistsSetButtonState(b, GamepadButtons.XINPUT_GAMEPAD_X);
                FlagExistsSetButtonState(b, GamepadButtons.XINPUT_GAMEPAD_Y);
                oldflags = b;

                controller.SetAxisValue(Xbox360Axis.LeftThumbX, c.Gamepad.sThumbLX);
                controller.SetAxisValue(Xbox360Axis.LeftThumbY, c.Gamepad.sThumbLY);
                controller.SetAxisValue(Xbox360Axis.RightThumbX, c.Gamepad.sThumbRX);
                controller.SetAxisValue(Xbox360Axis.RightThumbY, c.Gamepad.sThumbRY);

                if (oldvalue_lefttrigger != c.Gamepad.bLeftTrigger)
                {
                    oldvalue_lefttrigger = c.Gamepad.bLeftTrigger;
                    controller.SetSliderValue(Xbox360Slider.LeftTrigger, c.Gamepad.bLeftTrigger);
                }

                if (oldvalue_righttrigger != c.Gamepad.bRightTrigger)
                {
                    oldvalue_righttrigger = c.Gamepad.bRightTrigger;
                    if (isControllerToggleEnabled) // if player enabled the toggle 99% trigger option
                    {
                        // if player is holding above 99%, just bring back to 99%
                        if (c.Gamepad.bRightTrigger >= 254)
                        {
                            controller.SetSliderValue(Xbox360Slider.RightTrigger, 254);
                        }
                        else
                        {
                            //otherwise just copy the input.
                            controller.SetSliderValue(Xbox360Slider.RightTrigger, c.Gamepad.bRightTrigger);
                        }
                    }
                    else
                    {
                        controller.SetSliderValue(Xbox360Slider.RightTrigger, c.Gamepad.bRightTrigger);
                    }
                }
            }
        }
    }

    // Find every controller and test if we have a change in hardware connection
    private bool TestControllerChange()
    {
        bool change = false;
        for (int i = 0; i < 4; i++)
        {
            bool available = false;
            if (XInputGetState(i, out XINPUT_STATE c) == 0)
            {
                available = true;
            }
            if (ControllersConected[i] != available)
            {
                ControllersConected[i] = available;
                change = true;
            }
        }
        return change;
    }

    // To find the fake controller ID created by the program we need to create a specific situation for it.
    // just cycle between every controller and find the one that has the left trigger value set to exactly 3.
    private void FindFakeController()
    {
        controller.SetSliderValue(Xbox360Slider.LeftTrigger, 3);
        for (int i = 0; i < 4; i++)
        {
            // ERROR_SUCCESS = 0, anything else is >= 1
            if (XInputGetState(i, out XINPUT_STATE c) == 0)
            {
                if (c.Gamepad.bLeftTrigger == 3)
                {
                    FakeControllerID = i;
                    break;
                }
            }
        }
        controller.SetSliderValue(Xbox360Slider.LeftTrigger, 0);
    }

    // we only want to change inputs that actually did change on the true controller,
    // otherwise the inputs are going to switch on and off every frame...
    // creating a few situations where the input is 0 for a frame then back to 1, then back to 0, etc...
    private void FlagExistsSetButtonState(GamepadButtons flags, GamepadButtons which)
    {
        if (flags.HasFlag(which) != oldflags.HasFlag(which))
        {
            controller.SetButtonState(ConvertFlagIntoXboxButton(which), flags.HasFlag(which));
        }
    }

    // Converting internal enum into api enum.
    // why? making code easy to read later.
    private static Xbox360Button ConvertFlagIntoXboxButton(GamepadButtons c)
    {
        switch (c)
        {
            case GamepadButtons.XINPUT_GAMEPAD_DPAD_UP:
                return Xbox360Button.Up;

            case GamepadButtons.XINPUT_GAMEPAD_DPAD_DOWN:
                return Xbox360Button.Down;

            case GamepadButtons.XINPUT_GAMEPAD_DPAD_LEFT:
                return Xbox360Button.Left;

            case GamepadButtons.XINPUT_GAMEPAD_DPAD_RIGHT:
                return Xbox360Button.Right;

            case GamepadButtons.XINPUT_GAMEPAD_START:
                return Xbox360Button.Start;

            case GamepadButtons.XINPUT_GAMEPAD_BACK:
                return Xbox360Button.Back;

            case GamepadButtons.XINPUT_GAMEPAD_LEFT_THUMB:
                return Xbox360Button.LeftThumb;

            case GamepadButtons.XINPUT_GAMEPAD_RIGHT_THUMB:
                return Xbox360Button.RightThumb;

            case GamepadButtons.XINPUT_GAMEPAD_LEFT_SHOULDER:
                return Xbox360Button.LeftShoulder;

            case GamepadButtons.XINPUT_GAMEPAD_RIGHT_SHOULDER:
                return Xbox360Button.RightShoulder;

            case GamepadButtons.XINPUT_GAMEPAD_A:
                return Xbox360Button.A;

            case GamepadButtons.XINPUT_GAMEPAD_B:
                return Xbox360Button.B;

            case GamepadButtons.XINPUT_GAMEPAD_X:
                return Xbox360Button.X;

            case GamepadButtons.XINPUT_GAMEPAD_Y:
                return Xbox360Button.Y;

            default:
                return Xbox360Button.Up;
        }
    }
    private void ResetAllFakeControllerInputs()
    {
        controller.SetButtonState(Xbox360Button.A, false);
        controller.SetButtonState(Xbox360Button.B, false);
        controller.SetButtonState(Xbox360Button.X, false);
        controller.SetButtonState(Xbox360Button.Y, false);
        controller.SetButtonState(Xbox360Button.LeftShoulder, false);
        controller.SetButtonState(Xbox360Button.RightShoulder, false);
        controller.SetButtonState(Xbox360Button.LeftThumb, false);
        controller.SetButtonState(Xbox360Button.RightThumb, false);
        controller.SetButtonState(Xbox360Button.Start, false);
        controller.SetButtonState(Xbox360Button.Back, false);
        controller.SetButtonState(Xbox360Button.Up, false);
        controller.SetButtonState(Xbox360Button.Down, false);
        controller.SetButtonState(Xbox360Button.Left, false);
        controller.SetButtonState(Xbox360Button.Right, false);
        controller.SetSliderValue(Xbox360Slider.LeftTrigger, 0);
        controller.SetSliderValue(Xbox360Slider.RightTrigger, 0);
        controller.SetAxisValue(Xbox360Axis.LeftThumbX, 0);
        controller.SetAxisValue(Xbox360Axis.LeftThumbY, 0);
        controller.SetAxisValue(Xbox360Axis.RightThumbX, 0);
        controller.SetAxisValue(Xbox360Axis.RightThumbY, 0);
    }

    private bool waitUnpressControllerToggle = false;
    private bool waitUnpressKeyboardToggle = false;

    // the main loop where everything is going to happen
    void TimerLoop(object sender, EventArgs e)
    {
        // check if something changed on the hardware.
        // windows updates the controller ID on every input hardware change.
        // Need to find the fake controller ID
        if (TestControllerChange())
        {
            FindFakeController();
            ResetAllFakeControllerInputs();
        }

        // Since GTAV can only detect one controller, we are going to be responsable to take any controller input
        // and send it via the virtual controller.
        PassWindowsInputsToFakeController();

        // by default, the combo box is empty when you open the program, just to make sure nothing is going to break
        // or crash.
        if (comboBox1.SelectedItem != null && selectedKey > 0)
        {

            // if the keyboard key is selected, do the fake 99% left trigger press
            isPressingSelectedKey = (GetAsyncKeyState(selectedKey) & 0x8000) != 0;
            if (isPressingSelectedKey)
            {
                controller.SetSliderValue(Xbox360Slider.RightTrigger, 254);
            }
            else
            {
                controller.SetSliderValue(Xbox360Slider.RightTrigger, oldvalue_righttrigger);
            }
        }

        // Controller toggle.
        if (comboBox_ToggleKey != null && toggleSelectedKey > 0)
        {
            if ((GetAsyncKeyState(toggleSelectedKey) & 0x8000) != 0)
            {
                // We only need to do this function once. do everything bellow and wait for the key to be released.
                if (!waitUnpressControllerToggle)
                {
                    waitUnpressControllerToggle = true;

                    if (isControllerToggleEnabled)
                    {

                        isControllerToggleEnabled = false;
                        // Play sound if file is loaded.
                        if (soundToggleDeactivate.IsLoadCompleted && checkBox_PlaySoundsController.Checked)
                            try
                            {
                                soundToggleDeactivate.Play();
                            }
                            catch
                            {
                                MessageBox.Show("Something happened while trying to play the deactivate (off.wav) sound. maybe is not a valid .wav file");
                            }

                        label_togglestatus.Text = "Is Controller Right Trigger limited to 99%: NO";
                    }
                    else
                    {
                        // play sound if file is loaded.
                        if (soundToggleActivate.IsLoadCompleted && checkBox_PlaySoundsController.Checked)
                            try
                            {
                                soundToggleActivate.Play();
                            }
                            catch
                            {
                                MessageBox.Show("Something happened while trying to play the activate (on.wav) sound. maybe is not a valid .wav file");
                            }
                        isControllerToggleEnabled = true;
                        label_togglestatus.Text = "Is Controller Right Trigger limited to 99%: YES";
                    }
                }
            }
            else
            {
                //Key is not pressed, reset.
                waitUnpressControllerToggle = false;
            }
        }

        if (comboBox_ToggleKeyboard != null && toggleKeyboardSelectedKey > 0)
        {
            //Keyboard Toggle.
            if ((GetAsyncKeyState(toggleKeyboardSelectedKey) & 1) != 0)
            {
                // We only need to do this function once. do everything bellow and wait for the key to be released.
                if (!waitUnpressKeyboardToggle)
                {
                    waitUnpressKeyboardToggle = true;

                    if (isKeyboardToggleEnabled)
                    {

                        isKeyboardToggleEnabled = false;
                        // Play sound if file is loaded.
                        if (soundToggleDeactivate.IsLoadCompleted && checkBox_PlaySoundsKeyboard.Checked)
                        {
                            try
                            {
                                soundToggleDeactivate.Play();
                            }
                            catch
                            {
                                MessageBox.Show("Something happened while trying to play the deactivate (off.wav) sound. maybe is not a valid .wav file?");
                            }
                            label_IsKeyboardKeyDisabled.Text = "Is the selected keyboard key being blocked: NO";
                        }
                    }
                    else
                    {
                        isKeyboardToggleEnabled = true;
                        // play sound if file is loaded.
                        if (soundToggleActivate.IsLoadCompleted && checkBox_PlaySoundsKeyboard.Checked)
                        {
                            try
                            {
                                soundToggleActivate.Play();
                            }
                            catch
                            {
                                MessageBox.Show("Something happened while trying to play the activate (on.wav) sound. maybe is not a valid .wav file?");
                            }
                            label_IsKeyboardKeyDisabled.Text = "Is the selected keyboard key being blocked: YES";
                        }
                    }
                }
            }
            else
            {
                //Key is not pressed, reset.
                waitUnpressKeyboardToggle = false;
            }
        }

    }

    // Event Functions

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboBox1.SelectedItem == null)
        {
            return;
        }

        string selected = comboBox1.GetItemText(comboBox1.SelectedItem);
        selectedKey = VirtualKeys[selected];
    }

    private void comboBox_toggleKey_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboBox_ToggleKey.SelectedItem == null)
        {
            return;
        }

        string selected = comboBox_ToggleKey.GetItemText(comboBox_ToggleKey.SelectedItem);
        toggleSelectedKey = VirtualKeys[selected];
    }

    private void comboBox1_KeyDown(object sender, KeyEventArgs e)
    {
        //Need to surpress the key press to avoid issues of the dropbox changing selections.
        e.SuppressKeyPress = true;
        e.Handled = true;
    }

    private void comboBox_ToggleKey_KeyDown(object sender, KeyEventArgs e)
    {
        //Need to surpress the key press to avoid issues of the dropbox changing selections.
        e.SuppressKeyPress = true;
        e.Handled = true;
    }
    private void comboBox_ToggleKeyboard_KeyDown(object sender, KeyEventArgs e)
    {
        //Need to surpress the key press to avoid issues of the dropbox changing selections.
        e.SuppressKeyPress = true;
        e.Handled = true;
    }

    private void comboBox_ToggleKeyboard_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboBox_ToggleKeyboard.SelectedItem == null)
        {
            return;
        }

        string selected = comboBox_ToggleKeyboard.GetItemText(comboBox_ToggleKeyboard.SelectedItem);
        if (selected == "LBUTTON" || selected == "RBUTTON")
        {
            MessageBox.Show("The toggle keyboard key can not be this button, don't try to lock yourself from your computer.", "Anti dumb people warning");
            comboBox_ToggleKeyboard.SelectedIndex = 0;
            return;
        }
        toggleKeyboardSelectedKey = VirtualKeys[selected];
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
#if TRIGGERANTICHEAT || DEBUG
        UnhookWindowsHookEx(hookID);
#endif
        controller.Disconnect();
        base.OnFormClosing(e);
    }

    private void button_helpKeyboard_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Select a button from the dropdown.\r\nPressing the selected button will simulate a 99% pressed right controller trigger.\r\n\r\nIs not complicated.", "Help");
    }

    private void button_helpToggleKeyboard_Click(object sender, EventArgs e)
    {
#if TRIGGERANTICHEAT || DEBUG
        MessageBox.Show("You might want to use a key like *W* for the Keyboard Acceleration key, but doing so will cause issues because you will be sending two inputs to the game (W key from your keyboard and the Right Controller Trigger from the program)."
            +
            "\n\n\n" +
            "You can select a key from the dropdown menu to toggle between the 99% trigger and your normal keyboard key." +
            "\n\n\n" +
            "The program is going to block the Acceleration key from working when the toggle is active, allowing you to maybe use a key like *W* as 99% acceleration button without having issues of extra inputs." +
            "\n\n\n" +
            "The text bellow will say YES if the selected acceleration key is being blocked from working at the moment"
            , "Help");
#else
       MessageBox.Show("This option is only available on the Trigger Anti Cheat version of the program, because it needs to capture, interrupt and block the keyboard key input to work properly. if you are interested in this feature, consider downloading the Trigger Anti Cheat version.", "Help"); 
#endif
    }

    private void button_HelpController_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Select a button from the dropdown.\r\nPressing the selected button will toggle between normal controller Right Trigger behavior and 99% pressed Right Trigger."+
            "\n\n"+
            "For the program to work with controllers, windows need to set this program as player 1 / controller 0."+
            "\n\n"+
            "To do this, unplug any physical controller connected to your computer and restart the program. Once that is done, you can plug everything back again."
            , "Help");
    }
}
