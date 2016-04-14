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
using System.IO.Ports;
using System.IO;
using System.Data.OleDb;

namespace SerialComBytes
{
    public partial class Form1
    {

        public Form1()
        {
            InitializeComponent();
        }

        private string Excel03ConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'"; //for db connection
        private string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";

        private List<Component> componentList;

        private byte[] crcTableH = new byte[] { 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40 };

        private byte[] crcTableL = new byte[] { 0x00, 0xC0, 0xC1, 0x01, 0xC3, 0x03, 0x02, 0xC2, 0xC6, 0x06, 0x07, 0xC7, 0x05, 0xC5, 0xC4, 0x04, 0xCC, 0x0C, 0x0D, 0xCD, 0x0F, 0xCF, 0xCE, 0x0E, 0x0A, 0xCA, 0xCB, 0x0B, 0xC9, 0x09, 0x08, 0xC8, 0xD8, 0x18, 0x19, 0xD9, 0x1B, 0xDB, 0xDA, 0x1A, 0x1E, 0xDE, 0xDF, 0x1F, 0xDD, 0x1D, 0x1C, 0xDC, 0x14, 0xD4, 0xD5, 0x15, 0xD7, 0x17, 0x16, 0xD6, 0xD2, 0x12, 0x13, 0xD3, 0x11, 0xD1, 0xD0, 0x10, 0xF0, 0x30, 0x31, 0xF1, 0x33, 0xF3, 0xF2, 0x32, 0x36, 0xF6, 0xF7, 0x37, 0xF5, 0x35, 0x34, 0xF4, 0x3C, 0xFC, 0xFD, 0x3D, 0xFF, 0x3F, 0x3E, 0xFE, 0xFA, 0x3A, 0x3B, 0xFB, 0x39, 0xF9, 0xF8, 0x38, 0x28, 0xE8, 0xE9, 0x29, 0xEB, 0x2B, 0x2A, 0xEA, 0xEE, 0x2E, 0x2F, 0xEF, 0x2D, 0xED, 0xEC, 0x2C, 0xE4, 0x24, 0x25, 0xE5, 0x27, 0xE7, 0xE6, 0x26, 0x22, 0xE2, 0xE3, 0x23, 0xE1, 0x21, 0x20, 0xE0, 0xA0, 0x60, 0x61, 0xA1, 0x63, 0xA3, 0xA2, 0x62, 0x66, 0xA6, 0xA7, 0x67, 0xA5, 0x65, 0x64, 0xA4, 0x6C, 0xAC, 0xAD, 0x6D, 0xAF, 0x6F, 0x6E, 0xAE, 0xAA, 0x6A, 0x6B, 0xAB, 0x69, 0xA9, 0xA8, 0x68, 0x78, 0xB8, 0xB9, 0x79, 0xBB, 0x7B, 0x7A, 0xBA, 0xBE, 0x7E, 0x7F, 0xBF, 0x7D, 0xBD, 0xBC, 0x7C, 0xB4, 0x74, 0x75, 0xB5, 0x77, 0xB7, 0xB6, 0x76, 0x72, 0xB2, 0xB3, 0x73, 0xB1, 0x71, 0x70, 0xB0, 0x50, 0x90, 0x91, 0x51, 0x93, 0x53, 0x52, 0x92, 0x96, 0x56, 0x57, 0x97, 0x55, 0x95, 0x94, 0x54, 0x9C, 0x5C, 0x5D, 0x9D, 0x5F, 0x9F, 0x9E, 0x5E, 0x5A, 0x9A, 0x9B, 0x5B, 0x99, 0x59, 0x58, 0x98, 0x88, 0x48, 0x49, 0x89, 0x4B, 0x8B, 0x8A, 0x4A, 0x4E, 0x8E, 0x8F, 0x4F, 0x8D, 0x4D, 0x4C, 0x8C, 0x44, 0x84, 0x85, 0x45, 0x87, 0x47, 0x46, 0x86, 0x82, 0x42, 0x43, 0x83, 0x41, 0x81, 0x80, 0x40 };

        private int portCnt;
        private int tmrChrBrk;
        private int prevTxMsgLen;
        private int tmrDlySnd;
        private int chrBrkConst;
        private int txByteCnt;
        private string prevSelPort = null;

        private void Form1_Load(object sender, System.EventArgs e)
        {
            lstBauds.SelectedIndex = 5;
            CloseComPort();
            string filePath = Path.GetDirectoryName(Application.ExecutablePath) + @"\Files\Components.xlsx";
            try
            {
                loadComponentGrid(filePath);
            }catch(Exception ex)
            {
                Console.WriteLine("Invalid path");
            }

            componentList = getComponentNameList();
            populateOutputColumns(componentList);


        }
        private void dataRcvEvent(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            //reload char break timer
            //in timer1, when tmrChrBrk = 0 => full frame of msg has been rcv'd in buffer
            tmrChrBrk = chrBrkConst;
        }
        private void Timer1_Tick(object sender, System.EventArgs e)
        {
            //refresh port list constantly
            RefreshComPortList();

            if (myComPort.IsOpen)
            {
                tmrChrBrk -= 1;
                if (tmrChrBrk == 0)
                {
                    //rcv msg detected break in transmission
                    int rcvMsgLen = myComPort.BytesToRead;
                    byte[] rcvMsgArr = new byte[rcvMsgLen + 1];

                    myComPort.Read(rcvMsgArr, 0, rcvMsgLen);
                    string s = byteArraytoStr(rcvMsgArr, rcvMsgLen);

                    string raw_value = s.Remove(0, 6);
                    raw_value = raw_value.Remove(raw_value.Length - 4, 4);
                    Console.WriteLine(raw_value);

                    int decimalValue = Convert.ToInt32(raw_value, 16);
                    valueBox.Text += decimalValue + Environment.NewLine;


                    clrMsgBoxBut.Enabled = true;
                    allMsgBox.Text += "<-  " + addHexSpaces(s) + Environment.NewLine;
                    allMsgBox.SelectionStart = allMsgBox.Text.Length - 2;
                    allMsgBox.ScrollToCaret();

                }
                else if (tmrChrBrk <= 0)
                {
                    tmrChrBrk = 0; //to avoid recursive
                }

                tmrDlySnd -= 1;
                if (tmrDlySnd == 0)
                {
                    //transmit msg in txMsgBox if not empty
                    if (txMsgBox.Text.Length != 0)
                    {
                        SerialOut(txMsgBox.Text);
                        txMsgBox.Text = null;
                    }
                }
                else if (tmrDlySnd <= 0)
                {
                    tmrDlySnd = 0; //to avoid recursive
                }

            }
        }

        //Private Function getModbusCRC(ByVal ba As Byte(), ByVal l As Integer) As Byte()
        //    Dim crc16 As UInt16 = &HFFFF        'initial crc16 = 0xffff

        //    For i As Integer = 0 To l - 1
        //        crc16 = crc16 Xor Convert.ToUInt16(ba(i))
        //        For j As Integer = 1 To 8
        //            If ((crc16 And 1) <> 0) Then
        //                crc16 >>= 1
        //                crc16 = crc16 Xor &HA001    'xor with 0xA001
        //            Else
        //                crc16 >>= 1
        //            End If
        //        Next
        //    Next
        //    'Dim crc As Byte() = {Convert.ToByte(crc16 Mod 256), Convert.ToByte(crc16 / 256)}
        //    'Return crc
        //    Return {Convert.ToByte(crc16 Mod 256), Convert.ToByte(crc16 / 256)}
        //End Function

        private byte[] getCRC_TableMethod(byte[] ba, int l)
        {
            //CRC16 by Table
            byte[] crc16 = { 255, 255 };
            byte crcindex = 0;

            for (var i = 0; i < l; i++)
            {
                crcindex = (byte)(crc16[0] ^ ba[i]);
                crc16[0] = (byte)(crc16[1] ^ crcTableH[crcindex]);
                crc16[1] = crcTableL[crcindex];
            }
            return crc16;
        }


        private byte getLRC(byte[] ba, int l)
        {
            UInt16 lrc8 = 0;

            for (int i = 0; i < l; i++)
            {
                lrc8 += ba[i];
                lrc8 = (UInt16)(lrc8 % 256);
            }
            return Convert.ToByte(lrc8);
        }
        private string byteArraytoStr(byte[] ba, int l)
        {
            string s = "";

            for (int i = 0; i < l; i++)
            {
                s += ba[i].ToString("X2");
            }
            return s;
        }

        private void SerialOut(string s)
        {
            //to transmit serial msg with crc or lrc or none
            //1. convert txMsgBox.Text to byteArray
            //2. use byteArray to compute CRC or LRC depending on selection
            //3. put CRC or LRC to array and transmit
            byte[] myTxBuf = HexStrToByteArray(s);
            byte[] crc16 = { 255, 255 };

            if (crc_RdBut.Checked)
            {
                //crc16 = getModbusCRC(myTxBuf, myTxBuf.Length)
                crc16 = getCRC_TableMethod(myTxBuf, myTxBuf.Length);
                Array.Resize(ref myTxBuf, myTxBuf.Length + 2);
                myTxBuf[myTxBuf.Length - 1] = crc16[1];
                myTxBuf[myTxBuf.Length - 2] = crc16[0];
                s = byteArraytoStr(myTxBuf, myTxBuf.Length);
            }
            else if (lrc_RdBut.Checked)
            {
                crc16[0] = getLRC(myTxBuf, myTxBuf.Length);
                Array.Resize(ref myTxBuf, myTxBuf.Length + 2);
                myTxBuf[myTxBuf.Length - 2] = crc16[0];
                myTxBuf[myTxBuf.Length - 1] = 0x16;
                s = byteArraytoStr(myTxBuf, myTxBuf.Length);
            }

            myComPort.Write(myTxBuf, 0, myTxBuf.Length);
            clrMsgBoxBut.Enabled = true;
            allMsgBox.Text += "->  " + addHexSpaces(s) + Environment.NewLine;
            allMsgBox.SelectionStart = allMsgBox.Text.Length - 2;
            allMsgBox.ScrollToCaret();

        }
        private byte[] HexStrToByteArray(string s)
        {
            string s1 = rmvHexSpaces(s);
            int i = 0;
            int a = 0;
            byte h = 0;
            //Dim myByteArray() As Byte = New Byte(Convert.ToInt16(s1.Length / 2) - 1) {}
            byte[] myByteArray = new byte[txByteCnt];

            foreach (char c in s1)
            {
                i = i + 1;
                if (i % 2 != 0) //upper nib
                {
                    h = (byte)(Convert.ToInt32(Char.ToString(c), 16) * 16);
                }
                else //lower nib
                {
                    h += (byte)Convert.ToInt32(Char.ToString(c), 16);
                    myByteArray[a] = h;
                    a = a + 1;
                }
            }
            return myByteArray;
        }
        private void RefreshComPortList()
        {
            string curSelPort = "";
            string[] newPorts = SerialPort.GetPortNames();
            try
            {
                curSelPort = lstPorts.SelectedItem.ToString();
            }
            catch (Exception)
            {


            }
            //Dim prevPorts() As IEnumerable(Of String) = lstPorts.Items.Cast(Of String)()

            portCntLabel.Text = "Available Port Count = " + newPorts.Count().ToString();
            //Checking if any changes in ports availability
            if (portCnt != newPorts.Count())
            {
                portCnt = newPorts.Count();

                //lstPorts.DataSource = System.IO.Ports.SerialPort.GetPortNames
                //For Each port As Object In lstPorts.DataSource
                //    allMsgBox.Text += port.ToString() + vbCrLf
                //Next

                Array.Sort(newPorts);
                lstPorts.DataSource = newPorts;

                if (!(newPorts.Contains(curSelPort)))
                {
                    CloseComPort();
                }
                else
                {
                    lstPorts.Text = myComPort.PortName; //maintain disp of currently selected port on combobox
                }
            }
            if (portCnt > 0)
            {
                openPortBut.Enabled = true;
            }
            else
            {
                openPortBut.Enabled = false;
                lstPorts.Text = null;
                CloseComPort();
            }
        }
        private void CloseComPort()
        {
            myComPort.Close();
            openPortBut.Text = "Open Com Port";
            comStatusLabel.Text = "Not Connected";
            comStatusLabel.BackColor = Color.Red;
        }
        private void openPortBut_Click(object sender, System.EventArgs e)
        {
            if (!(myComPort.IsOpen))
            {
                try
                {
                    //myComPort.PortName = lstPorts.SelectedItem.ToString()
                    //myComPort.BaudRate = Convert.ToInt32(lstBauds.SelectedItem)
                    myComPort.PortName = lstPorts.SelectedItem.ToString();
                    myComPort.BaudRate = Convert.ToInt32(lstBauds.SelectedItem);
                    myComPort.Parity = Parity.None;
                    myComPort.DataBits = 8;
                    myComPort.StopBits = StopBits.One;

                    prevSelPort = myComPort.PortName;
                    myComPort.Open();
                    comStatusLabel.Text = myComPort.PortName + " Opened";
                    comStatusLabel.BackColor = Color.Green;
                    openPortBut.Text = "Close Com Port";
                    chrBrkConst = Convert.ToInt32(30000 * 5 / (double)myComPort.BaudRate);
                    if (chrBrkConst <= 3)
                    {
                        chrBrkConst = 3;
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show("Com Port Not Available.  Try Again later.", "! Warning !");
                    CloseComPort();
                }
                catch (SystemException ex)
                {
                }
            }
            else
            {
                CloseComPort();
            }
        }
        private void clrMsgBoxBut_Click(object sender, System.EventArgs e)
        {
            allMsgBox.Text = null;
            clrMsgBoxBut.Enabled = false;
        }
        private void txMsgBox_TxtChgd(object sender, System.EventArgs e)
        {
            string s = txMsgBox.Text;

            if (!(prevTxMsgLen > s.Length)) //so that can do back space
            {
                txMsgBox.Text = addHexSpaces(s); //add spaces to separate each byte
                txMsgBox.SelectionStart = txMsgBox.TextLength; //set cursor to end of text
            }
            prevTxMsgLen = txMsgBox.TextLength;
            txByteCnt = Convert.ToInt32(Math.Floor((prevTxMsgLen + 1) / 3.0));
            label4.Text = "Byte Count = " + txByteCnt.ToString();
            if (txByteCnt > 0)
            {
                sndTxMsgBut.Enabled = true;
            }
            else
            {
                sndTxMsgBut.Enabled = false;
            }
        }
        private void portChgEvent(object sender, EventArgs e)
        {
            if ((lstPorts.SelectedItem.ToString() != myComPort.PortName) && (myComPort.IsOpen))
            {
                lstPorts.Text = lstPorts.SelectedItem.ToString();
                MessageBox.Show("Another COM Port is Opened !" + "\n" + "Please Close existing before selecting a different Port.", "!!! Notice !!!  ");
                lstPorts.Text = myComPort.PortName;
                openPortBut.Focus();
            }
        }

        private void baudChgEvent(object sender, EventArgs e)
        {
            if (myComPort.IsOpen && (myComPort.BaudRate != Convert.ToInt32(lstBauds.SelectedItem)))
            {
                lstBauds.Text = lstBauds.SelectedItem.ToString(); //update selection to display on combobox
                int warnMsgDone = (int)MessageBox.Show("Please Close COM Port before making any changes", "!!! Notice !!!  ");
                lstBauds.Text = myComPort.BaudRate.ToString(); //revert display to show actual setting
                openPortBut.Focus(); //set focus to openPort button
            }
        }
        private void sndTxMsgBut_Click(object sender, EventArgs e)
        {
            tmrDlySnd = 1; //will transmit msg on next timer1_Tick event
        }

        private void txMsgBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            txMsgBox.Focus();
            if (c == '\r' && sndTxMsgBut.Enabled)
            {
                tmrDlySnd = 1; //will transmit msg o next timer1_Tick event
            }
        }

        private string addHexSpaces(string s)
        {
            string s1 = rmvHexSpaces(s);
            int cindex = 0;

            s = null;
            if (!string.IsNullOrEmpty(s1))
            {
                foreach (char c in s1)
                {
                    if ((c.CompareTo('0') >= 0 && c.CompareTo('9') <= 0) || (c.CompareTo('a') >= 0 && c.CompareTo('f') <= 0) || (c.CompareTo('A') >= 0 && c.CompareTo('F') <= 0))
                    {
                        s = s + char.ToUpper(c);
                        cindex = cindex + 1;
                        if (cindex % 2 == 0)
                        {
                            s = s + " ";
                        }
                    }
                    else
                    {
                        break; //break
                    }
                }
            }
            return s;
        }
        private string rmvHexSpaces(string s)
        {
            //remove spaces and unrecognized hex chars and join them in sequence
            string s1 = null;

            foreach (char c in s)
            {
                if ((c.CompareTo('0') >= 0 && c.CompareTo('9') <= 0) || (c.CompareTo('a') >= 0 && c.CompareTo('f') <= 0) || (c.CompareTo('A') >= 0 && c.CompareTo('F') <= 0))
                {
                    s1 = s1 + char.ToUpper(c);
                }
            }
            return s1;
        }

        private void loadComponentGrid(string path)
        {
            string filePath = path;
            string extension = Path.GetExtension(filePath);
            Console.WriteLine(filePath);
            string header = "YES";
            string conStr, sheetName;

            conStr = string.Empty;
            switch (extension)
            {

                case ".xls": //Excel 97-03
                    conStr = string.Format(Excel03ConString, filePath, header);
                    break;

                case ".xlsx": //Excel 07
                    conStr = string.Format(Excel07ConString, filePath, header);
                    break;
            }

            //Get the name of the First Sheet.
            using (OleDbConnection con = new OleDbConnection(conStr))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = con;
                    con.Open();
                    DataTable dtExcelSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                    con.Close();
                }
            }

            //Read Data from the First Sheet.
            using (OleDbConnection con = new OleDbConnection(conStr))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    using (OleDbDataAdapter oda = new OleDbDataAdapter())
                    {
                        DataTable dt = new DataTable();
                        cmd.CommandText = "SELECT * From [" + sheetName + "]";
                        cmd.Connection = con;
                        con.Open();
                        oda.SelectCommand = cmd;
                        oda.Fill(dt);
                        con.Close();

                        //Populate DataGridView.
                        componentDataGrid.DataSource = dt;
                    }
                }
            }
        }

        private List<Component> getComponentNameList()
        {
            List<Component> componentList = new List<Component>();
            foreach(DataGridViewRow row in componentDataGrid.Rows)
            {
                Component component = new Component();
                component.Address = row.Cells[0].ToString();
                component.Name = row.Cells[1].Value.ToString();
                component.Unit = row.Cells[2].Value.ToString();
                component.Multiplier = Double.Parse(row.Cells[3].Value.ToString());
                component.RegCount = int.Parse(row.Cells[4].Value.ToString());
                componentList.Add(component);
            }
            return componentList;
        }

        private void populateOutputColumns(List<Component> componentList)
        {
            for (int i = 0; i < componentList.Count; i++)
            {
            
                outputDataGrid.Columns.Add(componentList[i].Name, componentList[i].Name);
            }
        }

        private static Form1 _DefaultInstance;
        public static Form1 DefaultInstance
        {
            get
            {
                if (_DefaultInstance == null)
                    _DefaultInstance = new Form1();

                return _DefaultInstance;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string filePath = openFileDialog1.FileName;
            loadComponentGrid(filePath);
        }
    }
}
