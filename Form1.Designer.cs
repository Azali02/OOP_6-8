namespace oop4_1
{
    partial class Form1
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
            btn_Delete = new Button();
            chb_Ctrl = new CheckBox();
            chb_flag = new CheckBox();
            pictureBox1 = new PictureBox();
            rbTriangle = new RadioButton();
            rbSquare = new RadioButton();
            rbCircle = new RadioButton();
            cbColor = new ComboBox();
            btn_notSelection = new Button();
            button_dlt = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btn_Delete
            // 
            btn_Delete.Location = new Point(287, 12);
            btn_Delete.Name = "btn_Delete";
            btn_Delete.Size = new Size(94, 52);
            btn_Delete.TabIndex = 0;
            btn_Delete.Text = "Очистить форму";
            btn_Delete.UseVisualStyleBackColor = true;
            btn_Delete.Click += button1_Click;
            // 
            // chb_Ctrl
            // 
            chb_Ctrl.AutoSize = true;
            chb_Ctrl.Location = new Point(12, 40);
            chb_Ctrl.Name = "chb_Ctrl";
            chb_Ctrl.Size = new Size(64, 24);
            chb_Ctrl.TabIndex = 1;
            chb_Ctrl.Text = "CTRL";
            chb_Ctrl.UseVisualStyleBackColor = true;
            // 
            // chb_flag
            // 
            chb_flag.AutoSize = true;
            chb_flag.Location = new Point(12, 70);
            chb_flag.Name = "chb_flag";
            chb_flag.Size = new Size(369, 24);
            chb_flag.TabIndex = 2;
            chb_flag.Text = "Выделять несколько объектов при пересечении";
            chb_flag.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.NavajoWhite;
            pictureBox1.Location = new Point(12, 102);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(760, 340);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += pictureBox1_Paint;
            pictureBox1.MouseClick += pictureBox1_MouseClick;
            // 
            // rbTriangle
            // 
            rbTriangle.AutoSize = true;
            rbTriangle.Location = new Point(544, 72);
            rbTriangle.Name = "rbTriangle";
            rbTriangle.Size = new Size(83, 24);
            rbTriangle.TabIndex = 4;
            rbTriangle.Text = "Triangle";
            rbTriangle.UseVisualStyleBackColor = true;
            rbTriangle.CheckedChanged += rbTriangle_CheckedChanged;
            // 
            // rbSquare
            // 
            rbSquare.AutoSize = true;
            rbSquare.Location = new Point(544, 42);
            rbSquare.Name = "rbSquare";
            rbSquare.Size = new Size(76, 24);
            rbSquare.TabIndex = 5;
            rbSquare.Text = "Square";
            rbSquare.UseVisualStyleBackColor = true;
            rbSquare.CheckedChanged += rbSquare_CheckedChanged;
            // 
            // rbCircle
            // 
            rbCircle.AutoSize = true;
            rbCircle.Checked = true;
            rbCircle.Location = new Point(544, 12);
            rbCircle.Name = "rbCircle";
            rbCircle.Size = new Size(67, 24);
            rbCircle.TabIndex = 6;
            rbCircle.TabStop = true;
            rbCircle.Text = "Circle";
            rbCircle.UseVisualStyleBackColor = true;
            rbCircle.CheckedChanged += rbCircle_CheckedChanged;
            // 
            // cbColor
            // 
            cbColor.BackColor = Color.AntiqueWhite;
            cbColor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbColor.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            cbColor.FormattingEnabled = true;
            cbColor.Items.AddRange(new object[] { "Black", "Blue", "Green", "Yellow", "Red" });
            cbColor.Location = new Point(387, 12);
            cbColor.Name = "cbColor";
            cbColor.Size = new Size(94, 33);
            cbColor.TabIndex = 7;
            cbColor.SelectedIndexChanged += cbColor_SelectedIndexChanged;
            cbColor.MouseEnter += cbColor_MouseEnter;
            // 
            // btn_notSelection
            // 
            btn_notSelection.Location = new Point(187, 12);
            btn_notSelection.Name = "btn_notSelection";
            btn_notSelection.Size = new Size(94, 52);
            btn_notSelection.TabIndex = 8;
            btn_notSelection.Text = "Убрать выделение";
            btn_notSelection.UseVisualStyleBackColor = true;
            btn_notSelection.Click += btn_notSelection_Click;
            // 
            // button_dlt
            // 
            button_dlt.Location = new Point(87, 12);
            button_dlt.Name = "button_dlt";
            button_dlt.Size = new Size(94, 54);
            button_dlt.TabIndex = 9;
            button_dlt.Text = "Удалить";
            button_dlt.UseVisualStyleBackColor = true;
            button_dlt.Click += button_dlt_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AntiqueWhite;
            ClientSize = new Size(782, 453);
            Controls.Add(button_dlt);
            Controls.Add(btn_notSelection);
            Controls.Add(cbColor);
            Controls.Add(rbCircle);
            Controls.Add(rbSquare);
            Controls.Add(rbTriangle);
            Controls.Add(pictureBox1);
            Controls.Add(chb_flag);
            Controls.Add(chb_Ctrl);
            Controls.Add(btn_Delete);
            KeyPreview = true;
            Name = "Form1";
            Text = "OOP 6";
            SizeChanged += Form1_SizeChanged;
            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Delete;
        private CheckBox chb_Ctrl;
        private CheckBox chb_flag;
        private PictureBox pictureBox1;
        private RadioButton rbTriangle;
        private RadioButton rbSquare;
        private RadioButton rbCircle;
        private ComboBox cbColor;
        private Button btn_notSelection;
        private Button button_dlt;
    }
}