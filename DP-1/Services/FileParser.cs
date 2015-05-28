using DP_1.Model;
using DP_1.Model.Gates;
using DP_1.Model.Probes;
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
        private Dictionary<string, bool> inputs;
        private List<Probe> outputs;
        private Circuit circuit;
        public Circuit Circuit
        {
            get
            {
                return circuit;
            }
        }

        public FileParser()
        {
            circuit = new Circuit();
            gates = new List<Gate>();
            inputs = new Dictionary<string, bool>();
            outputs = new List<Probe>();
            path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Schemas\\circuit1.txt";
            schemaText = File.ReadAllLines(path);

            Dictionary<string, List<string>> stringContainers = new Dictionary<string, List<string>>();
            stringContainers.Add("gate", new List<string>());
            stringContainers.Add("input", new List<string>());
            stringContainers.Add("output", new List<string>());

            bool switchRead = false;
            foreach (string lineText in schemaText)
            {
                string line = Regex.Replace(lineText, @"\t| ", "");

                if (line.Length == 0)
                {
                    ParseGates(stringContainers["gate"]);
                    ParseInputs(stringContainers["input"]);
                    ParseOutputs(stringContainers["output"]);
                    switchRead = true;
                    continue;
                }
                if (switchRead)
                {
                    readLinkSet(line, stringContainers);
                }
                else
                {
                    readNodeSet(line, stringContainers);
                }
            }

            circuit.Gates = gates;
            circuit.Outputs = outputs;
        }

        public void readLinkSet(string line, Dictionary<string, List<string>> stringContainers)
        {
            if (line.StartsWith("#"))
            {
                return;
            }

            string[] splitString = line.Split(':');

            string name = splitString[0];
            string links = splitString[1].TrimEnd(';');

            string[] linkNodes = links.Split(',');

            //Output
            var toOutput = outputs.Where(r => linkNodes.Contains(r.Name));

            //Input
            var fromInput = inputs.Where(r => r.Key == name);

            //Gate
            var fromGates = gates.Where(r => r.Name == name);
            var toGates = gates.Where(r => linkNodes.Contains(r.Name));

            if (fromGates.Count() == 1)
            {
                Gate fromGate = fromGates.First();
                foreach (Gate g in toGates)
                {
                    circuit.linkGate(fromGate, g);
                    Console.WriteLine("Linking [" + fromGate.Name + "] to [" + g.Name + "]");
                }

                foreach (Probe p in toOutput)
                {
                    circuit.linkProbe(fromGate, p);
                    Console.WriteLine("Outputting [" + fromGate.Name + "] to [" + p.Name + "]");
                }
            }
            else if (fromInput.Count() == 1)
            {
                bool input = fromInput.First().Value;
                foreach (Gate g in toGates)
                {
                    circuit.linkInput(input, g);
                    Console.WriteLine("Input set  [" + input + "] to [" + g.Name + "]");
                }
            }





        }

        public void readNodeSet(string line, Dictionary<string, List<string>> stringContainers)
        {
            int hashCount = 0;


            if (line.StartsWith("#"))
            {
                hashCount++;
            }
            if (line.EndsWith("AND;") || line.EndsWith("OR;") || line.EndsWith("NOT;"))
            {
                stringContainers["gate"].Add(line.TrimEnd(';'));
            }
            if (line.EndsWith("INPUT_HIGH;") || line.EndsWith("INPUT_LOW;"))
            {
                //Console.WriteLine("INPUTTING INTO INPUT: " + line);
                stringContainers["input"].Add(line.TrimEnd(';'));
            }
            if (line.EndsWith("PROBE;"))
            {
                stringContainers["output"].Add(line);
            }
        }

        public List<Gate> ParseGates(List<string> gateStrings)
        {
            //List<Gate> gates = new List<Gate>();
            //gates = new List<Gate>();

            foreach (string gateString in gateStrings)
            {
                string[] splitString = gateString.Split(':');

                string name = splitString[0];
                string type = splitString[1];

                switch (type)
                {
                    case "AND":
                        gates.Add(GateFactory.createGate(GateEnum.AND, name));
                        break;
                    case "OR":
                        gates.Add(GateFactory.createGate(GateEnum.OR, name));
                        break;
                    case "NOT":
                        gates.Add(GateFactory.createGate(GateEnum.NOT, name));
                        break;
                    default:
                        break;
                }
            }
            return gates;
        }

        private void ParseOutputs(List<string> outputStrings)
        {
            foreach (string gateString in outputStrings)
            {

                string[] splitString = gateString.Split(':');

                string name = splitString[0];
                string type = splitString[1];
                Probe p = new Probe();
                p.Name = name;
                outputs.Add(p);
            }
        }

        private void ParseInputs(List<string> inputStrings)
        {
            foreach (string gateString in inputStrings)
            {
                string[] splitString = gateString.Split(':');

                string name = splitString[0];
                string type = splitString[1];
                Console.WriteLine(type);

                if (type.Equals("INPUT_HIGH"))
                {
                    inputs.Add(name, true);
                }
                else if (type.Equals("INPUT_LOW"))
                {
                    inputs.Add(name, false);
                }
            }
        }

        private void LinkEdges(object Component, object[] connectedComponents)
        {
            foreach (var component in connectedComponents)
            {
                // link components
            }
        }

        //public void ParseInputs(List<string> inputStrings)
        //{
        //    foreach (String s in inputStrings)
        //    {
        //        //Console.WriteLine(s);
        //    }
        //}
    }
}
