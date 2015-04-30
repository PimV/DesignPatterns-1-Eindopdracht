using DP_1.Model;
using DP_1.Model.Gates;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_1.Services
{
    class FileParser
    {
        private string path;
        private string[] schemaText;
        private List<Gate> gates;

        public FileParser()
        {
            path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Schemas";
            schemaText = File.ReadAllLines(path);

            foreach (string line in schemaText)
            {
                int hashCount = 0;
                List<string> gateStrings = new List<string>();
                List<string> inputStrings = new List<string>();
                List<string> outputStrings = new List<string>();

                while (hashCount < 2)
                {
                    if (line.StartsWith("#"))
                    {
                        hashCount++;
                    }
                    if (line.StartsWith("NODE"))
                    {
                        gateStrings.Add(line);
                    }
                    if (line.StartsWith("A") || line.StartsWith("B") || line.StartsWith("Cin"))
                    {
                        inputStrings.Add(line);
                    }
                    if (line.StartsWith("Cout") || line.StartsWith("S"))
                    {
                        outputStrings.Add(line);
                    }
                }
            }
        }

        public List<GateEnum> ParseGates(List<string> gateStrings)
        {
            List<GateEnum> enums = new List<GateEnum>();

            foreach (string gateString in gateStrings)
            {
                string[] splitString = gateString.Split(':');

                switch (splitString[1])
                {
                    case "AND":
                        enums.Add(GateEnum.AND);
                        break;
                    case "OR":
                        enums.Add(GateEnum.OR);
                        break;
                    case "NOT":
                        enums.Add(GateEnum.NOT);
                        break;
                    default:
                        break;
                }
            }
            return enums;
        }

        public List<IOEnums> ParseInputs(List<string> inputStrings)
        {
                      
        }
    }
}
