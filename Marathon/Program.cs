using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

namespace Marathon
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string s = "zhhyv@126.com" + Environment.NewLine;
            s = s + Environment.NewLine;

            StreamReader objReader = new StreamReader("input.txt");
            string sLine = "";
            ArrayList LineList = new ArrayList();
            int i = 0;
            while (sLine != null)
            {
                
                sLine = objReader.ReadLine();
                if (i >= 7)
                {
                    if (sLine.Equals(""))
                        break;
                    sLine = ReplaceUnit(sLine);
                    double result = new ExpressionHelper().CalculateByExpression(sLine);
                    s = s + String.Format("{0:F}", result) + " m" + Environment.NewLine; 
                };
                if (sLine != null && !sLine.Equals(""))
                    LineList.Add(sLine);
                i++;
            }
            objReader.Close();             


            FileStream fs = new FileStream("output.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(s);
            sw.Flush();
            sw.Close();
            fs.Close();

        }

        static string ReplaceUnit(string s)
        {
            s = s.Replace("miles", " * 1609.344");
            s = s.Replace("mile"," * 1609.344");

            s = s.Replace("yards", " * 0.9144");
            s = s.Replace("yard", " * 0.9144");

            s = s.Replace("inches", " * 0.00254");
            s = s.Replace("inch", " * 0.00254");

            s = s.Replace("feet", " * 0.03048");
            s = s.Replace("foot", " * 0.03048");
            

            s = s.Replace("faths", " * 1.8288");
            s = s.Replace("fath", " * 1.8288");

            s = s.Replace("furlongs", " * 201.17");
            s = s.Replace("furlong", " * 201.17");

            return s;
        }


    }
}
