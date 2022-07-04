using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Dapper;
namespace  TP11_CursosWeb.Models
{
    public static class BD {
        private static string _connectionString = @"Server=DESKTOP-2N6B5NK\SQLEXPRESS; DataBase=BDWebCursos; Trusted_Connection=True;";
        
        public static Curso ConsultaCurso(int IdCurso) {
            Curso CursoElegido = null;
            string sql = "SELECT * FROM CURSOS WHERE IdCurso = @pIdCurso";
            using (SqlConnection db = new SqlConnection (_connectionString)) {
                CursoElegido = db.QueryFirstOrDefault<Curso>(sql, new { pIdCurso = IdCurso });
            }
            return CursoElegido;
        }

        public static Especialidad ConsultaEspecialidad(int IdEspecialidad) {
            Especialidad EspecialidadElegida = null;
            string sql = "SELECT * FROM ESPECIALIDADES WHERE IdEspecialidad = @pIdEspecialidad";
            using (SqlConnection db = new SqlConnection (_connectionString)) {
                EspecialidadElegida = db.QueryFirstOrDefault<Especialidad>(sql, new { pIdEspecialidad = IdEspecialidad });
            }
            return EspecialidadElegida;
        }

        public static List<Curso> ListarCursos (int IdEspecialidad) {
            List<Curso> ListadoCursos = new List<Curso>();
            List<Curso> ListadoCursosxEspecialidad = new List<Curso>();
            if (IdEspecialidad == -1) {
                string sql = "SELECT * FROM Cursos";
                using (SqlConnection db = new SqlConnection (_connectionString)) {
                    ListadoCursos = db.Query<Curso>(sql).ToList();
                }            
                return ListadoCursos;     
            }
            else {
                string sql = "SELECT * FROM Cursos WHERE IdEspecialidad = @pIdEspecialidad";
                using (SqlConnection db = new SqlConnection (_connectionString)) {
                    ListadoCursosxEspecialidad = db.Query<Curso>(sql, new { pIdEspecialidad = IdEspecialidad }).ToList();
                }            
                return ListadoCursosxEspecialidad;
            }
        }
        public static List<Especialidad> ListarEspecialidades() {
            List<Especialidad> ListadoEspecialidades = new List<Especialidad>();
            string sql = "SELECT * FROM ESPECIALIDADES";
                using (SqlConnection db = new SqlConnection (_connectionString)) {
                ListadoEspecialidades = db.Query<Especialidad>(sql).ToList();
            }
            return ListadoEspecialidades;
        }

        public static void AgregarCurso(Curso UnCurso) {
            string sql = "INSERT INTO CURSOS(Nombre, IdEspecialidad, Descripcion, Imagen, UrlCurso, MeGusta, NoMeGusta) VALUES (@pNombre, @pIdEspecialidad, @pDescripcion, @pImagen, @pUrlCurso, @pMeGusta, @pNoMeGusta)";
            using (SqlConnection db = new SqlConnection (_connectionString)) {
                db.Execute(sql, new { @pNombre = UnCurso.Nombre, @pIdEspecialidad = UnCurso.IdEspecialidad, @pDescripcion = UnCurso.Descripcion, @pImagen = UnCurso.Imagen, @pUrlCurso = UnCurso.UrlCurso, @pMeGusta = UnCurso.MeGusta, @pNoMeGusta = UnCurso.NoMeGusta});
            }
        }

        public static void CalificarCurso(int IdCurso, bool Gusta) {
            if(Gusta == true){
                string sql = "UPDATE Cursos SET MeGusta = MeGusta + 1 WHERE IdCurso = @pIdCurso";
                using (SqlConnection db = new SqlConnection (_connectionString)) {
                    db.Execute(sql, new {@pIdCurso = IdCurso});
                }
            }
            else{
                string sql = "UPDATE Cursos SET NoMeGusta = NoMeGusta + 1 WHERE IdCurso = @pIdCurso";
                using (SqlConnection db = new SqlConnection (_connectionString)) {
                     db.Execute(sql, new {@pIdCurso = IdCurso});
                }
            }
        }
    }
}