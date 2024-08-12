using System.Data;
using System.Data.SqlClient;
using Dapper;
public class BD
{
    private static string _connectionString = @"Server=localhost; DataBase=JJOO ; Trusted_Connection=True ;";

    public static void AgregarDeportista(Deportista dep)
    {

        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "INSERT INTO Deportista (Apellido, Nombre, FechaNacimiento, Foto, IdPais, IdDeporte) VALUES (@pApellido, @pNombre, @pFechaNacimiento, @pFoto, @pIdPais, @pIdDeporte)";
            db.Execute(sql, new { pApellido = dep.Apellido, pNombre = dep.Nombre, pFechaNacimiento = dep.FechaNacimiento, pFoto = dep.Foto, pIdPais = dep.IdPais, pIdDeporte = dep.IdDeporte });
        }
    }

    public static void EliminarDeportista(int idDeportista)
    {
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "DELETE FROM Deportista WHERE IdDeportista = @pidDeportista";
            db.Execute(sql, new { pidDeportista = idDeportista });
        }
    }

    public static Deporte VerInfoDeporte(int idDeporte)
    {
        Deporte deporte = null;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Deporte WHERE IdDeporte = @pidDeporte";
            deporte = db.QueryFirstOrDefault<Deporte>(sql, new { pidDeporte = idDeporte });
        }
        return deporte;
    }

    public static Pais VerInfoPais(int idPais)
    {
        Pais pais = null;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Pais WHERE IdPais = @pidPais";
            pais = db.QueryFirstOrDefault<Pais>(sql, new { pidPais = idPais });
        }
        return pais;
    }

    public static Deportista VerInfoDeportista(int idDeportista)
    {
        Deportista deportista = null;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Deportista WHERE IdDeportista = @pidDeportista";
            deportista = db.QueryFirstOrDefault<Deportista>(sql, new { pidDeportista = idDeportista });
        }
        return deportista;
    }

    public static List<Pais> ListarPaises()
    {

        List<Pais> ListaPaises = null;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
        string sql = "SELECT * FROM Paises";
        ListaPaises = db.Query<Pais>(sql).ToList();
        }
        return ListaPaises;
    }

    public static List<Deportista> ListarDeportistas()
    {
        List<Deportista> ListaDeportistas = null;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
        string sql = "SELECT * FROM Deportistas";
        ListaDeportistas = db.Query<Deportista>(sql).ToList();
        }
        return ListaDeportistas;
    }

    public static List<Deporte> ListarDeportes()
    {
        List<Deporte> ListaDeportes = null;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
        string sql = "SELECT * FROM Deportes";
        ListaDeportes = db.Query<Deporte>(sql).ToList();
        }
        return ListaDeportes;
    }


    public static List<Deportista> ListarDeportistasPorDeporte(int idDeporte)
    {

        List<Deportista> ListaDeportistasPorDeporte = null;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
        string sql = "SELECT * FROM Deportistas WHERE IdDeporte = @pidDeporte";
        ListaDeportistasPorDeporte = db.Query<Deportista>(sql, new {pidDeporte = idDeporte}).ToList();
        }
        return ListaDeportistasPorDeporte;
    }

    public static List<Deportista> ListarDeportistasPorPais (int idPais){
        List<Deportista> ListaDeportistasPorPais = null;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
        string sql = "SELECT * FROM Deportista WHERE IdPais = @pidPais";
        ListaDeportistasPorPais = db.Query<Deportista>(sql, new {pidPais = idPais}).ToList();
        }
        return ListaDeportistasPorPais;
    }
}
