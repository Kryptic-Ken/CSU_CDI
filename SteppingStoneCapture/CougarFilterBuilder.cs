using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteppingStoneCapture
{
    class CougarFilterBuilder
    {
        public List<string> protocols = new List<string>();
        public List<string> attributes = new List<string>();

        public void AddToProtocolList(string stringToAdd)
        {
            AddToFilterLists(stringToAdd, true);
        }

        public void AddToAttributeList(string stringToAdd)
        {
            AddToFilterLists(stringToAdd, false);
        }

        public void ClearFilterLists()
        {
            ClearAttributesList();
            ClearProtocolList();
        }

        public string BuildFilterString()
        {
            string captureString = "";

            if (NonEmptyAttributesList() || NonEmptyProtocolList())
            {
                for (int protoIndx = 0; protoIndx < protocols.Count; ++protoIndx)
                {
                    string current = protocols[protoIndx];
                    for (int attrIndx = 0; attrIndx < attributes.Count; ++attrIndx)
                    {
                        if (protocols[protoIndx].CompareTo("DNS") != 0)
                        {
                                current += " and " + attributes[attrIndx];
                        }
                        else
                        {
                            if (attrIndx == 0)
                                current =  "udp port 53 or tcp port 53";
                        } 
                    }

                    if (protoIndx < protocols.Count - 1)
                        captureString += current + " or ";
                    else
                        captureString += current;
                }
            }

            return captureString.Trim().ToLower();
        }

        private void ClearProtocolList()
        {
            protocols.Clear();
        }

        private void ClearAttributesList()
        {
            attributes.Clear();
        }

        private string CombineEqualIndexedItems()
        {
            return "";
        }

        private void AddToFilterLists(string stringToAdd, bool isProtocol)
        {
            if (isProtocol)
                protocols.Add(stringToAdd);
            else
                attributes.Add(stringToAdd);
        }

        private bool NonEmptyProtocolList()
        {
            return (protocols.Count > 0);
        }

        private bool NonEmptyAttributesList()
        {
            return (attributes.Count > 0);
        }
    }
}
