using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using PcapDotNet.Core;
using PcapDotNet.Packets;
using PcapDotNet.Packets.IpV4;

namespace SteppingStoneCapture
{
    public partial class CaptureForm : Form
    {
        //Kendrick
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
            //DetermineNetworkInterface();
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

                        cfb.AddToProtocolList(chk.Text);
                        
                    }
                }
                if (c is TextBox tb)
                {
                    if (tb.Name == "txtSrcIP")
                    {
                        if (tb.Text != "")
                         cfb.AddToAttributeList("src host "+ tb.Text.ToLower());
                    }
                    if (tb.Name == "txtDestIP")
                    {
                        if (tb.Text != "")
                            cfb.AddToAttributeList("dst host " + tb.Text.ToLower());
                    }
                    if (tb.Name == "txtSrcPort")
                    {
                        if (tb.Text != "")
                            cfb.AddToAttributeList("src port " + tb.Text);
                    }
                    if (tb.Name == "txtDestPort")
                    {
                        if (tb.Text != "")
                            cfb.AddToAttributeList("dst port "+tb.Text);
                    }
                }
            }

            filter = cfb.BuildFilterString();
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

        private void CapturePackets()
        {
            // Take the selected adapter
            PacketDevice selectedDevice = allDevices[this.deviceIndex];
            // Open the device
            using (PacketCommunicator communicator =
                selectedDevice.Open(65536,                                  // portion of the packet to capture
                                                                            // 65536 guarantees that the whole packet will be captured on all the link layers
                                    PacketDeviceOpenAttributes.Promiscuous, // promiscuous mode
                                    1000))                                  // read timeout
            {
                this.Invoke((MethodInvoker)(() => {
                    ListViewItem lvi = new ListViewItem(filter);
                }));
                
                communicator.SetFilter(filter);
                Packet packet;
                int prevInd = 0;
                while (captFlag)
                {
                    PacketCommunicatorReceiveResult result = communicator.ReceivePacket(out packet);
                    byte[] packetInfo;

                    switch (result)
                    {
                        case PacketCommunicatorReceiveResult.Timeout:
                            // Timeout elapsed
                            break;
                        case PacketCommunicatorReceiveResult.Ok:
                            IpV4Datagram ipv4 = packet.Ethernet.IpV4;
                            IpV4Protocol i = ipv4.Protocol;

                            switch (i)
                            {

                            }
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
                                if (chkAutoScroll.Checked && prevInd > 4)
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

        private void btnStop_Click(object sender, EventArgs e)
        {
            captFlag = false;
            if (numThreads > 0)
            {
                numThreads--;
            }            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            boxChecked = false;
            foreach (Control c in this.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox chk = (CheckBox)c;
                    chk.Checked = false;                 
                }

                if (c is TextBox)
                {
                    TextBox txt = (TextBox)c;
                    txt.Text = "";
                }
            }

            ResetNecessaryProperties();
        }

        private void cmbInterfaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbInterfaces.Items != null)
            {
                deviceIndex = cmbInterfaces.SelectedIndex;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string fileName = string.Format(@"C:\Users\Public\Documents\{0}_captureFile.txt",
                                            DateTime.Now.ToString("dd-MM-yyyy_hhmmssffff"));

            foreach (byte[] barr in packetBytes)
            {
                File.AppendAllText(fileName, Encoding.ASCII.GetString(barr));
            }

            packetBytes.Clear();
        }

        private void ResetNecessaryProperties()
        {
            txtFilterField.Text = defaultFilterField;
            packetNumber = 0;
            captFlag = true;
            packetView.Items.Clear();
            cfb.ClearFilterLists();
            packetBytes.Clear();
        }
    }
}
