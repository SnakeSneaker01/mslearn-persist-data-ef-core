using System;
using System.Collections.Generic;
using System.IO;

static class ReadingCSV {
    public static List<Person> ReadPersons(string filePath) {
        List<Person> returnPersons = new List<Person>();
        StreamReader reader = new StreamReader(File.OpenRead(filePath));
        List<string> lines = new List<string>();

        while (!reader.EndOfStream) {
            string line = reader.ReadLine();
            lines.Add(line);
        }

        List<string> ret = new List<string>();
        foreach (string line in lines) {
            string[] values = line.Split(',');
            foreach (string value in values)
                if (System.String.IsNullOrWhiteSpace(value))
                    continue;
                else
                    ret.Add(value.Trim());
        }

        for (int i = 0; i < ret.Count; i += 4) {
            string lastname = ret[i];
            string name = ret[i + 1];
            string zipcode = ret[i + 2].Substring(0, 5);
            string city = ret[i + 2].Substring(5).Trim();
            int colorNumber = Int32.Parse(ret[i + 3]);
            Person.Color color = (Person.Color)colorNumber;
            Person person = new Person();
            // person.Id = person.NextID();
            person.Lastname = lastname;
            person.Name = name;
            person.Zipcode = zipcode;
            person.City = city;
            person.color = color;

            // PersonController.persons.Add(person);
            returnPersons.Add(person);
        }
        reader.Close();
        return returnPersons;
    }
}