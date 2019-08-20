using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PosPrintService;
using TeamTickets.Entity;
using TeamTickets.Service;
namespace TeamTickets.Service
{
    public class PrintService
    {
        System.IO.Ports.SerialPort serialPort;
        BeiYangOPOS opos;
        public PrintService()
        {
            serialPort = new System.IO.Ports.SerialPort(ConstInfo.comPort);
            opos = new BeiYangOPOS();
        }
        public Result<string> print(TicketCode ticket)
        {
            Result<string> result = new Result<string>();
            bool openFlag = opos.OpenComPort(ref serialPort);
            if (!openFlag)
            {
                result.addErr("打开端口失败");
                return result;
            }
            try
            {
                BeiYangOPOS.POS_SetRightSpacing(0);
                BeiYangOPOS.POS_S_TextOut($"序号：{ticket.Id} \n\n", 0, 1, 1, opos.POS_FONT_TYPE_CHINESE, opos.POS_FONT_STYLE_NORMAL);
                BeiYangOPOS.POS_S_TextOut("     团体票购买凭证      \n", 0, 2, 2, opos.POS_FONT_TYPE_CHINESE, opos.POS_FONT_STYLE_BOLD);
                BeiYangOPOS.POS_S_TextOut($"     {ticket.Code}      \n", 0, 2, 2, opos.POS_FONT_TYPE_CHINESE, opos.POS_FONT_STYLE_NORMAL);
                BeiYangOPOS.POS_S_TextOut($"团体票：{ticket.TeamCount} |半价票：{ticket.HalfCount}\n", 0, 1, 1, opos.POS_FONT_TYPE_CHINESE, opos.POS_FONT_STYLE_NORMAL);
                BeiYangOPOS.POS_S_TextOut($"导游票：{ticket.GuideCount} |儿童票：{ticket.BabyCount}\n", 0, 1, 1, opos.POS_FONT_TYPE_CHINESE, opos.POS_FONT_STYLE_NORMAL);
                BeiYangOPOS.POS_S_TextOut("------------------------\n", 0, 2, 1, opos.POS_FONT_TYPE_CHINESE, opos.POS_FONT_STYLE_NORMAL);
                BeiYangOPOS.POS_SetLineSpacing(30);

                var notices = ConfigurationManager.AppSettings.AllKeys.Where(x => x.Contains("Ticket_")).OrderBy(x => x).ToList();
                foreach (var item in notices)
                {
                    BeiYangOPOS.POS_S_TextOut(ConfigurationManager.AppSettings[item]+"\n", 0, 1, 1, opos.POS_FONT_TYPE_CHINESE, opos.POS_FONT_STYLE_NORMAL);
                }
                
                BeiYangOPOS.POS_S_TextOut($"【有效期：{ticket.AffectStr}】", 0, 1, 1, opos.POS_FONT_TYPE_CHINESE, opos.POS_FONT_STYLE_NORMAL);

                BeiYangOPOS.POS_FeedLines(10);
                BeiYangOPOS.POS_CutPaper(opos.POS_CUT_MODE_FULL, 100);
                opos.ClosePrinterPort();
            }
            catch (Exception err)
            {
                result.addErr(err.Message);
            }
            
            return result;
        }
        

        
    }
}
