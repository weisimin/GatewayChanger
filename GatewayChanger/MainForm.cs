using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SharpPcap;
using PacketDotNet;
using SharpPcap.LibPcap;
using System.Threading;
using System.Net;

namespace GatewayChanger
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        bool Runing = false;

        private void btn_switch_Click(object sender, EventArgs e)
        {
            if (Runing == false)
            {
                Runing = !Runing;
                btn_switch.Text = "运行中";
                WinCapHelper.WinCapInstance.Listen(device_OnPacketArrival);
            }
            else
            {
                Runing = !Runing;
                btn_switch.Text = "关闭";
                WinCapHelper.WinCapInstance.StopAll();
            }


        }
        bool autoadd = false;
        private void cb_autoadd_CheckedChanged(object sender, EventArgs e)
        {
            autoadd = cb_autoadd.Checked;
        }
        bool autochange = true;
        private void cb_autochange_CheckedChanged(object sender, EventArgs e)
        {
            autochange = cb_autochange.Checked;
        }

        Dictionary<string, string> RouteTable = new Dictionary<string, string>();
        CookieCollection cc = new CookieCollection();
        private void device_OnPacketArrival(object sender, CaptureEventArgs e)
        {
            ////解析出基本包  
            var packet = PacketDotNet.Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);
            ////协议类别  
            // var dlPacket = PacketDotNet.DataLinkPacket.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);  
            //var ethernetPacket = PacketDotNet.EthernetPacket.GetEncapsulated(packet);  
            //var internetLinkPacket = PacketDotNet.InternetLinkLayerPacket.Parse(packet.BytesHighPerformance.Bytes);  
            //var internetPacket = PacketDotNet.InternetPacket.Parse(packet.BytesHighPerformance.Bytes); 
            //var sessionPacket = PacketDotNet.SessionPacket.Parse(packet.BytesHighPerformance.Bytes);  
            //var appPacket = PacketDotNet.ApplicationPacket.Parse(packet.BytesHighPerformance.Bytes);  
            //var pppoePacket = PacketDotNet.PPPoEPacket.Parse(packet.BytesHighPerformance.Bytes); 
            //var arpPacket = PacketDotNet.ARPPacket.GetEncapsulated(packet);  
            var ipPacket = packet.Extract(typeof(IpPacket));//ip包  
            if (ipPacket != null)
            {
                String FromAddress = ((IpPacket)ipPacket).SourceAddress.ToString();
                String ToAddress = ((IpPacket)ipPacket).SourceAddress.ToString();
                String Message = "源地址" + ((IpPacket)ipPacket).SourceAddress.ToString()
                     + " ,目的地址" + ((IpPacket)ipPacket).DestinationAddress.ToString();
                NetFramework.Console.Write(Message);
                if (ToAddress.Contains(".") == false || ToAddress.StartsWith("192") == true)
                {
                    return;
                }
                String URL = "https://www.ip.cn/api/index?ip=" + ToAddress + "&type=1";

                String IPCheck = NetFramework.Util_WEB.OpenUrl(URL, "", "", "GET", cc);
                if (

                    (IPCheck.Contains("美国") || IPCheck.Contains("香港") || IPCheck.Contains("日本") || IPCheck.Contains("台湾") || IPCheck.Contains("新加坡") || IPCheck.Contains("加拿大"))
                    && (IPCheck != tb_excuteip.Text)

                    )
                {
                    if (RouteTable.ContainsKey(ToAddress))
                    {
                        String CMDParammter = "ADD " + ToAddress + " MASK 255.255.255.255 " + tb_serverip.Text + " ";
                        NetFramework.Util_CMD.RunHideCmd("route", CMDParammter);
                        RouteTable.Add(ToAddress, "run");
                    }
                }

            }

            // var udpPacket = PacketDotNet.UdpPacket.GetEncapsulated(packet);  
            // var tcpPacket = PacketDotNet.TcpPacket.GetEncapsulated(packet);

            //var tcpp= packet.Extract(typeof(TcpPacket));
            //if (tcpp!=null)
            //{
            //    Console.WriteLine(tcpp.PrintHex());
            //}

            //string ret = "";
            //PrintPacket(ref ret, packet);

            //ParsePacket(ref ret, ethernetPacket);  
            //ParsePacket(ref ret, internetLinkPacket);  
            //ParsePacket(ref ret, internetPacket);  
            //ParsePacket(ref ret, sessionPacket);  
            //ParsePacket(ref ret, appPacket);  
            //ParsePacket(ref ret, pppoePacket);  
            //ParsePacket(ref ret, arpPacket);  
            //ParsePacket(ref ret, ipPacket);  
            //ParsePacket(ref ret, udpPacket);  
            //ParsePacket(ref ret, tcpPacket); 




        }
    }
    public class WinCapHelper
    {
        private static object syncObj = new object();
        private static WinCapHelper _capInstance;
        public static WinCapHelper WinCapInstance
        {
            get
            {
                if (null == _capInstance)
                {
                    lock (syncObj)
                    {
                        if (null == _capInstance)
                        {
                            _capInstance = new WinCapHelper();
                        }
                    }
                }
                return _capInstance;
            }
        }
        private Thread _thread;

        /// <summary>  
        /// when get pocket,callback  
        /// </summary>  
        public Action<string> _logAction;

        /// <summary>  
        /// 过滤条件关键字  
        /// </summary>  
        public string filter;

        private WinCapHelper()
        {
        }

        public void Listen(PacketArrivalEventHandler device_OnPacketArrival)
        {
            if (_thread != null && _thread.IsAlive)
            {
                return;
            }
            _thread = new Thread(new ThreadStart(() =>
            {
                ////遍历网卡  
                foreach (PcapDevice device in SharpPcap.CaptureDeviceList.Instance)
                {
                    ////分别启动监听，指定包的处理函数  
                    device.OnPacketArrival += new PacketArrivalEventHandler(device_OnPacketArrival);
                    device.Open(DeviceMode.Normal, 1000);
                    device.Capture(500);
                    //device.StartCapture();  
                }
            }));
            _thread.Start();
        }



        /// <summary>  
        /// 接收到包的处理函数  
        /// </summary>  
        /// <param name="sender"></param>  
        /// <param name="e"></param>  


        public void StopAll()
        {
            foreach (PcapDevice device in SharpPcap.CaptureDeviceList.Instance)
            {
                if (device.Opened)
                {
                    Thread.Sleep(500);
                    device.StopCapture();
                }
                _logAction("device : " + device.Description + " stoped.\r\n");
            }
            _thread.Abort();
        }
    }

    //https://www.ip.cn/api/index?ip=45.119.126.225&type=1
}
