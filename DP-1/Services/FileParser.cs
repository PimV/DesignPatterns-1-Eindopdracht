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

        private int gatesCreated;
        private int inputsCreated;
        private int outputsCreated;
        

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
        }

        public void parse(string filePath)
        {
            inputsCreated = 0;
            gatesCreated = 0;
            outputsCreated = 0;

            path = filePath;
            //path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Schemas\\circuit1.txt";
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

            Console.WriteLine("Parse Results: ");
            Console.WriteLine("Inputs found: " + inputsCreated);
            Console.WriteLine("Outputs found: " + outputsCreated);
            Console.WriteLine("Gates found: " + gatesCreated);
            Console.WriteLine("Total objects created: " + (gatesCreated + inputsCreated + outputsCreated));

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
                }

                foreach (Probe p in toOutput)
                {
                    circuit.linkProbe(fromGate, p);
                }
            }
            else if (fromInput.Count() == 1)
            {
                bool input = fromInput.First().Value;
                foreach (Gate g in toGates)
                {
                    circuit.linkInput(input, g);
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
                stringContainers["input"].Add(line.TrimEnd(';'));
            }
            if (line.EndsWith("PROBE;"))
            {
                stringContainers["output"].Add(line);
            }
        }

        public List<Gate> ParseGates(List<string> gateStrings)
        {
            foreach (string gateString in gateStrings)
            {
                string[] splitString = gateString.Split(':');

                string name = splitString[0];
                string type = splitString[1];

                switch (type)
                {
                    case "AND":
                        gates.Add(GateFactory.createGate(GateEnum.AND, name));
                        gatesCreated++;
                        break;
                    case "OR":
                        gates.Add(GateFactory.createGate(GateEnum.OR, name));
                        gatesCreated++;
                        break;
                    case "NOT":
                        gates.Add(GateFactory.createGate(GateEnum.NOT, name));
                        gatesCreated++;
                        break;
                    default:
                        Console.WriteLine("Unknown gate found: " + type);
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
                outputsCreated++;
            }
        }

        private void ParseInputs(List<string> inputStrings)
        {
            foreach (string gateString in inputStrings)
            {
                string[] splitString = gateString.Split(':');

                string name = splitString[0];
                string type = splitString[1];

                if (type.Equals("INPUT_HIGH"))
                {
                    
                    inputs.Add(name, true);
                    inputsCreated++;
                }
                else if (type.Equals("INPUT_LOW"))
                {
                    inputs.Add(name, false);
                    inputsCreated++;
                }
            }
        }
    }
}
