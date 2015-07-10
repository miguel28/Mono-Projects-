// Type: SysProgUSB.Constants
// Assembly: Master-Prog
// Assembly location: F:\MASTER-PROG\Master-Prog+.exe

namespace SysProgUSB
{
  public class Constants
  {
    public static uint[] BASELINE_CAL = new uint[41]
    {
      3072U,
      37U,
      103U,
      104U,
      105U,
      102U,
      3326U,
      6U,
      1574U,
      2568U,
      1830U,
      2570U,
      112U,
      3202U,
      49U,
      752U,
      2575U,
      753U,
      2575U,
      3321U,
      48U,
      3272U,
      49U,
      1286U,
      0U,
      0U,
      0U,
      0U,
      0U,
      752U,
      2584U,
      0U,
      3321U,
      48U,
      0U,
      0U,
      0U,
      753U,
      2584U,
      1030U,
      2568U
    };
    public static uint[] MR16F676FAM_CAL = new uint[48]
    {
      12288U,
      10245U,
      0U,
      0U,
      9U,
      5763U,
      144U,
      401U,
      415U,
      12542U,
      133U,
      4739U,
      12295U,
      153U,
      389U,
      6277U,
      10255U,
      7301U,
      10257U,
      416U,
      12418U,
      161U,
      2976U,
      10262U,
      2977U,
      10262U,
      12537U,
      160U,
      12488U,
      161U,
      5125U,
      0U,
      0U,
      0U,
      0U,
      0U,
      2976U,
      10271U,
      0U,
      12537U,
      160U,
      0U,
      0U,
      0U,
      2977U,
      10271U,
      4101U,
      10255U
    };
    public const string AppVersion = "3.0";
    public const byte DevFileCompatLevel = (byte) 5;
    public const byte DevFileCompatLevelMin = (byte) 0;
    public const string UserGuideFileName = "\\Instalación.pdf";
    public const byte FWVerMajorReq = (byte) 2;
    public const byte FWVerMinorReq = (byte) 32;
    public const byte FWVerDotReq = (byte) 0;
    public const string FWFileName = "ROM_MPP.bin";
    public const uint PACKET_SIZE = 65U;
    public const uint USB_REPORTLENGTH = 64U;
    public const byte BIT_MASK_0 = (byte) 1;
    public const byte BIT_MASK_1 = (byte) 2;
    public const byte BIT_MASK_2 = (byte) 4;
    public const byte BIT_MASK_3 = (byte) 8;
    public const byte BIT_MASK_4 = (byte) 16;
    public const byte BIT_MASK_5 = (byte) 32;
    public const byte BIT_MASK_6 = (byte) 64;
    public const byte BIT_MASK_7 = (byte) 128;
    public const ushort MChipVendorID = (ushort) 4660;
    public const ushort PUSBDeviceID = (ushort) 51;
    public const ushort ConfigRows = (ushort) 2;
    public const ushort ConfigColumns = (ushort) 4;
    public const ushort NumConfigMasks = (ushort) 8;
    public const float VddThresholdForSelfPoweredTarget = 2.3f;
    public const bool NoMessage = false;
    public const bool ShowMessage = true;
    public const bool UpdateMemoryDisplays = true;
    public const bool DontUpdateMemDisplays = false;
    public const bool EraseEE = true;
    public const bool WriteEE = false;
    public const int UploadBufferSize = 128;
    public const int DownLoadBufferSize = 256;
    public const byte READFWFLASH = (byte) 1;
    public const byte WRITEFWFLASH = (byte) 2;
    public const byte ERASEFWFLASH = (byte) 3;
    public const byte READFWEEDATA = (byte) 4;
    public const byte WRITEFWEEDATA = (byte) 5;
    public const byte RESETFWDEVICE = (byte) 255;
    public const byte ENTER_BOOTLOADER = (byte) 66;
    public const byte NO_OPERATION = (byte) 90;
    public const byte FIRMWARE_VERSION = (byte) 118;
    public const byte SETVDD = (byte) 160;
    public const byte SETVPP = (byte) 161;
    public const byte READ_STATUS = (byte) 162;
    public const byte READ_VOLTAGES = (byte) 163;
    public const byte DOWNLOAD_SCRIPT = (byte) 164;
    public const byte RUN_SCRIPT = (byte) 165;
    public const byte EXECUTE_SCRIPT = (byte) 166;
    public const byte CLR_DOWNLOAD_BUFFER = (byte) 167;
    public const byte DOWNLOAD_DATA = (byte) 168;
    public const byte CLR_UPLOAD_BUFFER = (byte) 169;
    public const byte UPLOAD_DATA = (byte) 170;
    public const byte CLR_SCRIPT_BUFFER = (byte) 171;
    public const byte UPLOAD_DATA_NOLEN = (byte) 172;
    public const byte END_OF_BUFFER = (byte) 173;
    public const byte RESET = (byte) 174;
    public const byte SCRIPT_BUFFER_CHKSUM = (byte) 175;
    public const byte SET_VOLTAGE_CALS = (byte) 176;
    public const byte WR_INTERNAL_EE = (byte) 177;
    public const byte RD_INTERNAL_EE = (byte) 178;
    public const byte ENTER_UART_MODE = (byte) 179;
    public const byte EXIT_UART_MODE = (byte) 180;
    public const byte ENTER_LEARN_MODE = (byte) 181;
    public const byte EXIT_LEARN_MODE = (byte) 182;
    public const byte ENABLE_PK2GO_MODE = (byte) 183;
    public const byte LOGIC_ANALYZER_GO = (byte) 184;
    public const byte COPY_RAM_UPLOAD = (byte) 185;
    public const byte MC_READ_OSCCAL = (byte) 128;
    public const byte MC_WRITE_OSCCAL = (byte) 129;
    public const byte MC_START_CHECKSUM = (byte) 130;
    public const byte MC_VERIFY_CHECKSUM = (byte) 131;
    public const byte MC_CHECK_DEVICE_ID = (byte) 132;
    public const byte MC_READ_BANDGAP = (byte) 133;
    public const byte MC_WRITE_CFG_BANDGAP = (byte) 134;
    public const byte MC_CHANGE_CHKSM_FRMT = (byte) 135;
    public const byte _VDD_ON = (byte) 255;
    public const byte _VDD_OFF = (byte) 254;
    public const byte _VDD_GND_ON = (byte) 253;
    public const byte _VDD_GND_OFF = (byte) 252;
    public const byte _VPP_ON = (byte) 251;
    public const byte _VPP_OFF = (byte) 250;
    public const byte _VPP_PWM_ON = (byte) 249;
    public const byte _VPP_PWM_OFF = (byte) 248;
    public const byte _MCLR_GND_ON = (byte) 247;
    public const byte _MCLR_GND_OFF = (byte) 246;
    public const byte _BUSY_LED_ON = (byte) 245;
    public const byte _BUSY_LED_OFF = (byte) 244;
    public const byte _SET_ICSP_PINS = (byte) 243;
    public const byte _WRITE_BYTE_LITERAL = (byte) 242;
    public const byte _WRITE_BYTE_BUFFER = (byte) 241;
    public const byte _READ_BYTE_BUFFER = (byte) 240;
    public const byte _READ_BYTE = (byte) 239;
    public const byte _WRITE_BITS_LITERAL = (byte) 238;
    public const byte _WRITE_BITS_BUFFER = (byte) 237;
    public const byte _READ_BITS_BUFFER = (byte) 236;
    public const byte _READ_BITS = (byte) 235;
    public const byte _SET_ICSP_SPEED = (byte) 234;
    public const byte _LOOP = (byte) 233;
    public const byte _DELAY_LONG = (byte) 232;
    public const byte _DELAY_SHORT = (byte) 231;
    public const byte _IF_EQ_GOTO = (byte) 230;
    public const byte _IF_GT_GOTO = (byte) 229;
    public const byte _GOTO_INDEX = (byte) 228;
    public const byte _EXIT_SCRIPT = (byte) 227;
    public const byte _PEEK_SFR = (byte) 226;
    public const byte _POKE_SFR = (byte) 225;
    public const byte _ICDSLAVE_RX = (byte) 224;
    public const byte _ICDSLAVE_TX_LIT = (byte) 223;
    public const byte _ICDSLAVE_TX_BUF = (byte) 222;
    public const byte _LOOPBUFFER = (byte) 221;
    public const byte _ICSP_STATES_BUFFER = (byte) 220;
    public const byte _POP_DOWNLOAD = (byte) 219;
    public const byte _COREINST18 = (byte) 218;
    public const byte _COREINST24 = (byte) 217;
    public const byte _NOP24 = (byte) 216;
    public const byte _VISI24 = (byte) 215;
    public const byte _RD2_BYTE_BUFFER = (byte) 214;
    public const byte _RD2_BITS_BUFFER = (byte) 213;
    public const byte _WRITE_BUFWORD_W = (byte) 212;
    public const byte _WRITE_BUFBYTE_W = (byte) 211;
    public const byte _CONST_WRITE_DL = (byte) 210;
    public const byte _WRITE_BITS_LIT_HLD = (byte) 209;
    public const byte _WRITE_BITS_BUF_HLD = (byte) 208;
    public const byte _SET_AUX = (byte) 207;
    public const byte _AUX_STATE_BUFFER = (byte) 206;
    public const byte _I2C_START = (byte) 205;
    public const byte _I2C_STOP = (byte) 204;
    public const byte _I2C_WR_BYTE_LIT = (byte) 203;
    public const byte _I2C_WR_BYTE_BUF = (byte) 202;
    public const byte _I2C_RD_BYTE_ACK = (byte) 201;
    public const byte _I2C_RD_BYTE_NACK = (byte) 200;
    public const byte _SPI_WR_BYTE_LIT = (byte) 199;
    public const byte _SPI_WR_BYTE_BUF = (byte) 198;
    public const byte _SPI_RD_BYTE_BUF = (byte) 197;
    public const byte _SPI_RDWR_BYTE_LIT = (byte) 196;
    public const byte _SPI_RDWR_BYTE_BUF = (byte) 195;
    public const byte _ICDSLAVE_RX_BL = (byte) 194;
    public const byte _ICDSLAVE_TX_LIT_BL = (byte) 193;
    public const byte _ICDSLAVE_TX_BUF_BL = (byte) 192;
    public const byte _MEASURE_PULSE = (byte) 191;
    public const byte _UNIO_TX = (byte) 190;
    public const byte _UNIO_TX_RX = (byte) 189;
    public const byte _JT2_SETMODE = (byte) 188;
    public const byte _JT2_SENDCMD = (byte) 187;
    public const byte _JT2_XFERDATA8_LIT = (byte) 186;
    public const byte _JT2_XFERDATA32_LIT = (byte) 185;
    public const byte _JT2_XFRFASTDAT_LIT = (byte) 184;
    public const byte _JT2_XFRFASTDAT_BUF = (byte) 183;
    public const byte _JT2_XFERINST_BUF = (byte) 182;
    public const byte _JT2_GET_PE_RESP = (byte) 181;
    public const byte _JT2_WAIT_PE_RESP = (byte) 180;
    public const int SEARCH_ALL_FAMILIES = 16777215;
    public const byte PROG_ENTRY = (byte) 0;
    public const byte PROG_EXIT = (byte) 1;
    public const byte RD_DEVID = (byte) 2;
    public const byte PROGMEM_RD = (byte) 3;
    public const byte ERASE_CHIP_PREP = (byte) 4;
    public const byte PROGMEM_ADDRSET = (byte) 5;
    public const byte PROGMEM_WR_PREP = (byte) 6;
    public const byte PROGMEM_WR = (byte) 7;
    public const byte EE_RD_PREP = (byte) 8;
    public const byte EE_RD = (byte) 9;
    public const byte EE_WR_PREP = (byte) 10;
    public const byte EE_WR = (byte) 11;
    public const byte CONFIG_RD_PREP = (byte) 12;
    public const byte CONFIG_RD = (byte) 13;
    public const byte CONFIG_WR_PREP = (byte) 14;
    public const byte CONFIG_WR = (byte) 15;
    public const byte USERID_RD_PREP = (byte) 16;
    public const byte USERID_RD = (byte) 17;
    public const byte USERID_WR_PREP = (byte) 18;
    public const byte USERID_WR = (byte) 19;
    public const byte OSSCAL_RD = (byte) 20;
    public const byte OSSCAL_WR = (byte) 21;
    public const byte ERASE_CHIP = (byte) 22;
    public const byte ERASE_PROGMEM = (byte) 23;
    public const byte ERASE_EE = (byte) 24;
    public const byte ROW_ERASE = (byte) 26;
    public const byte TESTMEM_RD = (byte) 27;
    public const byte EEROW_ERASE = (byte) 28;
    public const int OSCCAL_MASK = 7;
    public const int PROTOCOL_CFG = 0;
    public const int ADR_MASK_CFG = 1;
    public const int ADR_BITS_CFG = 2;
    public const int CS_PINS_CFG = 3;
    public const int I2C_BUS = 1;
    public const int SPI_BUS = 2;
    public const int MICROWIRE_BUS = 3;
    public const int UNIO_BUS = 4;
    public const bool READ_BIT = true;
    public const bool WRITE_BIT = false;
    public const uint FLASHW_STOP = 0U;
    public const uint FLASHW_CAPTION = 1U;
    public const uint FLASHW_TRAY = 2U;
    public const uint FLASHW_ALL = 3U;
    public const uint FLASHW_TIMER = 4U;
    public const uint FLASHW_TIMERNOFG = 12U;
    public const byte ADC_CAL_L = (byte) 0;
    public const byte ADC_CAL_H = (byte) 1;
    public const byte CPP_OFFSET = (byte) 2;
    public const byte CPP_CAL = (byte) 3;
    public const byte UNIT_ID = (byte) 240;
    public const uint P32_PROGRAM_FLASH_START_ADDR = 486539264U;
    public const uint P32_BOOT_FLASH_START_ADDR = 532676608U;

    static Constants()
    {
    }

    public enum PICkit2USB
    {
      found,
      notFound,
      writeError,
      readError,
      firmwareInvalid,
      bootloader,
    }

    public enum PICkit2PWR
    {
      no_response,
      vdd_on,
      vdd_off,
      vdderror,
      vpperror,
      vddvpperrors,
      selfpowered,
      unpowered,
    }

    public enum FileRead
    {
      success,
      failed,
      noconfig,
      partialcfg,
      largemem,
    }

    public enum StatusColor
    {
      normal,
      green,
      yellow,
      red,
    }

    public enum VddTargetSelect
    {
      auto,
      pickit2,
      target,
    }
  }
}
