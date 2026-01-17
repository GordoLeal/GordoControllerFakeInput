namespace GordoControllerFakeInput;

partial class GordoControllerFakeInput
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        comboBox1 = new ComboBox();
        SuspendLayout();
        // 
        // comboBox1
        // 
        comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox1.FormattingEnabled = true;
        comboBox1.Items.AddRange(new object[] { "LBUTTON", "RBUTTON", "MBUTTON", "XBUTTON1", "XBUTTON2", "BACKSPACE", "TAB", "ENTER", "SHIFT", "CTRL", "ALT", "PAUSE", "CAPS LOCK", "ESC", "SPACE", "PAGE UP", "PAGE DOWN", "END", "HOME", "LEFT", "UP", "RIGHT", "DOWN", "PRINT SCREEN", "INSERT", "DELETE", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "LEFT WINDOWS", "RIGHT WINDOWS", "APPLICATION", "NUMPAD0", "NUMPAD1", "NUMPAD2", "NUMPAD3", "NUMPAD4", "NUMPAD5", "NUMPAD6", "NUMPAD7", "NUMPAD8", "NUMPAD9", "MULTIPLY", "ADD", "SUBTRACT", "DECIMAL", "DIVIDE", "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "F12", "F13", "F14", "F15", "F16", "F17", "F18", "F19", "F20", "F21", "F22", "F23", "F24", "NUM LOCK", "SCROLL LOCK", "LEFT SHIFT", "RIGHT SHIFT", "LEFT CTRL", "RIGHT CTRL", "LEFT ALT", "RIGHT ALT", "VOLUME MUTE", "VOLUME DOWN", "VOLUME UP", "MEDIA NEXT", "MEDIA PREV", "MEDIA STOP", "MEDIA PLAY" });
        comboBox1.Location = new Point(12, 12);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new Size(121, 23);
        comboBox1.TabIndex = 0;
        comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        // 
        // GordoControllerFakeInput
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(169, 60);
        Controls.Add(comboBox1);
        MaximizeBox = false;
        Name = "GordoControllerFakeInput";
        ShowIcon = false;
        Text = "GordoControllerFakeInput";
        ResumeLayout(false);
    }

    #endregion

    private ComboBox comboBox1;
}
