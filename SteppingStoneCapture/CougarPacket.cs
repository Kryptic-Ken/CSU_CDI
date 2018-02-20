using PcapDotNet.Packets.IpV4;

namespace SteppingStoneCapture
{
    class CougarPacket
    {
        private int packetNumber;
        private string timeStamp;
        private int length;
        private IpV4Address sourceAddress;
        private IpV4Address destAddress;

        public string TimeStamp { get => timeStamp; set => timeStamp = value; }
        public int PacketNumber { get => packetNumber; set => packetNumber = value; }
        public int Length { get => length; set => length = value; }
        public IpV4Address SourceAddress { get => sourceAddress; set => sourceAddress = value; }
        public IpV4Address DestAddress { get => destAddress; set => destAddress = value; }
        
        public CougarPacket(string timeStamp = "-",
                            int packetNumber = 0,
                            int length = 0,
                            string sourceIp = "-",
                            string destinationIp = "-")
        {
            TimeStamp = timeStamp;
            PacketNumber = packetNumber;
            Length = length;
            sourceAddress = new IpV4Address(sourceIp);
            destAddress = new IpV4Address(destinationIp);
        }

        public override string ToString()
        {
            string description = string.Format("{0},{1},{2},{3},{4}",
                                                PacketNumber,
                                                TimeStamp,
                                                Length,
                                                SourceAddress,
                                                DestAddress);
            return description;
        }

        public string[] toPropertyArray()
        {
            string[] propertyArray = new string[5];

            propertyArray[0] = PacketNumber.ToString();
            propertyArray[1] = TimeStamp.ToString();
            propertyArray[2] = SourceAddress.ToString();
            propertyArray[3] = DestAddress.ToString();
            propertyArray[4] = Length.ToString();

            return propertyArray;
        }
    }
}
