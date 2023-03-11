using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace VoleyPlaya.Models
{
    internal class CompeticionWrapper
    {
        public string Filename { get; set; }        

        public DateTime Date { get; set; }
        public Competicion Competicion { get; set; }

        public CompeticionWrapper()
        {
            Filename = $"{Path.GetRandomFileName()}.competiciones.txt";
            Date = DateTime.Now;
            Competicion = new Competicion
            {
                Temporada = "",
                Nombre = EnumCompeticiones.Competiciones[0],
                Categoria = EnumCategorias.None,
                Genero = EnumGeneros.None,
                Grupo = "",
                NumEquipos = 0,
                Jornadas = 0,
                Equipos = new List<Equipo>()
            };
        }
        public void Save()
        {
            if (Competicion.NumEquipos != Competicion.Equipos.Count)
            {
                for (int i = Competicion.Equipos.Count; i < Competicion.NumEquipos; i++)
                    Competicion.Equipos.Add(new Equipo(i + 1, string.Empty));
            }

            string jsonString = JsonSerializer.Serialize(Competicion);
            File.WriteAllText(System.IO.Path.Combine(FileSystem.AppDataDirectory, Filename), jsonString);
        }
        public void Delete() =>
            File.Delete(System.IO.Path.Combine(FileSystem.AppDataDirectory, Filename));

        public static CompeticionWrapper Load(string filename)
        {
            filename = System.IO.Path.Combine(FileSystem.AppDataDirectory, filename);

            if (!File.Exists(filename))
                throw new FileNotFoundException("Unable to find file on local storage.", filename);
            string text = File.ReadAllText(filename);
            CompeticionWrapper wrapper = new CompeticionWrapper
                {
                    Filename = Path.GetFileName(filename),
                    Competicion = JsonSerializer.Deserialize<Competicion>(text),
                    Date = File.GetLastWriteTime(filename)
                };
            return wrapper;
        }
        public static IEnumerable<CompeticionWrapper> LoadAll()
        {
            // Get the folder where the notes are stored.
            string appDataPath = FileSystem.AppDataDirectory;

            // Use Linq extensions to load the *.notes.txt files.
            return Directory

                    // Select the file names from the directory
                    .EnumerateFiles(appDataPath, "*.competiciones.txt")

                    // Each file name is used to load a note
                    .Select(filename => CompeticionWrapper.Load(Path.GetFileName(filename)))

                    // With the final collection of notes, order them by date
                    .OrderByDescending(comp => comp.Date);
        }
    }
}
