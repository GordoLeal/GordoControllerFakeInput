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
        Label label2;
        Label label3;
        Label label1;
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GordoControllerFakeInput));
        comboBox_ToggleKey = new ComboBox();
        checkBox_PlaySoundsController = new CheckBox();
        label_togglestatus = new Label();
        groupBox2 = new GroupBox();
        button_HelpController = new Button();
        comboBox_ToggleKeyboard = new ComboBox();
        comboBox1 = new ComboBox();
        checkBox_PlaySoundsKeyboard = new CheckBox();
        label_IsKeyboardKeyDisabled = new Label();
        groupBox1 = new GroupBox();
        button_helpToggleKeyboard = new Button();
        button_helpKeyboard = new Button();
        label2 = new Label();
        label3 = new Label();
        label1 = new Label();
        groupBox2.SuspendLayout();
        groupBox1.SuspendLayout();
        SuspendLayout();
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(8, 30);
        label2.Name = "label2";
        label2.Size = new Size(233, 15);
        label2.TabIndex = 3;
        label2.Text = "Key to toggle Controller Right Trigger Limit";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(12, 102);
        label3.Name = "label3";
        label3.Size = new Size(279, 15);
        label3.TabIndex = 8;
        label3.Text = "Toggle to block 99% Acceleration Key from working";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(12, 30);
        label1.Name = "label1";
        label1.Size = new Size(202, 15);
        label1.TabIndex = 1;
        label1.Text = "Key to 99% Accelerate with Keyboard";
        // 
        // comboBox_ToggleKey
        // 
        comboBox_ToggleKey.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox_ToggleKey.FormattingEnabled = true;
        comboBox_ToggleKey.Items.AddRange(new object[] { "NONE", "LBUTTON", "RBUTTON", "MBUTTON", "XBUTTON1", "XBUTTON2", "BACKSPACE", "TAB", "ENTER", "SHIFT", "CTRL", "ALT", "PAUSE", "CAPS LOCK", "ESC", "SPACE", "PAGE UP", "PAGE DOWN", "END", "HOME", "LEFT", "UP", "RIGHT", "DOWN", "PRINT SCREEN", "INSERT", "DELETE", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "LEFT WINDOWS", "RIGHT WINDOWS", "APPLICATION", "NUMPAD0", "NUMPAD1", "NUMPAD2", "NUMPAD3", "NUMPAD4", "NUMPAD5", "NUMPAD6", "NUMPAD7", "NUMPAD8", "NUMPAD9", "MULTIPLY", "ADD", "SUBTRACT", "DECIMAL", "DIVIDE", "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "F12", "F13", "F14", "F15", "F16", "F17", "F18", "F19", "F20", "F21", "F22", "F23", "F24", "NUM LOCK", "SCROLL LOCK", "LEFT SHIFT", "RIGHT SHIFT", "LEFT CTRL", "RIGHT CTRL", "LEFT ALT", "RIGHT ALT", "VOLUME MUTE", "VOLUME DOWN", "VOLUME UP", "MEDIA NEXT", "MEDIA PREV", "MEDIA STOP", "MEDIA PLAY" });
        comboBox_ToggleKey.Location = new Point(8, 50);
        comboBox_ToggleKey.Name = "comboBox_ToggleKey";
        comboBox_ToggleKey.Size = new Size(143, 23);
        comboBox_ToggleKey.TabIndex = 2;
        comboBox_ToggleKey.TabStop = false;
        comboBox_ToggleKey.SelectedIndexChanged += comboBox_toggleKey_SelectedIndexChanged;
        comboBox_ToggleKey.KeyDown += comboBox_ToggleKey_KeyDown;
        // 
        // checkBox_PlaySoundsController
        // 
        checkBox_PlaySoundsController.AutoSize = true;
        checkBox_PlaySoundsController.Checked = true;
        checkBox_PlaySoundsController.CheckState = CheckState.Checked;
        checkBox_PlaySoundsController.Location = new Point(174, 52);
        checkBox_PlaySoundsController.Name = "checkBox_PlaySoundsController";
        checkBox_PlaySoundsController.Size = new Size(90, 19);
        checkBox_PlaySoundsController.TabIndex = 5;
        checkBox_PlaySoundsController.Text = "Play Sounds";
        checkBox_PlaySoundsController.UseVisualStyleBackColor = true;
        // 
        // label_togglestatus
        // 
        label_togglestatus.AutoSize = true;
        label_togglestatus.Location = new Point(8, 84);
        label_togglestatus.Name = "label_togglestatus";
        label_togglestatus.Size = new Size(244, 15);
        label_togglestatus.TabIndex = 4;
        label_togglestatus.Text = "Is Controller Right Trigger limited to 99%: NO";
        // 
        // groupBox2
        // 
        groupBox2.Controls.Add(button_HelpController);
        groupBox2.Controls.Add(checkBox_PlaySoundsController);
        groupBox2.Controls.Add(label2);
        groupBox2.Controls.Add(label_togglestatus);
        groupBox2.Controls.Add(comboBox_ToggleKey);
        groupBox2.Location = new Point(379, 11);
        groupBox2.Name = "groupBox2";
        groupBox2.Size = new Size(310, 119);
        groupBox2.TabIndex = 11;
        groupBox2.TabStop = false;
        groupBox2.Text = "For Controllers";
        // 
        // button_HelpController
        // 
        button_HelpController.Location = new Point(270, 48);
        button_HelpController.Name = "button_HelpController";
        button_HelpController.Size = new Size(26, 23);
        button_HelpController.TabIndex = 6;
        button_HelpController.Text = "?";
        button_HelpController.UseVisualStyleBackColor = true;
        button_HelpController.Click += button_HelpController_Click;
        // 
        // comboBox_ToggleKeyboard
        // 
        comboBox_ToggleKeyboard.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox_ToggleKeyboard.FormattingEnabled = true;
        comboBox_ToggleKeyboard.Items.AddRange(new object[] { "NONE", "LBUTTON", "RBUTTON", "MBUTTON", "XBUTTON1", "XBUTTON2", "BACKSPACE", "TAB", "ENTER", "SHIFT", "CTRL", "ALT", "PAUSE", "CAPS LOCK", "ESC", "SPACE", "PAGE UP", "PAGE DOWN", "END", "HOME", "LEFT", "UP", "RIGHT", "DOWN", "PRINT SCREEN", "INSERT", "DELETE", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "LEFT WINDOWS", "RIGHT WINDOWS", "APPLICATION", "NUMPAD0", "NUMPAD1", "NUMPAD2", "NUMPAD3", "NUMPAD4", "NUMPAD5", "NUMPAD6", "NUMPAD7", "NUMPAD8", "NUMPAD9", "MULTIPLY", "ADD", "SUBTRACT", "DECIMAL", "DIVIDE", "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "F12", "F13", "F14", "F15", "F16", "F17", "F18", "F19", "F20", "F21", "F22", "F23", "F24", "NUM LOCK", "SCROLL LOCK", "LEFT SHIFT", "RIGHT SHIFT", "LEFT CTRL", "RIGHT CTRL", "LEFT ALT", "RIGHT ALT", "VOLUME MUTE", "VOLUME DOWN", "VOLUME UP", "MEDIA NEXT", "MEDIA PREV", "MEDIA STOP", "MEDIA PLAY" });
        comboBox_ToggleKeyboard.Location = new Point(12, 122);
        comboBox_ToggleKeyboard.Name = "comboBox_ToggleKeyboard";
        comboBox_ToggleKeyboard.Size = new Size(143, 23);
        comboBox_ToggleKeyboard.TabIndex = 6;
        comboBox_ToggleKeyboard.TabStop = false;
        comboBox_ToggleKeyboard.SelectedIndexChanged += comboBox_ToggleKeyboard_SelectedIndexChanged;
        comboBox_ToggleKeyboard.KeyDown += comboBox_ToggleKeyboard_KeyDown;
        // 
        // comboBox1
        // 
        comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox1.FormattingEnabled = true;
        comboBox1.Items.AddRange(new object[] { "NONE", "LBUTTON", "RBUTTON", "MBUTTON", "XBUTTON1", "XBUTTON2", "BACKSPACE", "TAB", "ENTER", "SHIFT", "CTRL", "ALT", "PAUSE", "CAPS LOCK", "ESC", "SPACE", "PAGE UP", "PAGE DOWN", "END", "HOME", "LEFT", "UP", "RIGHT", "DOWN", "PRINT SCREEN", "INSERT", "DELETE", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "LEFT WINDOWS", "RIGHT WINDOWS", "APPLICATION", "NUMPAD0", "NUMPAD1", "NUMPAD2", "NUMPAD3", "NUMPAD4", "NUMPAD5", "NUMPAD6", "NUMPAD7", "NUMPAD8", "NUMPAD9", "MULTIPLY", "ADD", "SUBTRACT", "DECIMAL", "DIVIDE", "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "F12", "F13", "F14", "F15", "F16", "F17", "F18", "F19", "F20", "F21", "F22", "F23", "F24", "NUM LOCK", "SCROLL LOCK", "LEFT SHIFT", "RIGHT SHIFT", "LEFT CTRL", "RIGHT CTRL", "LEFT ALT", "RIGHT ALT", "VOLUME MUTE", "VOLUME DOWN", "VOLUME UP", "MEDIA NEXT", "MEDIA PREV", "MEDIA STOP", "MEDIA PLAY" });
        comboBox1.Location = new Point(12, 52);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new Size(143, 23);
        comboBox1.TabIndex = 0;
        comboBox1.TabStop = false;
        comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        comboBox1.KeyDown += comboBox1_KeyDown;
        // 
        // checkBox_PlaySoundsKeyboard
        // 
        checkBox_PlaySoundsKeyboard.AutoSize = true;
        checkBox_PlaySoundsKeyboard.Checked = true;
        checkBox_PlaySoundsKeyboard.CheckState = CheckState.Checked;
        checkBox_PlaySoundsKeyboard.Location = new Point(172, 122);
        checkBox_PlaySoundsKeyboard.Name = "checkBox_PlaySoundsKeyboard";
        checkBox_PlaySoundsKeyboard.Size = new Size(90, 19);
        checkBox_PlaySoundsKeyboard.TabIndex = 7;
        checkBox_PlaySoundsKeyboard.Text = "Play Sounds";
        checkBox_PlaySoundsKeyboard.UseVisualStyleBackColor = true;
        // 
        // label_IsKeyboardKeyDisabled
        // 
        label_IsKeyboardKeyDisabled.AutoSize = true;
        label_IsKeyboardKeyDisabled.Location = new Point(12, 146);
        label_IsKeyboardKeyDisabled.Name = "label_IsKeyboardKeyDisabled";
        label_IsKeyboardKeyDisabled.Size = new Size(281, 15);
        label_IsKeyboardKeyDisabled.TabIndex = 9;
        label_IsKeyboardKeyDisabled.Text = "Is Keyboard key being overwrite by the 99% key: YES";
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(button_helpToggleKeyboard);
        groupBox1.Controls.Add(button_helpKeyboard);
        groupBox1.Controls.Add(label1);
        groupBox1.Controls.Add(label_IsKeyboardKeyDisabled);
        groupBox1.Controls.Add(comboBox1);
        groupBox1.Controls.Add(checkBox_PlaySoundsKeyboard);
        groupBox1.Controls.Add(label3);
        groupBox1.Controls.Add(comboBox_ToggleKeyboard);
        groupBox1.Location = new Point(9, 11);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(364, 194);
        groupBox1.TabIndex = 12;
        groupBox1.TabStop = false;
        groupBox1.Text = "Keyboard";
        // 
        // button_helpToggleKeyboard
        // 
        button_helpToggleKeyboard.Location = new Point(282, 122);
        button_helpToggleKeyboard.Name = "button_helpToggleKeyboard";
        button_helpToggleKeyboard.Size = new Size(25, 23);
        button_helpToggleKeyboard.TabIndex = 11;
        button_helpToggleKeyboard.Text = "?";
        button_helpToggleKeyboard.UseVisualStyleBackColor = true;
        button_helpToggleKeyboard.Click += button_helpToggleKeyboard_Click;
        // 
        // button_helpKeyboard
        // 
        button_helpKeyboard.Location = new Point(172, 52);
        button_helpKeyboard.Name = "button_helpKeyboard";
        button_helpKeyboard.Size = new Size(27, 23);
        button_helpKeyboard.TabIndex = 10;
        button_helpKeyboard.Text = "?";
        button_helpKeyboard.UseVisualStyleBackColor = true;
        button_helpKeyboard.Click += button_helpKeyboard_Click;
        // 
        // GordoControllerFakeInput
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(698, 218);
        Controls.Add(groupBox2);
        Controls.Add(groupBox1);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximizeBox = false;
        Name = "GordoControllerFakeInput";
        Text = "Gordo's Fake 99 Input";
        groupBox2.ResumeLayout(false);
        groupBox2.PerformLayout();
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        ResumeLayout(false);
    }

    #endregion
    private ComboBox comboBox_ToggleKey;
    private CheckBox checkBox_PlaySoundsController;
    private Label label_togglestatus;
    private GroupBox groupBox2;
    private ComboBox comboBox_ToggleKeyboard;
    private ComboBox comboBox1;
    private CheckBox checkBox_PlaySoundsKeyboard;
    private Label label_IsKeyboardKeyDisabled;
    private GroupBox groupBox1;
    private ToolTip toolTip1;
    private Button button_helpKeyboard;
    private Button button_helpToggleKeyboard;
    private Button button_HelpController;
}
