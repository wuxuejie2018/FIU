﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ECAN
{
   

    public enum ECANStatus : uint
    {
        STATUS_ERR = 0x00000,
        STATUS_OK = 0x00001,
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct CAN_OBJ//can数据结构体
    {
        public uint ID;
        public uint TimeStamp;
        public byte TimeFlag;
        public byte SendType;
        public byte RemoteFlag;
        public byte ExternFlag;
        public byte DataLen;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] data;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] Reserved;
    }
    public struct CAN_ERR_INFO//can错误信息结构体
    {
        public uint ErrCode;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] Passive_ErrData;
        public byte ArLost_ErrData;
    }

    public struct INIT_CONFIG//初始化配置结构体
    {
        public uint AccCode;
        public uint AccMask;
        public uint Reserved;
        public byte Filter;
        public byte Timing0;
        public byte Timing1;
        public byte Mode;
    }
    public struct BOARD_INFO//can板卡的信息
    {
        public ushort hw_Version;
        public ushort fw_Version;
        public ushort dr_Version;
        public ushort in_Version;
        public ushort irq_Num;
        public byte can_Num;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] str_Serial_Num;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
        public byte[] str_hw_Type;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public ushort[] Reserved;
    }

    class CANAPIData
    {
        [DllImport("user32.dll")]
        internal static extern IntPtr FindWindow(string className, string Caption);
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        public static class ECANDLL//外部调用的DLL函数
        {
            

            [DllImport("ECanVci64.dll", EntryPoint = "OpenDevice")]
            public static extern ECANStatus OpenDevice(
                UInt32 DeviceType,
                UInt32 DeviceInd,
                UInt32 Reserved);

            [DllImport("ECanVci64.dll", EntryPoint = "CloseDevice")]
            public static extern ECANStatus CloseDevice(
                UInt32 DeviceType,
                UInt32 DeviceInd);


            [DllImport("ECanVci64.dll", EntryPoint = "InitCAN")]
            public static extern ECANStatus InitCAN(
                UInt32 DeviceType,
                UInt32 DeviceInd,
                UInt32 CANInd,
                ref INIT_CONFIG InitConfig);


            [DllImport("ECanVci64.dll", EntryPoint = "StartCAN")]
            public static extern ECANStatus StartCAN(
                UInt32 DeviceType,
                UInt32 DeviceInd,
                UInt32 CANInd);


            [DllImport("ECanVci64.dll", EntryPoint = "ResetCAN")]
            public static extern ECANStatus ResetCAN(
                UInt32 DeviceType,
                UInt32 DeviceInd,
                UInt32 CANInd);


            [DllImport("ECanVci64.dll", EntryPoint = "Transmit")]
            public static extern ECANStatus Transmit(
                UInt32 DeviceType,
                UInt32 DeviceInd,
                UInt32 CANInd,
                CAN_OBJ[] Send,
                uint mLen,
                UInt16 length);


            [DllImport("ECanVci64.dll", EntryPoint = "Receive")]
            public static extern ECANStatus Receive(
                UInt32 DeviceType,
                UInt32 DeviceInd,
                UInt32 CANInd,
                out CAN_OBJ Receive,
                UInt32 length,
                UInt32 WaitTime);

            [DllImport("ECanVci64.dll", EntryPoint = "ReadErrInfo")]
            public static extern ECANStatus ReadErrInfo(
                UInt32 DeviceType,
                UInt32 DeviceInd,
                UInt32 CANInd,
                out CAN_ERR_INFO ReadErrInfo);



            [DllImport("ECanVci64.dll", EntryPoint = "ReadBoardInfo")]
            public static extern ECANStatus ReadBoardInfo(
                UInt32 DeviceType,
                UInt32 DeviceInd,
                out BOARD_INFO ReadErrInfo);

        }
    }
}
