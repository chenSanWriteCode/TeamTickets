using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.IO.Ports;

namespace PosPrintService
{
    /// <summary>
    /// ����OPOSָ����ο�����DLL����  
    ///   
    public class BeiYangOPOS
    {
        const string _DllVer = "1.4";
        /// <summary>
        /// ��ȡ��̬��汾��
        /// </summary>
        public string GetDllVer
        {
            get { return _DllVer;}
        }

      
        /// <summary>
        /// �豸�򿪺�ľ��
        /// </summary>
        public IntPtr POS_IntPtr;

        /// <summary>
        /// ��������ֵ
        /// </summary>
        public uint POS_SUCCESS = 1001;//  ����ִ�гɹ� 
        public uint POS_FAIL = 1002;   //  ����ִ��ʧ�� 
        public uint POS_ERROR_INVALID_HANDLE = 1101; // �˿ڻ��ļ��ľ����Ч 
        public uint POS_ERROR_INVALID_PARAMETER = 1102;// ������Ч 
        public uint POS_ERROR_NOT_BITMAP = 1103 ; // ����λͼ��ʽ���ļ� 
        public uint POS_ERROR_NOT_MONO_BITMAP = 1104;// λͼ���ǵ�ɫ�� 
        public uint POS_ERROR_BEYONG_AREA = 1105 ;//λͼ������ӡ�����Դ���Ĵ�С 
        public uint POS_ERROR_INVALID_PATH = 1106; // û���ҵ�ָ�����ļ�·������ 

        /// <summary>
        /// ֹͣλ
        /// </summary>
        public uint POS_COM_ONESTOPBIT = 0x00;//ֹͣλΪ1
        public uint POS_COM_ONE5STOPBITS = 0x01;//ֹͣλΪ1.5
        public uint POS_COM_TWOSTOPBITS = 0x02;//ֹͣλΪ2
        /// <summary>
        /// ��żУ��
        /// </summary>
        public uint POS_COM_NOPARITY = 0x00;//��У��
        public uint POS_COM_ODDPARITY = 0x01;//��У��
        public uint POS_COM_EVENPARITY = 0x02;//żУ��
        public uint POS_COM_MARKPARITY = 0x03;//���У��
        public uint POS_COM_SPACEPARITY = 0x04;//�ո�У��
        /// <summary>
        /// ����COM�ڲ������˿����Ͷ���
        /// </summary>
        public uint POS_COM_DTR_DSR = 0x00;// ������ΪDTR/DST  
        public uint POS_COM_RTS_CTS = 0x01;// ������ΪRTS/CTS 
        public uint POS_COM_XON_XOFF = 0x02;// ������ΪXON/OFF 
        public uint POS_COM_NO_HANDSHAKE = 0x03;//������ 
        public uint POS_OPEN_PARALLEL_PORT = 0x12;//�򿪲���ͨѶ�˿� 
        public uint POS_OPEN_BYUSB_PORT = 0x13;//��USBͨѶ�˿� 
        public uint POS_OPEN_PRINTNAME = 0X14;// �򿪴�ӡ���������� 
        public uint POS_OPEN_NETPORT = 0x15;// ������ӿ� 

        public uint POS_CUT_MODE_FULL = 0x00;// ȫ�� 
        public uint POS_CUT_MODE_PARTIAL = 0x01;// ���� 
        public uint POS_BARCODE_TYPE_CODE128 = 0x49;//code128

        /// <summary>
        /// ��POS���Ķ˿� ��ʼ�Ự
        /// </summary>
        /// <param name="lpName">
        ///ָ���� null ��β�Ĵ�ӡ�����ƻ�˿����ơ�
        ///������nParam��ֵΪPOS_COM_DTR_DSR��POS_COM_RTS_CTS��POS_COM_XON_XOFF��POS_COM_NO_HANDSHAKE ʱ�� ��COM1������COM2������COM3������COM4���ȱ�ʾ���ڣ�
        ///������nParam��ֵΪPOS_OPEN_PARALLEL_PORTʱ����LPT1������LPT2���ȱ�ʾ���ڣ�
        ///������nParam��ֵΪPOS_OPEN_BYUSB_PORTʱ����BYUSB-0������BYUSB-1������BYUSB-2������BYUSB-3���ȱ�ʾUSB�˿ڡ�
        ///������nParam��ֵΪPOS_OPEN_PRINTNAMEʱ����ʾ��ָ���Ĵ�ӡ����
        ///������nParam��ֵΪPOS_OPEN_NETPORTʱ����ʾ��ָ��������ӿڣ��硰192.168.10.251����ʾ����ӿ�IP��ַ</param>
        /// <param name="nComBaudrate">����ͨ����Ҫ�Ĳ�����</param>
        /// <param name="nComDataBits">����ͨ����Ҫ������λ</param>
        /// <param name="nComStopBits">����ͨ����Ҫ��ֹͣλ</param>
        /// <param name="nComParity">����ͨ����Ҫ���Ƿ�Ҫ��żУ��</param>
        /// <param name="nParam">ָ���� null ��β�Ĵ�ӡ�����ƻ�˿����ơ�
        /// ����nParam��ֵΪPOS_COM_DTR_DSR��POS_COM_RTS_CTS��POS_COM_XON_XOFF��POS_COM_NO_HANDSHAKE ʱ��
        /// ��COM1������COM2������COM3������COM4���ȱ�ʾ���ڣ�
        /// ������nParam��ֵΪPOS_OPEN_PARALLEL_PORTʱ����LPT1������LPT2���ȱ�ʾ���ڣ�
        /// ������nParam��ֵΪPOS_OPEN_BYUSB_PORTʱ����BYUSB-0������BYUSB-1������BYUSB-2������BYUSB-3���ȱ�ʾUSB�˿ڡ�
        /// ������nParam��ֵΪPOS_OPEN_PRINTNAMEʱ����ʾ��ָ���Ĵ�ӡ����</param>
        /// <returns>����������óɹ�������һ���Ѵ򿪵Ķ˿ھ���������������ʧ�ܣ�����ֵΪ INVALID_HANDLE_VALUE ��-1����</returns>
        [DllImport("POSDLL.dll", CharSet = CharSet.Ansi)]
        public static extern IntPtr POS_Open([MarshalAs(UnmanagedType.LPStr)]string lpName, 
                                             uint nComBaudrate, 
                                             uint nComDataBits, 
                                             uint nComStopBits, 
                                             uint nComParity,
                                             uint nParam);

        /// <summary>
        /// �ر��Ѿ��򿪵Ĳ��ڻ򴮿ڣ�USB�˿ڣ�����ӿڻ��ӡ����
        /// </summary>
        /// <returns></returns>
        [DllImport("POSDLL.dll", SetLastError = true)]
        public static extern IntPtr POS_Close();

        /// <summary>
        /// ��λ��ӡ�����Ѵ�ӡ�������е�����������ַ����иߵ����ñ��������ӡģʽ���ָ����ϵ�ʱ��ȱʡģʽ��
        /// </summary>
        /// <returns></returns>
        [DllImport("POSDLL.dll", SetLastError = true)]
        public static extern IntPtr POS_Reset();

        /// <summary>
        /// ���ô�ӡ�����ƶ���λ��
        /// </summary>
        /// <param name="nHorizontalMU">��ˮƽ�����ϵ��ƶ���λ����Ϊ 25.4 / nHorizontalMU ���ס�����Ϊ0��255��</param>
        /// <param name="nVerticalMU">�Ѵ�ֱ�����ϵ��ƶ���λ����Ϊ 25.4 / nVerticalMU ���ס�����Ϊ0��255��</param>
        /// <returns>
        /// ��������ɹ����򷵻�ֵΪ POS_SUCCESS��
        /// �������ʧ�ܣ��򷵻�ֵΪ����ֵ֮һ��POS_FAIL POS_ERROR_INVALID_HANDLE POS_ERROR_INVALID_PARAMETER </returns>
        [DllImport("POSDLL.dll", SetLastError = true)]
        public static extern IntPtr POS_SetMotionUnit(uint nHorizontalMU, uint nVerticalMU);
        /// <summary>
        /// ѡ������ַ����ʹ���ҳ
        /// </summary>
        /// <param name="nCharSet">
        /// ָ�������ַ�������ͬ�Ĺ����ַ�����0x23��0x7E��ASCII��ֵ��Ӧ�ķ��Ŷ����ǲ�ͬ�ġ�
        /// ����Ϊ�����б�������ֵ֮һ��
        /// 0x00 U.S.A  0x01 France  0x02 Germany  0x03 U.K. 0x04 Denmark I 0x05 Sweden 
        /// 0x06 Italy 0x07 Spain I  0x08 Japan 0x09 Nonway 0x0A Denmark II 0x0B Spain II 
        /// 0x0C Latin America 0x0D Korea </param>
        /// <param name="nCodePage">
        /// ָ���ַ��Ĵ���ҳ����ͬ�Ĵ���ҳ��0x80��0xFF��ASCII��ֵ��Ӧ�ķ��Ŷ����ǲ�ͬ�ġ�
        /// 0x00 PC437 [U.S.A. Standard Europe 0x01 Reserved 0x02 PC850 [Multilingual] 
        /// 0x03 PC860 [Portuguese] 0x04 PC863 [Canadian-French] 0x05 PC865 [Nordic] 
        /// 0x12 PC852 0x13 PC858 
        /// </param>
        /// <returns>
        /// ��������ɹ����򷵻�ֵΪ POS_SUCCESS��
        /// �������ʧ�ܣ��򷵻�ֵΪ����ֵ֮һ��POS_FAIL POS_ERROR_INVALID_HANDLE POS_ERROR_INVALID_PARAMETER </returns>
        [DllImport("POSDLL.dll", SetLastError = true)]
        public static extern IntPtr POS_SetCharSetAndCodePage(uint nCharSet, uint nCodePage);

        /// <summary>
        /// POS������ʽ
        /// </summary>
        /// 
        public uint  POS_FONT_TYPE_STANDARD  = 0x00;// ��׼ ASCII 
        public uint  POS_FONT_TYPE_COMPRESSED = 0x01;// ѹ�� ASCII  
        public uint  POS_FONT_TYPE_UDC = 0x02;       // �û��Զ����ַ� 
        public uint  POS_FONT_TYPE_CHINESE = 0x03;   // ��׼ �����塱 
        public uint  POS_FONT_STYLE_NORMAL =  0x00;   //  ���� 
        public uint  POS_FONT_STYLE_BOLD =  0x08;   //  �Ӵ� 
        public uint  POS_FONT_STYLE_THIN_UNDERLINE =  0x80;   //  1��ֵ��»��� 
        public uint  POS_FONT_STYLE_THICK_UNDERLINE =  0x100;   //  2��ֵ��»��� 
        public uint  POS_FONT_STYLE_UPSIDEDOWN =  0x200;   //  ���ã�ֻ��������Ч�� 
        public uint  POS_FONT_STYLE_REVERSE =  0x400;   //  ���ԣ��ڵװ��֣� 
        public uint  POS_FONT_STYLE_SMOOTH =  0x800;   //  ƽ���������ڷŴ�ʱ�� 
        public uint POS_FONT_STYLE_CLOCKWISE_90 = 0x1000;   //  ÿ���ַ�˳ʱ����ת 90 ��

        /// <summary>
        /// �ѽ�Ҫ��ӡ���ַ������ݷ��͵���ӡ�������У���ָ��X ����ˮƽ���ϵľ�����ʼ��λ�ã�
        /// ָ��ÿ���ַ���Ⱥ͸߶ȷ����ϵķŴ��������ͺͷ��
        /// </summary>
        /// <param name="pszString">ָ���� null ��β���ַ���������</param>
        /// <param name="nOrgx">ָ�� X ����ˮƽ������ʼ��λ������߽�ĵ�����</param>
        /// <param name="nWidthTimes">ָ���ַ��Ŀ�ȷ����ϵķŴ���������Ϊ 1�� 6��</param>
        /// <param name="nHeightTimes">ָ���ַ��߶ȷ����ϵķŴ���������Ϊ 1 �� 6��</param>
        /// <param name="nFontType">ָ���ַ����������͡�</param>
        /// <param name="nFontStyle">ָ���ַ���������</param>
        /// <returns></returns>
        
        [DllImport("POSDLL.dll", SetLastError = true)]
        public static extern IntPtr POS_S_TextOut([MarshalAs(UnmanagedType.LPStr)]string pszString, 
                                                   uint nOrgx, uint nWidthTimes, uint nHeightTimes, 
                                                   uint nFontType, uint nFontStyle);

        /// <summary>
        /// ����POS�Ĵ�ӡģʽ (ֻ������ ҳģʽ�ͱ�׼ģʽ)
        /// </summary>
        /// <param name="nPrintMode">
        /// POS_PRINT_MODE_STANDARD 0x00 ��׼ģʽ����ģʽ�� 
        /// POS_PRINT_MODE_PAGE 0x01 ҳģʽ 
        /// POS_PRINT_MODE_BLACK_MARK_LABEL 0x02 �ڱ�Ǳ�ǩģʽ 
        /// POS_PRINT_MODE_WHITE_MARK_LABEL 0x03 �ױ�Ǳ�ǩģʽ </param>
        /// <returns></returns>
        [DllImport("POSDLL.dll", SetLastError = true)]
        public static extern IntPtr POS_SetMode(uint nPrintMode);
        /// <summary>
        /// �����ַ����иߡ�
        /// </summary>
        /// <param name="nDistance">ָ���иߵ���������Ϊ 0 �� 255��ÿ��ľ������ӡͷ�ֱ�����ء�</param>
        /// <returns></returns>
        [DllImport("POSDLL.dll", SetLastError = true)]
        public static extern IntPtr POS_SetLineSpacing(uint nDistance);
        /// <summary>
        /// �����ַ����Ҽ�ࣨ���������ַ��ļ�϶���룩��
        /// </summary>
        /// <param name="nDistance">ָ���Ҽ��ĵ���������Ϊ 0 �� 255��ÿ��ľ������ӡͷ�ֱ�����ء�</param>
        /// <returns></returns>
        [DllImport("POSDLL.dll", SetLastError = true)]
        public static extern IntPtr POS_SetRightSpacing(int nDistance);

        /// <summary>
        /// ��ǰ��ֽ��
        /// 1������ڱ�׼��ӡģʽ����ģʽ���´�ӡ�ı������ӡ�������е����ݣ��Ҵ�ӡλ���Զ��ƶ�����һ�е����ס�
        /// 2������ڱ�׼��ӡģʽ����ģʽ���´�ӡλͼ������ָ����λ�ô�ӡλͼ���Ҵ�ӡλ���Զ��ƶ�����һ�е����ס�
        /// 3�������ҳģʽ���ǩģʽ�£������Ҫ��ӡ������������ָ����λ�ã�ͬʱ�Ѵ�ӡλ���ƶ�����һ�����ף�
        /// ���ǲ���������ֽ����ӡ������һֱ������ POS_PL_Print ����ʱ�Ŵ�ӡ��
        /// </summary>
        /// <returns></returns>
        [DllImport("POSDLL.dll", SetLastError = true)]
        public static extern IntPtr POS_FeedLine();
        /// <summary>
        /// ��ӡͷ��n�� 
        /// </summary>
        /// <returns></returns>
        [DllImport("POSDLL.dll", SetLastError = true)]
        public static extern IntPtr POS_FeedLines(uint nLines);
        
        /// <summary>
        /// ��ֽ
        /// </summary>
        /// <param name="nMode">ģʽ��� ���л���ȫ��</param>
        /// <param name="nDistance">��λ�ľ���</param>
        /// <returns></returns>
        [DllImport("POSDLL.dll", SetLastError = true)]
        public static extern IntPtr POS_CutPaper(uint nMode, uint nDistance);

        /// <summary>
        /// �����ұ߾�
        /// </summary>
        /// <param name="nDistance">�ұ߾�</param>
        /// <returns></returns>
        [DllImport("POSDLL.dll", SetLastError = true)]
        public static extern IntPtr POS_SetRightSpacing(uint nDistance);
        /// <summary>
        /// Ԥ����һ��λͼ����ӡ���� RAM �У�ͬʱָ����λͼ�� ID �š�
        /// </summary>
        /// <param name="pszPath">ָ���� null ��β�ı�ʾλͼ·�������ļ������ַ�����</param>
        /// <param name="nID">ָ����Ҫ���ص�λͼ�� ID �š�����Ϊ 0 �� 7��</param>
        /// <returns></returns>
        [DllImport("POSDLL.dll", SetLastError = true)]
        public static extern IntPtr POS_PreDownloadBmpToRAM([MarshalAs(UnmanagedType.LPStr)]string pszPath, uint nID);
        /// <summary>
        /// ���ز���ӡλͼ
        /// </summary>
        /// <param name="pszPath">ָ����null ��β�İ���λͼ�ļ�·���������Ƶ��ַ�����</param>
        /// <param name="nOrgx">ָ����Ҫ��ӡ��λͼ����߽�ľ������������Ϊ 0�� 65535 �㡣</param>
        /// <param name="nMode">ָ��λͼ�Ĵ�ӡģʽ��</param>
        /// <returns></returns>
        [DllImport("POSDLL.dll", SetLastError = true)]
        public static extern IntPtr POS_S_DownloadAndPrintBmp([MarshalAs(UnmanagedType.LPStr)]string pszPath, uint nOrgx, uint nMode);

        [DllImport("POSDLL.dll", SetLastError = true)]
        public static extern IntPtr POS_S_PrintBmpInRAM(uint nID, uint nOrgx, uint nMode);

        [DllImport("POSDLL.dll", SetLastError = true)]
        public static extern IntPtr POS_S_PrintBmpInFlash(uint nID, uint nOrgx, uint nMode);

        /// <summary>
        /// ͨ�����ڷ��ص�ǰ��ӡ����״̬���˺�����ʵʱ�ġ�
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        [DllImport("POSDLL.dll", SetLastError = true)]
        public static extern IntPtr POS_RTQueryStatus(byte[] address);

        /// <summary>
        /// ͨ�����ڲ�ѯ��ӡ����ǰ��״̬���˺����Ƿ�ʵʱ�ġ�
        /// </summary>
        /// <param name="pszStatus">
        /// ָ�򷵻ص�״̬���ݵĻ���������������СΪ 1 ���ֽڡ�
        /// 0��1 0/1 ��ֽ������ֽ / ֽ���þ� 2��3 0/1 ��ӡͷ����ֽ / ��ֽ 
        /// 4��5 0/1 Ǯ������������ 3 �ĵ�ƽΪ�� / �ߣ���ʾ�򿪻�رգ� 
        /// 6��7 0 �������̶�Ϊ0�� 
        /// </param>
        /// <param name="nTimeouts">���ò�ѯ״̬ʱ��Լ�ĳ�ʱʱ�䣨���룩��</param>
        /// <returns></returns>
        [DllImport("POSDLL.dll", SetLastError = true)]
        public static extern IntPtr POS_QueryStatus(byte[] pszStatus, int nTimeouts);
        /// <summary>
        /// ͨ������ӿڲ�ѯ���ص�ǰ��ӡ����״̬��
        /// </summary>
        /// <param name="ipAddress">�豸IP��ַ���硰192.168.10.251����</param>
        /// <param name="pszStatus">
        /// ָ����շ���״̬�Ļ���������������СΪ 1 ���ֽڡ� 
        /// 0 0/1 Ǯ������������ 3 �ĵ�ƽΪ��/�ߣ���ʾ�򿪻�رգ� 
        /// 1 0/1 ��ӡ������/�ѻ� 
        /// 2 0/1 �ϸǹر�/�� 
        /// 3 0/1 û��/������Feed�����¶���ֽ 
        /// 4 0/1 ��ӡ��û��/�г��� 
        /// 5 0/1 �е�û��/�г��� 
        /// 6 0/1 ��ֽ/ֽ������ֽ����������̽�⣩ 
        /// 7 0/1 ��ֽ/ֽ�þ���ֽ������̽�⣩ 
        /// </param>
        /// <returns></returns>
        [DllImport("POSDLL.dll", SetLastError = true)]
        public static extern int POS_NETQueryStatus([MarshalAs(UnmanagedType.LPStr)]string ipAddress, out Byte pszStatus);

        
        /// <summary>
        /// ���ò���ӡ���롣
        /// </summary>
        /// <param name="pszInfo">ָ���� null ��β���ַ�����ÿ���ַ�����ķ�Χ�͸�ʽ��������������йء�</param>
        /// <param name="nOrgx">ָ����Ҫ��ӡ�������ˮƽ��ʼ������߽�ľ������������Ϊ 0 ��65535��</param>
        /// <param name="nType">
        /// ָ����������͡�����Ϊ�����б�������ֵ֮һ��
        /// POS_BARCODE_TYPE_UPC_A 0x41 UPC-A POS_BARCODE_TYPE_UPC_E 0x42 UPC-C 
        /// POS_BARCODE_TYPE_JAN13 0x43 JAN13(EAN13) POS_BARCODE_TYPE_JAN8 0x44 JAN8(EAN8) 
        /// POS_BARCODE_TYPE_CODE39 0x45 CODE39 POS_BARCODE_TYPE_ITF 0x46 INTERLEAVED 2 OF 5 
        /// POS_BARCODE_TYPE_CODEBAR 0x47 CODEBAR POS_BARCODE_TYPE_CODE93 0x48 25 
        /// POS_BARCODE_TYPE_CODE128 0x49 CODE 128 </param>
        /// <param name="nWidthX">
        /// ָ������Ļ���Ԫ�ؿ�ȡ�
        /// 2 0��25mm 0��25mm 0��625mm 3 0��375mm 0��375mm 1��0mm 4 0��5mm 0��5mm 1��25mm 
        /// 5 0��625mm 0��625mm 1��625mm 6 0��75mm 0��75mm 1.875mm 
        /// </param>
        /// <param name="nheight">ָ������ĸ߶ȵ���������Ϊ 1 �� 255 ��Ĭ��ֵΪ162 �㡣</param>
        /// <param name="nHriFontType">
        /// ָ�� HRI��Human Readable Interpretation���ַ����������͡�����Ϊ�����б�������ֵ֮һ��
        /// POS_FONT_TYPE_STANDARD 0x00 ��׼ASCII POS_FONT_TYPE_COMPRESSED 0x01 ѹ��ASCII 
        /// </param>
        /// <param name="nHriFontPosition">
        /// ָ��HRI��Human Readable Interpretation���ַ���λ�á�
        /// POS_HRI_POSITION_NONE  0x00 ����ӡ POS_HRI_POSITION_ABOVE 0x01 ֻ�������Ϸ���ӡ 
        /// POS_HRI_POSITION_BELOW 0x02 ֻ�������·���ӡ POS_HRI_POSITION_BOTH  0x03 �����ϡ��·�����ӡ 
        /// </param>
        /// <param name="nBytesOfInfo">ָ���ɲ��� pszInfoBufferָ����ַ�������������Ҫ���͸���ӡ�����ַ�����������ֵ�����������йء�</param>
        /// <returns></returns>
        [DllImport("POSDLL.dll", SetLastError = true)]
        public static extern IntPtr POS_S_SetBarcode([MarshalAs(UnmanagedType.LPStr)]string pszInfo,
                                                      uint nOrgx,uint nType,uint nWidthX,uint nheight,
                                                      uint nHriFontType,uint nHriFontPosition,uint nBytesOfInfo);


        [DllImport("POSDLL.dll", SetLastError = true)]
        public static extern IntPtr POS_PL_SetArea(uint nOrgx , uint nOrgY , uint nWidth , uint nheight , uint nDirection );

        [DllImport("POSDLL.dll", SetLastError = true)]
        public static extern IntPtr POS_PL_TextOut([MarshalAs(UnmanagedType.LPStr)]string pszString,uint nOrgx,uint nOrgY, 
                                                   uint nWidthTimes, uint nHeightTimes, uint nFontType, uint nFontStyle);

        [DllImport("POSDLL.dll", SetLastError = true)]
        public static extern IntPtr POS_PL_PrintBmpInRAM(uint nID , uint nOrgx , uint nOrgY , uint nMode );

        [DllImport("POSDLL.dll", SetLastError = true)]
        public static extern IntPtr POS_PL_PrintBmpInFlash(uint nID, uint nOrgx, uint nOrgY, uint nMode);

        [DllImport("POSDLL.dll", SetLastError = true)]
        public static extern IntPtr POS_PL_SetBarcode([MarshalAs(UnmanagedType.LPStr)]string pszInfo, 
                                                       uint nOrgx , uint nOrgY , uint nType , uint nWidthX,uint nheight,
                                                       uint nHriFontType,uint nHriFontPosition,uint nBytesOfInfo);

        [DllImport("POSDLL.dll", SetLastError = true)]
        public static extern IntPtr POS_PL_Clear();

        [DllImport("POSDLL.dll", SetLastError = true)]
        public static extern IntPtr POS_PL_Print();
        /// <summary>
        /// ��Ǯ�����ŷ��������Դ�Ǯ�䡣
        /// </summary>
        /// <param name="nID">ָ��Ǯ������š�0x00 Ǯ������������2 0x01 Ǯ������������5 </param>
        /// <param name="nOnTimes">ָ����Ǯ�䷢�͵ĸߵ�ƽ���屣��ʱ�䣬�� nOnTimes �� 2 ���롣����Ϊ1 �� 255��</param>
        /// <param name="nOffTimes">ָ����Ǯ�䷢�͵ĵ͵�ƽ���屣��ʱ�䣬�� nOffTimes �� 2 ���롣����Ϊ1 �� 255��</param>
        /// <returns></returns>
        [DllImport("POSDLL.dll", SetLastError = true)]
        public static extern IntPtr POS_KickOutDrawer(uint nID, uint nOnTimes, uint nOffTimes);
        /// <summary>
        /// �½�һ����ӡ��ҵ��
        /// </summary>
        /// <returns></returns>
        [DllImport("POSDLL.dll", SetLastError = true)]
        public static extern bool POS_StartDoc();
        /// <summary>
        /// ����һ����ӡ��ҵ��
        /// </summary>
        /// <returns></returns>
        [DllImport("POSDLL.dll", SetLastError = true)]
        public static extern bool POS_EndDoc();
        /// <summary>
        /// �������ݵ��˿ڻ��ļ���ͨ�ö˿ڴ�ӡ����ʹ�ô˺��� һ�㲻�����������С��ʽ��
        /// </summary>
        /// <param name="hPort">�˿ڻ��ļ����������ͨ��POS_Open����ȡ</param>
        /// <param name="pszData">ָ��Ҫ���͵����ݻ�������</param>
        /// <param name="nBytesToWrite">ָ����Ҫ���͵����ݵ��ֽ�����</param>
        /// <returns></returns>
        [DllImport("POSDLL.dll", SetLastError = true)]
        public static extern IntPtr POS_WriteFile(IntPtr hPort, byte[] pszData, uint nBytesToWrite);
        /// <summary>
        /// �Ӵ��ڣ���USB�˿ڻ��ļ������ݵ�ָ���Ļ�������
        /// </summary>
        /// <param name="hPort">�˿ڻ��ļ����������ͨ��POS_Open����ȡ</param>
        /// <param name="pszData">ָ��Ҫ��ȡ�����ݻ�������</param>
        /// <param name="nBytesToRead">���ݵ��ֽ���</param>
        /// <param name="nTimeouts">�����Ƕ�ȡ���ݵļ��ʱ��</param>
        /// <returns></returns>
        [DllImport("POSDLL.dll", SetLastError = true)]
        public static extern IntPtr POS_ReadFile(IntPtr hPort, byte[] pszData, uint nBytesToRead, uint nTimeouts);

        /// <summary>
        /// �򿪴�ӡ�豸�Ĵ���
        /// </summary>
        /// <param name="PrintSerialPort">���ڶ���(��Ҫ�ȳ�ʼ�������Բ�������Ч������£�������)</param>
        /// <returns>�Ƿ�򿪳ɹ�</returns>
        public bool OpenComPort(ref SerialPort PrintSerialPort)
        { 
            uint i_stopbits=0;
            if (PrintSerialPort.StopBits== StopBits.One)
                i_stopbits=POS_COM_ONESTOPBIT;
            if (PrintSerialPort.StopBits== StopBits.OnePointFive)
                i_stopbits=POS_COM_ONE5STOPBITS;
            if (PrintSerialPort.StopBits== StopBits.Two)
                i_stopbits=POS_COM_TWOSTOPBITS;

            uint i_nComParity=0;
            if (PrintSerialPort.Parity== Parity.None)
                i_nComParity=POS_COM_NOPARITY;
            if (PrintSerialPort.Parity== Parity.Even)
                i_nComParity=POS_COM_EVENPARITY;
            if (PrintSerialPort.Parity== Parity.Odd)
                i_nComParity=POS_COM_ODDPARITY;
            if (PrintSerialPort.Parity== Parity.Space)
                i_nComParity=POS_COM_SPACEPARITY;
            if (PrintSerialPort.Parity== Parity.Mark)
                i_nComParity=POS_COM_MARKPARITY;

            uint i_para=0;
            if (PrintSerialPort.Handshake== Handshake.None)
                i_para=POS_COM_NO_HANDSHAKE;
            if (PrintSerialPort.Handshake== Handshake.RequestToSend)
                i_para=POS_COM_DTR_DSR;
            if (PrintSerialPort.Handshake== Handshake.RequestToSendXOnXOff)
                i_para=POS_COM_RTS_CTS;
            if (PrintSerialPort.Handshake== Handshake.XOnXOff)
                i_para=POS_COM_XON_XOFF;

            POS_IntPtr = POS_Open(PrintSerialPort.PortName, 
                                 (uint)PrintSerialPort.BaudRate,
                                 (uint)PrintSerialPort.DataBits,
                                 i_stopbits, i_nComParity, i_para);

            if ((int)POS_IntPtr != -1)
                return true;
            else
                return false;
        }
        /// <summary>
        /// �򿪴�ӡ�豸����
        /// </summary>
        /// <param name="LPTPortName">��������</param>
        /// <returns>�Ƿ�򿪳ɹ�</returns>
        public bool OpenLPTPort(string LPTPortName)
        {
            POS_IntPtr = POS_Open(LPTPortName, 0, 0, 0, 0, POS_OPEN_PARALLEL_PORT);
            if ((int)POS_IntPtr != -1)
                return true;
            else
                return false;
        }
        /// <summary>
        /// �򿪴�ӡ�豸������
        /// </summary>
        /// <param name="IPAddress">�豸��IP��ַ</param>
        /// <returns>�Ƿ�򿪳ɹ�</returns>
        public bool OpenNetPort(string IPAddress)
        {
            POS_IntPtr = POS_Open(IPAddress, 0, 0, 0, 0, POS_OPEN_NETPORT);
            if ((int)POS_IntPtr != -1)
                return true;
            else
                return false;
        }
        /// <summary>
        /// �򿪴�ӡ�豸��USB�˿�
        /// </summary>
        /// <param name="USBPortName">��BYUSB-0������BYUSB-1������BYUSB-2������BYUSB-3��</param>
        /// <returns>�Ƿ�򿪳ɹ�</returns>
        public bool OpenUSBPort(string USBPortName)
        {
            POS_IntPtr = POS_Open(USBPortName, 0, 0, 0, 0, POS_OPEN_BYUSB_PORT);
            if ((int)POS_IntPtr != -1)
                return true;
            else
                return false;
        }
        /// <summary>
        /// ʹ��windows��ӡ��������������OPOS�豸
        /// </summary>
        /// <param name="PrintName">��ӡ���������Ӧ�Ĵ�ӡ������</param>
        /// <returns>�Ƿ�򿪳ɹ�</returns>
        public bool OpenPrinter(string PrintName)
        {
            POS_IntPtr = POS_Open(PrintName, 0, 0, 0, 0, POS_OPEN_PRINTNAME);
            if ((int)POS_IntPtr != -1)
                return true;
            else
                return false;
        }
        /// <summary>
        /// �ر��豸�˿�
        /// </summary>
        /// <returns>�Ƿ�رճɹ�</returns>
        public bool ClosePrinterPort()
        {
            IntPtr tmpIntPtr = POS_Close();
            return ((uint)tmpIntPtr == POS_SUCCESS);
        }
    }
}
