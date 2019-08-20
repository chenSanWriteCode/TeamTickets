using System;
using System.Text;
using System.Runtime.InteropServices;
using TeamTickets.Entity;
using System.Timers;

namespace TeamTickets.Service
{
    public partial class ReadID
    {
        /// <summary>
        /// 扫描身份证
        /// </summary>
        private Timer scanTimer;
        /// <summary>
        /// 判断是否在工作，即身份证有没有在机器上
        /// </summary>
        private Timer workingTimer;
        private bool workingflag=false;
        private int port;
        public Action<IDCard> receivedID;
        public ReadID(int port = 1001)
        {
            scanTimer = new Timer();
            scanTimer.AutoReset = true;
            scanTimer.Interval = 1000;
            scanTimer.Enabled = true;
            scanTimer.Elapsed += ScanTimer_Elapsed;

            workingTimer = new Timer(400);
            workingTimer.AutoReset = true;
            workingTimer.Elapsed += WorkingTimer_Elapsed;

            this.port = port;
        }
        public void start()
        {
            int intOpenRet = InitComm(port);
            if (intOpenRet != 1)
            {
                throw new Exception($"无法打开端口号{port}");
            }
            else
            { 
                scanTimer.Start();
            }

        }
        public void end()
        {
            scanTimer.Stop();
            workingTimer.Stop();
            int flag = CloseComm();
            if (flag!=1)
            {
                throw new Exception($"端口号{port}关闭失败");
            }
        }

        private void WorkingTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (workingflag)
            {
                int intReadRet = Authenticate();
                if (intReadRet == 0)
                {
                    workingflag = false;
                    workingTimer.Stop();
                }
            }
        }

        private void ScanTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!workingflag)
            {
                int intReadRet = Authenticate();
                if (intReadRet == 1)
                {
                    workingflag = true;
                    ReadIDCard();
                    workingTimer.Start();
                }
            };
        }
        public void ReadIDCard()
        {
            StringBuilder Name = new StringBuilder(31);
            StringBuilder Gender = new StringBuilder(3);
            StringBuilder Folk = new StringBuilder(10);
            StringBuilder BirthDay = new StringBuilder(9);
            StringBuilder Code = new StringBuilder(19);
            StringBuilder Address = new StringBuilder(71);
            StringBuilder Agency = new StringBuilder(31);
            StringBuilder ExpireStart = new StringBuilder(9);
            StringBuilder ExpireEnd = new StringBuilder(9);
            
            //读身份证信息 
            int intReadBaseInfosRet = ReadBaseInfos(Name, Gender, Folk, BirthDay, Code, Address, Agency, ExpireStart, ExpireEnd);
            if (intReadBaseInfosRet == 1)
            {
                IDCard CardData = new IDCard();
                CardData.Code = Code.ToString().Trim();
                CardData.Name = Name.ToString().Trim();
                CardData.Gender = Gender.ToString().Trim();
                CardData.Flok = Folk.ToString().Trim();
                CardData.BirthDay = BirthDay.ToString().Trim();
                CardData.Address = Address.ToString().Trim();
                CardData.Agency = Agency.ToString().Trim();
                CardData.ExpireStart = ExpireStart.ToString().Trim();
                CardData.ExpireEnd = ExpireEnd.ToString().Trim();
                //CardData.PhotoDirectory +=  "//photo.bmp";
                receivedID?.Invoke(CardData);
            }
        }

        [DllImport("Sdtapi.dll")]
        private static extern int InitComm(int iPort);
        [DllImport("Sdtapi.dll")]
        private static extern int Authenticate();
        [DllImport("Sdtapi.dll")]
        private static extern int ReadBaseInfos(StringBuilder Name, StringBuilder Gender, StringBuilder Folk,
                                                    StringBuilder BirthDay, StringBuilder Code, StringBuilder Address,
                                                        StringBuilder Agency, StringBuilder ExpireStart, StringBuilder ExpireEnd);
        [DllImport("Sdtapi.dll")]
        private static extern int CloseComm();
        [DllImport("Sdtapi.dll")]
        private static extern int ReadBaseMsg(byte[] pMsg, ref int len);
        [DllImport("Sdtapi.dll")]
        private static extern int ReadBaseMsgW(byte[] pMsg, ref int len);
    }
}