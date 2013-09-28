using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace LprDatabase
{
    class DbParser
    {
        
        public Rectangle plate { get; set; }

        public List<Character> characters { get; set; }

        public void saveFile(string file)
        {
            int line_cout = characters.Count + 2;

            string[] lines = new string[line_cout];

            lines[0] = plate.Top + " " + plate.Left + " " + plate.Right + " " + plate.Bottom;
            lines[1] = characters.Count.ToString();

            for (int i = 0; i < characters.Count; i++ )
            {
                Character c = characters[i];
                lines[i+2] = c.rec.Top + " " + c.rec.Left + " " + c.rec.Right + " " + c.rec.Bottom + " " +c.val;
            }

            //lines[line_cout-1] = plateValue;

            File.WriteAllLines(file, lines);
        }

        public void parseFile(string file)
        {
            string[] lines = File.ReadAllLines(file);

            plate = getRectangleFromDbLine(lines[0]);

            int nbchars = int.Parse(lines[1]);
            characters = new List<Character>();

            for (int i = 2; i < (nbchars + 2); i++)
            {
                characters.Add(getCharacterFromLine(lines[i]));
            }

            //plateValue = lines[nbchars + 2];
        }

        public DbParser()
        {
        }

        public DbParser(string file)
        {
            parseFile(file);
            
        }

        private Character getCharacterFromLine(string line)
        {
            int top = int.Parse(line.Split(' ')[0]);
            int left = int.Parse(line.Split(' ')[1]);
            int right = int.Parse(line.Split(' ')[2]);
            int bottom = int.Parse(line.Split(' ')[3]);

            int x = left;
            int y = top;
            int width = (right - left);
            int height = (bottom - top);

            Character c = new Character();
            c.rec = new Rectangle(x, y, width, height);
            c.val = char.Parse(line.Split(' ')[4]);

            return c;

        }

        private Rectangle getRectangleFromDbLine(string line)
        {
            int top = int.Parse(line.Split(' ')[0]);
            int left = int.Parse(line.Split(' ')[1]);
            int right = int.Parse(line.Split(' ')[2]);
            int bottom = int.Parse(line.Split(' ')[3]);

            int x = left;
            int y = top;
            int width = (right - left);
            int height = (bottom - top);

            return new Rectangle(x, y, width, height);
        }



    }
}
