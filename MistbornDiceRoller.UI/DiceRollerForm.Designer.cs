﻿// <auto-generated/>
namespace MistbornDiceRoller.UI
{
    partial class DiceRollerForm
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
            this.txtDiceCount = new System.Windows.Forms.TextBox();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.lblDiceNumber = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.lblNudges = new System.Windows.Forms.Label();
            this.txtNudges = new System.Windows.Forms.TextBox();
            this.btnRoll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtDiceCount
            // 
            this.txtDiceCount.Location = new System.Drawing.Point(15, 63);
            this.txtDiceCount.Name = "txtDiceCount";
            this.txtDiceCount.Size = new System.Drawing.Size(40, 20);
            this.txtDiceCount.TabIndex = 0;
            this.txtDiceCount.Text = "6";
            this.txtDiceCount.TextChanged += new System.EventHandler(this.TxtDiceCount_TextChanged);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(15, 31);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(40, 23);
            this.btnUp.TabIndex = 1;
            this.btnUp.Text = "↑";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.BtnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(15, 90);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(40, 23);
            this.btnDown.TabIndex = 2;
            this.btnDown.Text = "↓";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.BtnDown_Click);
            // 
            // lblDiceNumber
            // 
            this.lblDiceNumber.AutoSize = true;
            this.lblDiceNumber.Location = new System.Drawing.Point(12, 15);
            this.lblDiceNumber.Name = "lblDiceNumber";
            this.lblDiceNumber.Size = new System.Drawing.Size(84, 13);
            this.lblDiceNumber.TabIndex = 3;
            this.lblDiceNumber.Text = "Number of Dice:";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(134, 15);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(40, 13);
            this.lblResult.TabIndex = 4;
            this.lblResult.Text = "Result:";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(137, 33);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(56, 20);
            this.txtResult.TabIndex = 5;
            // 
            // lblNudges
            // 
            this.lblNudges.AutoSize = true;
            this.lblNudges.Location = new System.Drawing.Point(134, 66);
            this.lblNudges.Name = "lblNudges";
            this.lblNudges.Size = new System.Drawing.Size(47, 13);
            this.lblNudges.TabIndex = 6;
            this.lblNudges.Text = "Nudges:";
            // 
            // txtNudges
            // 
            this.txtNudges.Location = new System.Drawing.Point(137, 92);
            this.txtNudges.Name = "txtNudges";
            this.txtNudges.Size = new System.Drawing.Size(56, 20);
            this.txtNudges.TabIndex = 7;
            // 
            // btnRoll
            // 
            this.btnRoll.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoll.Location = new System.Drawing.Point(24, 149);
            this.btnRoll.Name = "btnRoll";
            this.btnRoll.Size = new System.Drawing.Size(169, 52);
            this.btnRoll.TabIndex = 8;
            this.btnRoll.Text = "Roll";
            this.btnRoll.UseVisualStyleBackColor = true;
            this.btnRoll.Click += new System.EventHandler(this.BtnRoll_Click);
            // 
            // DiceRollerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnRoll);
            this.Controls.Add(this.txtNudges);
            this.Controls.Add(this.lblNudges);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblDiceNumber);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.txtDiceCount);
            this.Name = "DiceRollerForm";
            this.Text = "Mistborn Dice Roller";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDiceCount;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Label lblDiceNumber;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label lblNudges;
        private System.Windows.Forms.TextBox txtNudges;
        private System.Windows.Forms.Button btnRoll;
    }
}

