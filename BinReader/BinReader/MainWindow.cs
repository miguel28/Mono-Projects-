using System;
using System.IO;
using System.Text;
using Gtk;
using BinReader;

public partial class MainWindow: Gtk.Window
{	
	public static DeviceFile DevFile = new DeviceFile();
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		ReadDeviceFile("/Users/mike/Desktop/MASTER-PROG/Dispositivos.bin");
		//WriteDeviceFile ("/Users/mike/Desktop/MASTER-PROG/Dispositivos.bin2");
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	private static int[] familySearchTable;
	public static bool ReadDeviceFile(string DeviceFileName)
	{
		if (!File.Exists(DeviceFileName))
			return false;
		try
		{
			FileStream fileStream = File.OpenRead(DeviceFileName);
			using (BinaryReader binaryReader = new BinaryReader((Stream) fileStream))
			{
				DevFile.Info.VersionMajor = binaryReader.ReadInt32();
				Console.WriteLine(DevFile.Info.VersionMajor.ToString());

				DevFile.Info.VersionMinor = binaryReader.ReadInt32();
				Console.WriteLine(DevFile.Info.VersionMinor.ToString());

				DevFile.Info.VersionDot = binaryReader.ReadInt32();
				Console.WriteLine(DevFile.Info.VersionDot.ToString());

				DevFile.Info.VersionNotes = binaryReader.ReadString();
				Console.WriteLine(DevFile.Info.VersionNotes);

				DevFile.Info.NumberFamilies = binaryReader.ReadInt32();
				Console.WriteLine(DevFile.Info.NumberFamilies);

				DevFile.Info.NumberParts = binaryReader.ReadInt32();
				Console.WriteLine(DevFile.Info.NumberParts);

				DevFile.Info.NumberScripts = binaryReader.ReadInt32();
				Console.WriteLine(DevFile.Info.NumberScripts.ToString());

				DevFile.Info.Compatibility = binaryReader.ReadByte();
				Console.WriteLine(DevFile.Info.Compatibility.ToString());

				DevFile.Info.UNUSED1A = binaryReader.ReadByte();
				Console.WriteLine(DevFile.Info.UNUSED1A.ToString());

				DevFile.Info.UNUSED1B = binaryReader.ReadUInt16();
				Console.WriteLine(DevFile.Info.UNUSED1B.ToString());

				DevFile.Info.UNUSED2 = binaryReader.ReadUInt32();
				Console.WriteLine(DevFile.Info.UNUSED2.ToString());
				//DeviceFileVersion = string.Format("{0:D1}.{1:D2}.{2:D2}", (object) DevFile.Info.VersionMajor, (object) DevFile.Info.VersionMinor, (object) DevFile.Info.VersionDot);
				DevFile.Families = new DeviceFile.DeviceFamilyParams[DevFile.Info.NumberFamilies];
				DevFile.PartsList = new DeviceFile.DevicePartParams[DevFile.Info.NumberParts];
				DevFile.Scripts = new DeviceFile.DeviceScripts[DevFile.Info.NumberScripts];
				//Console.WriteLine("============");
				int index = 0;
				for (index = 0; index < 3; ++index)
				{
					DevFile.Families[index].FamilyID = binaryReader.ReadUInt16();
					Console.WriteLine(DevFile.Families[index].FamilyID.ToString());

					DevFile.Families[index].FamilyType = binaryReader.ReadUInt16();
				Console.WriteLine(DevFile.Families[index].FamilyType.ToString());

					DevFile.Families[index].SearchPriority = binaryReader.ReadUInt16();
				Console.WriteLine(DevFile.Families[index].SearchPriority.ToString());

					DevFile.Families[index].FamilyName = binaryReader.ReadString();
				Console.WriteLine(DevFile.Families[index].FamilyName.ToString());

					DevFile.Families[index].ProgEntryScript = binaryReader.ReadUInt16();
				Console.WriteLine(DevFile.Families[index].ProgEntryScript.ToString());

					DevFile.Families[index].ProgExitScript = binaryReader.ReadUInt16();
				Console.WriteLine(DevFile.Families[index].ProgExitScript.ToString());

					DevFile.Families[index].ReadDevIDScript = binaryReader.ReadUInt16();
				Console.WriteLine(DevFile.Families[index].ReadDevIDScript.ToString());

					DevFile.Families[index].DeviceIDMask = binaryReader.ReadUInt32();
				Console.WriteLine(DevFile.Families[index].DeviceIDMask.ToString());

					DevFile.Families[index].BlankValue = binaryReader.ReadUInt32();
				Console.WriteLine(DevFile.Families[index].BlankValue.ToString());

					DevFile.Families[index].BytesPerLocation = binaryReader.ReadByte();
				Console.WriteLine(DevFile.Families[index].BytesPerLocation.ToString());

					DevFile.Families[index].AddressIncrement = binaryReader.ReadByte();
				Console.WriteLine(DevFile.Families[index].AddressIncrement.ToString());

					DevFile.Families[index].PartDetect = binaryReader.ReadBoolean();
				Console.WriteLine(DevFile.Families[index].PartDetect.ToString());

					DevFile.Families[index].ProgEntryVPPScript = binaryReader.ReadUInt16();
				Console.WriteLine(DevFile.Families[index].ProgEntryVPPScript.ToString());

					DevFile.Families[index].UNUSED1 = binaryReader.ReadUInt16();
				Console.WriteLine(DevFile.Families[index].UNUSED1.ToString());

					DevFile.Families[index].EEMemBytesPerWord = binaryReader.ReadByte();
				Console.WriteLine(DevFile.Families[index].EEMemBytesPerWord.ToString());

					DevFile.Families[index].EEMemAddressIncrement = binaryReader.ReadByte();
				Console.WriteLine(DevFile.Families[index].EEMemAddressIncrement.ToString());

					DevFile.Families[index].UserIDHexBytes = binaryReader.ReadByte();
				Console.WriteLine(DevFile.Families[index].UserIDHexBytes.ToString());

					DevFile.Families[index].UserIDBytes = binaryReader.ReadByte();
				Console.WriteLine(DevFile.Families[index].UserIDBytes.ToString());

					DevFile.Families[index].ProgMemHexBytes = binaryReader.ReadByte();
				Console.WriteLine(DevFile.Families[index].ProgMemHexBytes.ToString());

					DevFile.Families[index].EEMemHexBytes = binaryReader.ReadByte();
				Console.WriteLine(DevFile.Families[index].EEMemHexBytes.ToString());

					DevFile.Families[index].ProgMemShift = binaryReader.ReadByte();
				Console.WriteLine(DevFile.Families[index].ProgMemShift.ToString());

					DevFile.Families[index].TestMemoryStart = binaryReader.ReadUInt32();
				Console.WriteLine(DevFile.Families[index].TestMemoryStart.ToString());

					DevFile.Families[index].TestMemoryLength = binaryReader.ReadUInt16();
				Console.WriteLine(DevFile.Families[index].TestMemoryLength.ToString());

					DevFile.Families[index].Vpp = binaryReader.ReadSingle();
				Console.WriteLine(DevFile.Families[index].Vpp.ToString());
				Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>");
				}
				/*familySearchTable = new int[DevFile.Info.NumberFamilies];
				int index1 = 0;
				for(index = 0; index < DevFile.Info.NumberFamilies; ++index)
					familySearchTable[(int) DevFile.Families[index].SearchPriority] = index;
				for (index1 = 0; index1 < DevFile.Info.NumberParts; ++index1)
				{
					DevFile.PartsList[index1].PartName = binaryReader.ReadString();
					DevFile.PartsList[index1].Family = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].DeviceID = binaryReader.ReadUInt32();
					DevFile.PartsList[index1].ProgramMem = binaryReader.ReadUInt32();
					DevFile.PartsList[index1].EEMem = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].EEAddr = binaryReader.ReadUInt32();
					DevFile.PartsList[index1].ConfigWords = binaryReader.ReadByte();
					DevFile.PartsList[index1].ConfigAddr = binaryReader.ReadUInt32();
					DevFile.PartsList[index1].UserIDWords = binaryReader.ReadByte();
					DevFile.PartsList[index1].UserIDAddr = binaryReader.ReadUInt32();
					DevFile.PartsList[index1].BandGapMask = binaryReader.ReadUInt32();
					DevFile.PartsList[index1].ConfigMasks = new ushort[8];
					DevFile.PartsList[index1].ConfigBlank = new ushort[8];
					for (int index2 = 0; index2 < 8; ++index2)
						DevFile.PartsList[index1].ConfigMasks[index2] = binaryReader.ReadUInt16();
					for (int index2 = 0; index2 < 8; ++index2)
						DevFile.PartsList[index1].ConfigBlank[index2] = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].CPMask = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].CPConfig = binaryReader.ReadByte();
					DevFile.PartsList[index1].OSSCALSave = binaryReader.ReadBoolean();
					DevFile.PartsList[index1].IgnoreAddress = binaryReader.ReadUInt32();
					DevFile.PartsList[index1].VddMin = binaryReader.ReadSingle();
					DevFile.PartsList[index1].VddMax = binaryReader.ReadSingle();
					DevFile.PartsList[index1].VddErase = binaryReader.ReadSingle();
					DevFile.PartsList[index1].CalibrationWords = binaryReader.ReadByte();
					DevFile.PartsList[index1].ChipEraseScript = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].ProgMemAddrSetScript = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].ProgMemAddrBytes = binaryReader.ReadByte();
					DevFile.PartsList[index1].ProgMemRdScript = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].ProgMemRdWords = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].EERdPrepScript = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].EERdScript = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].EERdLocations = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].UserIDRdPrepScript = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].UserIDRdScript = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].ConfigRdPrepScript = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].ConfigRdScript = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].ProgMemWrPrepScript = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].ProgMemWrScript = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].ProgMemWrWords = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].ProgMemPanelBufs = binaryReader.ReadByte();
					DevFile.PartsList[index1].ProgMemPanelOffset = binaryReader.ReadUInt32();
					DevFile.PartsList[index1].EEWrPrepScript = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].EEWrScript = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].EEWrLocations = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].UserIDWrPrepScript = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].UserIDWrScript = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].ConfigWrPrepScript = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].ConfigWrScript = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].OSCCALRdScript = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].OSCCALWrScript = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].DPMask = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].WriteCfgOnErase = binaryReader.ReadBoolean();
					DevFile.PartsList[index1].BlankCheckSkipUsrIDs = binaryReader.ReadBoolean();
					DevFile.PartsList[index1].IgnoreBytes = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].ChipErasePrepScript = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].BootFlash = binaryReader.ReadUInt32();
					DevFile.PartsList[index1].UNUSED4 = binaryReader.ReadUInt32();
					DevFile.PartsList[index1].ProgMemEraseScript = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].EEMemEraseScript = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].ConfigMemEraseScript = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].reserved1EraseScript = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].reserved2EraseScript = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].TestMemoryRdScript = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].TestMemoryRdWords = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].EERowEraseScript = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].EERowEraseWords = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].ExportToMPLAB = binaryReader.ReadBoolean();
					DevFile.PartsList[index1].DebugHaltScript = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].DebugRunScript = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].DebugStatusScript = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].DebugReadExecVerScript = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].DebugSingleStepScript = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].DebugBulkWrDataScript = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].DebugBulkRdDataScript = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].DebugWriteVectorScript = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].DebugReadVectorScript = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].DebugRowEraseScript = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].DebugRowEraseSize = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].DebugReserved5Script = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].DebugReserved6Script = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].DebugReserved7Script = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].DebugReserved8Script = binaryReader.ReadUInt16();
					DevFile.PartsList[index1].DebugReserved9Script = binaryReader.ReadUInt16();
				}
				for (index1 = 0; index1 < DevFile.Info.NumberScripts; ++index1)
				{
					DevFile.Scripts[index1].ScriptNumber = binaryReader.ReadUInt16();
					DevFile.Scripts[index1].ScriptName = binaryReader.ReadString();
					DevFile.Scripts[index1].ScriptVersion = binaryReader.ReadUInt16();
					DevFile.Scripts[index1].UNUSED1 = binaryReader.ReadUInt32();
					DevFile.Scripts[index1].ScriptLength = binaryReader.ReadUInt16();
					DevFile.Scripts[index1].Script = new ushort[(int) DevFile.Scripts[index1].ScriptLength];
					for (int index2 = 0; index2 < (int) DevFile.Scripts[index1].ScriptLength; ++index2)
						DevFile.Scripts[index1].Script[index2] = binaryReader.ReadUInt16();
					DevFile.Scripts[index1].Comment = binaryReader.ReadString();
				}*/
				binaryReader.Close();
			}
			fileStream.Close();
		}
		catch
		{
			return false;
		}
		return true;
	}

	public static bool WriteDeviceFile(string DeviceFileName)
	{
		//if (!File.Exists(DeviceFileName+"2"))
		//	return false;
		try
		{
			FileStream fileStream = File.OpenWrite(DeviceFileName);
			using (BinaryWriter binaryWriter = new BinaryWriter((Stream) fileStream))
			{
				binaryWriter.Write(DevFile.Info.VersionMajor);  //.ReadInt32();

				binaryWriter.Write(DevFile.Info.VersionMinor);  //.ReadInt32();

				binaryWriter.Write(DevFile.Info.VersionDot);  //.ReadInt32();

				binaryWriter.Write(DevFile.Info.VersionNotes);  //.ReadString();

				binaryWriter.Write(DevFile.Info.NumberFamilies);  //.ReadInt32();

				binaryWriter.Write(DevFile.Info.NumberParts);  //.ReadInt32();

				binaryWriter.Write(DevFile.Info.NumberScripts);  //.ReadInt32();

				binaryWriter.Write(DevFile.Info.Compatibility);  //.ReadByte();
				binaryWriter.Write(DevFile.Info.UNUSED1A);  //.ReadByte();
				binaryWriter.Write(DevFile.Info.UNUSED1B);  //.ReadUInt16();
				Console.WriteLine(DevFile.Info.UNUSED1B.ToString());
				binaryWriter.Write(DevFile.Info.UNUSED2);  //.ReadUInt32();


				int index = 0;
				for (index = 0; index < DevFile.Info.NumberFamilies; ++index)
				{
					binaryWriter.Write(DevFile.Families[index].FamilyID);  //.ReadUInt16();
					//	Console.WriteLine(binaryWriter.Write(DevFile.Families[index].FamilyID.ToString());

					binaryWriter.Write(DevFile.Families[index].FamilyType);  //.ReadUInt16();
					//Console.WriteLine(binaryWriter.Write(DevFile.Families[index].FamilyType.ToString());

					binaryWriter.Write(DevFile.Families[index].SearchPriority);  //.ReadUInt16();
					//Console.WriteLine(binaryWriter.Write(DevFile.Families[index].SearchPriority.ToString());

					binaryWriter.Write(DevFile.Families[index].FamilyName);  //.ReadString();
					//Console.WriteLine(binaryWriter.Write(DevFile.Families[index].FamilyName.ToString());

					binaryWriter.Write(DevFile.Families[index].ProgEntryScript);  //.ReadUInt16();
					//Console.WriteLine(binaryWriter.Write(DevFile.Families[index].ProgEntryScript.ToString());

					binaryWriter.Write(DevFile.Families[index].ProgExitScript);  //.ReadUInt16();
					//Console.WriteLine(binaryWriter.Write(DevFile.Families[index].ProgExitScript.ToString());

					binaryWriter.Write(DevFile.Families[index].ReadDevIDScript);  //.ReadUInt16();
					//Console.WriteLine(binaryWriter.Write(DevFile.Families[index].ReadDevIDScript.ToString());

					binaryWriter.Write(DevFile.Families[index].DeviceIDMask);  //.ReadUInt32();
					//Console.WriteLine(binaryWriter.Write(DevFile.Families[index].DeviceIDMask.ToString());

					binaryWriter.Write(DevFile.Families[index].BlankValue);  //.ReadUInt32();
					//Console.WriteLine(binaryWriter.Write(DevFile.Families[index].BlankValue.ToString());

					binaryWriter.Write(DevFile.Families[index].BytesPerLocation);  //.ReadByte();
					//Console.WriteLine(binaryWriter.Write(DevFile.Families[index].BytesPerLocation.ToString());

					binaryWriter.Write(DevFile.Families[index].AddressIncrement);  //.ReadByte();
					//Console.WriteLine(binaryWriter.Write(DevFile.Families[index].AddressIncrement.ToString());

					binaryWriter.Write(DevFile.Families[index].PartDetect);  //.ReadBoolean();
					//Console.WriteLine(binaryWriter.Write(DevFile.Families[index].PartDetect.ToString());

					binaryWriter.Write(DevFile.Families[index].ProgEntryVPPScript);  //.ReadUInt16();
					//Console.WriteLine(binaryWriter.Write(DevFile.Families[index].ProgEntryVPPScript.ToString());

					binaryWriter.Write(DevFile.Families[index].UNUSED1);  //.ReadUInt16();
					//Console.WriteLine(binaryWriter.Write(DevFile.Families[index].UNUSED1.ToString());

					binaryWriter.Write(DevFile.Families[index].EEMemBytesPerWord);  //.ReadByte();
					//Console.WriteLine(binaryWriter.Write(DevFile.Families[index].EEMemBytesPerWord.ToString());

					binaryWriter.Write(DevFile.Families[index].EEMemAddressIncrement);  //.ReadByte();
					//Console.WriteLine(binaryWriter.Write(DevFile.Families[index].EEMemAddressIncrement.ToString());

					binaryWriter.Write(DevFile.Families[index].UserIDHexBytes);  //.ReadByte();
					//Console.WriteLine(binaryWriter.Write(DevFile.Families[index].UserIDHexBytes.ToString());

					binaryWriter.Write(DevFile.Families[index].UserIDBytes);  //.ReadByte();
					//Console.WriteLine(binaryWriter.Write(DevFile.Families[index].UserIDBytes.ToString());

					binaryWriter.Write(DevFile.Families[index].ProgMemHexBytes);  //.ReadByte();
					//Console.WriteLine(binaryWriter.Write(DevFile.Families[index].ProgMemHexBytes.ToString());

					binaryWriter.Write(DevFile.Families[index].EEMemHexBytes);  //.ReadByte();
					//Console.WriteLine(binaryWriter.Write(DevFile.Families[index].EEMemHexBytes.ToString());

					binaryWriter.Write(DevFile.Families[index].ProgMemShift);  //.ReadByte();
					//Console.WriteLine(binaryWriter.Write(DevFile.Families[index].ProgMemShift.ToString());

					binaryWriter.Write(DevFile.Families[index].TestMemoryStart);  //.ReadUInt32();
					//Console.WriteLine(binaryWriter.Write(DevFile.Families[index].TestMemoryStart.ToString());

					binaryWriter.Write(DevFile.Families[index].TestMemoryLength);  //.ReadUInt16();
					//Console.WriteLine(binaryWriter.Write(DevFile.Families[index].TestMemoryLength.ToString());

					binaryWriter.Write(Convert.ToDouble(DevFile.Families[index].Vpp));  //.ReadSingle();
					//Console.WriteLine(DevFile.Families[index].Vpp.ToString());
					//Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>");
				}

				for (index = 0; index < DevFile.Info.NumberFamilies; ++index)
						familySearchTable[(int) DevFile.Families[index].SearchPriority] = index;
				int index1 =0;
				for (index1 = 0; index1 < DevFile.Info.NumberParts; ++index1)
					{
						binaryWriter.Write(DevFile.PartsList[index1].PartName);  //.ReadString();
						binaryWriter.Write(DevFile.PartsList[index1].Family);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].DeviceID);  //.ReadUInt32();
						binaryWriter.Write(DevFile.PartsList[index1].ProgramMem);  //.ReadUInt32();
						binaryWriter.Write(DevFile.PartsList[index1].EEMem);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].EEAddr);  //.ReadUInt32();
						binaryWriter.Write(DevFile.PartsList[index1].ConfigWords);  //.ReadByte();
						binaryWriter.Write(DevFile.PartsList[index1].ConfigAddr);  //.ReadUInt32();
						binaryWriter.Write(DevFile.PartsList[index1].UserIDWords);  //.ReadByte();
						binaryWriter.Write(DevFile.PartsList[index1].UserIDAddr);  //.ReadUInt32();
						binaryWriter.Write(DevFile.PartsList[index1].BandGapMask);  //.ReadUInt32();

						for (int index2 = 0; index2 < 8; ++index2)
							binaryWriter.Write(DevFile.PartsList[index1].ConfigMasks[index2]);  //.ReadUInt16();
						for (int index2 = 0; index2 < 8; ++index2)
							binaryWriter.Write(DevFile.PartsList[index1].ConfigBlank[index2]);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].CPMask);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].CPConfig);  //.ReadByte();
						binaryWriter.Write(DevFile.PartsList[index1].OSSCALSave);  //.ReadBoolean();
						binaryWriter.Write(DevFile.PartsList[index1].IgnoreAddress);  //.ReadUInt32();
						binaryWriter.Write(Convert.ToDouble(DevFile.PartsList[index1].VddMin));  //.ReadSingle();
						binaryWriter.Write(Convert.ToDouble(DevFile.PartsList[index1].VddMax));  //.ReadSingle();
					    binaryWriter.Write(Convert.ToDouble(DevFile.PartsList[index1].VddErase));  //.ReadSingle();
						binaryWriter.Write(DevFile.PartsList[index1].CalibrationWords);  //.ReadByte();
						binaryWriter.Write(DevFile.PartsList[index1].ChipEraseScript);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].ProgMemAddrSetScript);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].ProgMemAddrBytes);  //.ReadByte();
						binaryWriter.Write(DevFile.PartsList[index1].ProgMemRdScript);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].ProgMemRdWords);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].EERdPrepScript);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].EERdScript);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].EERdLocations);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].UserIDRdPrepScript);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].UserIDRdScript);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].ConfigRdPrepScript);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].ConfigRdScript);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].ProgMemWrPrepScript);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].ProgMemWrScript);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].ProgMemWrWords);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].ProgMemPanelBufs);  //.ReadByte();
						binaryWriter.Write(DevFile.PartsList[index1].ProgMemPanelOffset);  //.ReadUInt32();
						binaryWriter.Write(DevFile.PartsList[index1].EEWrPrepScript);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].EEWrScript);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].EEWrLocations);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].UserIDWrPrepScript);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].UserIDWrScript);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].ConfigWrPrepScript);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].ConfigWrScript);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].OSCCALRdScript);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].OSCCALWrScript);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].DPMask);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].WriteCfgOnErase);  //.ReadBoolean();
						binaryWriter.Write(DevFile.PartsList[index1].BlankCheckSkipUsrIDs);  //.ReadBoolean();
						binaryWriter.Write(DevFile.PartsList[index1].IgnoreBytes);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].ChipErasePrepScript);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].BootFlash);  //.ReadUInt32();
						binaryWriter.Write(DevFile.PartsList[index1].UNUSED4);  //.ReadUInt32();
						binaryWriter.Write(DevFile.PartsList[index1].ProgMemEraseScript);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].EEMemEraseScript);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].ConfigMemEraseScript);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].reserved1EraseScript);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].reserved2EraseScript);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].TestMemoryRdScript);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].TestMemoryRdWords);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].EERowEraseScript);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].EERowEraseWords);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].ExportToMPLAB);  //.ReadBoolean();
						binaryWriter.Write(DevFile.PartsList[index1].DebugHaltScript);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].DebugRunScript);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].DebugStatusScript);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].DebugReadExecVerScript);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].DebugSingleStepScript);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].DebugBulkWrDataScript);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].DebugBulkRdDataScript);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].DebugWriteVectorScript);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].DebugReadVectorScript);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].DebugRowEraseScript);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].DebugRowEraseSize);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].DebugReserved5Script);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].DebugReserved6Script);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].DebugReserved7Script);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].DebugReserved8Script);  //.ReadUInt16();
						binaryWriter.Write(DevFile.PartsList[index1].DebugReserved9Script);  //.ReadUInt16();
					}
					for (index1 = 0; index1 < DevFile.Info.NumberScripts; ++index1)
					{
						binaryWriter.Write(DevFile.Scripts[index1].ScriptNumber);  //.ReadUInt16();
						binaryWriter.Write(DevFile.Scripts[index1].ScriptName);  //.ReadString();
						binaryWriter.Write(DevFile.Scripts[index1].ScriptVersion);  //.ReadUInt16();
						binaryWriter.Write(DevFile.Scripts[index1].UNUSED1);  //.ReadUInt32();
						binaryWriter.Write(DevFile.Scripts[index1].ScriptLength);  //.ReadUInt16();
						for (int index2 = 0; index2 < (int) DevFile.Scripts[index1].ScriptLength; ++index2)
							binaryWriter.Write(DevFile.Scripts[index1].Script[index2]);  //.ReadUInt16();
							
						binaryWriter.Write(DevFile.Scripts[index1].Comment);  //.ReadString();
					}
							                   
					binaryWriter.Close();
				}
				fileStream.Close();
			}
			catch
			{
				return false;
			}
			return true;
		}

}
