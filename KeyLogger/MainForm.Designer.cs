﻿namespace KeyLogger
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
<<<<<<< HEAD
            this.components = new System.ComponentModel.Container();
            this.lblKeyClickCount = new System.Windows.Forms.Label();
=======
            this.label1 = new System.Windows.Forms.Label();
>>>>>>> de3253b... Refactoring source code
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.txtBxKeyClick = new System.Windows.Forms.TextBox();
            this.txtBxMouseClick = new System.Windows.Forms.TextBox();
<<<<<<< HEAD
            this.lblMouseClickCount = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtBxTotalClickCounter = new System.Windows.Forms.TextBox();
            this.lblTotalClickCount = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblQuestionNo = new System.Windows.Forms.Label();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblKeyClickCount
            // 
            this.lblKeyClickCount.AutoSize = true;
            this.lblKeyClickCount.Location = new System.Drawing.Point(157, 249);
            this.lblKeyClickCount.Name = "lblKeyClickCount";
            this.lblKeyClickCount.Size = new System.Drawing.Size(82, 13);
            this.lblKeyClickCount.TabIndex = 0;
            this.lblKeyClickCount.Text = "Key Click Count";
=======
            this.label2 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtBxTotalClickCounter = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Key Click Count";
>>>>>>> de3253b... Refactoring source code
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(105, 35);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start Inspection";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(195, 35);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(77, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop Inspection";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // txtBxKeyClick
            // 
<<<<<<< HEAD
            this.txtBxKeyClick.Location = new System.Drawing.Point(267, 246);
=======
            this.txtBxKeyClick.Location = new System.Drawing.Point(151, 99);
>>>>>>> de3253b... Refactoring source code
            this.txtBxKeyClick.Name = "txtBxKeyClick";
            this.txtBxKeyClick.ReadOnly = true;
            this.txtBxKeyClick.Size = new System.Drawing.Size(67, 20);
            this.txtBxKeyClick.TabIndex = 3;
            // 
            // txtBxMouseClick
            // 
<<<<<<< HEAD
            this.txtBxMouseClick.Location = new System.Drawing.Point(267, 279);
=======
            this.txtBxMouseClick.Location = new System.Drawing.Point(151, 132);
>>>>>>> de3253b... Refactoring source code
            this.txtBxMouseClick.Name = "txtBxMouseClick";
            this.txtBxMouseClick.ReadOnly = true;
            this.txtBxMouseClick.Size = new System.Drawing.Size(67, 20);
            this.txtBxMouseClick.TabIndex = 5;
            // 
<<<<<<< HEAD
            // lblMouseClickCount
            // 
            this.lblMouseClickCount.AutoSize = true;
            this.lblMouseClickCount.Location = new System.Drawing.Point(157, 282);
            this.lblMouseClickCount.Name = "lblMouseClickCount";
            this.lblMouseClickCount.Size = new System.Drawing.Size(96, 13);
            this.lblMouseClickCount.TabIndex = 4;
            this.lblMouseClickCount.Text = "Mouse Click Count";
=======
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mouse Click Count";
>>>>>>> de3253b... Refactoring source code
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(12, 35);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtBxTotalClickCounter
            // 
<<<<<<< HEAD
            this.txtBxTotalClickCounter.Location = new System.Drawing.Point(267, 309);
=======
            this.txtBxTotalClickCounter.Location = new System.Drawing.Point(151, 162);
>>>>>>> de3253b... Refactoring source code
            this.txtBxTotalClickCounter.Name = "txtBxTotalClickCounter";
            this.txtBxTotalClickCounter.ReadOnly = true;
            this.txtBxTotalClickCounter.Size = new System.Drawing.Size(67, 20);
            this.txtBxTotalClickCounter.TabIndex = 8;
<<<<<<< HEAD
            // 
            // lblTotalClickCount
            // 
            this.lblTotalClickCount.AutoSize = true;
            this.lblTotalClickCount.Location = new System.Drawing.Point(157, 312);
            this.lblTotalClickCount.Name = "lblTotalClickCount";
            this.lblTotalClickCount.Size = new System.Drawing.Size(88, 13);
            this.lblTotalClickCount.TabIndex = 7;
            this.lblTotalClickCount.Text = "Total Click Count";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 315);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "Status:";
            // 
            // lblQuestionNo
            // 
            this.lblQuestionNo.AutoSize = true;
            this.lblQuestionNo.Location = new System.Drawing.Point(52, 99);
            this.lblQuestionNo.Name = "lblQuestionNo";
            this.lblQuestionNo.Size = new System.Drawing.Size(49, 13);
            this.lblQuestionNo.TabIndex = 10;
            this.lblQuestionNo.Text = "Question";
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Location = new System.Drawing.Point(105, 125);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(49, 13);
            this.lblQuestion.TabIndex = 11;
            this.lblQuestion.Text = "Question";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(241, 187);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 12;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 337);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.lblQuestionNo);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtBxTotalClickCounter);
            this.Controls.Add(this.lblTotalClickCount);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.txtBxMouseClick);
            this.Controls.Add(this.lblMouseClickCount);
            this.Controls.Add(this.txtBxKeyClick);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblKeyClickCount);
            this.Name = "MainForm";
            this.Text = "Questions";
=======
            this.txtBxTotalClickCounter.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Total Click Count";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.txtBxTotalClickCounter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.txtBxMouseClick);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBxKeyClick);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "KeyLogger";
>>>>>>> de3253b... Refactoring source code
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

<<<<<<< HEAD
        private System.Windows.Forms.Label lblKeyClickCount;
=======
        private System.Windows.Forms.Label label1;
>>>>>>> de3253b... Refactoring source code
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox txtBxKeyClick;
        private System.Windows.Forms.TextBox txtBxMouseClick;
<<<<<<< HEAD
        private System.Windows.Forms.Label lblMouseClickCount;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtBxTotalClickCounter;
        private System.Windows.Forms.Label lblTotalClickCount;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblQuestionNo;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Timer timer;
=======
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtBxTotalClickCounter;
        private System.Windows.Forms.Label label3;
>>>>>>> de3253b... Refactoring source code
    }
}

