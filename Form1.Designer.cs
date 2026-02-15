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
        Label label1;
        Label label2;
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GordoControllerFakeInput));
        comboBox1 = new ComboBox();
        comboBox_ToggleKey = new ComboBox();
        label_togglestatus = new Label();
        label1 = new Label();
        label2 = new Label();
        SuspendLayout();
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(12, 14);
        label1.Name = "label1";
        label1.Size = new Size(104, 15);
        label1.TabIndex = 1;
        label1.Text = "99% Keyboard Key";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(12, 67);
        label2.Name = "label2";
        label2.Size = new Size(143, 15);
        label2.TabIndex = 3;
        label2.Text = "Toggle Key for Controllers";
        // 
        // comboBox1
        // 
        comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox1.FormattingEnabled = true;
        comboBox1.Items.AddRange(new object[] { "NONE", "LBUTTON", "RBUTTON", "MBUTTON", "XBUTTON1", "XBUTTON2", "BACKSPACE", "TAB", "ENTER", "SHIFT", "CTRL", "ALT", "PAUSE", "CAPS LOCK", "ESC", "SPACE", "PAGE UP", "PAGE DOWN", "END", "HOME", "LEFT", "UP", "RIGHT", "DOWN", "PRINT SCREEN", "INSERT", "DELETE", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "LEFT WINDOWS", "RIGHT WINDOWS", "APPLICATION", "NUMPAD0", "NUMPAD1", "NUMPAD2", "NUMPAD3", "NUMPAD4", "NUMPAD5", "NUMPAD6", "NUMPAD7", "NUMPAD8", "NUMPAD9", "MULTIPLY", "ADD", "SUBTRACT", "DECIMAL", "DIVIDE", "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "F12", "F13", "F14", "F15", "F16", "F17", "F18", "F19", "F20", "F21", "F22", "F23", "F24", "NUM LOCK", "SCROLL LOCK", "LEFT SHIFT", "RIGHT SHIFT", "LEFT CTRL", "RIGHT CTRL", "LEFT ALT", "RIGHT ALT", "VOLUME MUTE", "VOLUME DOWN", "VOLUME UP", "MEDIA NEXT", "MEDIA PREV", "MEDIA STOP", "MEDIA PLAY" });
        comboBox1.Location = new Point(12, 32);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new Size(143, 23);
        comboBox1.TabIndex = 0;
        comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        // 
        // comboBox_ToggleKey
        // 
        comboBox_ToggleKey.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox_ToggleKey.FormattingEnabled = true;
        comboBox_ToggleKey.Items.AddRange(new object[] { "NONE", "LBUTTON", "RBUTTON", "MBUTTON", "XBUTTON1", "XBUTTON2", "BACKSPACE", "TAB", "ENTER", "SHIFT", "CTRL", "ALT", "PAUSE", "CAPS LOCK", "ESC", "SPACE", "PAGE UP", "PAGE DOWN", "END", "HOME", "LEFT", "UP", "RIGHT", "DOWN", "PRINT SCREEN", "INSERT", "DELETE", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "LEFT WINDOWS", "RIGHT WINDOWS", "APPLICATION", "NUMPAD0", "NUMPAD1", "NUMPAD2", "NUMPAD3", "NUMPAD4", "NUMPAD5", "NUMPAD6", "NUMPAD7", "NUMPAD8", "NUMPAD9", "MULTIPLY", "ADD", "SUBTRACT", "DECIMAL", "DIVIDE", "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "F12", "F13", "F14", "F15", "F16", "F17", "F18", "F19", "F20", "F21", "F22", "F23", "F24", "NUM LOCK", "SCROLL LOCK", "LEFT SHIFT", "RIGHT SHIFT", "LEFT CTRL", "RIGHT CTRL", "LEFT ALT", "RIGHT ALT", "VOLUME MUTE", "VOLUME DOWN", "VOLUME UP", "MEDIA NEXT", "MEDIA PREV", "MEDIA STOP", "MEDIA PLAY" });
        comboBox_ToggleKey.Location = new Point(12, 85);
        comboBox_ToggleKey.Name = "comboBox_ToggleKey";
        comboBox_ToggleKey.Size = new Size(143, 23);
        comboBox_ToggleKey.TabIndex = 2;
        comboBox_ToggleKey.SelectedIndexChanged += comboBox_toggleKey_SelectedIndexChanged;
        // 
        // label_togglestatus
        // 
        label_togglestatus.AutoSize = true;
        label_togglestatus.Location = new Point(12, 111);
        label_togglestatus.Name = "label_togglestatus";
        label_togglestatus.Size = new Size(179, 15);
        label_togglestatus.TabIndex = 4;
        label_togglestatus.Text = "Limit Controller trigger: Disabled";
        // 
        // GordoControllerFakeInput
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(277, 139);
        Controls.Add(label_togglestatus);
        Controls.Add(label2);
        Controls.Add(comboBox_ToggleKey);
        Controls.Add(label1);
        Controls.Add(comboBox1);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximizeBox = false;
        Name = "GordoControllerFakeInput";
        Text = "Gordo's Fake 99 Input";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private ComboBox comboBox1;
    private ComboBox comboBox_ToggleKey;
    private Label label_togglestatus;
}
