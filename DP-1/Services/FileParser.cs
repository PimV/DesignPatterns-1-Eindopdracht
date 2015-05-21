using DP_1.Model;
using DP_1.Model.Gates;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Schemas\\circuit1.txt";
            schemaText = File.ReadAllLines(path);

            List<string> gateStrings = new List<string>();
            List<string> inputStrings = new List<string>();
            List<string> outputStrings = new List<string>();

            foreach (string lineText in schemaText)
            {
                int hashCount = 0;
                string line = Regex.Replace(lineText, @"\t", "");

                if (line.StartsWith("#"))
                {
                    hashCount++;
                }
                if (line.EndsWith("AND;") || line.EndsWith("OR;") || line.EndsWith("NOT;"))
                {
                    gateStrings.Add(line.TrimEnd(';'));
                }
                if (line.EndsWith("INPUT_HIGH;") || line.EndsWith("INPUT_LOW;"))
                {
                    inputStrings.Add(line);
                }
                if (line.EndsWith("PROBE"))
                {
                    outputStrings.Add(line);
                }
            }
            ParseGates(gateStrings);
            //ParseInputs(inputStrings);
            //ParseOutputs(outputStrings);
        }

        public List<Gate> ParseGates(List<string> gateStrings)
        {
            List<Gate> gates = new List<Gate>();

            foreach (string gateString in gateStrings)
            {
                string[] splitString = gateString.Split(':');

                switch (splitString[1])
                {
                    case "AND":
                        gates.Add(new ANDGate());
                        break;
                    case "OR":
                        gates.Add(new ORGate());
                        break;
                    case "NOT":
                        gates.Add(new NOTGate());
                        break;
                    default:
                        break;
                }
            }
            return gates;
        }

        //private List<Probe> ParseOutputs(List<string> outputStrings)
        //{
        //    List<Probe> probes = new List<Probe>();

        //    foreach (string outputString in outputStrings)
        //    {
        //        string[] splitString = outputString.Split(':');

        //        switch (splitString[1])
        //        {
        //            case "AND":
        //                gates.Add(new ANDGate());
        //                break;
        //            case "OR":
        //                gates.Add(new ORGate());
        //                break;
        //            case "NOT":
        //                gates.Add(new NOTGate());
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    return gates;
        //}

        //private void ParseInputs(List<string> inputStrings)
        //{
        //    throw new NotImplementedException();
        //}

        private void LinkEdges(object Component, object[] connectedComponents)
        {
            foreach (var component in connectedComponents)
            {
                // link components
            }
        }

        //public List<IOEnums> ParseInputs(List<string> inputStrings)
        //{
        //    return null;
        //}
    }
}
