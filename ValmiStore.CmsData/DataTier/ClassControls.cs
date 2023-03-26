using System.Data.SqlClient;
using Data.Config;
using System.Data;

namespace Data.DataTier
{
    public static class ClassControls
    {
        public static string GetClassControlURL(int classId)
        {
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@ClassId", classId);
            arParams[0].Direction = ParameterDirection.Input;
            arParams[1] = new SqlParameter("@ControlURL", "");
            arParams[1].Direction = ParameterDirection.InputOutput;
            arParams[1].Size = 500;
            SqlConnection con = new SqlConnection(ApplicationSettings.ConnectionString);
            con.Open();
            SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spClassControlGet", arParams);
            con.Close();
            var url = arParams[1].Value.ToString();
            return url;
        }
    }
}
