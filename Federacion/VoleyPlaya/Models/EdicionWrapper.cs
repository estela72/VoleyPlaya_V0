using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

using VoleyPlaya.Repository.Services;

namespace VoleyPlaya.Models
{
    public class EdicionWrapper
    {
        public string Filename { get; set; }        
        public string EdicionName { get; set; }
        public DateTime Date { get; set; }
        public Edicion Edicion { get; set; }
        public EdicionWrapper()
        {
            Filename = $"{Path.GetRandomFileName()}.competiciones.txt";
            EdicionName = "";
            Date = DateTime.Now;
            Edicion = new Edicion
            {
                Temporada = "",
                Nombre = EnumCompeticiones.Competiciones[0],
                Categoria = EnumCategorias.None,
                Genero = EnumGeneros.None,
                Grupo = "",
                NumEquipos = 0,
                NumJornadas = 0,
                Equipos = new List<Equipo>(),
                Partidos = new List<Partido>()
            };
        }
        public async Task Save()
        {
            EdicionName = VoleyPlayaService.GetNombreEdicion(Edicion.Temporada, Edicion.Nombre, Edicion.CategoriaStr, Edicion.GeneroStr, Edicion.Grupo);
            await GenerarPartidos();
            string jsonString = JsonSerializer.Serialize(Edicion);
            File.WriteAllText(System.IO.Path.Combine(FileSystem.AppDataDirectory, Filename), jsonString);
        }
        public void Delete()
        {
            File.Delete(System.IO.Path.Combine(FileSystem.AppDataDirectory, Filename));
        }
        public static EdicionWrapper Load(string filename)
        {
            filename = System.IO.Path.Combine(FileSystem.AppDataDirectory, filename);

            if (!File.Exists(filename))
                throw new FileNotFoundException("Unable to find file on local storage.", filename);
            string text = File.ReadAllText(filename);
            EdicionWrapper wrapper = new ()
                {
                    Filename = Path.GetFileName(filename),
                    Edicion = JsonSerializer.Deserialize<Edicion>(text),
                    Date = File.GetLastWriteTime(filename)
                };
            return wrapper;
        }
        public static IEnumerable<EdicionWrapper> LoadAll()
        {
            // Get the folder where the notes are stored.
            string appDataPath = FileSystem.AppDataDirectory;

            // Use Linq extensions to load the *.notes.txt files.
            return Directory

                    // Select the file names from the directory
                    .EnumerateFiles(appDataPath, "*.competiciones.txt")

                    // Each file name is used to load a note
                    .Select(filename => EdicionWrapper.Load(Path.GetFileName(filename)))

                    // With the final collection of notes, order them by date
                    .OrderByDescending(comp => comp.Date);
        }
        internal async Task GenerarPartidos()
        {
            await Edicion.GenerarPartidosAsync();
        }
        internal async Task Update()
        {
            string jsonString = JsonSerializer.Serialize(Edicion);
            File.WriteAllText(System.IO.Path.Combine(FileSystem.AppDataDirectory, Filename), jsonString);
        }
        internal static EdicionWrapper FromJson(JsonNode edicionJson)
        {
            EdicionWrapper wrapper = new()
            {
                Filename = string.Empty,
                EdicionName = edicionJson["Nombre"].GetValue<string>(),
                Edicion = Edicion.FromJson(edicionJson),
                Date = edicionJson["UpdatedDate"].GetValue<DateTime>()
            };
            return wrapper;
        }
    }
}
