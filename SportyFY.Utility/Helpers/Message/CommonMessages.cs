using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportyFY.Utility.Helpers.Message
{
    public class CommonMessages
    {
        public enum messageType { INFO, WARNING, ERROR, SUCCESS }

        public static string ShowMsg_Literal(string msg, messageType msgtype)
        {
            string finalmsg = "";
            if (msgtype.ToString().Trim() == "SUCCESS")
            {
                finalmsg = msgtype.ToString().Trim() + " " + msg;
            }
            else if (msgtype.ToString().Trim() == "WARNING")
            {
                finalmsg = msgtype.ToString().Trim() + " " + msg;
            }
            else if (msgtype.ToString().Trim() == "ERROR")
            {
                finalmsg = msgtype.ToString().Trim() + " " + msg;
            }
            else if (msgtype.ToString().Trim() == "INFO")
            {
                finalmsg = msgtype.ToString().Trim() + " " + msg;
            }
            return finalmsg;
        }
    }
}
