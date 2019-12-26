using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECAN;

namespace FIU_Controler
{
    class FunctionCall
    {

        // Fields

        public const int REC_MSG_BUF_MAX = 1000;

        public CAN_OBJ[] gRecMsgBuf;
        public uint gRecMsgBufHead;
        public uint gRecMsgBufTail;


        public const int SEND_MSG_BUF_MAX = 1000;

        public CAN_OBJ[] gSendMsgBuf;
        public uint gSendMsgBufHead;
        public uint gSendMsgBufTail;

        public FunctionCall()
        {
            this.gSendMsgBuf = new CAN_OBJ[SEND_MSG_BUF_MAX];
            this.gSendMsgBufHead = 0;
            this.gSendMsgBufTail = 0;


            this.gRecMsgBuf = new CAN_OBJ[REC_MSG_BUF_MAX];
            this.gRecMsgBufHead = 0;
            this.gRecMsgBufTail = 0;

        }

        public   void ReadMessages(UInt32 DeviceTypetmp, UInt32 DeviceIndTmp, UInt32 CANIndtmp)
        {
            CAN_OBJ mMsg = new CAN_OBJ();

            int sCount = 0;
            while(true)
            { 
                do
                {
                    uint mLen = 1;
                    if (!((CANAPIData.ECANDLL.Receive(DeviceTypetmp, DeviceIndTmp, CANIndtmp, out mMsg, mLen, 1) == ECANStatus.STATUS_OK) & (mLen > 0)))
                    {
                        break;
                    }


                    this.gRecMsgBuf[this.gRecMsgBufHead].ID = mMsg.ID;
                    this.gRecMsgBuf[this.gRecMsgBufHead].DataLen = mMsg.DataLen;
                    this.gRecMsgBuf[this.gRecMsgBufHead].data = mMsg.data;
                    this.gRecMsgBuf[this.gRecMsgBufHead].ExternFlag = mMsg.ExternFlag;
                    this.gRecMsgBuf[this.gRecMsgBufHead].RemoteFlag = mMsg.RemoteFlag;
                    this.gRecMsgBuf[this.gRecMsgBufHead].TimeStamp = mMsg.TimeStamp;
                    this.gRecMsgBuf[this.gRecMsgBufHead].Reserved = mMsg.Reserved;
                    this.gRecMsgBuf[this.gRecMsgBufHead].TimeFlag = mMsg.TimeFlag;
                    this.gRecMsgBufHead += 1;
                    if (this.gRecMsgBufHead >= REC_MSG_BUF_MAX-1)
                    {
                        this.gRecMsgBufHead = 0;
                    }
                    sCount++;
                }
                while (sCount < 500);
            }
        }

     

        //public void SendMessages(UInt32 DeviceTypetmp, UInt32 DeviceIndTmp, UInt32 CANIndtmp)
        //{
        //    CAN_OBJ[] mMsg = new CAN_OBJ[1];
        //    //int aa = 0;

        //    int sCount = 0;
        //    do
        //    {
        //        if (this.gSendMsgBufHead == this.gSendMsgBufTail)
        //        {
        //            break;
        //        }
        //        mMsg[1] = this.gSendMsgBuf[this.gSendMsgBufTail];
        //        this.gSendMsgBufTail += 1;
        //        if (this.gSendMsgBufTail >= SEND_MSG_BUF_MAX)
        //        {
        //            this.gSendMsgBufTail = 0;
        //        }
        //        uint mLen = 1;
        //        //aa = System.Runtime.InteropServices.Marshal.SizeOf(mMsg);
        //        if (CANAPIData.ECANDLL.Transmit(DeviceTypetmp, DeviceIndTmp, CANIndtmp, mMsg, (ushort)mLen) != ECANStatus.STATUS_OK)
        //        {
        //            ;
        //        }
        //        sCount++;
        //    }
        //    while (sCount < 200);
        //}


    }

}
