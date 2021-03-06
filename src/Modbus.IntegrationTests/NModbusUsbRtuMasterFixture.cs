using System;
using FtdAdapter;
using Modbus.Device;
using NUnit.Framework;

namespace Modbus.IntegrationTests
{
	[TestFixture]
	public class NModbusUsbRtuMasterFixture
	{
		[Test, ExpectedException(typeof(TimeoutException))]
		public void NModbusUsbRtuMaster_ReadTimeout()
		{
			var port = ModbusMasterFixture.CreateAndOpenUsbPort(ModbusMasterFixture.DefaultMasterUsbPortId);
			using (var master = ModbusSerialMaster.CreateRtu(port))
			{
				master.Transport.ReadTimeout = master.Transport.WriteTimeout = 1000;
				master.ReadCoils(100, 1, 1);
			}
		}
	}
}
