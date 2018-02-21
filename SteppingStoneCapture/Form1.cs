using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using PcapDotNet.Core;
using PcapDotNet.Packets;
using PcapDotNet.Packets.IpV4;

namespace SteppingStoneCapture
{
    //
    /// <summary>
    /// Captures and displays information of packets transferred
    /// through a desired network interface
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    public partial class CaptureForm : Form
    {
        private int deviceIndex = 0;
        private IList<LivePacketDevice> allDevices;
        private string defaultFilterField = "";
        private string filter = "";
        private List<byte[]> packetBytes = new List<byte[]>();
        private Int32 packetNumber = 0;
        private bool captFlag = true;
        private int numThreads = 0;
        private Boolean boxChecked = false;
        private CougarFilterBuilder cfb = new CougarFilterBuilder();


        public CaptureForm()
        {
            InitializeComponent();
        }

        private void DetermineNetworkInterface(int numTries = 5)
        {
            //Detect all interfaces
            allDevices = LivePacketDevice.AllLocalMachine;

            //Try the allotted number of times if no interfaces detected
            if (allDevices.Count == 0)
            {
                if (numTries > 0)
                    DetermineNetworkInterface(--numTries);
            }

            //list available interfaces in ComboBox
            else if (allDevices.Count > 0)
            {
                for (int i = 0; i != allDevices.Count; ++i)
                {
                    int offsetForWindowsMachines = 16;
                    LivePacketDevice device = allDevices[i];
                    if (device.Description != null)
                        cmbInterfaces.Items.Add(device.Description.Substring(offsetForWindowsMachines));
                    else
                        cmbInterfaces.Items.Add("*** (No description available)");
                }
            }
        }

        private void showFilterFieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtFilterField.Visible = !txtFilterField.Visible;
            lblFilterField.Visible = !lblFilterField.Visible;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CaptureForm_Load(object sender, EventArgs e)
        {
            DetermineNetworkInterface();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!captFlag) captFlag = true;
            txtFilterField.Text = "";

            foreach (Control c in this.Controls)
            {
                if (c is CheckBox chk)
                {
                    if (chk.Checked)
                    {
                        boxChecked = true;
                        if (chk.Name != "chkAutoScroll")
                            cfb.AddToProtocolList(chk.Text);
                        
                    }
                }
                else if (c is TextBox tb)
                {
                    if (tb.Name == "txtSrcIP")
                    {
                        if (tb.Text != "")
                         cfb.AddToAttributeList("src host "+ tb.Text.ToLower());
                    }
                    else if (tb.Name == "txtDestIP")
                    {
                        if (tb.Text != "")
                            cfb.AddToAttributeList("dst host " + tb.Text.ToLower());
                    }
                    else if (tb.Name == "txtSrcPort")
                    {
                        if (tb.Text != "")
                            cfb.AddToAttributeList("src port " + tb.Text);
                    }
                    else if (tb.Name == "txtDestPort")
                    {
                        if (tb.Text != "")
                            cfb.AddToAttributeList("dst port "+tb.Text);
                    }
                }
            }

            filter = cfb.FilterString;
            txtFilterField.Text = filter;
            //capture packets     
            if ((numThreads < 1) && (deviceIndex != 0))
            {
                ++numThreads;
                Thread t = new Thread(new ThreadStart(CapturePackets))
                {
                    IsBackground = true
                };
                t.Start();                
            }
        }


        //Captures packets while issuing concurrent calls to update the GUI
        /// <summary>
        /// Capture packets and stores their information
        /// </summary>
        private void CapturePackets()
        {
            // Take the selected adapter
            PacketDevice selectedDevice = allDevices[this.deviceIndex];
            int prevInd = 0;
            // Open the device
            using (PacketCommunicator communicator =
                selectedDevice.Open(65536,                                  // portion of the packet to capture
                                                                            // 65536 guarantees that the whole packet will be captured on all the link layers
                                    PacketDeviceOpenAttributes.Promiscuous, // promiscuous mode
                                    1000))                                  // read timeout
            {               
                communicator.SetFilter(filter);
                while (captFlag)
                {
                    PacketCommunicatorReceiveResult result = communicator.ReceivePacket(out Packet packet);
                    byte[] packetInfo;
                    
                    switch (result)
                    {
                        case PacketCommunicatorReceiveResult.Timeout:
                            // Timeout elapsed
                            break;
                        case PacketCommunicatorReceiveResult.Ok:
                            IpV4Datagram ipv4 = packet.Ethernet.IpV4;
                            IpV4Protocol i = ipv4.Protocol;

                            CougarPacket cp = new CougarPacket(packet.Timestamp.ToString("hh:mm:ss.fff"),
                                                               ++packetNumber,
                                                               packet.Length,
                                                               ipv4.Source.ToString(),
                                                               ipv4.Destination.ToString());

                            packetInfo = Encoding.ASCII.GetBytes(cp.ToString() + "\n");
                            packetBytes.Add(packetInfo);

                            this.Invoke((MethodInvoker)(() =>
                            {
                                packetView.Items.Add(new ListViewItem(cp.toPropertyArray()));
                                
                                ++prevInd;
                                if (chkAutoScroll.Checked && prevInd > 12)
                                {
                                    packetView.Items[packetView.Items.Count - 1].EnsureVisible();
                                    prevInd = 0;
                                }
                            }));
                            break;
                        default:
                            throw new InvalidOperationException("The result " + result + " should never be reached here");
                    }
                }
            }
        }

        //Signals for cease of capture function
        /// <summary>
        /// Signals for program to cease capture
        /// </summary>
        /// <remarks>
        /// Additionally, decreases number of running threads by one
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStop_Click(object sender, EventArgs e)
        {
            captFlag = false;
            if (numThreads > 0) --numThreads;
        }

        //Resets the form and properties for following runs
        /// <summary>
        /// Signals for reset of the different controls and 
        /// properties of the form for following runs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnReset_Click(object sender, EventArgs e)
        {         
            //reset every control in the form to its default value
            foreach (Control c in Controls)
            {
                if (c is CheckBox ck) ck.Checked = false;   
                else if (c is TextBox tb) tb.Text = "";                
            }

            ResetNecessaryProperties();
        }

        //Captures the selection of desired network interface
        /// <summary>
        /// Captures which network interface the user would like to capture packets
        /// from
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmbInterfaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbInterfaces.Items != null)
            {
                deviceIndex = cmbInterfaces.SelectedIndex;
            }
        }

        //Initiates save of captured packets
        /// <summary>
        /// Signals for save of data of packets captured from the last save,
        /// or reset, up to now in a file
        /// </summary>
        /// <remarks>
        /// Allows user to select which fields to save to file
        /// Permits users to decide save file type
        /// </remarks>
        /// /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            string fileName = string.Format(@"C:\Users\Public\Documents\{0}_captureFile.txt",
                                            DateTime.Now.ToString("dd-MM-yyyy_hhmmssffff"));

            foreach (byte[] barr in packetBytes)
            {
                File.AppendAllText(fileName, Encoding.ASCII.GetString(barr));
            }

            packetBytes.Clear();
        }

        //Reset different attributes of the form for the next run
        /// <summary>
        /// Resets attributes of the form for following runs
        /// </summary>
        private void ResetNecessaryProperties()
        {
            txtFilterField.Text = defaultFilterField;
            packetNumber = 0;
            captFlag = true;
            packetView.Items.Clear();
            cfb.ClearFilterLists();
            packetBytes.Clear();
            boxChecked = false;
        }

        
    }
}
