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

                if (autoadd == true)
                {
                    String CMDParammter = " delete 0.0.0.0 ";
                    NetFramework.Util_CMD.RunHideCmd("route", CMDParammter);
                    CMDParammter = "ADD 192.168.6.0 MASK 255.255.255.0 " + tb_localgateway.Text + " ";
                    NetFramework.Util_CMD.RunHideCmd("route", CMDParammter);
                    CMDParammter = "ADD 192.168.1.0 MASK 255.255.255.0 " + tb_localgateway.Text + " ";
                    NetFramework.Util_CMD.RunHideCmd("route", CMDParammter);
                    CMDParammter = "ADD 202.96.128.86 MASK 255.255.255.255 " + tb_localgateway.Text + " ";
                    NetFramework.Util_CMD.RunHideCmd("route", CMDParammter);
                    CMDParammter = "ADD " + tb_excuteip.Text + " MASK 255.255.255.255 " + tb_localgateway.Text + " ";
                    NetFramework.Util_CMD.RunHideCmd("route", CMDParammter);
                }
                if (autochange == true)
                {

                    String CMDParammter = "ADD 8.8.8.8 MASK 255.255.255.255 " + tb_serverip.Text + " ";
                    NetFramework.Util_CMD.RunHideCmd("route", CMDParammter);
                    CMDParammter = "ADD 114.114.114.114 MASK 255.255.255.255 " + tb_serverip.Text + " ";
                    NetFramework.Util_CMD.RunHideCmd("route", CMDParammter);
                }

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
            var sessionPacket = packet.Extract(typeof(SessionPacket));//ip包  
            if (sessionPacket != null)
            {

                //NetFramework.Console.Write("sessionPacket:" + Encoding.ASCII.GetString(((InternetLinkLayerPacket)sessionPacket).));

            }

            var internetPacket = packet.Extract(typeof(InternetPacket));//ip包  
            if (internetPacket != null)
            {

               // NetFramework.Console.Write("InternetPacket包" + Encoding.ASCII.GetString(((InternetPacket)internetPacket).Header));

            }
            //var pppoePacket = PacketDotNet.PPPoEPacket.Parse(packet.BytesHighPerformance.Bytes); 
            var arpPacket = packet.Extract(typeof(ARPPacket));//ip包  
            if (arpPacket != null)
            {
               // NetFramework.Console.Write("arpPacket：" + ((ARPPacket)arpPacket).SenderProtocolAddress.ToString());
               
            }

            var ipPacket = packet.Extract(typeof(IpPacket));//ip包  
            if (ipPacket != null)
            {
                 
                String FromAddress = ((IpPacket)ipPacket).SourceAddress.ToString();
                String ToAddress = ((IpPacket)ipPacket).DestinationAddress.ToString();
                String Message = "源地址" + ((IpPacket)ipPacket).SourceAddress.ToString()
                     + " ,目的地址" + ((IpPacket)ipPacket).DestinationAddress.ToString();
                // NetFramework.Console.Write("IP:" + Message);

                #region 自动添加
                if (autochange == true)
                {


                    if (

                    (ToAddress.Contains(".") == true && ToAddress.StartsWith("192") == false)
                    && (ToAddress != tb_excuteip.Text)
                    )
                    {
                        String URL = "https://www.ip.cn/api/index?ip=" + ToAddress + "&type=1";

                        String IPCheck = NetFramework.Util_WEB.OpenUrl(URL, "", "", "GET", cc);

                        if (

                            (IPCheck.Contains("美国") || IPCheck.Contains("香港") || IPCheck.Contains("日本") || IPCheck.Contains("台湾") || IPCheck.Contains("新加坡") || IPCheck.Contains("加拿大"))
                            && (IPCheck != tb_excuteip.Text)

                            )
                        {

                            if (RouteTable.ContainsKey(ToAddress) == false)
                            {
                                NetFramework.Console.Write("IP转换" + IPCheck);
                                String CMDParammter = "ADD " + ToAddress + " MASK 255.255.255.255 " + tb_serverip.Text + " ";
                                NetFramework.Util_CMD.RunHideCmd("route", CMDParammter);
                                RouteTable.Add(ToAddress, "run");
                            }
                        }
                    }//符合条件的
                }
                    #endregion
                    #region 添加到本地
                    if (autoadd == true)
                    {
                        if (ToAddress.Contains("."))
                        {
                            if (RouteTable.ContainsKey(ToAddress) == false)
                            {
                                NetFramework.Console.Write("添加到路由" + ToAddress);
                                String CMDParammter = "ADD " + ToAddress + " MASK 255.255.255.255 " + tb_localgateway.Text + " ";
                                NetFramework.Util_CMD.RunHideCmd("route", CMDParammter);
                                RouteTable.Add(ToAddress, "run");
                            }
                        }



                    }
                    #endregion
                
            }

            var udpPacket = packet.Extract(typeof(UdpPacket));//ip包
            if (udpPacket != null)
            {

                //((UdpPacket)udpPacket).
                //NetFramework.Console.Write("TCP:" + Encoding.ASCII.GetString(((UdpPacket)udpPacket).Header));
            }
            var tcpPacket = packet.Extract(typeof(TcpPacket));//ip包  
            if (tcpPacket != null)
            {
                //((TcpPacket)tcpPacket).HO
                //NetFramework.Console.Write("UDP:" + Encoding.ASCII.GetString(((TcpPacket)tcpPacket).Header));
            }

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

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void tb_setserverdefault_Click(object sender, EventArgs e)
        {
            String CMDParammter = "ADD 0.0.0.0 MASK 0.0.0.0 " + tb_serverip.Text + " ";
            NetFramework.Util_CMD.RunHideCmd("route", CMDParammter);
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
                    if (device.Description.ToLower().Contains("oray"))
                    {
                        continue;
                    }
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
            }
            _thread.Abort();
        }
    }

    //https://www.ip.cn/api/index?ip=45.119.126.225&type=1
}
