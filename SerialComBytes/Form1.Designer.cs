﻿using System.IO.Ports;

//INSTANT C# NOTE: Formerly VB project-level imports:
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;

namespace SerialComBytes
{
	[Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
	public partial class Form1 : System.Windows.Forms.Form
	{
		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && components != null)
				{
					components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;

		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.  
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.lstPorts = new System.Windows.Forms.ComboBox();
            this.lstBauds = new System.Windows.Forms.ComboBox();
            this.comStatusLabel = new System.Windows.Forms.Label();
            this.openPortBut = new System.Windows.Forms.Button();
            this.clrMsgBoxBut = new System.Windows.Forms.Button();
            this.portCntLabel = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.nocrc_RdBut = new System.Windows.Forms.RadioButton();
            this.crc_RdBut = new System.Windows.Forms.RadioButton();
            this.lrc_RdBut = new System.Windows.Forms.RadioButton();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.sndTxMsgBut = new System.Windows.Forms.Button();
            this.allMsgBox = new System.Windows.Forms.TextBox();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.txMsgBox = new System.Windows.Forms.TextBox();
            this.myComPort = new System.IO.Ports.SerialPort(this.components);
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.outputDataGrid = new System.Windows.Forms.DataGridView();
            this.componentDataGrid = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadComponentListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveOutputDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outputDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.componentDataGrid)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(14, 31);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(53, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Com Port:";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(14, 54);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(40, 13);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Bauds:";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(14, 77);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(62, 13);
            this.Label3.TabIndex = 2;
            this.Label3.Text = "Port Status:";
            // 
            // lstPorts
            // 
            this.lstPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstPorts.FormattingEnabled = true;
            this.lstPorts.Location = new System.Drawing.Point(77, 28);
            this.lstPorts.Name = "lstPorts";
            this.lstPorts.Size = new System.Drawing.Size(89, 21);
            this.lstPorts.TabIndex = 3;
            this.lstPorts.SelectionChangeCommitted += new System.EventHandler(this.portChgEvent);
            // 
            // lstBauds
            // 
            this.lstBauds.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBauds.FormattingEnabled = true;
            this.lstBauds.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "28800",
            "38400",
            "57600",
            "115200"});
            this.lstBauds.Location = new System.Drawing.Point(77, 51);
            this.lstBauds.Name = "lstBauds";
            this.lstBauds.Size = new System.Drawing.Size(89, 21);
            this.lstBauds.TabIndex = 4;
            this.lstBauds.SelectionChangeCommitted += new System.EventHandler(this.baudChgEvent);
            // 
            // comStatusLabel
            // 
            this.comStatusLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.comStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comStatusLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.comStatusLabel.Location = new System.Drawing.Point(77, 77);
            this.comStatusLabel.Name = "comStatusLabel";
            this.comStatusLabel.Size = new System.Drawing.Size(89, 17);
            this.comStatusLabel.TabIndex = 5;
            this.comStatusLabel.Text = "Not Connected";
            // 
            // openPortBut
            // 
            this.openPortBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openPortBut.Location = new System.Drawing.Point(17, 101);
            this.openPortBut.Name = "openPortBut";
            this.openPortBut.Size = new System.Drawing.Size(70, 40);
            this.openPortBut.TabIndex = 6;
            this.openPortBut.Text = "Open Com Port";
            this.openPortBut.UseVisualStyleBackColor = true;
            this.openPortBut.Click += new System.EventHandler(this.openPortBut_Click);
            // 
            // clrMsgBoxBut
            // 
            this.clrMsgBoxBut.Enabled = false;
            this.clrMsgBoxBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clrMsgBoxBut.Location = new System.Drawing.Point(96, 101);
            this.clrMsgBoxBut.Name = "clrMsgBoxBut";
            this.clrMsgBoxBut.Size = new System.Drawing.Size(70, 40);
            this.clrMsgBoxBut.TabIndex = 7;
            this.clrMsgBoxBut.Text = "Clear Msg Box";
            this.clrMsgBoxBut.UseVisualStyleBackColor = true;
            this.clrMsgBoxBut.Click += new System.EventHandler(this.clrMsgBoxBut_Click);
            // 
            // portCntLabel
            // 
            this.portCntLabel.AutoSize = true;
            this.portCntLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portCntLabel.Location = new System.Drawing.Point(14, 151);
            this.portCntLabel.Name = "portCntLabel";
            this.portCntLabel.Size = new System.Drawing.Size(121, 13);
            this.portCntLabel.TabIndex = 8;
            this.portCntLabel.Text = "Available Port Count = 0";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.comStatusLabel);
            this.GroupBox1.Controls.Add(this.portCntLabel);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.clrMsgBoxBut);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.openPortBut);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.lstPorts);
            this.GroupBox1.Controls.Add(this.lstBauds);
            this.GroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.ForeColor = System.Drawing.SystemColors.MenuText;
            this.GroupBox1.Location = new System.Drawing.Point(12, 47);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(181, 176);
            this.GroupBox1.TabIndex = 9;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Port Setting";
            // 
            // nocrc_RdBut
            // 
            this.nocrc_RdBut.AutoSize = true;
            this.nocrc_RdBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nocrc_RdBut.Location = new System.Drawing.Point(6, 23);
            this.nocrc_RdBut.Name = "nocrc_RdBut";
            this.nocrc_RdBut.Size = new System.Drawing.Size(51, 17);
            this.nocrc_RdBut.TabIndex = 10;
            this.nocrc_RdBut.Text = "None";
            this.nocrc_RdBut.UseVisualStyleBackColor = true;
            // 
            // crc_RdBut
            // 
            this.crc_RdBut.AutoSize = true;
            this.crc_RdBut.Checked = true;
            this.crc_RdBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crc_RdBut.Location = new System.Drawing.Point(6, 46);
            this.crc_RdBut.Name = "crc_RdBut";
            this.crc_RdBut.Size = new System.Drawing.Size(59, 17);
            this.crc_RdBut.TabIndex = 11;
            this.crc_RdBut.TabStop = true;
            this.crc_RdBut.Text = "CRC16";
            this.crc_RdBut.UseVisualStyleBackColor = true;
            // 
            // lrc_RdBut
            // 
            this.lrc_RdBut.AutoSize = true;
            this.lrc_RdBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lrc_RdBut.Location = new System.Drawing.Point(6, 70);
            this.lrc_RdBut.Name = "lrc_RdBut";
            this.lrc_RdBut.Size = new System.Drawing.Size(72, 17);
            this.lrc_RdBut.TabIndex = 12;
            this.lrc_RdBut.Text = "LRC+H16";
            this.lrc_RdBut.UseVisualStyleBackColor = true;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.label4);
            this.GroupBox2.Controls.Add(this.sndTxMsgBut);
            this.GroupBox2.Controls.Add(this.crc_RdBut);
            this.GroupBox2.Controls.Add(this.lrc_RdBut);
            this.GroupBox2.Controls.Add(this.nocrc_RdBut);
            this.GroupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox2.Location = new System.Drawing.Point(12, 539);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(181, 100);
            this.GroupBox2.TabIndex = 13;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Msg Authentication Mode";
            this.GroupBox2.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(87, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Byte Count = 0";
            // 
            // sndTxMsgBut
            // 
            this.sndTxMsgBut.Enabled = false;
            this.sndTxMsgBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sndTxMsgBut.Location = new System.Drawing.Point(90, 59);
            this.sndTxMsgBut.Name = "sndTxMsgBut";
            this.sndTxMsgBut.Size = new System.Drawing.Size(73, 28);
            this.sndTxMsgBut.TabIndex = 13;
            this.sndTxMsgBut.Text = "Send Msg";
            this.sndTxMsgBut.UseVisualStyleBackColor = true;
            this.sndTxMsgBut.Click += new System.EventHandler(this.sndTxMsgBut_Click);
            // 
            // allMsgBox
            // 
            this.allMsgBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.allMsgBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allMsgBox.Location = new System.Drawing.Point(6, 26);
            this.allMsgBox.Multiline = true;
            this.allMsgBox.Name = "allMsgBox";
            this.allMsgBox.ReadOnly = true;
            this.allMsgBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.allMsgBox.Size = new System.Drawing.Size(1131, 94);
            this.allMsgBox.TabIndex = 14;
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.allMsgBox);
            this.GroupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox3.Location = new System.Drawing.Point(199, 539);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(1143, 132);
            this.GroupBox3.TabIndex = 15;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Communication Messages";
            // 
            // txMsgBox
            // 
            this.txMsgBox.Location = new System.Drawing.Point(199, 675);
            this.txMsgBox.Name = "txMsgBox";
            this.txMsgBox.Size = new System.Drawing.Size(1137, 20);
            this.txMsgBox.TabIndex = 16;
            this.txMsgBox.TextChanged += new System.EventHandler(this.txMsgBox_TxtChgd);
            this.txMsgBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txMsgBox_KeyPress);
            // 
            // myComPort
            // 
            this.myComPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.dataRcvEvent);
            // 
            // Timer1
            // 
            this.Timer1.Enabled = true;
            this.Timer1.Interval = 1;
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.outputDataGrid);
            this.groupBox4.Controls.Add(this.componentDataGrid);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(199, 47);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1149, 486);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Data";
            // 
            // outputDataGrid
            // 
            this.outputDataGrid.AllowUserToAddRows = false;
            this.outputDataGrid.AllowUserToDeleteRows = false;
            this.outputDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.outputDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.outputDataGrid.Location = new System.Drawing.Point(6, 257);
            this.outputDataGrid.Name = "outputDataGrid";
            this.outputDataGrid.ReadOnly = true;
            this.outputDataGrid.Size = new System.Drawing.Size(1137, 222);
            this.outputDataGrid.TabIndex = 2;
            // 
            // componentDataGrid
            // 
            this.componentDataGrid.AllowUserToAddRows = false;
            this.componentDataGrid.AllowUserToDeleteRows = false;
            this.componentDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.componentDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.componentDataGrid.Location = new System.Drawing.Point(7, 21);
            this.componentDataGrid.Name = "componentDataGrid";
            this.componentDataGrid.ReadOnly = true;
            this.componentDataGrid.Size = new System.Drawing.Size(1136, 230);
            this.componentDataGrid.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Excel Files|*.xls;*.xlsx";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1354, 24);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadComponentListToolStripMenuItem,
            this.saveOutputDataToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadComponentListToolStripMenuItem
            // 
            this.loadComponentListToolStripMenuItem.Name = "loadComponentListToolStripMenuItem";
            this.loadComponentListToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl + O";
            this.loadComponentListToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.loadComponentListToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.loadComponentListToolStripMenuItem.Text = "Load Component List";
            this.loadComponentListToolStripMenuItem.Click += new System.EventHandler(this.loadComponentListToolStripMenuItem_Click);
            // 
            // saveOutputDataToolStripMenuItem
            // 
            this.saveOutputDataToolStripMenuItem.Name = "saveOutputDataToolStripMenuItem";
            this.saveOutputDataToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl + S";
            this.saveOutputDataToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveOutputDataToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.saveOutputDataToolStripMenuItem.Text = "Save as";
            this.saveOutputDataToolStripMenuItem.Click += new System.EventHandler(this.saveOutputDataToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(234, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // inputButton
            // 
            this.inputButton.Location = new System.Drawing.Point(12, 645);
            this.inputButton.Name = "inputButton";
            this.inputButton.Size = new System.Drawing.Size(181, 50);
            this.inputButton.TabIndex = 20;
            this.inputButton.Text = "Start";
            this.inputButton.UseVisualStyleBackColor = true;
            this.inputButton.Click += new System.EventHandler(this.inputButton_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(29, 304);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            600000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(149, 20);
            this.numericUpDown1.TabIndex = 21;
            this.numericUpDown1.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 285);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Timer interval (ms): ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1354, 706);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.inputButton);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.txMsgBox);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.MenuText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MobBus";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.outputDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.componentDataGrid)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		internal System.IO.Ports.SerialPort myComPort;
		private System.Windows.Forms.Timer Timer1;
		private System.Windows.Forms.Label Label1;
		private System.Windows.Forms.Label Label2;
		private System.Windows.Forms.Label Label3;
		private System.Windows.Forms.ComboBox lstPorts;
		private System.Windows.Forms.ComboBox lstBauds;
		private System.Windows.Forms.Label comStatusLabel;
		private System.Windows.Forms.Button openPortBut;
		private System.Windows.Forms.Button clrMsgBoxBut;
		private System.Windows.Forms.Label portCntLabel;
		private System.Windows.Forms.GroupBox GroupBox1;
		private System.Windows.Forms.RadioButton nocrc_RdBut;
		private System.Windows.Forms.RadioButton crc_RdBut;
		private System.Windows.Forms.RadioButton lrc_RdBut;
		private System.Windows.Forms.GroupBox GroupBox2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button sndTxMsgBut;
		private System.Windows.Forms.TextBox allMsgBox;
		private System.Windows.Forms.GroupBox GroupBox3;
		private System.Windows.Forms.TextBox txMsgBox;
        private DataGridView componentDataGrid;
        private GroupBox groupBox4;
        private OpenFileDialog openFileDialog1;
        private DataGridView outputDataGrid;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem loadComponentListToolStripMenuItem;
        private Button inputButton;
        private ToolStripMenuItem saveOutputDataToolStripMenuItem;
        private SaveFileDialog saveFileDialog1;
        private NumericUpDown numericUpDown1;
        private Label label5;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem exitToolStripMenuItem;
    }

}