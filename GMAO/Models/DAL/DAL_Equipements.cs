using GMAO.Models.Entities;
using ServerTemplateAPI.Models.Connection;
using System.Data.SqlClient;
using ServerTemplateAPI.Utilities;
using ServerTemplateAPI.Models;
using System.Data;
namespace GMAO.Models.DAL
{
    public class DAL_Equipements
    {

        public static int Add(Equipements equipement) {

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                string StrAQL = "Insert Into Equipements(Type,Marque,Modele, NumeroSerie,Localisation, DateInstallation,DateGarantie) VALUES(@Type,@Marque,@Modele,@NumeroSerie,@Localisation,@DateInstallation,@DateGarantie)";

                SqlCommand cmd = new SqlCommand(StrAQL, connection);
                cmd.Parameters.AddWithValue("@Type", equipement.Type);
                cmd.Parameters.AddWithValue("@Marque", equipement.Marque);
                cmd.Parameters.AddWithValue("@Modele", equipement.Modele);
                cmd.Parameters.AddWithValue("@NumeroSerie", equipement.NumeroSerie);
                cmd.Parameters.AddWithValue("@Localisation", equipement.Localisation);
                cmd.Parameters.AddWithValue("@DateInstallation", equipement.DateInstallation);
                cmd.Parameters.AddWithValue("@DateGarantie", equipement.DateGarantie);
                return Convert.ToInt32(DataBaseAccessUtilities.NonQueryRequest(cmd));

            } 
        }

    public static void Update(int id , Equipements equipement)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string StrSQL = " Update Equipements SET Type=@Type,Marque=@Marque,Modele=@Modele, NumeroSerie=@NumeroSerie,Localisation=@Localisation, DateInstallation=@DateInstallation,DateGarantie=@DateGarantie WHERE IdEquipement = @EntityKey";
                SqlCommand cmd = new SqlCommand( StrSQL, conn);
                cmd.Parameters.AddWithValue ("@EntityKey", id);
                cmd.Parameters.AddWithValue("@Type", equipement.Type);
                cmd.Parameters.AddWithValue("@Marque", equipement.Marque);
                cmd.Parameters.AddWithValue("@Modele", equipement.Modele);
                cmd.Parameters.AddWithValue("@NumeroSerie", equipement.NumeroSerie);
                cmd.Parameters.AddWithValue("@Localisation", equipement.Localisation);
                cmd.Parameters.AddWithValue("@DateInstallation", equipement.DateInstallation);
                cmd.Parameters.AddWithValue("@DateGarantie", equipement.DateGarantie);
                DataBaseAccessUtilities.NonQueryRequest(cmd);

            }
        }

        public static void Delete(int EntityKey)
        {

            using (SqlConnection connection = DBConnection.GetConnection())
            {

                string StrSQL = "Delete From Equipements Where IdEquipement=@EntityKey";
                SqlCommand cmd = new SqlCommand(StrSQL, connection);
                cmd.Parameters.AddWithValue("@EntityKey", EntityKey);
                DataBaseAccessUtilities.NonQueryRequest (cmd);

            }
        }
        private static Equipements GetEntityFromDataRow(DataRow Datarow)
        {
            Equipements equipements = new Equipements();
            equipements.IdEquipement = Convert.ToInt32(Datarow["IdEquipement"]);
            equipements.Type = Datarow["Type"].ToString();
            equipements.Marque = Datarow["Marque"].ToString();
            equipements.Modele = Datarow["Modele"].ToString();
            equipements.NumeroSerie = Datarow["NumeroSerie"].ToString();
            equipements.Localisation = Datarow["Localisation"].ToString();
            equipements.DateInstallation = (DateTime)(Datarow.IsNull("DateInstallation") ? null : (DateTime?)Datarow["DateInstallation"]);
            equipements.DateGarantie = (DateTime)(Datarow.IsNull("DateGarantie") ? null : (DateTime?)Datarow["DateGarantie"]);

            return equipements;

        }

        private static List<Equipements> GetListFromDataTable(DataTable dt)
        {

            List<Equipements > list = new List<Equipements>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(GetEntityFromDataRow(dr));
                }
              
            }
            return list;

        }
        public static Equipements SelectById(int EntityKey)
        {
            using(SqlConnection cnn=DBConnection.GetConnection())
            {
                cnn.Open();
                string StrSQL = "Select * From Equipements Where IdEquipement=@EntityKey";
                SqlCommand cmd =  new SqlCommand(StrSQL,cnn);

                cmd.Parameters.AddWithValue("@EntityKey", EntityKey);
                DataTable dt =  DataBaseAccessUtilities.SelectRequest(cmd);
                if (dt != null && dt.Rows.Count != 0)
                    return GetEntityFromDataRow(dt.Rows[0]);
                else
                    return null;
            }
        }
        public static List<Equipements> SelectAll()
        {
            DataTable dataTable;
            using(SqlConnection conn=DBConnection.GetConnection())
            {
                conn.Open();
                string StrSQL = "Select * From Equipements ";
                SqlCommand cmd = new SqlCommand( StrSQL,conn);
                dataTable=DataBaseAccessUtilities.SelectRequest(cmd);
            }
            return GetListFromDataTable(dataTable);
        }


    }






}
