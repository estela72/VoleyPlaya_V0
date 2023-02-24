using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Data
{
    public static partial class LigamaniaEnum
    {
        public enum eCheckClubResponse { ExisteNombre, ExisteAlias, NoExiste}
        public enum eCheckJugadorResponse { ExisteActivo, ExisteInactivo, NoExiste }
        public enum ERol { Master, Super, Admin, Entrenador, Invitado, Manager }
        public enum eTipoCompeticion { Liga, Copa, Supercopa, Pretemporada}
        public enum EEstadoTemporada { UnderConstruction, EnJuego, Finalizada, EnPretemporada, Cerrada }
        public enum eTipoAlineacion { Normal, Cambio, Previa, Nula }
        public enum ETipoLista { Temporada, Competicion, Categoria, Jornada, Equipo,
            Jugador, Entrenador, Estado, Operacion, Club, Puesto, JugadorBaja, ClubBaja, ClubTemporada,
            CategoriaCompeticion, CategoriasActivas, CompeticionActivas, Calendario, JugadorTemporada, JugadorPuestoTemporada,RondaCopa
        }
        public enum eVersionDB { V1, V2 };

        public enum ePuestoCompeticion { Primero,Segundo, Tercero, Pichichi }
        public enum EPremio
        {
            Campeon = 1,        // ronda 7 - ganador
            Subcampeon = 2,     // ronda 7 - perdedor
            Tercero = 3,
            Pichichi = 4,
            Desconocido = 0,    
            Semifinales = 3,    // ronda 6
            Cuartos = 4,        // ronda 5
            Octavos = 5,        // ronda 4
            Dieciseisavos = 6,  // ronda 3
            SegundaRonda = 7,   // ronda 2
            PrimeraRonda = 8,   // ronda 1
            Previa = 9,
            NoParticipo
        }
        public enum eSINO { SI, NO}
        public enum eCriteriosGanador
        {
            [Display(Name = "Criterio no establecido")]
            Ninguno,
            [Display(Name = "Partido contra equipo BOT o Filial")]
            EquipoBOT,
            [Display(Name = "Mayor número de goles marcados en la eliminatoria")]
            NumeroGoles,
            [Display(Name = "Mayor número de goles marcados en campo contrario en la eliminatoria")]
            NumeroGolesCampoContrario,
            [Display(Name = "Menor número de goles EXTRAS conseguidos en la eliminatoria")]
            NumeroGolesExtra,
            [Display(Name = "Mayor número de goleadores distintos")]
            NumeroGoleadoresDistintos,
            [Display(Name = "Mayor número de Porteros que marcan")]
            NumeroPorteros,
            [Display(Name = "Mayor número de Defensas que marcan")]
            NumeroDefensas,
            [Display(Name = "Mayor número de Medios que marcan")]
            NumeroMedios,
            [Display(Name = "Mayor número de minutos jugados (según acta arbitral) de todo el equipo, sumando la ida y la vuelta")]
            MinutosJugados,
            [Display(Name = "Menor número de tarjetas rojas (expulsión por 2 amarillas contará como una roja, pero no como dos amarillas)")]
            TarjetasRojas,
            [Display(Name = "Menor número de tarjetas amarillas (expulsión por 2 amarillas contará como una roja, pero no como dos amarillas)")]
            TarjetasAmarillas,
            [Display(Name = "Mejor promedio de goles a favor en Copa hasta el momento")]
            PromedioGoles,
            [Display(Name = "Mayor número de defensas que no han encajado gol en la eliminatoria")]
            NumeroDefensasSinEncajarGol,
            [Display(Name = "El último gol marcado por cada uno, según la secuencia de partidos disputados en la liga real(es decir, no importa en qué minuto de su partido, sino el momento en el que marca para Ligamanía) ")]
            UltimoGolMarcado,
            [Display(Name = "Sorteo. Si el cupón de la Once del día siguiente a la finalización de la jornada es par, pasará el equipo visitante del partido de vuelta y si es impar, el equipo local")]
            Sorteo,
            [Display(Name="Manual. El administrador de Ligamanía determina manualmente el ganador del partido")]
            Manual
        }
    }

    public static class LigamaniaConst
    {
        public const string Competicion = "Competicion";
        public const string Categoria = "Categoria";
        public const string Jornada = "Jornada";
        public const string Temporada = "Temporada";
        public const string Club = "Club";
        public const string Baja = "Baja";
        public const string Puesto = "Puesto";

        public const string Competicion_Liga = "Liga";
        public const string Competicion_Supercopa = "Supercopa";
        public const string Competicion_Copa = "Copa";
        public const string Competicion_Pretemporada = "Pretemporada";

        public const string Categoria_Golden = "Golden";
        public const string Categoria_SilverA = "Silver A";
        public const string Categoria_SilverB = "Silver B";
        public const string Categoria_Bronze = "Bronze";
        public const string Categoria_SinCategoria = "Sin Categoria";
        public const string SinPreferencia = "Sin Preferencia";

        public const string PasswordInicial = "ligamania";
        public const string Estado_Jornada_Inicial = "JORNADA_INICIAL";

        public const string Operacion_Inicial = "INICIAL";
        public const string Operacion_Abrir_Alineacion = "ABRIR_ALINEACION";
        public const string Operacion_Cerrar_Alineacion = "CERRAR_ALINEACION";
        public const string Operacion_Contar_Jugador = "CONTAR_JUGADORES";
        public const string Operacion_Calcular_Preeliminados = "CALCULAR_PREELIMINADOS";
        public const string Operacion_Publicar_Carrusel = "PUBLICAR_CARRUSEL";
        public const string Operacion_Cerrar_Jornada = "CERRAR_JORNADA";

        public const string Estado_Abrir_Jornada = "ABRIR_JORNADA";

        public const string Operacion_Actualizar_Eliminados = "ACTUALIZAR_ELIMINADOS";
        public const string Operacion_Rescatar_Eliminados = "RESCATAR_ELIMINADOS";
        public const string Operacion_Cambiar_Jornada = "CAMBIAR_JORNADA";
        public const string Operacion_Abrir_Cambios = "ABRIR_CAMBIOS";

        public const string Estado_Cerrar_Jornada = "CERRAR_JORNADA";

        public const string Operacion_Clasificacion = "CLASIFICACION";
        public const string Operacion_Resultados = "ACTUALIZAR_RESULTADOS";
        public const string Operacion_Cerrar_Cambios = "CERRAR_CAMBIOS";
        public const string Operacion_Guardar_Alineacion = "GUARDAR_ALINEACION";
        public const string Operacion_EstablecerGanadores = "ESTABLECER_GANADORES";

        public const string Estado_Temporada_Finalizada = "TEMPORADA_FINALIZADA";
        public const string Operacion_TemporadaVisible = "VISIBLE";

        public const string JI_EstadoInicial = Estado_Jornada_Inicial + "-" + Operacion_Inicial;
        public const string JI_AbrirAli = Estado_Jornada_Inicial + "-" + Operacion_Abrir_Alineacion;
        public const string JI_CerrarAli = Estado_Jornada_Inicial + "-" + Operacion_Cerrar_Alineacion;
        public const string JI_ContarJug = Estado_Jornada_Inicial + "-" + Operacion_Contar_Jugador;
        public const string JI_CalcPre = Estado_Jornada_Inicial + "-" + Operacion_Calcular_Preeliminados;
        public const string JI_PubCarr = Estado_Jornada_Inicial + "-" + Operacion_Publicar_Carrusel;
        public const string JI_CerrarJornada = Estado_Jornada_Inicial + "-" + Operacion_Cerrar_Jornada;

        public const string AJ_ActuEli = Estado_Abrir_Jornada + "-" + Operacion_Actualizar_Eliminados;
        public const string AJ_RescEli = Estado_Abrir_Jornada + "-" + Operacion_Rescatar_Eliminados;
        public const string AJ_CambJor = Estado_Abrir_Jornada + "-" + Operacion_Cambiar_Jornada;
        public const string AJ_AbrirCam = Estado_Abrir_Jornada + "-" + Operacion_Abrir_Cambios;
        public const string AJ_Resultados = Estado_Abrir_Jornada + "-" + Operacion_Resultados;
        public const string AJ_EstablecerGanadores = Estado_Abrir_Jornada + "-" + Operacion_EstablecerGanadores;

        public const string CJ_Clasif = Estado_Cerrar_Jornada + "-" + Operacion_Clasificacion;
        public const string CJ_Resultados = Estado_Cerrar_Jornada + "-" + Operacion_Resultados;
        public const string CJ_CerrarCam = Estado_Cerrar_Jornada + "-" + Operacion_Cerrar_Cambios;
        public const string CJ_GuarAli = Estado_Cerrar_Jornada + "-" + Operacion_Guardar_Alineacion;
        public const string CJ_CalcPre = Estado_Cerrar_Jornada + "-" + Operacion_Calcular_Preeliminados;
        public const string CJ_PubCarr = Estado_Cerrar_Jornada + "-" + Operacion_Publicar_Carrusel;
        public const string CJ_CerrarJornada = Estado_Cerrar_Jornada + "-" + Operacion_Cerrar_Jornada;
        public const string CJ_CambJor = Estado_Cerrar_Jornada + "-" + Operacion_Cambiar_Jornada;

        public const string TF_Visible = Estado_Temporada_Finalizada + "-" + Operacion_TemporadaVisible;

        public const string Puesto_Portero = "Portero";
        public const string Puesto_Delantero = "Delantero";
        public const string Puesto_Medio = "Medio";
        public const string Puesto_Defensa = "Defensa";

        public const string CadenaInicial = "---";
        public const string JugadorAlineacion = "--- - ---";

        public const int Maximo_Veces_Eliminado = 3;
        public const int Numero_Jornadas_Eliminado = 5;

        public const string SinDefinir = "SIN DEFINIR";
        public const string Ganador_Auto = "Automatico";
        public const string Ganador_Manual = "Manual";
        public const string Jugador_Calendario = "Participante";

        public const string SeleccioneElemento = "Seleccione ";
        public const string SI = "SI";
        public const string NO = "NO";

        public const string PuestoDesconocido = "?";
        public const string PuestoCampeon = "CAMPEÓN";
        public const string PuestoSubcampeon = "SUBCAMPEÓN";
        public const string PuestoSemifinales = "SEMIFINALES";
        public const string PuestoCuartos = "CUARTOS DE FINAL";
        public const string PuestoOctavos = "OCTAVOS DE FINAL";
        public const string PuestoDieciseisavos = "DIECISEISAVOS DE FINAL";
        public const string PuestoSegundaRonda = "2ª RONDA";
        public const string PuestoPrimeraRonda = "1ª RONDA";
        public const string PuestoPrevia = "PREVIA";
        public const string PuestoNoParticipo = "NO PARTICIPÓ";

        public const string Equipo_Bay = "Bye";
        public static DateTime MINDATETIME { get; set; } = new DateTime(1753, 1, 1);
        public static List<string> PuestoCopa { get; set; } = new List<string>
        {
            PuestoDesconocido,
            PuestoCampeon,
            PuestoSubcampeon,
            PuestoSemifinales,
            PuestoCuartos,
            PuestoOctavos,
            PuestoDieciseisavos,
            PuestoSegundaRonda,
            PuestoPrimeraRonda,
            PuestoPrevia,
            PuestoNoParticipo
        };
    }
}
