using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteppingStoneCapture
{
    class CougarFilterBuilder
    {
        private List<string> protocols = new List<string>();
        private List<string> attributes = new List<string>();

        public void addToFilterLists(string stringToAdd, bool isProtocol)
        {
            if (isProtocol)
                protocols.Add(stringToAdd);
            else
                attributes.Add(stringToAdd);
        }

        public string buildFilterString()
        {
            string captureString = "";

            if (nonEmptyAttributesList() && nonEmptyProtocolList())
            {
                for (int protoIndx = 0; protoIndx < protocols.Count; ++protoIndx)
                {
                    for (int attrIndx = 0; attrIndx < attributes.Count; ++attrIndx)
                    {
                        if ((protoIndx != protocols.Count-1) && (attrIndx != attributes.Count-1))
                        {
                            captureString += protocols[protoIndx] + " " + attributes[attrIndx] + " or ";
                        }
                        else
                        {
                            captureString += protocols[protoIndx] + " " + attributes[attrIndx];
                        }
                    }
                }
            }

            return captureString;
        }

        private bool nonEmptyProtocolList()
        {
            return (protocols.Count > 0);
        }

        private bool nonEmptyAttributesList()
        {
            return (attributes.Count > 0);
        }
    }
}
