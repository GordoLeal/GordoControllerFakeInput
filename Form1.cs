using Nefarius.ViGEm.Client;
using Nefarius.ViGEm.Client.Targets.Xbox360;
using System;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.JavaScript;

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
    Dictionary<String, int> VirtualKeys = new Dictionary<string, int>()
    {
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

    private int selectedKey = -1;

    System.Windows.Forms.Timer looptimer = new();
    Nefarius.ViGEm.Client.Targets.IXbox360Controller controller;
    private int FakeControllerID = -1;
    private bool[] ControllersConected = new bool[4];
    private byte oldvalue_lefttrigger = 0;
    private byte oldvalue_righttrigger = 0;
    public GordoControllerFakeInput()
    {
        InitializeComponent();

        var client = new ViGEmClient();
        controller = client.CreateXbox360Controller();
        controller.Connect();


        looptimer.Interval = 4;
        looptimer.Tick += TimerLoop;
        looptimer.Start();
    }
    private void WindowsGamepadInputs()
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
                    controller.SetSliderValue(Xbox360Slider.RightTrigger, c.Gamepad.bRightTrigger);
                }
            }
        }
    }

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
    private void FindFakeController()
    {
        controller.SetSliderValue(Xbox360Slider.LeftTrigger, 3);
        for (int i = 0; i < 4; i++)
        {
            if (XInputGetState(i, out XINPUT_STATE c) == 0)
            {
                if (c.Gamepad.bLeftTrigger == 3)
                {
                    FakeControllerID = i;
                    break;
                }
            }
        }
        controller.SetSliderValue(Xbox360Slider.LeftTrigger, oldvalue_lefttrigger);
    }
    GamepadButtons oldflags;
    private void FlagExistsSetButtonState(GamepadButtons flags, GamepadButtons which)
    {
        if (flags.HasFlag(which) != oldflags.HasFlag(which))
        {
            controller.SetButtonState(ConvertFlagIntoXboxButton(which), flags.HasFlag(which));
        }
    }

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
    void TimerLoop(object sender, EventArgs e)
    {
        if (comboBox1.SelectedItem == null)
        {
            return;
        }

        if (TestControllerChange())
        {
            FindFakeController();
        }

        WindowsGamepadInputs();
        bool xPressed = (GetAsyncKeyState(selectedKey) & 0x8000) != 0;

        if (xPressed)
        {
            controller.SetSliderValue(Xbox360Slider.RightTrigger, 254);
        }
        else
        {
            controller.SetSliderValue(Xbox360Slider.RightTrigger, oldvalue_righttrigger);
        }
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboBox1.SelectedItem == null)
        {
            return;
        }

        string selected = comboBox1.GetItemText(comboBox1.SelectedItem);
        selectedKey = VirtualKeys[selected];
        //bool pressed = (GetAsyncKeyState(selectedKey) & 0x8000) != 0;
    }
}
