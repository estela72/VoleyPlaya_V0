using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using static System.Net.Mime.MediaTypeNames;

namespace VoleyPlaya.Domain.Models
{
    public class TablaCalendarioWrapper
    {
        public TablaCalendario TablaCalendario { get; set; }
        public string Filename { get; set; }
        public DateTime Date { get; set; }

        public TablaCalendarioWrapper()
        {
            Filename = $"{Path.GetRandomFileName()}.tablaCalendario.txt";
            Date = DateTime.Now;
            TablaCalendario = new TablaCalendario();
        }
        public void Save()
        {
            string jsonString = JsonSerializer.Serialize(TablaCalendario);
            File.WriteAllText(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Filename), jsonString);
        }
        public void Delete() =>
            File.Delete(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Filename));

        public static TablaCalendarioWrapper Load(string filename)
        {
            filename = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), filename);

            if (!File.Exists(filename))
                throw new FileNotFoundException("Unable to find file on local storage.", filename);
            string text = File.ReadAllText(filename);
            return
                new()
                {
                    Filename = Path.GetFileName(filename),
                    TablaCalendario = JsonSerializer.Deserialize<TablaCalendario>(text),
                    Date = File.GetLastWriteTime(filename)
                };
        }
        public static IEnumerable<TablaCalendarioWrapper> LoadAll()
        {
            // Get the folder where the notes are stored.
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            // Use Linq extensions to load the *.notes.txt files.
            return Directory

                    // Select the file names from the directory
                    .EnumerateFiles(appDataPath, "*.tablaCalendario.txt")

                    // Each file name is used to load a note
                    .Select(filename => TablaCalendarioWrapper.Load(Path.GetFileName(filename)))

                    // With the final collection of notes, order them by date
                    .OrderByDescending(tablaCalendario => tablaCalendario.Date);
        }
    }
}
