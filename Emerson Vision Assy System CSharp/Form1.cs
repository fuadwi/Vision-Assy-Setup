using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using RYB_PTL_API;

namespace Emerson_Vision_Assy_System_CSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            String IP = "192.168.80.251";
            RYB_PTL.RYB_PTL_Connect(IP, 6020);
            RYB_PTL.UserResultAvailable += RYB_PTL_UserResultAvailable;
            }
        Boolean flagComplete = false;
        Boolean flagOnAction = false;
        int actionNum = 0;
        private void RYB_PTL_UserResultAvailable(RYB_PTL.RtnValueStruct rs)
        {
            String IP = "192.168.80.251";
            Console.WriteLine("Tag ID = " + rs.Tagid);
            Console.WriteLine("Number = " + rs.Number);
            Console.WriteLine("Locator = " + rs.Locator);
            Console.WriteLine("KeyCode = " + rs.KeyCode);
            
                if (rs.Tagid == "FFE5")
                {
                    if (flagOnAction)
                    {
                        RYB_PTL.RYB_PTL_AisleLamp(IP, "FFF4", 5, 3); //FFF4 ADALAH NO ADDRESS TOWERLAMP
                        return;
                    }
                    if (rs.Number == "4547648203388")
                    {
                        RYB_PTL.RYB_PTL_DspDigit5(IP, "0001", 10, 3, 1);
                        RYB_PTL.RYB_PTL_DspDigit5(IP, "0002", 16, 4, 2);
                        flagOnAction = true;

                    }
                    if (rs.Number == "4547648203395")
                    {
                        RYB_PTL.RYB_PTL_DspDigit5(IP, "0003", 3, 3, 1);
                        RYB_PTL.RYB_PTL_DspDigit5(IP, "0004", 2, 4, 2);
                        flagOnAction = true;
                    }
                }
        }
     
    }
}
